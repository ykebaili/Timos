using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.CodeDom;
using System.Windows.Forms;

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

using timos.acteurs;
using timos.securite;
using timos.data;
using timos.composantphysique;
using timos.data.composantphysique;

namespace timos
{

	[ObjectEditeur(typeof(CTypeEquipement))]
	public class CFormEditionTypeEquipement : CFormEditionStdTimos, 
		IFormNavigable
	{
		#region Designer generated code

        private sc2i.win32.common.ListViewAutoFilled m_listViewRoles;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn5;
		//private CafelApp.CPanelGestionDroits m_panelDroits;
		private System.Windows.Forms.Timer m_timerMAJOnglets;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private Crownwood.Magic.Controls.TabPage m_pageInstallation;
		//private CafelApp.CPanelGestionDroits m_panelDroits;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewColumn6;
		private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChampsPhysiques;
		private sc2i.win32.common.C2iPanelOmbre m_panTop;
		private sc2i.win32.common.C2iTextBox m_txtNom;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeRestrictionsSurChamp;
		private Label m_lblLabel;
		private CComboBoxArbreObjetDonneesHierarchique m_comboFamille;
		private LinkLabel m_lnkFamilles;
		private Crownwood.Magic.Controls.TabPage m_pageFiche;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
		private C2iTabControl m_tabParametreEquipements;
		private Crownwood.Magic.Controls.TabPage tabPage4;
		private Crownwood.Magic.Controls.TabPage tabPage5;
		private ListViewAutoFilledColumn listViewColumn2;
		private Crownwood.Magic.Controls.TabPage m_pageFournisseurs;
		private Label label3;
		private ListViewAutoFilled m_wndListeFournisseurs;
		private C2iTextBoxSelectionne m_txtSelectFournisseur;
		private ListViewAutoFilledColumn m_colonneLibelleFournisseur;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionFournisseurs;
		private Panel m_panelFournisseur;
		private Label m_lblFournisseur;
		private Label label4;
		private CExtLinkField m_linkFournisseur;
		private C2iTextBox c2iTextBox1;
		private CWndLinkStd m_lnkSupprimerFournisseur;
		private CWndLinkStd m_lnkAjouterFournisseur;
		private Crownwood.Magic.Controls.TabPage m_pageComportementStock;
		private CWndLinkStd m_lnkSupprimeTypeStock;
		private Panel m_panelStock;
		private Label label7;
		private Label label10;
		private ListViewAutoFilled m_wndListeTypesStocks;
		private ListViewAutoFilledColumn listViewAutoFilledColumn5;
		private C2iTextBoxSelectionne m_txtSelectTypeStock;
		private Label label11;
		private CWndLinkStd m_lnkAddTypeStock;
		private CExtLinkField m_linkStock;
		private GroupBox groupBox1;
		private Label label13;
		private Label label12;
		private C2iTextBoxNumerique c2iTextBoxNumerique3;
		private C2iTextBoxNumerique c2iTextBoxNumerique2;
		private C2iTextBoxNumerique c2iTextBoxNumerique1;
		private Panel panel2;
		private C2iTextBoxNumerique c2iTextBoxNumerique4;
		private GroupBox groupBox2;
		private C2iTextBoxNumerique c2iTextBoxNumerique5;
		private C2iTextBoxNumerique c2iTextBoxNumerique6;
		private Label label14;
		private Label label15;
		private Label label16;
		private Label label17;
		private PictureBox pictureBox5;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionStock;
		private Crownwood.Magic.Controls.TabPage m_pagePeutInclure;
		private Label label18;
		private C2iTextBoxSelectionne m_txtSelectTypeInclu;
		private CExtLinkField m_linkSousType;
		private CWndLinkStd m_lnkDeleteTypeInclu;
		private ListViewAutoFilled m_wndListeEquipementsInclus;
		private ListViewAutoFilledColumn listViewAutoFilledColumn6;
		private CWndLinkStd m_lnkAddTypeInclu;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireTypesInclus;
		private Crownwood.Magic.Controls.TabPage m_pageEOs;
		private CPanelAffectationEO m_panelEOS;
		private CheckBox checkBox1;
		private Label label2;
		private ListViewAutoFilled m_wndListeTypeDonnateurs;
		private ListViewAutoFilledColumn listViewAutoFilledColumn7;
		private CWndLinkStd m_lnkAddTypeDonnateur;
		private C2iTextBoxSelectionne m_txtSelectTypeDonnateur;
		private CWndLinkStd m_lnkRemoveTypeDonnateur;
		private CGestionnaireEditionSousObjetDonnee m_gestionEditionTypeDonnateur;
		private CWndLinkStd m_lnkDeleteTypeIncluant;
		private ListViewAutoFilled m_wndListeEquipementsIncluants;
		private ListViewAutoFilledColumn listViewAutoFilledColumn8;
		private CWndLinkStd m_lnkAddTypeIncluant;
		private C2iTextBoxSelectionne m_txtSelectTypeIncluant;
		private Label label5;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireTypesIncluant;
        private Crownwood.Magic.Controls.TabPage m_pageEquivalences;
        private Label label6;
        private CWndLinkStd m_lnkAjouterRelRemplacement;
        private Panel m_conteneurRemplacement;
        private C2iTextBoxSelectionne m_txtSelectTypeRemplacement;
        private ColumnHeader columnHeader1;
        private ListViewAutoFilled m_listeRelationsRemplacement;
        private ListViewAutoFilledColumn colRelRemplacement;
        private CWndLinkStd m_lnkSupprimerRelRemplacement;
        private Label m_lblRelRemplacement;
        private CExtLinkField m_linkRemplacement;
        private CGestionnaireEditionSousObjetDonnee m_gestionRelationsRemplacement;
        private RadioButton m_radSens2vers1;
        private RadioButton m_radSensBijective;
        private RadioButton m_radSens1vers2;
        private Label label21;
        private Label label8;
        private Label m_lblTypeEdite;
        private LinkLabel m_linkShowAllParentsRelations;
		private Crownwood.Magic.Controls.TabPage m_pageOptions;
		private CGestionnaireEditionSousObjetDonnee m_gestionEditionParametrageNiveau;
        private Crownwood.Magic.Controls.TabPage m_pageFabricant;
        private SplitContainer splitContainer1;
        private CWndLinkStd m_lnkSupprimerConstructeur;
        private ListViewAutoFilled m_wndListeConstructeurs;
        private ListViewAutoFilledColumn m_colonneLibelle;
        private C2iTextBoxSelectionne m_txtSelectConstructeur;
        private Label label24;
        private CWndLinkStd m_lnkAjouterConstructeur;
        private C2iTextBox m_txtConstructeurReference;
        private Label label22;
        private Label m_lblConstructeur;
        private ListViewAutoFilled listViewAutoFilled1;
        private ListViewAutoFilledColumn listViewAutoFilledColumn9;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionConstructeurs;
        private CExtLinkField m_linkConstructeur;
        private Panel m_panelConstructeur;
		private CControleEditeObjetASystemeCoordonnee m_panelSystemeCoordonnees;
        private CControleEditionOptionsControleCoordonnees m_panelOptionsControle;
        private SplitContainer splitContainer2;
        private C2iTextBox c2iTextBox3;
        private Label m_lblMnemonic;
        private Label m_lblCodeInterne;
        private C2iTextBox c2iTextBox2;
		private Crownwood.Magic.Controls.TabPage m_pageTablesParametrables;
		private CPanelListeRelationSelection m_tableParametrablesLstSelec;
		private ListViewAutoFilledColumn m_colTableCustom;
        private CheckBox m_chkIsDotation;
		private Crownwood.Magic.Controls.TabPage tabPage1;
		private GroupBox groupBox3;
		private Label label9;
		private CheckBox checkBox2;
		private C2iTextBoxSelectionne m_txtSelectTypeFonction;
		private Crownwood.Magic.Controls.TabPage tabPage2;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelDefinisseurChampsLogiques;
        private Crownwood.Magic.Controls.TabPage m_pagePorts;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListePorts;
        private LinkLabel m_linkEditPorts;
        private CPanelSymboleElement m_panelSymbole;
        private SplitContainer m_splitContainerPorts;
        private ListViewAutoFilledColumn m_colonneReference;
        private ListViewAutoFilledColumn m_colonneReferenceFournisseur;
        private C2iTextBoxSelectionne m_txtSelectConstructeur2;
        private Label label19;
        private C2iTextBoxSelectionne m_txtSelectFournisseur2;
        private Label label20;
        private timos.coordonnees.CControlEditionObjetAOccupation m_panelOccupation;
        private C2iPanel m_panelParametrage;
        private System.ComponentModel.IContainer components = null;

		
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
		//-------------------------------------------------------------------------
		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeEquipement));
            this.m_listViewRoles = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageTablesParametrables = new Crownwood.Magic.Controls.TabPage();
            this.m_tableParametrablesLstSelec = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.m_colTableCustom = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_pageFiche = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageFabricant = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lnkSupprimerConstructeur = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeConstructeurs = new sc2i.win32.common.ListViewAutoFilled();
            this.m_colonneLibelle = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_colonneReference = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_txtSelectConstructeur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label24 = new System.Windows.Forms.Label();
            this.m_lnkAjouterConstructeur = new sc2i.win32.common.CWndLinkStd();
            this.m_panelConstructeur = new System.Windows.Forms.Panel();
            this.m_txtSelectConstructeur2 = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label19 = new System.Windows.Forms.Label();
            this.m_lblConstructeur = new System.Windows.Forms.Label();
            this.m_txtConstructeurReference = new sc2i.win32.common.C2iTextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.m_pageFournisseurs = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkSupprimerFournisseur = new sc2i.win32.common.CWndLinkStd();
            this.m_panelFournisseur = new System.Windows.Forms.Panel();
            this.m_txtSelectFournisseur2 = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label20 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblFournisseur = new System.Windows.Forms.Label();
            this.m_wndListeFournisseurs = new sc2i.win32.common.ListViewAutoFilled();
            this.m_colonneLibelleFournisseur = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_colonneReferenceFournisseur = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_txtSelectFournisseur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lnkAjouterFournisseur = new sc2i.win32.common.CWndLinkStd();
            this.m_pageComportementStock = new Crownwood.Magic.Controls.TabPage();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.c2iTextBoxNumerique4 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.c2iTextBoxNumerique5 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.c2iTextBoxNumerique6 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.m_lnkSupprimeTypeStock = new sc2i.win32.common.CWndLinkStd();
            this.m_panelStock = new System.Windows.Forms.Panel();
            this.c2iTextBoxNumerique3 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.c2iTextBoxNumerique2 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.c2iTextBoxNumerique1 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_wndListeTypesStocks = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_txtSelectTypeStock = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label11 = new System.Windows.Forms.Label();
            this.m_lnkAddTypeStock = new sc2i.win32.common.CWndLinkStd();
            this.m_pagePeutInclure = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.label18 = new System.Windows.Forms.Label();
            this.m_lnkDeleteTypeInclu = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectTypeInclu = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAddTypeInclu = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeEquipementsInclus = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_wndListeEquipementsIncluants = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn8 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkDeleteTypeIncluant = new sc2i.win32.common.CWndLinkStd();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtSelectTypeIncluant = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAddTypeIncluant = new sc2i.win32.common.CWndLinkStd();
            this.m_pageEOs = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEOS = new timos.CPanelAffectationEO();
            this.m_pageInstallation = new Crownwood.Magic.Controls.TabPage();
            this.m_tabParametreEquipements = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurChampsPhysiques = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelDefinisseurChampsLogiques = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.tabPage5 = new Crownwood.Magic.Controls.TabPage();
            this.m_lnkRemoveTypeDonnateur = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeTypeDonnateurs = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn7 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkAddTypeDonnateur = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectTypeDonnateur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.m_txtSelectTypeFonction = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label9 = new System.Windows.Forms.Label();
            this.m_chkIsDotation = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_pageEquivalences = new Crownwood.Magic.Controls.TabPage();
            this.m_linkShowAllParentsRelations = new System.Windows.Forms.LinkLabel();
            this.m_lnkSupprimerRelRemplacement = new sc2i.win32.common.CWndLinkStd();
            this.m_listeRelationsRemplacement = new sc2i.win32.common.ListViewAutoFilled();
            this.colRelRemplacement = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_lnkAjouterRelRemplacement = new sc2i.win32.common.CWndLinkStd();
            this.m_conteneurRemplacement = new System.Windows.Forms.Panel();
            this.m_lblTypeEdite = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.m_radSens2vers1 = new System.Windows.Forms.RadioButton();
            this.m_radSensBijective = new System.Windows.Forms.RadioButton();
            this.m_radSens1vers2 = new System.Windows.Forms.RadioButton();
            this.m_lblRelRemplacement = new System.Windows.Forms.Label();
            this.m_txtSelectTypeRemplacement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label6 = new System.Windows.Forms.Label();
            this.m_pageOptions = new Crownwood.Magic.Controls.TabPage();
            this.m_panelOccupation = new timos.coordonnees.CControlEditionObjetAOccupation();
            this.m_panelParametrage = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelSystemeCoordonnees = new timos.CControleEditeObjetASystemeCoordonnee();
            this.m_panelOptionsControle = new timos.CControleEditionOptionsControleCoordonnees();
            this.m_pagePorts = new Crownwood.Magic.Controls.TabPage();
            this.m_splitContainerPorts = new System.Windows.Forms.SplitContainer();
            this.m_linkEditPorts = new System.Windows.Forms.LinkLabel();
            this.m_panelSymbole = new timos.CPanelSymboleElement();
            this.m_panelListePorts = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_wndListeRestrictionsSurChamp = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_comboFamille = new sc2i.win32.data.navigation.CComboBoxArbreObjetDonneesHierarchique();
            this.m_txtNom = new sc2i.win32.common.C2iTextBox();
            this.m_lblLabel = new System.Windows.Forms.Label();
            this.c2iTextBox3 = new sc2i.win32.common.C2iTextBox();
            this.m_lblMnemonic = new System.Windows.Forms.Label();
            this.m_lnkFamilles = new System.Windows.Forms.LinkLabel();
            this.c2iTextBox2 = new sc2i.win32.common.C2iTextBox();
            this.m_lblCodeInterne = new System.Windows.Forms.Label();
            this.listViewAutoFilled1 = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn9 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_timerMAJOnglets = new System.Windows.Forms.Timer(this.components);
            this.listViewColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewColumn6 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_gestionnaireEditionFournisseurs = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkFournisseur = new sc2i.win32.common.CExtLinkField();
            this.m_linkStock = new sc2i.win32.common.CExtLinkField();
            this.m_gestionnaireEditionStock = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireTypesInclus = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkSousType = new sc2i.win32.common.CExtLinkField();
            this.m_gestionEditionTypeDonnateur = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireTypesIncluant = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_gestionRelationsRemplacement = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkRemplacement = new sc2i.win32.common.CExtLinkField();
            this.m_gestionEditionParametrageNiveau = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_gestionnaireEditionConstructeurs = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkConstructeur = new sc2i.win32.common.CExtLinkField();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_tabControl.SuspendLayout();
            this.m_pageTablesParametrables.SuspendLayout();
            this.m_pageFiche.SuspendLayout();
            this.m_pageFabricant.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_panelConstructeur.SuspendLayout();
            this.m_pageFournisseurs.SuspendLayout();
            this.m_panelFournisseur.SuspendLayout();
            this.m_pageComportementStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.m_panelStock.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.m_pagePeutInclure.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.m_pageEOs.SuspendLayout();
            this.m_pageInstallation.SuspendLayout();
            this.m_tabParametreEquipements.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.m_pageEquivalences.SuspendLayout();
            this.m_conteneurRemplacement.SuspendLayout();
            this.m_pageOptions.SuspendLayout();
            this.m_panelOccupation.SuspendLayout();
            this.m_pagePorts.SuspendLayout();
            this.m_splitContainerPorts.Panel1.SuspendLayout();
            this.m_splitContainerPorts.Panel2.SuspendLayout();
            this.m_splitContainerPorts.SuspendLayout();
            this.m_panTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_linkConstructeur.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkRemplacement.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkSousType.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkStock.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_linkConstructeur.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkRemplacement.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkSousType.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkStock.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkRemplacement.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkSousType.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkConstructeur.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkStock.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_linkConstructeur.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkRemplacement.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkSousType.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkStock.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_linkConstructeur.SetLinkField(this.m_panelNavigation, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelNavigation, "");
            this.m_linkSousType.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelNavigation, "");
            this.m_linkStock.SetLinkField(this.m_panelNavigation, "");
            this.m_panelNavigation.Location = new System.Drawing.Point(677, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extLinkField.SetLinkField(this.m_lblNbListes, "");
            this.m_linkFournisseur.SetLinkField(this.m_lblNbListes, "");
            this.m_linkStock.SetLinkField(this.m_lblNbListes, "");
            this.m_linkSousType.SetLinkField(this.m_lblNbListes, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblNbListes, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblNbListes, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_linkConstructeur.SetLinkField(this.m_btnPrecedent, "");
            this.m_extLinkField.SetLinkField(this.m_btnPrecedent, "");
            this.m_linkRemplacement.SetLinkField(this.m_btnPrecedent, "");
            this.m_linkSousType.SetLinkField(this.m_btnPrecedent, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnPrecedent, "");
            this.m_linkStock.SetLinkField(this.m_btnPrecedent, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_linkFournisseur.SetLinkField(this.m_btnSuivant, "");
            this.m_linkRemplacement.SetLinkField(this.m_btnSuivant, "");
            this.m_linkStock.SetLinkField(this.m_btnSuivant, "");
            this.m_linkSousType.SetLinkField(this.m_btnSuivant, "");
            this.m_linkConstructeur.SetLinkField(this.m_btnSuivant, "");
            this.m_extLinkField.SetLinkField(this.m_btnSuivant, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_linkConstructeur.SetLinkField(this.m_btnAjout, "");
            this.m_extLinkField.SetLinkField(this.m_btnAjout, "");
            this.m_linkRemplacement.SetLinkField(this.m_btnAjout, "");
            this.m_linkSousType.SetLinkField(this.m_btnAjout, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnAjout, "");
            this.m_linkStock.SetLinkField(this.m_btnAjout, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extLinkField.SetLinkField(this.m_lblId, "Id");
            this.m_linkFournisseur.SetLinkField(this.m_lblId, "");
            this.m_linkStock.SetLinkField(this.m_lblId, "");
            this.m_linkSousType.SetLinkField(this.m_lblId, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblId, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblId, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_linkConstructeur.SetLinkField(this.m_panelCle, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelCle, "");
            this.m_linkSousType.SetLinkField(this.m_panelCle, "");
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelCle, "");
            this.m_linkStock.SetLinkField(this.m_panelCle, "");
            this.m_panelCle.Location = new System.Drawing.Point(590, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_linkRemplacement.SetLinkField(this.m_panelMenu, "");
            this.m_linkConstructeur.SetLinkField(this.m_panelMenu, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelMenu, "");
            this.m_linkStock.SetLinkField(this.m_panelMenu, "");
            this.m_linkSousType.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_linkRemplacement.SetLinkField(this.m_btnHistorique, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnHistorique, "");
            this.m_linkConstructeur.SetLinkField(this.m_btnHistorique, "");
            this.m_linkSousType.SetLinkField(this.m_btnHistorique, "");
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_linkStock.SetLinkField(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_linkRemplacement.SetLinkField(this.m_imageCle, "");
            this.m_linkFournisseur.SetLinkField(this.m_imageCle, "");
            this.m_linkConstructeur.SetLinkField(this.m_imageCle, "");
            this.m_linkSousType.SetLinkField(this.m_imageCle, "");
            this.m_extLinkField.SetLinkField(this.m_imageCle, "");
            this.m_linkStock.SetLinkField(this.m_imageCle, "");
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_linkRemplacement.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkFournisseur.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkConstructeur.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkSousType.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnChercherObjet, "");
            this.m_linkStock.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
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
            this.m_linkRemplacement.SetLinkField(this.m_listViewRoles, "");
            this.m_linkConstructeur.SetLinkField(this.m_listViewRoles, "");
            this.m_linkFournisseur.SetLinkField(this.m_listViewRoles, "");
            this.m_linkSousType.SetLinkField(this.m_listViewRoles, "");
            this.m_linkStock.SetLinkField(this.m_listViewRoles, "");
            this.m_extLinkField.SetLinkField(this.m_listViewRoles, "");
            this.m_listViewRoles.Location = new System.Drawing.Point(8, 8);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listViewRoles, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_listViewRoles, "");
            this.m_listViewRoles.Name = "m_listViewRoles";
            this.m_listViewRoles.Size = new System.Drawing.Size(652, 304);
            this.m_extStyle.SetStyleBackColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listViewRoles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listViewRoles.TabIndex = 0;
            this.m_listViewRoles.UseCompatibleStateImageBehavior = false;
            this.m_listViewRoles.View = System.Windows.Forms.View.Details;
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
            this.m_linkSousType.SetLinkField(this.m_tabControl, "");
            this.m_extLinkField.SetLinkField(this.m_tabControl, "");
            this.m_linkStock.SetLinkField(this.m_tabControl, "");
            this.m_linkRemplacement.SetLinkField(this.m_tabControl, "");
            this.m_linkConstructeur.SetLinkField(this.m_tabControl, "");
            this.m_linkFournisseur.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(16, 126);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageFiche;
            this.m_tabControl.Size = new System.Drawing.Size(814, 416);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFiche,
            this.m_pageFabricant,
            this.m_pageFournisseurs,
            this.m_pageComportementStock,
            this.m_pagePeutInclure,
            this.m_pageEOs,
            this.m_pageInstallation,
            this.m_pageEquivalences,
            this.m_pageOptions,
            this.m_pageTablesParametrables,
            this.m_pagePorts});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageTablesParametrables
            // 
            this.m_pageTablesParametrables.Controls.Add(this.m_tableParametrablesLstSelec);
            this.m_linkConstructeur.SetLinkField(this.m_pageTablesParametrables, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageTablesParametrables, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageTablesParametrables, "");
            this.m_extLinkField.SetLinkField(this.m_pageTablesParametrables, "");
            this.m_linkStock.SetLinkField(this.m_pageTablesParametrables, "");
            this.m_linkSousType.SetLinkField(this.m_pageTablesParametrables, "");
            this.m_pageTablesParametrables.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTablesParametrables, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageTablesParametrables, "ATABLES_PARAM");
            this.m_pageTablesParametrables.Name = "m_pageTablesParametrables";
            this.m_pageTablesParametrables.Selected = false;
            this.m_pageTablesParametrables.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageTablesParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTablesParametrables, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTablesParametrables.TabIndex = 19;
            this.m_pageTablesParametrables.Title = "Custom Table Types|1194";
            // 
            // m_tableParametrablesLstSelec
            // 
            this.m_tableParametrablesLstSelec.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.m_colTableCustom});
            this.m_tableParametrablesLstSelec.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tableParametrablesLstSelec.EnableCustomisation = true;
            this.m_tableParametrablesLstSelec.ExclusionParException = false;
            this.m_linkConstructeur.SetLinkField(this.m_tableParametrablesLstSelec, "");
            this.m_extLinkField.SetLinkField(this.m_tableParametrablesLstSelec, "");
            this.m_linkStock.SetLinkField(this.m_tableParametrablesLstSelec, "");
            this.m_linkSousType.SetLinkField(this.m_tableParametrablesLstSelec, "");
            this.m_linkFournisseur.SetLinkField(this.m_tableParametrablesLstSelec, "");
            this.m_linkRemplacement.SetLinkField(this.m_tableParametrablesLstSelec, "");
            this.m_tableParametrablesLstSelec.Location = new System.Drawing.Point(0, 0);
            this.m_tableParametrablesLstSelec.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tableParametrablesLstSelec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_tableParametrablesLstSelec, "");
            this.m_tableParametrablesLstSelec.Name = "m_tableParametrablesLstSelec";
            this.m_tableParametrablesLstSelec.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_tableParametrablesLstSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_tableParametrablesLstSelec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_tableParametrablesLstSelec.TabIndex = 0;
            // 
            // m_colTableCustom
            // 
            this.m_colTableCustom.Field = "Libelle";
            this.m_colTableCustom.PrecisionWidth = 17508;
            this.m_colTableCustom.ProportionnalSize = true;
            this.m_colTableCustom.Text = "Label|50";
            this.m_colTableCustom.Visible = true;
            this.m_colTableCustom.Width = 17508;
            // 
            // m_pageFiche
            // 
            this.m_pageFiche.Controls.Add(this.m_panelChamps);
            this.m_linkConstructeur.SetLinkField(this.m_pageFiche, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageFiche, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageFiche, "");
            this.m_extLinkField.SetLinkField(this.m_pageFiche, "");
            this.m_linkStock.SetLinkField(this.m_pageFiche, "");
            this.m_linkSousType.SetLinkField(this.m_pageFiche, "");
            this.m_pageFiche.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFiche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFiche, "");
            this.m_pageFiche.Name = "m_pageFiche";
            this.m_pageFiche.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFiche, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFiche.TabIndex = 10;
            this.m_pageFiche.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_linkStock.SetLinkField(this.m_panelChamps, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_linkSousType.SetLinkField(this.m_panelChamps, "");
            this.m_linkConstructeur.SetLinkField(this.m_panelChamps, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelChamps, "");
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 6;
            // 
            // m_pageFabricant
            // 
            this.m_pageFabricant.Controls.Add(this.splitContainer1);
            this.m_linkConstructeur.SetLinkField(this.m_pageFabricant, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageFabricant, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageFabricant, "");
            this.m_extLinkField.SetLinkField(this.m_pageFabricant, "");
            this.m_linkStock.SetLinkField(this.m_pageFabricant, "");
            this.m_linkSousType.SetLinkField(this.m_pageFabricant, "");
            this.m_pageFabricant.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFabricant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFabricant, "");
            this.m_pageFabricant.Name = "m_pageFabricant";
            this.m_pageFabricant.Selected = false;
            this.m_pageFabricant.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageFabricant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFabricant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFabricant.TabIndex = 17;
            this.m_pageFabricant.Title = "Manufacturers|459";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkConstructeur.SetLinkField(this.splitContainer1, "");
            this.m_linkStock.SetLinkField(this.splitContainer1, "");
            this.m_linkFournisseur.SetLinkField(this.splitContainer1, "");
            this.m_linkRemplacement.SetLinkField(this.splitContainer1, "");
            this.m_linkSousType.SetLinkField(this.splitContainer1, "");
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1, "");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkSupprimerConstructeur);
            this.splitContainer1.Panel1.Controls.Add(this.m_wndListeConstructeurs);
            this.splitContainer1.Panel1.Controls.Add(this.m_txtSelectConstructeur);
            this.splitContainer1.Panel1.Controls.Add(this.label24);
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkAjouterConstructeur);
            this.m_linkStock.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_linkRemplacement.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_linkConstructeur.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_linkSousType.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_linkFournisseur.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_panelConstructeur);
            this.m_linkStock.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_linkRemplacement.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_linkConstructeur.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_linkSousType.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_linkFournisseur.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(798, 375);
            this.splitContainer1.SplitterDistance = 384;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 0;
            // 
            // m_lnkSupprimerConstructeur
            // 
            this.m_lnkSupprimerConstructeur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerConstructeur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerConstructeur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkSupprimerConstructeur, "");
            this.m_linkStock.SetLinkField(this.m_lnkSupprimerConstructeur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkSupprimerConstructeur, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkSupprimerConstructeur, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerConstructeur, "");
            this.m_linkSousType.SetLinkField(this.m_lnkSupprimerConstructeur, "");
            this.m_lnkSupprimerConstructeur.Location = new System.Drawing.Point(9, 342);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerConstructeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerConstructeur, "");
            this.m_lnkSupprimerConstructeur.Name = "m_lnkSupprimerConstructeur";
            this.m_lnkSupprimerConstructeur.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerConstructeur.TabIndex = 9;
            this.m_lnkSupprimerConstructeur.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerConstructeur.LinkClicked += new System.EventHandler(this.m_lnkSupprimerConstructeur_LinkClicked);
            // 
            // m_wndListeConstructeurs
            // 
            this.m_wndListeConstructeurs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeConstructeurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colonneLibelle,
            this.m_colonneReference});
            this.m_wndListeConstructeurs.EnableCustomisation = true;
            this.m_wndListeConstructeurs.FullRowSelect = true;
            this.m_wndListeConstructeurs.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.m_wndListeConstructeurs, "");
            this.m_linkConstructeur.SetLinkField(this.m_wndListeConstructeurs, "");
            this.m_linkFournisseur.SetLinkField(this.m_wndListeConstructeurs, "");
            this.m_linkSousType.SetLinkField(this.m_wndListeConstructeurs, "");
            this.m_linkStock.SetLinkField(this.m_wndListeConstructeurs, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeConstructeurs, "");
            this.m_wndListeConstructeurs.Location = new System.Drawing.Point(10, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeConstructeurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeConstructeurs, "");
            this.m_wndListeConstructeurs.MultiSelect = false;
            this.m_wndListeConstructeurs.Name = "m_wndListeConstructeurs";
            this.m_wndListeConstructeurs.Size = new System.Drawing.Size(362, 287);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeConstructeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeConstructeurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeConstructeurs.TabIndex = 7;
            this.m_wndListeConstructeurs.UseCompatibleStateImageBehavior = false;
            this.m_wndListeConstructeurs.View = System.Windows.Forms.View.Details;
            // 
            // m_colonneLibelle
            // 
            this.m_colonneLibelle.Field = "Constructeur.Acteur.Libelle";
            this.m_colonneLibelle.PrecisionWidth = 0;
            this.m_colonneLibelle.ProportionnalSize = false;
            this.m_colonneLibelle.Text = "Label|50";
            this.m_colonneLibelle.Visible = true;
            this.m_colonneLibelle.Width = 200;
            // 
            // m_colonneReference
            // 
            this.m_colonneReference.Field = "Reference";
            this.m_colonneReference.PrecisionWidth = 0;
            this.m_colonneReference.ProportionnalSize = false;
            this.m_colonneReference.Text = "Manufacturer Reference|465";
            this.m_colonneReference.Visible = true;
            this.m_colonneReference.Width = 120;
            // 
            // m_txtSelectConstructeur
            // 
            this.m_txtSelectConstructeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectConstructeur.ElementSelectionne = null;
            this.m_txtSelectConstructeur.FonctionTextNull = null;
            this.m_txtSelectConstructeur.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectConstructeur, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectConstructeur, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectConstructeur, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectConstructeur, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectConstructeur, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectConstructeur, "");
            this.m_txtSelectConstructeur.Location = new System.Drawing.Point(107, 6);
            this.m_txtSelectConstructeur.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectConstructeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectConstructeur, "");
            this.m_txtSelectConstructeur.Name = "m_txtSelectConstructeur";
            this.m_txtSelectConstructeur.SelectedObject = null;
            this.m_txtSelectConstructeur.Size = new System.Drawing.Size(265, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectConstructeur.TabIndex = 6;
            this.m_txtSelectConstructeur.TextNull = "";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label24, "");
            this.m_linkFournisseur.SetLinkField(this.label24, "");
            this.m_linkStock.SetLinkField(this.label24, "");
            this.m_linkSousType.SetLinkField(this.label24, "");
            this.m_linkRemplacement.SetLinkField(this.label24, "");
            this.m_linkConstructeur.SetLinkField(this.label24, "");
            this.label24.Location = new System.Drawing.Point(7, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label24, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label24, "");
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(100, 15);
            this.m_extStyle.SetStyleBackColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label24.TabIndex = 5;
            this.label24.Text = "Manufacturer|458";
            // 
            // m_lnkAjouterConstructeur
            // 
            this.m_lnkAjouterConstructeur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterConstructeur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkAjouterConstructeur, "");
            this.m_linkStock.SetLinkField(this.m_lnkAjouterConstructeur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkAjouterConstructeur, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkAjouterConstructeur, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterConstructeur, "");
            this.m_linkSousType.SetLinkField(this.m_lnkAjouterConstructeur, "");
            this.m_lnkAjouterConstructeur.Location = new System.Drawing.Point(107, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterConstructeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterConstructeur, "");
            this.m_lnkAjouterConstructeur.Name = "m_lnkAjouterConstructeur";
            this.m_lnkAjouterConstructeur.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterConstructeur.TabIndex = 8;
            this.m_lnkAjouterConstructeur.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterConstructeur.LinkClicked += new System.EventHandler(this.m_lnkAjouterConstructeur_LinkClicked);
            // 
            // m_panelConstructeur
            // 
            this.m_panelConstructeur.Controls.Add(this.m_txtSelectConstructeur2);
            this.m_panelConstructeur.Controls.Add(this.label19);
            this.m_panelConstructeur.Controls.Add(this.m_lblConstructeur);
            this.m_panelConstructeur.Controls.Add(this.m_txtConstructeurReference);
            this.m_panelConstructeur.Controls.Add(this.label22);
            this.m_panelConstructeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkConstructeur.SetLinkField(this.m_panelConstructeur, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelConstructeur, "");
            this.m_linkSousType.SetLinkField(this.m_panelConstructeur, "");
            this.m_extLinkField.SetLinkField(this.m_panelConstructeur, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelConstructeur, "");
            this.m_linkStock.SetLinkField(this.m_panelConstructeur, "");
            this.m_panelConstructeur.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConstructeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelConstructeur, "");
            this.m_panelConstructeur.Name = "m_panelConstructeur";
            this.m_panelConstructeur.Size = new System.Drawing.Size(410, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConstructeur.TabIndex = 6;
            // 
            // m_txtSelectConstructeur2
            // 
            this.m_txtSelectConstructeur2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectConstructeur2.ElementSelectionne = null;
            this.m_txtSelectConstructeur2.FonctionTextNull = null;
            this.m_txtSelectConstructeur2.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectConstructeur2, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectConstructeur2, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectConstructeur2, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectConstructeur2, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectConstructeur2, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectConstructeur2, "");
            this.m_txtSelectConstructeur2.Location = new System.Drawing.Point(109, 106);
            this.m_txtSelectConstructeur2.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectConstructeur2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectConstructeur2, "");
            this.m_txtSelectConstructeur2.Name = "m_txtSelectConstructeur2";
            this.m_txtSelectConstructeur2.SelectedObject = null;
            this.m_txtSelectConstructeur2.Size = new System.Drawing.Size(285, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectConstructeur2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectConstructeur2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectConstructeur2.TabIndex = 8;
            this.m_txtSelectConstructeur2.TextNull = "";
            // 
            // label19
            // 
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.m_linkFournisseur.SetLinkField(this.label19, "");
            this.m_linkStock.SetLinkField(this.label19, "");
            this.m_linkSousType.SetLinkField(this.label19, "");
            this.m_linkRemplacement.SetLinkField(this.label19, "");
            this.m_linkConstructeur.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(3, 110);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label19, "");
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(110, 13);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 7;
            this.label19.Text = "Manufacturer|458";
            // 
            // m_lblConstructeur
            // 
            this.m_lblConstructeur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblConstructeur.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_lblConstructeur, "");
            this.m_linkFournisseur.SetLinkField(this.m_lblConstructeur, "");
            this.m_linkStock.SetLinkField(this.m_lblConstructeur, "");
            this.m_linkSousType.SetLinkField(this.m_lblConstructeur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblConstructeur, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblConstructeur, "Constructeur.Acteur.Nom");
            this.m_lblConstructeur.Location = new System.Drawing.Point(3, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblConstructeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblConstructeur, "");
            this.m_lblConstructeur.Name = "m_lblConstructeur";
            this.m_lblConstructeur.Size = new System.Drawing.Size(363, 29);
            this.m_extStyle.SetStyleBackColor(this.m_lblConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblConstructeur.TabIndex = 3;
            this.m_lblConstructeur.Text = "[Constructeur.Acteur.Nom]";
            this.m_lblConstructeur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtConstructeurReference
            // 
            this.m_txtConstructeurReference.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_linkConstructeur.SetLinkField(this.m_txtConstructeurReference, "Reference");
            this.m_extLinkField.SetLinkField(this.m_txtConstructeurReference, "");
            this.m_linkSousType.SetLinkField(this.m_txtConstructeurReference, "");
            this.m_linkStock.SetLinkField(this.m_txtConstructeurReference, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtConstructeurReference, "");
            this.m_linkFournisseur.SetLinkField(this.m_txtConstructeurReference, "");
            this.m_txtConstructeurReference.Location = new System.Drawing.Point(109, 79);
            this.m_txtConstructeurReference.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtConstructeurReference, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtConstructeurReference, "");
            this.m_txtConstructeurReference.Name = "m_txtConstructeurReference";
            this.m_txtConstructeurReference.Size = new System.Drawing.Size(285, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtConstructeurReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtConstructeurReference, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtConstructeurReference.TabIndex = 5;
            this.m_txtConstructeurReference.Text = "[Reference]";
            // 
            // label22
            // 
            this.m_extLinkField.SetLinkField(this.label22, "");
            this.m_linkFournisseur.SetLinkField(this.label22, "");
            this.m_linkStock.SetLinkField(this.label22, "");
            this.m_linkSousType.SetLinkField(this.label22, "");
            this.m_linkRemplacement.SetLinkField(this.label22, "");
            this.m_linkConstructeur.SetLinkField(this.label22, "");
            this.label22.Location = new System.Drawing.Point(3, 82);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label22, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label22, "");
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 18);
            this.m_extStyle.SetStyleBackColor(this.label22, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label22, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label22.TabIndex = 4;
            this.label22.Text = "Reference|202";
            // 
            // m_pageFournisseurs
            // 
            this.m_pageFournisseurs.Controls.Add(this.m_lnkSupprimerFournisseur);
            this.m_pageFournisseurs.Controls.Add(this.m_panelFournisseur);
            this.m_pageFournisseurs.Controls.Add(this.m_wndListeFournisseurs);
            this.m_pageFournisseurs.Controls.Add(this.m_txtSelectFournisseur);
            this.m_pageFournisseurs.Controls.Add(this.label3);
            this.m_pageFournisseurs.Controls.Add(this.m_lnkAjouterFournisseur);
            this.m_linkConstructeur.SetLinkField(this.m_pageFournisseurs, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageFournisseurs, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageFournisseurs, "");
            this.m_extLinkField.SetLinkField(this.m_pageFournisseurs, "");
            this.m_linkStock.SetLinkField(this.m_pageFournisseurs, "");
            this.m_linkSousType.SetLinkField(this.m_pageFournisseurs, "");
            this.m_pageFournisseurs.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFournisseurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFournisseurs, "");
            this.m_pageFournisseurs.Name = "m_pageFournisseurs";
            this.m_pageFournisseurs.Selected = false;
            this.m_pageFournisseurs.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageFournisseurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFournisseurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFournisseurs.TabIndex = 11;
            this.m_pageFournisseurs.Title = "Suppliers|199";
            // 
            // m_lnkSupprimerFournisseur
            // 
            this.m_lnkSupprimerFournisseur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerFournisseur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerFournisseur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_linkStock.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_linkSousType.SetLinkField(this.m_lnkSupprimerFournisseur, "");
            this.m_lnkSupprimerFournisseur.Location = new System.Drawing.Point(10, 344);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerFournisseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerFournisseur, "");
            this.m_lnkSupprimerFournisseur.Name = "m_lnkSupprimerFournisseur";
            this.m_lnkSupprimerFournisseur.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerFournisseur.TabIndex = 4;
            this.m_lnkSupprimerFournisseur.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerFournisseur.LinkClicked += new System.EventHandler(this.m_lnkSupprimerFournisseur_LinkClicked);
            // 
            // m_panelFournisseur
            // 
            this.m_panelFournisseur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFournisseur.Controls.Add(this.m_txtSelectFournisseur2);
            this.m_panelFournisseur.Controls.Add(this.label20);
            this.m_panelFournisseur.Controls.Add(this.c2iTextBox1);
            this.m_panelFournisseur.Controls.Add(this.label4);
            this.m_panelFournisseur.Controls.Add(this.m_lblFournisseur);
            this.m_linkConstructeur.SetLinkField(this.m_panelFournisseur, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelFournisseur, "");
            this.m_linkSousType.SetLinkField(this.m_panelFournisseur, "");
            this.m_extLinkField.SetLinkField(this.m_panelFournisseur, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelFournisseur, "");
            this.m_linkStock.SetLinkField(this.m_panelFournisseur, "");
            this.m_panelFournisseur.Location = new System.Drawing.Point(342, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFournisseur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelFournisseur, "");
            this.m_panelFournisseur.Name = "m_panelFournisseur";
            this.m_panelFournisseur.Size = new System.Drawing.Size(443, 347);
            this.m_extStyle.SetStyleBackColor(this.m_panelFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFournisseur.TabIndex = 3;
            this.m_panelFournisseur.Visible = false;
            // 
            // m_txtSelectFournisseur2
            // 
            this.m_txtSelectFournisseur2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectFournisseur2.ElementSelectionne = null;
            this.m_txtSelectFournisseur2.FonctionTextNull = null;
            this.m_txtSelectFournisseur2.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectFournisseur2, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectFournisseur2, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectFournisseur2, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectFournisseur2, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectFournisseur2, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectFournisseur2, "");
            this.m_txtSelectFournisseur2.Location = new System.Drawing.Point(108, 98);
            this.m_txtSelectFournisseur2.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectFournisseur2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectFournisseur2, "");
            this.m_txtSelectFournisseur2.Name = "m_txtSelectFournisseur2";
            this.m_txtSelectFournisseur2.SelectedObject = null;
            this.m_txtSelectFournisseur2.Size = new System.Drawing.Size(315, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectFournisseur2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectFournisseur2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectFournisseur2.TabIndex = 4;
            this.m_txtSelectFournisseur2.TextNull = "";
            // 
            // label20
            // 
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.m_linkFournisseur.SetLinkField(this.label20, "");
            this.m_linkStock.SetLinkField(this.label20, "");
            this.m_linkSousType.SetLinkField(this.label20, "");
            this.m_linkRemplacement.SetLinkField(this.label20, "");
            this.m_linkConstructeur.SetLinkField(this.label20, "");
            this.label20.Location = new System.Drawing.Point(11, 103);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label20, "");
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(98, 13);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 3;
            this.label20.Text = "Supplier|201";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_linkFournisseur.SetLinkField(this.c2iTextBox1, "Reference");
            this.m_linkStock.SetLinkField(this.c2iTextBox1, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBox1, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBox1, "");
            this.m_linkSousType.SetLinkField(this.c2iTextBox1, "");
            this.c2iTextBox1.Location = new System.Drawing.Point(108, 71);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(315, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 2;
            this.c2iTextBox1.Text = "[Reference]";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_linkFournisseur.SetLinkField(this.label4, "");
            this.m_linkStock.SetLinkField(this.label4, "");
            this.m_linkSousType.SetLinkField(this.label4, "");
            this.m_linkRemplacement.SetLinkField(this.label4, "");
            this.m_linkConstructeur.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(7, 73);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 18);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 1;
            this.label4.Text = "Reference|202";
            // 
            // m_lblFournisseur
            // 
            this.m_lblFournisseur.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblFournisseur.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkFournisseur.SetLinkField(this.m_lblFournisseur, "Fournisseur.Acteur.Nom");
            this.m_linkConstructeur.SetLinkField(this.m_lblFournisseur, "");
            this.m_extLinkField.SetLinkField(this.m_lblFournisseur, "");
            this.m_linkSousType.SetLinkField(this.m_lblFournisseur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblFournisseur, "");
            this.m_linkStock.SetLinkField(this.m_lblFournisseur, "");
            this.m_lblFournisseur.Location = new System.Drawing.Point(4, 38);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblFournisseur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblFournisseur, "");
            this.m_lblFournisseur.Name = "m_lblFournisseur";
            this.m_lblFournisseur.Size = new System.Drawing.Size(339, 29);
            this.m_extStyle.SetStyleBackColor(this.m_lblFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblFournisseur.TabIndex = 0;
            this.m_lblFournisseur.Text = "[Fournisseur.Acteur.Nom]";
            this.m_lblFournisseur.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_wndListeFournisseurs
            // 
            this.m_wndListeFournisseurs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeFournisseurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colonneLibelleFournisseur,
            this.m_colonneReferenceFournisseur});
            this.m_wndListeFournisseurs.EnableCustomisation = true;
            this.m_wndListeFournisseurs.FullRowSelect = true;
            this.m_wndListeFournisseurs.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.m_wndListeFournisseurs, "");
            this.m_linkConstructeur.SetLinkField(this.m_wndListeFournisseurs, "");
            this.m_linkFournisseur.SetLinkField(this.m_wndListeFournisseurs, "");
            this.m_linkSousType.SetLinkField(this.m_wndListeFournisseurs, "");
            this.m_linkStock.SetLinkField(this.m_wndListeFournisseurs, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeFournisseurs, "");
            this.m_wndListeFournisseurs.Location = new System.Drawing.Point(11, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFournisseurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeFournisseurs, "");
            this.m_wndListeFournisseurs.MultiSelect = false;
            this.m_wndListeFournisseurs.Name = "m_wndListeFournisseurs";
            this.m_wndListeFournisseurs.Size = new System.Drawing.Size(325, 281);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeFournisseurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeFournisseurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeFournisseurs.TabIndex = 2;
            this.m_wndListeFournisseurs.UseCompatibleStateImageBehavior = false;
            this.m_wndListeFournisseurs.View = System.Windows.Forms.View.Details;
            // 
            // m_colonneLibelleFournisseur
            // 
            this.m_colonneLibelleFournisseur.Field = "Fournisseur.Acteur.Libelle";
            this.m_colonneLibelleFournisseur.PrecisionWidth = 0;
            this.m_colonneLibelleFournisseur.ProportionnalSize = false;
            this.m_colonneLibelleFournisseur.Text = "Label|50";
            this.m_colonneLibelleFournisseur.Visible = true;
            this.m_colonneLibelleFournisseur.Width = 200;
            // 
            // m_colonneReferenceFournisseur
            // 
            this.m_colonneReferenceFournisseur.Field = "Reference";
            this.m_colonneReferenceFournisseur.PrecisionWidth = 0;
            this.m_colonneReferenceFournisseur.ProportionnalSize = false;
            this.m_colonneReferenceFournisseur.Text = "Supplier Reference|10034";
            this.m_colonneReferenceFournisseur.Visible = true;
            this.m_colonneReferenceFournisseur.Width = 120;
            // 
            // m_txtSelectFournisseur
            // 
            this.m_txtSelectFournisseur.ElementSelectionne = null;
            this.m_txtSelectFournisseur.FonctionTextNull = null;
            this.m_txtSelectFournisseur.HasLink = true;
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectFournisseur, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectFournisseur, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectFournisseur, "");
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectFournisseur, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectFournisseur, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectFournisseur, "");
            this.m_txtSelectFournisseur.Location = new System.Drawing.Point(81, 8);
            this.m_txtSelectFournisseur.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectFournisseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectFournisseur, "");
            this.m_txtSelectFournisseur.Name = "m_txtSelectFournisseur";
            this.m_txtSelectFournisseur.SelectedObject = null;
            this.m_txtSelectFournisseur.Size = new System.Drawing.Size(255, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectFournisseur.TabIndex = 1;
            this.m_txtSelectFournisseur.TextNull = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_linkFournisseur.SetLinkField(this.label3, "");
            this.m_linkStock.SetLinkField(this.label3, "");
            this.m_linkSousType.SetLinkField(this.label3, "");
            this.m_linkRemplacement.SetLinkField(this.label3, "");
            this.m_linkConstructeur.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(8, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Supplier|201";
            // 
            // m_lnkAjouterFournisseur
            // 
            this.m_lnkAjouterFournisseur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterFournisseur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkAjouterFournisseur, "");
            this.m_linkStock.SetLinkField(this.m_lnkAjouterFournisseur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkAjouterFournisseur, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkAjouterFournisseur, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterFournisseur, "");
            this.m_linkSousType.SetLinkField(this.m_lnkAjouterFournisseur, "");
            this.m_lnkAjouterFournisseur.Location = new System.Drawing.Point(81, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterFournisseur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterFournisseur, "");
            this.m_lnkAjouterFournisseur.Name = "m_lnkAjouterFournisseur";
            this.m_lnkAjouterFournisseur.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterFournisseur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterFournisseur.TabIndex = 3;
            this.m_lnkAjouterFournisseur.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterFournisseur.LinkClicked += new System.EventHandler(this.m_lnkAjouterFournisseur_LinkClicked);
            // 
            // m_pageComportementStock
            // 
            this.m_pageComportementStock.Controls.Add(this.pictureBox5);
            this.m_pageComportementStock.Controls.Add(this.panel2);
            this.m_pageComportementStock.Controls.Add(this.m_lnkSupprimeTypeStock);
            this.m_pageComportementStock.Controls.Add(this.m_panelStock);
            this.m_pageComportementStock.Controls.Add(this.m_wndListeTypesStocks);
            this.m_pageComportementStock.Controls.Add(this.m_txtSelectTypeStock);
            this.m_pageComportementStock.Controls.Add(this.label11);
            this.m_pageComportementStock.Controls.Add(this.m_lnkAddTypeStock);
            this.m_linkConstructeur.SetLinkField(this.m_pageComportementStock, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageComportementStock, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageComportementStock, "");
            this.m_extLinkField.SetLinkField(this.m_pageComportementStock, "");
            this.m_linkStock.SetLinkField(this.m_pageComportementStock, "");
            this.m_linkSousType.SetLinkField(this.m_pageComportementStock, "");
            this.m_pageComportementStock.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageComportementStock, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageComportementStock, "ASTOCK");
            this.m_pageComportementStock.Name = "m_pageComportementStock";
            this.m_pageComportementStock.Selected = false;
            this.m_pageComportementStock.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageComportementStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageComportementStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageComportementStock.TabIndex = 12;
            this.m_pageComportementStock.Title = "Stock behaviour|209";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox5.BackColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.m_linkRemplacement.SetLinkField(this.pictureBox5, "");
            this.m_linkConstructeur.SetLinkField(this.pictureBox5, "");
            this.m_linkFournisseur.SetLinkField(this.pictureBox5, "");
            this.m_linkSousType.SetLinkField(this.pictureBox5, "");
            this.m_linkStock.SetLinkField(this.pictureBox5, "");
            this.pictureBox5.Location = new System.Drawing.Point(178, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(1, 371);
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 12;
            this.pictureBox5.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Controls.Add(this.c2iTextBoxNumerique4);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.label17);
            this.m_linkConstructeur.SetLinkField(this.panel2, "");
            this.m_linkRemplacement.SetLinkField(this.panel2, "");
            this.m_linkSousType.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_linkFournisseur.SetLinkField(this.panel2, "");
            this.m_linkStock.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(0, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(169, 325);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 11;
            // 
            // c2iTextBoxNumerique4
            // 
            this.c2iTextBoxNumerique4.Arrondi = 0;
            this.c2iTextBoxNumerique4.DecimalAutorise = false;
            this.c2iTextBoxNumerique4.IntValue = 0;
            this.m_linkFournisseur.SetLinkField(this.c2iTextBoxNumerique4, "");
            this.m_linkSousType.SetLinkField(this.c2iTextBoxNumerique4, "");
            this.m_linkStock.SetLinkField(this.c2iTextBoxNumerique4, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique4, "StockOptimal");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBoxNumerique4, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBoxNumerique4, "");
            this.c2iTextBoxNumerique4.Location = new System.Drawing.Point(85, 103);
            this.c2iTextBoxNumerique4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique4, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique4, "");
            this.c2iTextBoxNumerique4.Name = "c2iTextBoxNumerique4";
            this.c2iTextBoxNumerique4.NullAutorise = false;
            this.c2iTextBoxNumerique4.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique4.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique4.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.c2iTextBoxNumerique5);
            this.groupBox2.Controls.Add(this.c2iTextBoxNumerique6);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label15);
            this.m_linkSousType.SetLinkField(this.groupBox2, "");
            this.m_linkRemplacement.SetLinkField(this.groupBox2, "");
            this.m_linkConstructeur.SetLinkField(this.groupBox2, "");
            this.m_linkStock.SetLinkField(this.groupBox2, "");
            this.m_extLinkField.SetLinkField(this.groupBox2, "");
            this.m_linkFournisseur.SetLinkField(this.groupBox2, "");
            this.groupBox2.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox2, "");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(166, 71);
            this.m_extStyle.SetStyleBackColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Alerts|213";
            // 
            // c2iTextBoxNumerique5
            // 
            this.c2iTextBoxNumerique5.Arrondi = 0;
            this.c2iTextBoxNumerique5.DecimalAutorise = false;
            this.c2iTextBoxNumerique5.IntValue = 0;
            this.m_linkStock.SetLinkField(this.c2iTextBoxNumerique5, "");
            this.m_linkSousType.SetLinkField(this.c2iTextBoxNumerique5, "");
            this.m_linkFournisseur.SetLinkField(this.c2iTextBoxNumerique5, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique5, "StockCritique");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBoxNumerique5, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBoxNumerique5, "");
            this.c2iTextBoxNumerique5.Location = new System.Drawing.Point(85, 40);
            this.c2iTextBoxNumerique5.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique5, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique5, "");
            this.c2iTextBoxNumerique5.Name = "c2iTextBoxNumerique5";
            this.c2iTextBoxNumerique5.NullAutorise = false;
            this.c2iTextBoxNumerique5.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique5.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique5.TabIndex = 5;
            // 
            // c2iTextBoxNumerique6
            // 
            this.c2iTextBoxNumerique6.Arrondi = 0;
            this.c2iTextBoxNumerique6.DecimalAutorise = false;
            this.c2iTextBoxNumerique6.IntValue = 0;
            this.m_linkStock.SetLinkField(this.c2iTextBoxNumerique6, "");
            this.m_linkSousType.SetLinkField(this.c2iTextBoxNumerique6, "");
            this.m_linkFournisseur.SetLinkField(this.c2iTextBoxNumerique6, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique6, "StockAlerte");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBoxNumerique6, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBoxNumerique6, "");
            this.c2iTextBoxNumerique6.Location = new System.Drawing.Point(85, 17);
            this.c2iTextBoxNumerique6.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique6, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique6, "");
            this.c2iTextBoxNumerique6.Name = "c2iTextBoxNumerique6";
            this.c2iTextBoxNumerique6.NullAutorise = false;
            this.c2iTextBoxNumerique6.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique6.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique6.TabIndex = 4;
            // 
            // label14
            // 
            this.m_extLinkField.SetLinkField(this.label14, "");
            this.m_linkSousType.SetLinkField(this.label14, "");
            this.m_linkFournisseur.SetLinkField(this.label14, "");
            this.m_linkConstructeur.SetLinkField(this.label14, "");
            this.m_linkRemplacement.SetLinkField(this.label14, "");
            this.m_linkStock.SetLinkField(this.label14, "");
            this.label14.Location = new System.Drawing.Point(6, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label14, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label14, "");
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 23);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 1;
            this.label14.Text = "Alert threshold|210";
            // 
            // label15
            // 
            this.m_linkRemplacement.SetLinkField(this.label15, "");
            this.m_linkConstructeur.SetLinkField(this.label15, "");
            this.m_linkStock.SetLinkField(this.label15, "");
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.m_linkSousType.SetLinkField(this.label15, "");
            this.m_linkFournisseur.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(6, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 3;
            this.label15.Text = "Critical threshold|211";
            // 
            // label16
            // 
            this.m_extLinkField.SetLinkField(this.label16, "");
            this.m_linkFournisseur.SetLinkField(this.label16, "");
            this.m_linkStock.SetLinkField(this.label16, "");
            this.m_linkSousType.SetLinkField(this.label16, "");
            this.m_linkRemplacement.SetLinkField(this.label16, "");
            this.m_linkConstructeur.SetLinkField(this.label16, "");
            this.label16.Location = new System.Drawing.Point(6, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label16, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label16, "");
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 2;
            this.label16.Text = "Optimal threshold|212";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label17, "");
            this.m_linkFournisseur.SetLinkField(this.label17, "");
            this.m_linkStock.SetLinkField(this.label17, "");
            this.m_linkSousType.SetLinkField(this.label17, "");
            this.m_linkRemplacement.SetLinkField(this.label17, "");
            this.m_linkConstructeur.SetLinkField(this.label17, "");
            this.label17.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label17, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label17, "");
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(169, 29);
            this.m_extStyle.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 0;
            this.label17.Text = "Default behaviour|209";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkSupprimeTypeStock
            // 
            this.m_lnkSupprimeTypeStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimeTypeStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimeTypeStock.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkSupprimeTypeStock, "");
            this.m_linkStock.SetLinkField(this.m_lnkSupprimeTypeStock, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkSupprimeTypeStock, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkSupprimeTypeStock, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimeTypeStock, "");
            this.m_linkSousType.SetLinkField(this.m_lnkSupprimeTypeStock, "");
            this.m_lnkSupprimeTypeStock.Location = new System.Drawing.Point(184, 340);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimeTypeStock, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimeTypeStock, "");
            this.m_lnkSupprimeTypeStock.Name = "m_lnkSupprimeTypeStock";
            this.m_lnkSupprimeTypeStock.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimeTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimeTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimeTypeStock.TabIndex = 10;
            this.m_lnkSupprimeTypeStock.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimeTypeStock.LinkClicked += new System.EventHandler(this.m_lnkSupprimerTypeStock_LinkClicked);
            // 
            // m_panelStock
            // 
            this.m_panelStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelStock.Controls.Add(this.c2iTextBoxNumerique3);
            this.m_panelStock.Controls.Add(this.groupBox1);
            this.m_panelStock.Controls.Add(this.label12);
            this.m_panelStock.Controls.Add(this.label10);
            this.m_linkConstructeur.SetLinkField(this.m_panelStock, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelStock, "");
            this.m_linkSousType.SetLinkField(this.m_panelStock, "");
            this.m_extLinkField.SetLinkField(this.m_panelStock, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelStock, "");
            this.m_linkStock.SetLinkField(this.m_panelStock, "");
            this.m_panelStock.Location = new System.Drawing.Point(605, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelStock, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelStock, "");
            this.m_panelStock.Name = "m_panelStock";
            this.m_panelStock.Size = new System.Drawing.Size(176, 325);
            this.m_extStyle.SetStyleBackColor(this.m_panelStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelStock.TabIndex = 9;
            this.m_panelStock.Visible = false;
            // 
            // c2iTextBoxNumerique3
            // 
            this.c2iTextBoxNumerique3.Arrondi = 0;
            this.c2iTextBoxNumerique3.DecimalAutorise = false;
            this.c2iTextBoxNumerique3.DoubleValue = null;
            this.c2iTextBoxNumerique3.IntValue = null;
            this.m_linkStock.SetLinkField(this.c2iTextBoxNumerique3, "StockOptimal");
            this.m_linkSousType.SetLinkField(this.c2iTextBoxNumerique3, "");
            this.m_linkFournisseur.SetLinkField(this.c2iTextBoxNumerique3, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique3, "");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBoxNumerique3, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBoxNumerique3, "");
            this.c2iTextBoxNumerique3.Location = new System.Drawing.Point(100, 103);
            this.c2iTextBoxNumerique3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique3, "");
            this.c2iTextBoxNumerique3.Name = "c2iTextBoxNumerique3";
            this.c2iTextBoxNumerique3.NullAutorise = true;
            this.c2iTextBoxNumerique3.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique3.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique3.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.c2iTextBoxNumerique2);
            this.groupBox1.Controls.Add(this.c2iTextBoxNumerique1);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label13);
            this.m_linkFournisseur.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.m_linkRemplacement.SetLinkField(this.groupBox1, "");
            this.m_linkConstructeur.SetLinkField(this.groupBox1, "");
            this.m_linkStock.SetLinkField(this.groupBox1, "");
            this.m_linkSousType.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(0, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(173, 71);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Alerts|213";
            // 
            // c2iTextBoxNumerique2
            // 
            this.c2iTextBoxNumerique2.Arrondi = 0;
            this.c2iTextBoxNumerique2.DecimalAutorise = false;
            this.c2iTextBoxNumerique2.DoubleValue = null;
            this.c2iTextBoxNumerique2.IntValue = null;
            this.m_linkRemplacement.SetLinkField(this.c2iTextBoxNumerique2, "");
            this.m_linkStock.SetLinkField(this.c2iTextBoxNumerique2, "StockCritique");
            this.m_linkFournisseur.SetLinkField(this.c2iTextBoxNumerique2, "");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBoxNumerique2, "");
            this.m_linkSousType.SetLinkField(this.c2iTextBoxNumerique2, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique2, "");
            this.c2iTextBoxNumerique2.Location = new System.Drawing.Point(100, 40);
            this.c2iTextBoxNumerique2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique2, "");
            this.c2iTextBoxNumerique2.Name = "c2iTextBoxNumerique2";
            this.c2iTextBoxNumerique2.NullAutorise = true;
            this.c2iTextBoxNumerique2.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique2.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique2.TabIndex = 5;
            // 
            // c2iTextBoxNumerique1
            // 
            this.c2iTextBoxNumerique1.Arrondi = 0;
            this.c2iTextBoxNumerique1.DecimalAutorise = false;
            this.c2iTextBoxNumerique1.DoubleValue = null;
            this.c2iTextBoxNumerique1.IntValue = null;
            this.m_linkStock.SetLinkField(this.c2iTextBoxNumerique1, "StockAlerte");
            this.m_linkSousType.SetLinkField(this.c2iTextBoxNumerique1, "");
            this.m_linkFournisseur.SetLinkField(this.c2iTextBoxNumerique1, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique1, "");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBoxNumerique1, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBoxNumerique1, "");
            this.c2iTextBoxNumerique1.Location = new System.Drawing.Point(100, 17);
            this.c2iTextBoxNumerique1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique1, "");
            this.c2iTextBoxNumerique1.Name = "c2iTextBoxNumerique1";
            this.c2iTextBoxNumerique1.NullAutorise = true;
            this.c2iTextBoxNumerique1.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique1.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique1.TabIndex = 4;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_linkFournisseur.SetLinkField(this.label7, "");
            this.m_linkStock.SetLinkField(this.label7, "");
            this.m_linkSousType.SetLinkField(this.label7, "");
            this.m_linkRemplacement.SetLinkField(this.label7, "");
            this.m_linkConstructeur.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(6, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 1;
            this.label7.Text = "Alert threshold|210";
            // 
            // label13
            // 
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.m_linkFournisseur.SetLinkField(this.label13, "");
            this.m_linkStock.SetLinkField(this.label13, "");
            this.m_linkSousType.SetLinkField(this.label13, "");
            this.m_linkRemplacement.SetLinkField(this.label13, "");
            this.m_linkConstructeur.SetLinkField(this.label13, "");
            this.label13.Location = new System.Drawing.Point(6, 43);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 3;
            this.label13.Text = "Critical threshold|211";
            // 
            // label12
            // 
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.m_linkFournisseur.SetLinkField(this.label12, "");
            this.m_linkStock.SetLinkField(this.label12, "");
            this.m_linkSousType.SetLinkField(this.label12, "");
            this.m_linkRemplacement.SetLinkField(this.label12, "");
            this.m_linkConstructeur.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(6, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 23);
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
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_linkFournisseur.SetLinkField(this.label10, "");
            this.m_linkStock.SetLinkField(this.label10, "TypeStock.Libelle");
            this.m_linkSousType.SetLinkField(this.label10, "");
            this.m_linkRemplacement.SetLinkField(this.label10, "");
            this.m_linkConstructeur.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(176, 29);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "[TypeStock.Libelle]";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_wndListeTypesStocks
            // 
            this.m_wndListeTypesStocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeTypesStocks.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn5});
            this.m_wndListeTypesStocks.EnableCustomisation = true;
            this.m_wndListeTypesStocks.FullRowSelect = true;
            this.m_wndListeTypesStocks.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.m_wndListeTypesStocks, "");
            this.m_linkConstructeur.SetLinkField(this.m_wndListeTypesStocks, "");
            this.m_linkFournisseur.SetLinkField(this.m_wndListeTypesStocks, "");
            this.m_linkSousType.SetLinkField(this.m_wndListeTypesStocks, "");
            this.m_linkStock.SetLinkField(this.m_wndListeTypesStocks, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeTypesStocks, "");
            this.m_wndListeTypesStocks.Location = new System.Drawing.Point(184, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypesStocks, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeTypesStocks, "");
            this.m_wndListeTypesStocks.MultiSelect = false;
            this.m_wndListeTypesStocks.Name = "m_wndListeTypesStocks";
            this.m_wndListeTypesStocks.Size = new System.Drawing.Size(411, 276);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypesStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypesStocks, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypesStocks.TabIndex = 7;
            this.m_wndListeTypesStocks.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypesStocks.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn5
            // 
            this.listViewAutoFilledColumn5.Field = "TypeStock.Libelle";
            this.listViewAutoFilledColumn5.PrecisionWidth = 0;
            this.listViewAutoFilledColumn5.ProportionnalSize = false;
            this.listViewAutoFilledColumn5.Text = "Label|50";
            this.listViewAutoFilledColumn5.Visible = true;
            this.listViewAutoFilledColumn5.Width = 200;
            // 
            // m_txtSelectTypeStock
            // 
            this.m_txtSelectTypeStock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeStock.ElementSelectionne = null;
            this.m_txtSelectTypeStock.FonctionTextNull = null;
            this.m_txtSelectTypeStock.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectTypeStock, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectTypeStock, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectTypeStock, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeStock, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectTypeStock, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectTypeStock, "");
            this.m_txtSelectTypeStock.Location = new System.Drawing.Point(267, 9);
            this.m_txtSelectTypeStock.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeStock, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeStock, "");
            this.m_txtSelectTypeStock.Name = "m_txtSelectTypeStock";
            this.m_txtSelectTypeStock.SelectedObject = null;
            this.m_txtSelectTypeStock.Size = new System.Drawing.Size(241, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeStock.TabIndex = 6;
            this.m_txtSelectTypeStock.TextNull = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.m_linkFournisseur.SetLinkField(this.label11, "");
            this.m_linkConstructeur.SetLinkField(this.label11, "");
            this.m_linkSousType.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_linkRemplacement.SetLinkField(this.label11, "");
            this.m_linkStock.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(184, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 15);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 5;
            this.label11.Text = "Stock type|208";
            // 
            // m_lnkAddTypeStock
            // 
            this.m_lnkAddTypeStock.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeStock.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkAddTypeStock, "");
            this.m_linkStock.SetLinkField(this.m_lnkAddTypeStock, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkAddTypeStock, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkAddTypeStock, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeStock, "");
            this.m_linkSousType.SetLinkField(this.m_lnkAddTypeStock, "");
            this.m_lnkAddTypeStock.Location = new System.Drawing.Point(267, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeStock, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeStock, "");
            this.m_lnkAddTypeStock.Name = "m_lnkAddTypeStock";
            this.m_lnkAddTypeStock.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeStock, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeStock.TabIndex = 8;
            this.m_lnkAddTypeStock.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeStock.LinkClicked += new System.EventHandler(this.m_lnkAjouterTypeStock_LinkClicked);
            // 
            // m_pagePeutInclure
            // 
            this.m_pagePeutInclure.Controls.Add(this.splitContainer2);
            this.m_extLinkField.SetLinkField(this.m_pagePeutInclure, "");
            this.m_linkStock.SetLinkField(this.m_pagePeutInclure, "");
            this.m_linkConstructeur.SetLinkField(this.m_pagePeutInclure, "");
            this.m_linkRemplacement.SetLinkField(this.m_pagePeutInclure, "");
            this.m_linkSousType.SetLinkField(this.m_pagePeutInclure, "");
            this.m_linkFournisseur.SetLinkField(this.m_pagePeutInclure, "");
            this.m_pagePeutInclure.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePeutInclure, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePeutInclure, "");
            this.m_pagePeutInclure.Name = "m_pagePeutInclure";
            this.m_pagePeutInclure.Selected = false;
            this.m_pagePeutInclure.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pagePeutInclure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePeutInclure, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePeutInclure.TabIndex = 13;
            this.m_pagePeutInclure.Title = "Can include|217";
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkRemplacement.SetLinkField(this.splitContainer2, "");
            this.m_linkStock.SetLinkField(this.splitContainer2, "");
            this.m_linkFournisseur.SetLinkField(this.splitContainer2, "");
            this.m_extLinkField.SetLinkField(this.splitContainer2, "");
            this.m_linkConstructeur.SetLinkField(this.splitContainer2, "");
            this.m_linkSousType.SetLinkField(this.splitContainer2, "");
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2, "");
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.label18);
            this.splitContainer2.Panel1.Controls.Add(this.m_lnkDeleteTypeInclu);
            this.splitContainer2.Panel1.Controls.Add(this.m_txtSelectTypeInclu);
            this.splitContainer2.Panel1.Controls.Add(this.m_lnkAddTypeInclu);
            this.splitContainer2.Panel1.Controls.Add(this.m_wndListeEquipementsInclus);
            this.m_linkFournisseur.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_linkConstructeur.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_linkStock.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_linkRemplacement.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_linkSousType.SetLinkField(this.splitContainer2.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.m_wndListeEquipementsIncluants);
            this.splitContainer2.Panel2.Controls.Add(this.m_lnkDeleteTypeIncluant);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.m_txtSelectTypeIncluant);
            this.splitContainer2.Panel2.Controls.Add(this.m_lnkAddTypeIncluant);
            this.m_linkStock.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_linkRemplacement.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_linkConstructeur.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_linkSousType.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_linkFournisseur.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_extLinkField.SetLinkField(this.splitContainer2.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer2.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer2.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.Size = new System.Drawing.Size(798, 375);
            this.splitContainer2.SplitterDistance = 393;
            this.m_extStyle.SetStyleBackColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer2.TabIndex = 19;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.m_linkFournisseur.SetLinkField(this.label18, "");
            this.m_linkStock.SetLinkField(this.label18, "");
            this.m_linkSousType.SetLinkField(this.label18, "");
            this.m_linkRemplacement.SetLinkField(this.label18, "");
            this.m_linkConstructeur.SetLinkField(this.label18, "");
            this.label18.Location = new System.Drawing.Point(18, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label18, "");
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(175, 15);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 0;
            this.label18.Text = "This equipment can include|218";
            // 
            // m_lnkDeleteTypeInclu
            // 
            this.m_lnkDeleteTypeInclu.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkDeleteTypeInclu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDeleteTypeInclu.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkDeleteTypeInclu, "");
            this.m_linkStock.SetLinkField(this.m_lnkDeleteTypeInclu, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkDeleteTypeInclu, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkDeleteTypeInclu, "");
            this.m_extLinkField.SetLinkField(this.m_lnkDeleteTypeInclu, "");
            this.m_linkSousType.SetLinkField(this.m_lnkDeleteTypeInclu, "");
            this.m_lnkDeleteTypeInclu.Location = new System.Drawing.Point(21, 312);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeleteTypeInclu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDeleteTypeInclu, "");
            this.m_lnkDeleteTypeInclu.Name = "m_lnkDeleteTypeInclu";
            this.m_lnkDeleteTypeInclu.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDeleteTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDeleteTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDeleteTypeInclu.TabIndex = 13;
            this.m_lnkDeleteTypeInclu.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDeleteTypeInclu.LinkClicked += new System.EventHandler(this.m_lnkDeleteTypeInclu_LinkClicked);
            // 
            // m_txtSelectTypeInclu
            // 
            this.m_txtSelectTypeInclu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeInclu.ElementSelectionne = null;
            this.m_txtSelectTypeInclu.FonctionTextNull = null;
            this.m_txtSelectTypeInclu.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectTypeInclu, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectTypeInclu, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectTypeInclu, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeInclu, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectTypeInclu, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectTypeInclu, "");
            this.m_txtSelectTypeInclu.Location = new System.Drawing.Point(21, 26);
            this.m_txtSelectTypeInclu.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeInclu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeInclu, "");
            this.m_txtSelectTypeInclu.Name = "m_txtSelectTypeInclu";
            this.m_txtSelectTypeInclu.SelectedObject = null;
            this.m_txtSelectTypeInclu.Size = new System.Drawing.Size(174, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeInclu.TabIndex = 8;
            this.m_txtSelectTypeInclu.TextNull = "";
            // 
            // m_lnkAddTypeInclu
            // 
            this.m_lnkAddTypeInclu.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeInclu.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkAddTypeInclu, "");
            this.m_linkStock.SetLinkField(this.m_lnkAddTypeInclu, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkAddTypeInclu, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkAddTypeInclu, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeInclu, "");
            this.m_linkSousType.SetLinkField(this.m_lnkAddTypeInclu, "");
            this.m_lnkAddTypeInclu.Location = new System.Drawing.Point(21, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeInclu, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeInclu, "");
            this.m_lnkAddTypeInclu.Name = "m_lnkAddTypeInclu";
            this.m_lnkAddTypeInclu.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeInclu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeInclu.TabIndex = 12;
            this.m_lnkAddTypeInclu.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeInclu.LinkClicked += new System.EventHandler(this.m_lnkAddTypeInclu_LinkClicked);
            // 
            // m_wndListeEquipementsInclus
            // 
            this.m_wndListeEquipementsInclus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeEquipementsInclus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn6});
            this.m_wndListeEquipementsInclus.EnableCustomisation = true;
            this.m_wndListeEquipementsInclus.FullRowSelect = true;
            this.m_wndListeEquipementsInclus.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.m_wndListeEquipementsInclus, "");
            this.m_linkConstructeur.SetLinkField(this.m_wndListeEquipementsInclus, "");
            this.m_linkFournisseur.SetLinkField(this.m_wndListeEquipementsInclus, "");
            this.m_linkSousType.SetLinkField(this.m_wndListeEquipementsInclus, "");
            this.m_linkStock.SetLinkField(this.m_wndListeEquipementsInclus, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeEquipementsInclus, "");
            this.m_wndListeEquipementsInclus.Location = new System.Drawing.Point(21, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeEquipementsInclus, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeEquipementsInclus, "");
            this.m_wndListeEquipementsInclus.MultiSelect = false;
            this.m_wndListeEquipementsInclus.Name = "m_wndListeEquipementsInclus";
            this.m_wndListeEquipementsInclus.Size = new System.Drawing.Size(274, 235);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeEquipementsInclus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeEquipementsInclus.TabIndex = 11;
            this.m_wndListeEquipementsInclus.UseCompatibleStateImageBehavior = false;
            this.m_wndListeEquipementsInclus.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn6
            // 
            this.listViewAutoFilledColumn6.Field = "TypeInclu.Libelle";
            this.listViewAutoFilledColumn6.PrecisionWidth = 0;
            this.listViewAutoFilledColumn6.ProportionnalSize = false;
            this.listViewAutoFilledColumn6.Text = "Label|50";
            this.listViewAutoFilledColumn6.Visible = true;
            this.listViewAutoFilledColumn6.Width = 200;
            // 
            // m_wndListeEquipementsIncluants
            // 
            this.m_wndListeEquipementsIncluants.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeEquipementsIncluants.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn8});
            this.m_wndListeEquipementsIncluants.EnableCustomisation = true;
            this.m_wndListeEquipementsIncluants.FullRowSelect = true;
            this.m_wndListeEquipementsIncluants.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.m_wndListeEquipementsIncluants, "");
            this.m_linkConstructeur.SetLinkField(this.m_wndListeEquipementsIncluants, "");
            this.m_linkFournisseur.SetLinkField(this.m_wndListeEquipementsIncluants, "");
            this.m_linkSousType.SetLinkField(this.m_wndListeEquipementsIncluants, "");
            this.m_linkStock.SetLinkField(this.m_wndListeEquipementsIncluants, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeEquipementsIncluants, "");
            this.m_wndListeEquipementsIncluants.Location = new System.Drawing.Point(28, 71);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeEquipementsIncluants, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeEquipementsIncluants, "");
            this.m_wndListeEquipementsIncluants.MultiSelect = false;
            this.m_wndListeEquipementsIncluants.Name = "m_wndListeEquipementsIncluants";
            this.m_wndListeEquipementsIncluants.Size = new System.Drawing.Size(286, 235);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeEquipementsIncluants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeEquipementsIncluants, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeEquipementsIncluants.TabIndex = 16;
            this.m_wndListeEquipementsIncluants.UseCompatibleStateImageBehavior = false;
            this.m_wndListeEquipementsIncluants.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn8
            // 
            this.listViewAutoFilledColumn8.Field = "TypeIncluant.Libelle";
            this.listViewAutoFilledColumn8.PrecisionWidth = 0;
            this.listViewAutoFilledColumn8.ProportionnalSize = false;
            this.listViewAutoFilledColumn8.Text = "Label|50";
            this.listViewAutoFilledColumn8.Visible = true;
            this.listViewAutoFilledColumn8.Width = 200;
            // 
            // m_lnkDeleteTypeIncluant
            // 
            this.m_lnkDeleteTypeIncluant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkDeleteTypeIncluant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDeleteTypeIncluant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkDeleteTypeIncluant, "");
            this.m_linkStock.SetLinkField(this.m_lnkDeleteTypeIncluant, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkDeleteTypeIncluant, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkDeleteTypeIncluant, "");
            this.m_extLinkField.SetLinkField(this.m_lnkDeleteTypeIncluant, "");
            this.m_linkSousType.SetLinkField(this.m_lnkDeleteTypeIncluant, "");
            this.m_lnkDeleteTypeIncluant.Location = new System.Drawing.Point(28, 312);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeleteTypeIncluant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDeleteTypeIncluant, "");
            this.m_lnkDeleteTypeIncluant.Name = "m_lnkDeleteTypeIncluant";
            this.m_lnkDeleteTypeIncluant.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDeleteTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDeleteTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDeleteTypeIncluant.TabIndex = 18;
            this.m_lnkDeleteTypeIncluant.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDeleteTypeIncluant.LinkClicked += new System.EventHandler(this.m_lnkDeleteTypeIncluant_LinkClicked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_linkFournisseur.SetLinkField(this.label5, "");
            this.m_linkStock.SetLinkField(this.label5, "");
            this.m_linkSousType.SetLinkField(this.label5, "");
            this.m_linkRemplacement.SetLinkField(this.label5, "");
            this.m_linkConstructeur.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(25, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(214, 15);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 14;
            this.label5.Text = "This equipment can be included in |250";
            // 
            // m_txtSelectTypeIncluant
            // 
            this.m_txtSelectTypeIncluant.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeIncluant.ElementSelectionne = null;
            this.m_txtSelectTypeIncluant.FonctionTextNull = null;
            this.m_txtSelectTypeIncluant.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectTypeIncluant, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectTypeIncluant, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectTypeIncluant, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeIncluant, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectTypeIncluant, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectTypeIncluant, "");
            this.m_txtSelectTypeIncluant.Location = new System.Drawing.Point(28, 26);
            this.m_txtSelectTypeIncluant.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeIncluant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeIncluant, "");
            this.m_txtSelectTypeIncluant.Name = "m_txtSelectTypeIncluant";
            this.m_txtSelectTypeIncluant.SelectedObject = null;
            this.m_txtSelectTypeIncluant.Size = new System.Drawing.Size(201, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeIncluant.TabIndex = 15;
            this.m_txtSelectTypeIncluant.TextNull = "";
            // 
            // m_lnkAddTypeIncluant
            // 
            this.m_lnkAddTypeIncluant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeIncluant.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkAddTypeIncluant, "");
            this.m_linkStock.SetLinkField(this.m_lnkAddTypeIncluant, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkAddTypeIncluant, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkAddTypeIncluant, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeIncluant, "");
            this.m_linkSousType.SetLinkField(this.m_lnkAddTypeIncluant, "");
            this.m_lnkAddTypeIncluant.Location = new System.Drawing.Point(28, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeIncluant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeIncluant, "");
            this.m_lnkAddTypeIncluant.Name = "m_lnkAddTypeIncluant";
            this.m_lnkAddTypeIncluant.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeIncluant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeIncluant.TabIndex = 17;
            this.m_lnkAddTypeIncluant.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeIncluant.LinkClicked += new System.EventHandler(this.m_lnkAddTypeIncluant_LinkClicked);
            // 
            // m_pageEOs
            // 
            this.m_pageEOs.Controls.Add(this.m_panelEOS);
            this.m_linkConstructeur.SetLinkField(this.m_pageEOs, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageEOs, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageEOs, "");
            this.m_extLinkField.SetLinkField(this.m_pageEOs, "");
            this.m_linkStock.SetLinkField(this.m_pageEOs, "");
            this.m_linkSousType.SetLinkField(this.m_pageEOs, "");
            this.m_pageEOs.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEOs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEOs, "CEO");
            this.m_pageEOs.Name = "m_pageEOs";
            this.m_pageEOs.Selected = false;
            this.m_pageEOs.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEOs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEOs.TabIndex = 14;
            this.m_pageEOs.Title = "Organizational entities|53";
            // 
            // m_panelEOS
            // 
            this.m_panelEOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkConstructeur.SetLinkField(this.m_panelEOS, "");
            this.m_linkStock.SetLinkField(this.m_panelEOS, "");
            this.m_linkSousType.SetLinkField(this.m_panelEOS, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelEOS, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelEOS, "");
            this.m_extLinkField.SetLinkField(this.m_panelEOS, "");
            this.m_panelEOS.Location = new System.Drawing.Point(0, 0);
            this.m_panelEOS.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEOS, "");
            this.m_panelEOS.Name = "m_panelEOS";
            this.m_panelEOS.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEOS.TabIndex = 0;
            // 
            // m_pageInstallation
            // 
            this.m_pageInstallation.Controls.Add(this.m_tabParametreEquipements);
            this.m_linkConstructeur.SetLinkField(this.m_pageInstallation, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageInstallation, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageInstallation, "");
            this.m_extLinkField.SetLinkField(this.m_pageInstallation, "");
            this.m_linkStock.SetLinkField(this.m_pageInstallation, "");
            this.m_linkSousType.SetLinkField(this.m_pageInstallation, "");
            this.m_pageInstallation.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageInstallation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageInstallation, "");
            this.m_pageInstallation.Name = "m_pageInstallation";
            this.m_pageInstallation.Selected = false;
            this.m_pageInstallation.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageInstallation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageInstallation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageInstallation.TabIndex = 2;
            this.m_pageInstallation.Title = "Equipment setup|200";
            // 
            // m_tabParametreEquipements
            // 
            this.m_tabParametreEquipements.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_tabParametreEquipements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_tabParametreEquipements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabParametreEquipements.BoldSelectedPage = true;
            this.m_tabParametreEquipements.ForeColor = System.Drawing.Color.Black;
            this.m_tabParametreEquipements.IDEPixelArea = false;
            this.m_linkSousType.SetLinkField(this.m_tabParametreEquipements, "");
            this.m_extLinkField.SetLinkField(this.m_tabParametreEquipements, "");
            this.m_linkStock.SetLinkField(this.m_tabParametreEquipements, "");
            this.m_linkRemplacement.SetLinkField(this.m_tabParametreEquipements, "");
            this.m_linkConstructeur.SetLinkField(this.m_tabParametreEquipements, "");
            this.m_linkFournisseur.SetLinkField(this.m_tabParametreEquipements, "");
            this.m_tabParametreEquipements.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabParametreEquipements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabParametreEquipements, "");
            this.m_tabParametreEquipements.Name = "m_tabParametreEquipements";
            this.m_tabParametreEquipements.Ombre = false;
            this.m_tabParametreEquipements.PositionTop = true;
            this.m_tabParametreEquipements.SelectedIndex = 0;
            this.m_tabParametreEquipements.SelectedTab = this.tabPage4;
            this.m_tabParametreEquipements.Size = new System.Drawing.Size(798, 373);
            this.m_extStyle.SetStyleBackColor(this.m_tabParametreEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabParametreEquipements, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabParametreEquipements.TabIndex = 0;
            this.m_tabParametreEquipements.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage4,
            this.tabPage2,
            this.tabPage5,
            this.tabPage1});
            this.m_tabParametreEquipements.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_panelDefinisseurChampsPhysiques);
            this.m_linkFournisseur.SetLinkField(this.tabPage4, "");
            this.m_linkConstructeur.SetLinkField(this.tabPage4, "");
            this.m_linkSousType.SetLinkField(this.tabPage4, "");
            this.m_linkStock.SetLinkField(this.tabPage4, "");
            this.m_linkRemplacement.SetLinkField(this.tabPage4, "");
            this.m_extLinkField.SetLinkField(this.tabPage4, "");
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage4, "");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(798, 348);
            this.m_extStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 10;
            this.tabPage4.Title = "Custom Fields|198";
            // 
            // m_panelDefinisseurChampsPhysiques
            // 
            this.m_panelDefinisseurChampsPhysiques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkConstructeur.SetLinkField(this.m_panelDefinisseurChampsPhysiques, "");
            this.m_linkStock.SetLinkField(this.m_panelDefinisseurChampsPhysiques, "");
            this.m_linkSousType.SetLinkField(this.m_panelDefinisseurChampsPhysiques, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelDefinisseurChampsPhysiques, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelDefinisseurChampsPhysiques, "");
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChampsPhysiques, "");
            this.m_panelDefinisseurChampsPhysiques.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurChampsPhysiques.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChampsPhysiques, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurChampsPhysiques, "");
            this.m_panelDefinisseurChampsPhysiques.Name = "m_panelDefinisseurChampsPhysiques";
            this.m_panelDefinisseurChampsPhysiques.Size = new System.Drawing.Size(798, 348);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChampsPhysiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChampsPhysiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurChampsPhysiques.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelDefinisseurChampsLogiques);
            this.m_linkConstructeur.SetLinkField(this.tabPage2, "");
            this.m_linkFournisseur.SetLinkField(this.tabPage2, "");
            this.m_linkRemplacement.SetLinkField(this.tabPage2, "");
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.m_linkStock.SetLinkField(this.tabPage2, "");
            this.m_linkSousType.SetLinkField(this.tabPage2, "");
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(798, 348);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 13;
            this.tabPage2.Title = "Logical custom fields|20084";
            // 
            // m_panelDefinisseurChampsLogiques
            // 
            this.m_panelDefinisseurChampsLogiques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkConstructeur.SetLinkField(this.m_panelDefinisseurChampsLogiques, "");
            this.m_linkStock.SetLinkField(this.m_panelDefinisseurChampsLogiques, "");
            this.m_linkSousType.SetLinkField(this.m_panelDefinisseurChampsLogiques, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelDefinisseurChampsLogiques, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelDefinisseurChampsLogiques, "");
            this.m_extLinkField.SetLinkField(this.m_panelDefinisseurChampsLogiques, "");
            this.m_panelDefinisseurChampsLogiques.Location = new System.Drawing.Point(0, 0);
            this.m_panelDefinisseurChampsLogiques.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDefinisseurChampsLogiques, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelDefinisseurChampsLogiques, "");
            this.m_panelDefinisseurChampsLogiques.Name = "m_panelDefinisseurChampsLogiques";
            this.m_panelDefinisseurChampsLogiques.Size = new System.Drawing.Size(798, 348);
            this.m_extStyle.SetStyleBackColor(this.m_panelDefinisseurChampsLogiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDefinisseurChampsLogiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDefinisseurChampsLogiques.TabIndex = 1;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.m_lnkRemoveTypeDonnateur);
            this.tabPage5.Controls.Add(this.m_wndListeTypeDonnateurs);
            this.tabPage5.Controls.Add(this.m_lnkAddTypeDonnateur);
            this.tabPage5.Controls.Add(this.m_txtSelectTypeDonnateur);
            this.tabPage5.Controls.Add(this.label2);
            this.m_linkConstructeur.SetLinkField(this.tabPage5, "");
            this.m_linkFournisseur.SetLinkField(this.tabPage5, "");
            this.m_linkRemplacement.SetLinkField(this.tabPage5, "");
            this.m_extLinkField.SetLinkField(this.tabPage5, "");
            this.m_linkStock.SetLinkField(this.tabPage5, "");
            this.m_linkSousType.SetLinkField(this.tabPage5, "");
            this.tabPage5.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage5, "");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Selected = false;
            this.tabPage5.Size = new System.Drawing.Size(798, 348);
            this.m_extStyle.SetStyleBackColor(this.tabPage5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage5.TabIndex = 11;
            this.tabPage5.Title = "Inheritance|750";
            // 
            // m_lnkRemoveTypeDonnateur
            // 
            this.m_lnkRemoveTypeDonnateur.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkRemoveTypeDonnateur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveTypeDonnateur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkRemoveTypeDonnateur, "");
            this.m_linkStock.SetLinkField(this.m_lnkRemoveTypeDonnateur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkRemoveTypeDonnateur, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkRemoveTypeDonnateur, "");
            this.m_extLinkField.SetLinkField(this.m_lnkRemoveTypeDonnateur, "");
            this.m_linkSousType.SetLinkField(this.m_lnkRemoveTypeDonnateur, "");
            this.m_lnkRemoveTypeDonnateur.Location = new System.Drawing.Point(11, 320);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemoveTypeDonnateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkRemoveTypeDonnateur, "");
            this.m_lnkRemoveTypeDonnateur.Name = "m_lnkRemoveTypeDonnateur";
            this.m_lnkRemoveTypeDonnateur.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveTypeDonnateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveTypeDonnateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveTypeDonnateur.TabIndex = 16;
            this.m_lnkRemoveTypeDonnateur.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveTypeDonnateur.LinkClicked += new System.EventHandler(this.m_lnkDeleteTypeDonnateur_LinkClicked);
            // 
            // m_wndListeTypeDonnateurs
            // 
            this.m_wndListeTypeDonnateurs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeTypeDonnateurs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn7});
            this.m_wndListeTypeDonnateurs.EnableCustomisation = true;
            this.m_wndListeTypeDonnateurs.FullRowSelect = true;
            this.m_wndListeTypeDonnateurs.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.m_wndListeTypeDonnateurs, "");
            this.m_linkConstructeur.SetLinkField(this.m_wndListeTypeDonnateurs, "");
            this.m_linkFournisseur.SetLinkField(this.m_wndListeTypeDonnateurs, "");
            this.m_linkSousType.SetLinkField(this.m_wndListeTypeDonnateurs, "");
            this.m_linkStock.SetLinkField(this.m_wndListeTypeDonnateurs, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeTypeDonnateurs, "");
            this.m_wndListeTypeDonnateurs.Location = new System.Drawing.Point(11, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTypeDonnateurs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeTypeDonnateurs, "");
            this.m_wndListeTypeDonnateurs.MultiSelect = false;
            this.m_wndListeTypeDonnateurs.Name = "m_wndListeTypeDonnateurs";
            this.m_wndListeTypeDonnateurs.Size = new System.Drawing.Size(490, 261);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTypeDonnateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTypeDonnateurs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTypeDonnateurs.TabIndex = 14;
            this.m_wndListeTypeDonnateurs.UseCompatibleStateImageBehavior = false;
            this.m_wndListeTypeDonnateurs.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn7
            // 
            this.listViewAutoFilledColumn7.Field = "TypeParent.Libelle";
            this.listViewAutoFilledColumn7.PrecisionWidth = 0;
            this.listViewAutoFilledColumn7.ProportionnalSize = false;
            this.listViewAutoFilledColumn7.Text = "Label|50";
            this.listViewAutoFilledColumn7.Visible = true;
            this.listViewAutoFilledColumn7.Width = 200;
            // 
            // m_lnkAddTypeDonnateur
            // 
            this.m_lnkAddTypeDonnateur.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddTypeDonnateur.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkAddTypeDonnateur, "");
            this.m_linkStock.SetLinkField(this.m_lnkAddTypeDonnateur, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkAddTypeDonnateur, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkAddTypeDonnateur, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAddTypeDonnateur, "");
            this.m_linkSousType.SetLinkField(this.m_lnkAddTypeDonnateur, "");
            this.m_lnkAddTypeDonnateur.Location = new System.Drawing.Point(103, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddTypeDonnateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddTypeDonnateur, "");
            this.m_lnkAddTypeDonnateur.Name = "m_lnkAddTypeDonnateur";
            this.m_lnkAddTypeDonnateur.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddTypeDonnateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddTypeDonnateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddTypeDonnateur.TabIndex = 15;
            this.m_lnkAddTypeDonnateur.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddTypeDonnateur.LinkClicked += new System.EventHandler(this.m_lnkAddTypeDonnateur_LinkClicked);
            // 
            // m_txtSelectTypeDonnateur
            // 
            this.m_txtSelectTypeDonnateur.ElementSelectionne = null;
            this.m_txtSelectTypeDonnateur.FonctionTextNull = null;
            this.m_txtSelectTypeDonnateur.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectTypeDonnateur, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectTypeDonnateur, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectTypeDonnateur, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeDonnateur, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectTypeDonnateur, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectTypeDonnateur, "");
            this.m_txtSelectTypeDonnateur.Location = new System.Drawing.Point(103, 8);
            this.m_txtSelectTypeDonnateur.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeDonnateur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeDonnateur, "");
            this.m_txtSelectTypeDonnateur.Name = "m_txtSelectTypeDonnateur";
            this.m_txtSelectTypeDonnateur.SelectedObject = null;
            this.m_txtSelectTypeDonnateur.Size = new System.Drawing.Size(382, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeDonnateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeDonnateur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeDonnateur.TabIndex = 13;
            this.m_txtSelectTypeDonnateur.TextNull = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_linkFournisseur.SetLinkField(this.label2, "");
            this.m_linkStock.SetLinkField(this.label2, "");
            this.m_linkSousType.SetLinkField(this.label2, "");
            this.m_linkRemplacement.SetLinkField(this.label2, "");
            this.m_linkConstructeur.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "Inherits from|249";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.m_chkIsDotation);
            this.tabPage1.Controls.Add(this.checkBox1);
            this.m_linkConstructeur.SetLinkField(this.tabPage1, "");
            this.m_linkFournisseur.SetLinkField(this.tabPage1, "");
            this.m_linkRemplacement.SetLinkField(this.tabPage1, "");
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.m_linkStock.SetLinkField(this.tabPage1, "");
            this.m_linkSousType.SetLinkField(this.tabPage1, "");
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(798, 348);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 12;
            this.tabPage1.Title = "Options|20063";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBox2);
            this.groupBox3.Controls.Add(this.m_txtSelectTypeFonction);
            this.groupBox3.Controls.Add(this.label9);
            this.m_linkFournisseur.SetLinkField(this.groupBox3, "");
            this.m_extLinkField.SetLinkField(this.groupBox3, "");
            this.m_linkRemplacement.SetLinkField(this.groupBox3, "");
            this.m_linkConstructeur.SetLinkField(this.groupBox3, "");
            this.m_linkStock.SetLinkField(this.groupBox3, "");
            this.m_linkSousType.SetLinkField(this.groupBox3, "");
            this.groupBox3.Location = new System.Drawing.Point(10, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox3, "");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(509, 137);
            this.m_extStyle.SetStyleBackColor(this.groupBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Logical equipment association|20064";
            // 
            // checkBox2
            // 
            this.m_linkStock.SetLinkField(this.checkBox2, "");
            this.m_linkConstructeur.SetLinkField(this.checkBox2, "");
            this.m_linkFournisseur.SetLinkField(this.checkBox2, "");
            this.m_linkRemplacement.SetLinkField(this.checkBox2, "");
            this.m_linkSousType.SetLinkField(this.checkBox2, "");
            this.m_extLinkField.SetLinkField(this.checkBox2, "CreationAutomatiqueDeFonction");
            this.checkBox2.Location = new System.Drawing.Point(6, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox2, "");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(234, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Auto create Logical equipment|20066";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // m_txtSelectTypeFonction
            // 
            this.m_txtSelectTypeFonction.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectTypeFonction.ElementSelectionne = null;
            this.m_txtSelectTypeFonction.FonctionTextNull = null;
            this.m_txtSelectTypeFonction.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectTypeFonction, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectTypeFonction, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectTypeFonction, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeFonction, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectTypeFonction, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectTypeFonction, "");
            this.m_txtSelectTypeFonction.Location = new System.Drawing.Point(198, 12);
            this.m_txtSelectTypeFonction.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeFonction, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeFonction, "");
            this.m_txtSelectTypeFonction.Name = "m_txtSelectTypeFonction";
            this.m_txtSelectTypeFonction.SelectedObject = null;
            this.m_txtSelectTypeFonction.Size = new System.Drawing.Size(305, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeFonction.TabIndex = 11;
            this.m_txtSelectTypeFonction.TextNull = "";
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_linkStock.SetLinkField(this.label9, "");
            this.m_linkConstructeur.SetLinkField(this.label9, "");
            this.m_linkFournisseur.SetLinkField(this.label9, "");
            this.m_linkSousType.SetLinkField(this.label9, "");
            this.m_linkRemplacement.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(6, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(222, 16);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 10;
            this.label9.Text = "Associated equipment type|20065";
            // 
            // m_chkIsDotation
            // 
            this.m_linkStock.SetLinkField(this.m_chkIsDotation, "");
            this.m_linkConstructeur.SetLinkField(this.m_chkIsDotation, "");
            this.m_linkFournisseur.SetLinkField(this.m_chkIsDotation, "");
            this.m_linkRemplacement.SetLinkField(this.m_chkIsDotation, "");
            this.m_linkSousType.SetLinkField(this.m_chkIsDotation, "");
            this.m_extLinkField.SetLinkField(this.m_chkIsDotation, "IsDotationByDefault");
            this.m_chkIsDotation.Location = new System.Drawing.Point(291, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkIsDotation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkIsDotation, "");
            this.m_chkIsDotation.Name = "m_chkIsDotation";
            this.m_chkIsDotation.Size = new System.Drawing.Size(440, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkIsDotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkIsDotation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkIsDotation.TabIndex = 1;
            this.m_chkIsDotation.Text = "The Equipement of this Type are managed in Dotation mode by default|1251";
            this.m_chkIsDotation.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.m_linkStock.SetLinkField(this.checkBox1, "");
            this.m_linkConstructeur.SetLinkField(this.checkBox1, "");
            this.m_linkFournisseur.SetLinkField(this.checkBox1, "");
            this.m_linkRemplacement.SetLinkField(this.checkBox1, "");
            this.m_linkSousType.SetLinkField(this.checkBox1, "");
            this.m_extLinkField.SetLinkField(this.checkBox1, "IsAbstrait");
            this.checkBox1.Location = new System.Drawing.Point(24, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(234, 17);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "This type is abstract (no equipment)|248";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_pageEquivalences
            // 
            this.m_pageEquivalences.Controls.Add(this.m_linkShowAllParentsRelations);
            this.m_pageEquivalences.Controls.Add(this.m_lnkSupprimerRelRemplacement);
            this.m_pageEquivalences.Controls.Add(this.m_listeRelationsRemplacement);
            this.m_pageEquivalences.Controls.Add(this.m_lnkAjouterRelRemplacement);
            this.m_pageEquivalences.Controls.Add(this.m_conteneurRemplacement);
            this.m_pageEquivalences.Controls.Add(this.m_txtSelectTypeRemplacement);
            this.m_pageEquivalences.Controls.Add(this.label6);
            this.m_linkConstructeur.SetLinkField(this.m_pageEquivalences, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageEquivalences, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageEquivalences, "");
            this.m_extLinkField.SetLinkField(this.m_pageEquivalences, "");
            this.m_linkStock.SetLinkField(this.m_pageEquivalences, "");
            this.m_linkSousType.SetLinkField(this.m_pageEquivalences, "");
            this.m_pageEquivalences.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEquivalences, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEquivalences, "");
            this.m_pageEquivalences.Name = "m_pageEquivalences";
            this.m_pageEquivalences.Selected = false;
            this.m_pageEquivalences.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageEquivalences, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEquivalences, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEquivalences.TabIndex = 15;
            this.m_pageEquivalences.Title = "Equivalences|294";
            // 
            // m_linkShowAllParentsRelations
            // 
            this.m_linkShowAllParentsRelations.AutoSize = true;
            this.m_linkSousType.SetLinkField(this.m_linkShowAllParentsRelations, "");
            this.m_linkFournisseur.SetLinkField(this.m_linkShowAllParentsRelations, "");
            this.m_linkStock.SetLinkField(this.m_linkShowAllParentsRelations, "");
            this.m_linkConstructeur.SetLinkField(this.m_linkShowAllParentsRelations, "");
            this.m_extLinkField.SetLinkField(this.m_linkShowAllParentsRelations, "");
            this.m_linkRemplacement.SetLinkField(this.m_linkShowAllParentsRelations, "");
            this.m_linkShowAllParentsRelations.Location = new System.Drawing.Point(417, 41);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkShowAllParentsRelations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_linkShowAllParentsRelations, "");
            this.m_linkShowAllParentsRelations.Name = "m_linkShowAllParentsRelations";
            this.m_linkShowAllParentsRelations.Size = new System.Drawing.Size(144, 15);
            this.m_extStyle.SetStyleBackColor(this.m_linkShowAllParentsRelations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkShowAllParentsRelations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkShowAllParentsRelations.TabIndex = 6;
            this.m_linkShowAllParentsRelations.TabStop = true;
            this.m_linkShowAllParentsRelations.Text = "Show all parents Relations";
            this.m_linkShowAllParentsRelations.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkShowAllParentsRelations_LinkClicked);
            // 
            // m_lnkSupprimerRelRemplacement
            // 
            this.m_lnkSupprimerRelRemplacement.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerRelRemplacement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerRelRemplacement.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkSupprimerRelRemplacement, "");
            this.m_linkStock.SetLinkField(this.m_lnkSupprimerRelRemplacement, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkSupprimerRelRemplacement, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkSupprimerRelRemplacement, "");
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerRelRemplacement, "");
            this.m_linkSousType.SetLinkField(this.m_lnkSupprimerRelRemplacement, "");
            this.m_lnkSupprimerRelRemplacement.Location = new System.Drawing.Point(11, 347);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerRelRemplacement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerRelRemplacement, "");
            this.m_lnkSupprimerRelRemplacement.Name = "m_lnkSupprimerRelRemplacement";
            this.m_lnkSupprimerRelRemplacement.Size = new System.Drawing.Size(79, 18);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerRelRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerRelRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerRelRemplacement.TabIndex = 5;
            this.m_lnkSupprimerRelRemplacement.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerRelRemplacement.LinkClicked += new System.EventHandler(this.m_lnkSupprimerRelRemplacement_LinkClicked);
            // 
            // m_listeRelationsRemplacement
            // 
            this.m_listeRelationsRemplacement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeRelationsRemplacement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRelRemplacement});
            this.m_listeRelationsRemplacement.EnableCustomisation = true;
            this.m_listeRelationsRemplacement.FullRowSelect = true;
            this.m_listeRelationsRemplacement.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.m_listeRelationsRemplacement, "");
            this.m_linkConstructeur.SetLinkField(this.m_listeRelationsRemplacement, "");
            this.m_linkFournisseur.SetLinkField(this.m_listeRelationsRemplacement, "");
            this.m_linkSousType.SetLinkField(this.m_listeRelationsRemplacement, "");
            this.m_linkStock.SetLinkField(this.m_listeRelationsRemplacement, "");
            this.m_extLinkField.SetLinkField(this.m_listeRelationsRemplacement, "");
            this.m_listeRelationsRemplacement.Location = new System.Drawing.Point(10, 90);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeRelationsRemplacement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeRelationsRemplacement, "");
            this.m_listeRelationsRemplacement.MultiSelect = false;
            this.m_listeRelationsRemplacement.Name = "m_listeRelationsRemplacement";
            this.m_listeRelationsRemplacement.Size = new System.Drawing.Size(398, 251);
            this.m_extStyle.SetStyleBackColor(this.m_listeRelationsRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeRelationsRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeRelationsRemplacement.TabIndex = 4;
            this.m_listeRelationsRemplacement.UseCompatibleStateImageBehavior = false;
            this.m_listeRelationsRemplacement.View = System.Windows.Forms.View.Details;
            // 
            // colRelRemplacement
            // 
            this.colRelRemplacement.Field = "Libelle";
            this.colRelRemplacement.PrecisionWidth = 0;
            this.colRelRemplacement.ProportionnalSize = false;
            this.colRelRemplacement.Text = "Label|50";
            this.colRelRemplacement.Visible = true;
            this.colRelRemplacement.Width = 308;
            // 
            // m_lnkAjouterRelRemplacement
            // 
            this.m_lnkAjouterRelRemplacement.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterRelRemplacement.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_linkConstructeur.SetLinkField(this.m_lnkAjouterRelRemplacement, "");
            this.m_linkStock.SetLinkField(this.m_lnkAjouterRelRemplacement, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkAjouterRelRemplacement, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkAjouterRelRemplacement, "");
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterRelRemplacement, "");
            this.m_linkSousType.SetLinkField(this.m_lnkAjouterRelRemplacement, "");
            this.m_lnkAjouterRelRemplacement.Location = new System.Drawing.Point(55, 61);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterRelRemplacement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterRelRemplacement, "");
            this.m_lnkAjouterRelRemplacement.Name = "m_lnkAjouterRelRemplacement";
            this.m_lnkAjouterRelRemplacement.Size = new System.Drawing.Size(101, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterRelRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterRelRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterRelRemplacement.TabIndex = 3;
            this.m_lnkAjouterRelRemplacement.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterRelRemplacement.LinkClicked += new System.EventHandler(this.m_lnkAjouterRelRemplacement_LinkClicked);
            // 
            // m_conteneurRemplacement
            // 
            this.m_conteneurRemplacement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_conteneurRemplacement.Controls.Add(this.m_lblTypeEdite);
            this.m_conteneurRemplacement.Controls.Add(this.label21);
            this.m_conteneurRemplacement.Controls.Add(this.label8);
            this.m_conteneurRemplacement.Controls.Add(this.m_radSens2vers1);
            this.m_conteneurRemplacement.Controls.Add(this.m_radSensBijective);
            this.m_conteneurRemplacement.Controls.Add(this.m_radSens1vers2);
            this.m_conteneurRemplacement.Controls.Add(this.m_lblRelRemplacement);
            this.m_linkConstructeur.SetLinkField(this.m_conteneurRemplacement, "");
            this.m_linkRemplacement.SetLinkField(this.m_conteneurRemplacement, "");
            this.m_linkSousType.SetLinkField(this.m_conteneurRemplacement, "");
            this.m_extLinkField.SetLinkField(this.m_conteneurRemplacement, "");
            this.m_linkFournisseur.SetLinkField(this.m_conteneurRemplacement, "");
            this.m_linkStock.SetLinkField(this.m_conteneurRemplacement, "");
            this.m_conteneurRemplacement.Location = new System.Drawing.Point(420, 90);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_conteneurRemplacement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_conteneurRemplacement, "");
            this.m_conteneurRemplacement.Name = "m_conteneurRemplacement";
            this.m_conteneurRemplacement.Size = new System.Drawing.Size(368, 271);
            this.m_extStyle.SetStyleBackColor(this.m_conteneurRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_conteneurRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_conteneurRemplacement.TabIndex = 2;
            // 
            // m_lblTypeEdite
            // 
            this.m_lblTypeEdite.AutoSize = true;
            this.m_lblTypeEdite.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkFournisseur.SetLinkField(this.m_lblTypeEdite, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblTypeEdite, "");
            this.m_linkSousType.SetLinkField(this.m_lblTypeEdite, "");
            this.m_extLinkField.SetLinkField(this.m_lblTypeEdite, "Libelle");
            this.m_linkRemplacement.SetLinkField(this.m_lblTypeEdite, "");
            this.m_linkStock.SetLinkField(this.m_lblTypeEdite, "");
            this.m_lblTypeEdite.Location = new System.Drawing.Point(143, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTypeEdite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblTypeEdite, "");
            this.m_lblTypeEdite.Name = "m_lblTypeEdite";
            this.m_lblTypeEdite.Size = new System.Drawing.Size(87, 25);
            this.m_extStyle.SetStyleBackColor(this.m_lblTypeEdite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTypeEdite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeEdite.TabIndex = 5;
            this.m_lblTypeEdite.Text = "[Libelle]";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label21, "");
            this.m_linkFournisseur.SetLinkField(this.label21, "");
            this.m_linkStock.SetLinkField(this.label21, "");
            this.m_linkSousType.SetLinkField(this.label21, "");
            this.m_linkRemplacement.SetLinkField(this.label21, "");
            this.m_linkConstructeur.SetLinkField(this.label21, "");
            this.label21.Location = new System.Drawing.Point(11, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label21, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label21, "");
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(125, 25);
            this.m_extStyle.SetStyleBackColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label21.TabIndex = 4;
            this.label21.Text = "Type B:|302";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_linkFournisseur.SetLinkField(this.label8, "");
            this.m_linkStock.SetLinkField(this.label8, "");
            this.m_linkSousType.SetLinkField(this.label8, "");
            this.m_linkRemplacement.SetLinkField(this.label8, "");
            this.m_linkConstructeur.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(11, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(125, 25);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4;
            this.label8.Text = "Type A:|301";
            // 
            // m_radSens2vers1
            // 
            this.m_radSens2vers1.AutoSize = true;
            this.m_radSens2vers1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_linkRemplacement.SetLinkField(this.m_radSens2vers1, "");
            this.m_linkFournisseur.SetLinkField(this.m_radSens2vers1, "");
            this.m_linkStock.SetLinkField(this.m_radSens2vers1, "");
            this.m_linkConstructeur.SetLinkField(this.m_radSens2vers1, "");
            this.m_linkSousType.SetLinkField(this.m_radSens2vers1, "");
            this.m_extLinkField.SetLinkField(this.m_radSens2vers1, "");
            this.m_radSens2vers1.Location = new System.Drawing.Point(16, 126);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radSens2vers1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radSens2vers1, "");
            this.m_radSens2vers1.Name = "m_radSens2vers1";
            this.m_radSens2vers1.Size = new System.Drawing.Size(105, 19);
            this.m_extStyle.SetStyleBackColor(this.m_radSens2vers1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radSens2vers1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radSens2vers1.TabIndex = 3;
            this.m_radSens2vers1.TabStop = true;
            this.m_radSens2vers1.Text = "A can replace B";
            this.m_radSens2vers1.UseVisualStyleBackColor = true;
            // 
            // m_radSensBijective
            // 
            this.m_radSensBijective.AutoSize = true;
            this.m_radSensBijective.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_linkRemplacement.SetLinkField(this.m_radSensBijective, "");
            this.m_linkFournisseur.SetLinkField(this.m_radSensBijective, "");
            this.m_linkStock.SetLinkField(this.m_radSensBijective, "");
            this.m_linkConstructeur.SetLinkField(this.m_radSensBijective, "");
            this.m_linkSousType.SetLinkField(this.m_radSensBijective, "");
            this.m_extLinkField.SetLinkField(this.m_radSensBijective, "");
            this.m_radSensBijective.Location = new System.Drawing.Point(16, 103);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radSensBijective, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radSensBijective, "");
            this.m_radSensBijective.Name = "m_radSensBijective";
            this.m_radSensBijective.Size = new System.Drawing.Size(146, 19);
            this.m_extStyle.SetStyleBackColor(this.m_radSensBijective, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radSensBijective, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radSensBijective.TabIndex = 2;
            this.m_radSensBijective.TabStop = true;
            this.m_radSensBijective.Text = "A and B can be swaped";
            this.m_radSensBijective.UseVisualStyleBackColor = true;
            // 
            // m_radSens1vers2
            // 
            this.m_radSens1vers2.AutoSize = true;
            this.m_radSens1vers2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_linkRemplacement.SetLinkField(this.m_radSens1vers2, "");
            this.m_linkFournisseur.SetLinkField(this.m_radSens1vers2, "");
            this.m_linkStock.SetLinkField(this.m_radSens1vers2, "");
            this.m_linkConstructeur.SetLinkField(this.m_radSens1vers2, "");
            this.m_linkSousType.SetLinkField(this.m_radSens1vers2, "");
            this.m_extLinkField.SetLinkField(this.m_radSens1vers2, "");
            this.m_radSens1vers2.Location = new System.Drawing.Point(16, 80);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radSens1vers2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radSens1vers2, "");
            this.m_radSens1vers2.Name = "m_radSens1vers2";
            this.m_radSens1vers2.Size = new System.Drawing.Size(153, 19);
            this.m_extStyle.SetStyleBackColor(this.m_radSens1vers2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radSens1vers2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radSens1vers2.TabIndex = 1;
            this.m_radSens1vers2.TabStop = true;
            this.m_radSens1vers2.Text = "A can be subtituted by B";
            this.m_radSens1vers2.UseVisualStyleBackColor = true;
            // 
            // m_lblRelRemplacement
            // 
            this.m_lblRelRemplacement.AutoSize = true;
            this.m_lblRelRemplacement.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_linkFournisseur.SetLinkField(this.m_lblRelRemplacement, "");
            this.m_extLinkField.SetLinkField(this.m_lblRelRemplacement, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblRelRemplacement, "");
            this.m_linkSousType.SetLinkField(this.m_lblRelRemplacement, "");
            this.m_linkStock.SetLinkField(this.m_lblRelRemplacement, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblRelRemplacement, "TypeLie.Libelle");
            this.m_lblRelRemplacement.Location = new System.Drawing.Point(143, 46);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblRelRemplacement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblRelRemplacement, "");
            this.m_lblRelRemplacement.Name = "m_lblRelRemplacement";
            this.m_lblRelRemplacement.Size = new System.Drawing.Size(164, 25);
            this.m_extStyle.SetStyleBackColor(this.m_lblRelRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblRelRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblRelRemplacement.TabIndex = 0;
            this.m_lblRelRemplacement.Text = "[TypeLie.Libelle]";
            // 
            // m_txtSelectTypeRemplacement
            // 
            this.m_txtSelectTypeRemplacement.ElementSelectionne = null;
            this.m_txtSelectTypeRemplacement.FonctionTextNull = null;
            this.m_txtSelectTypeRemplacement.HasLink = true;
            this.m_linkFournisseur.SetLinkField(this.m_txtSelectTypeRemplacement, "");
            this.m_linkSousType.SetLinkField(this.m_txtSelectTypeRemplacement, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtSelectTypeRemplacement, "");
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeRemplacement, "");
            this.m_linkConstructeur.SetLinkField(this.m_txtSelectTypeRemplacement, "");
            this.m_linkStock.SetLinkField(this.m_txtSelectTypeRemplacement, "");
            this.m_txtSelectTypeRemplacement.Location = new System.Drawing.Point(55, 37);
            this.m_txtSelectTypeRemplacement.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeRemplacement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeRemplacement, "");
            this.m_txtSelectTypeRemplacement.Name = "m_txtSelectTypeRemplacement";
            this.m_txtSelectTypeRemplacement.SelectedObject = null;
            this.m_txtSelectTypeRemplacement.Size = new System.Drawing.Size(329, 18);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeRemplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeRemplacement.TabIndex = 1;
            this.m_txtSelectTypeRemplacement.TextNull = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_linkFournisseur.SetLinkField(this.label6, "");
            this.m_linkStock.SetLinkField(this.label6, "");
            this.m_linkSousType.SetLinkField(this.label6, "");
            this.m_linkRemplacement.SetLinkField(this.label6, "");
            this.m_linkConstructeur.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(53, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(202, 15);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "Select an Equipment Type to add|295";
            // 
            // m_pageOptions
            // 
            this.m_pageOptions.Controls.Add(this.m_panelOccupation);
            this.m_pageOptions.Controls.Add(this.m_panelSystemeCoordonnees);
            this.m_pageOptions.Controls.Add(this.m_panelOptionsControle);
            this.m_linkConstructeur.SetLinkField(this.m_pageOptions, "");
            this.m_linkFournisseur.SetLinkField(this.m_pageOptions, "");
            this.m_linkRemplacement.SetLinkField(this.m_pageOptions, "");
            this.m_linkSousType.SetLinkField(this.m_pageOptions, "");
            this.m_linkStock.SetLinkField(this.m_pageOptions, "");
            this.m_extLinkField.SetLinkField(this.m_pageOptions, "");
            this.m_pageOptions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageOptions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageOptions, "ASYS_COOR");
            this.m_pageOptions.Name = "m_pageOptions";
            this.m_pageOptions.Selected = false;
            this.m_pageOptions.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageOptions.TabIndex = 16;
            this.m_pageOptions.Title = "Options|30036";
            // 
            // m_panelOccupation
            // 
            this.m_panelOccupation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOccupation.Controls.Add(this.m_panelParametrage);
            this.m_panelOccupation.ForeColor = System.Drawing.Color.Black;
            this.m_linkConstructeur.SetLinkField(this.m_panelOccupation, "");
            this.m_linkStock.SetLinkField(this.m_panelOccupation, "");
            this.m_linkSousType.SetLinkField(this.m_panelOccupation, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelOccupation, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelOccupation, "");
            this.m_extLinkField.SetLinkField(this.m_panelOccupation, "");
            this.m_panelOccupation.Location = new System.Drawing.Point(3, 269);
            this.m_panelOccupation.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOccupation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelOccupation, "");
            this.m_panelOccupation.Name = "m_panelOccupation";
            this.m_panelOccupation.Size = new System.Drawing.Size(506, 103);
            this.m_extStyle.SetStyleBackColor(this.m_panelOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOccupation.TabIndex = 4013;
            // 
            // m_panelParametrage
            // 
            this.m_panelParametrage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelParametrage, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelParametrage, "");
            this.m_linkStock.SetLinkField(this.m_panelParametrage, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelParametrage, "");
            this.m_linkConstructeur.SetLinkField(this.m_panelParametrage, "");
            this.m_linkSousType.SetLinkField(this.m_panelParametrage, "");
            this.m_panelParametrage.Location = new System.Drawing.Point(0, 0);
            this.m_panelParametrage.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParametrage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelParametrage, "");
            this.m_panelParametrage.Name = "m_panelParametrage";
            this.m_panelParametrage.Size = new System.Drawing.Size(506, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelParametrage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelParametrage.TabIndex = 10;
            // 
            // m_panelSystemeCoordonnees
            // 
            this.m_panelSystemeCoordonnees.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelSystemeCoordonnees.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_linkConstructeur.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_linkStock.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_linkSousType.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_extLinkField.SetLinkField(this.m_panelSystemeCoordonnees, "");
            this.m_panelSystemeCoordonnees.Location = new System.Drawing.Point(0, 102);
            this.m_panelSystemeCoordonnees.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSystemeCoordonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSystemeCoordonnees, "");
            this.m_panelSystemeCoordonnees.Name = "m_panelSystemeCoordonnees";
            this.m_panelSystemeCoordonnees.Size = new System.Drawing.Size(798, 161);
            this.m_extStyle.SetStyleBackColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSystemeCoordonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSystemeCoordonnees.TabIndex = 4011;
            // 
            // m_panelOptionsControle
            // 
            this.m_panelOptionsControle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOptionsControle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelOptionsControle.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelOptionsControle.ForeColor = System.Drawing.Color.Black;
            this.m_linkConstructeur.SetLinkField(this.m_panelOptionsControle, "");
            this.m_linkStock.SetLinkField(this.m_panelOptionsControle, "");
            this.m_linkSousType.SetLinkField(this.m_panelOptionsControle, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelOptionsControle, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelOptionsControle, "");
            this.m_extLinkField.SetLinkField(this.m_panelOptionsControle, "");
            this.m_panelOptionsControle.Location = new System.Drawing.Point(0, 0);
            this.m_panelOptionsControle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelOptionsControle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelOptionsControle, "");
            this.m_panelOptionsControle.Name = "m_panelOptionsControle";
            this.m_panelOptionsControle.Size = new System.Drawing.Size(798, 102);
            this.m_extStyle.SetStyleBackColor(this.m_panelOptionsControle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOptionsControle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOptionsControle.TabIndex = 4012;
            // 
            // m_pagePorts
            // 
            this.m_pagePorts.Controls.Add(this.m_splitContainerPorts);
            this.m_linkConstructeur.SetLinkField(this.m_pagePorts, "");
            this.m_linkFournisseur.SetLinkField(this.m_pagePorts, "");
            this.m_linkRemplacement.SetLinkField(this.m_pagePorts, "");
            this.m_extLinkField.SetLinkField(this.m_pagePorts, "");
            this.m_linkStock.SetLinkField(this.m_pagePorts, "");
            this.m_linkSousType.SetLinkField(this.m_pagePorts, "");
            this.m_pagePorts.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePorts, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePorts, "");
            this.m_pagePorts.Name = "m_pagePorts";
            this.m_pagePorts.Selected = false;
            this.m_pagePorts.Size = new System.Drawing.Size(798, 375);
            this.m_extStyle.SetStyleBackColor(this.m_pagePorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePorts.TabIndex = 20;
            this.m_pagePorts.Title = "Ports|30040";
            // 
            // m_splitContainerPorts
            // 
            this.m_splitContainerPorts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_linkRemplacement.SetLinkField(this.m_splitContainerPorts, "");
            this.m_linkStock.SetLinkField(this.m_splitContainerPorts, "");
            this.m_linkFournisseur.SetLinkField(this.m_splitContainerPorts, "");
            this.m_extLinkField.SetLinkField(this.m_splitContainerPorts, "");
            this.m_linkConstructeur.SetLinkField(this.m_splitContainerPorts, "");
            this.m_linkSousType.SetLinkField(this.m_splitContainerPorts, "");
            this.m_splitContainerPorts.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainerPorts, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainerPorts, "");
            this.m_splitContainerPorts.Name = "m_splitContainerPorts";
            this.m_splitContainerPorts.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // m_splitContainerPorts.Panel1
            // 
            this.m_splitContainerPorts.Panel1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.m_splitContainerPorts.Panel1.Controls.Add(this.m_linkEditPorts);
            this.m_splitContainerPorts.Panel1.Controls.Add(this.m_panelSymbole);
            this.m_linkStock.SetLinkField(this.m_splitContainerPorts.Panel1, "");
            this.m_linkRemplacement.SetLinkField(this.m_splitContainerPorts.Panel1, "");
            this.m_linkConstructeur.SetLinkField(this.m_splitContainerPorts.Panel1, "");
            this.m_linkSousType.SetLinkField(this.m_splitContainerPorts.Panel1, "");
            this.m_linkFournisseur.SetLinkField(this.m_splitContainerPorts.Panel1, "");
            this.m_extLinkField.SetLinkField(this.m_splitContainerPorts.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainerPorts.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainerPorts.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerPorts.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerPorts.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainerPorts.Panel2
            // 
            this.m_splitContainerPorts.Panel2.Controls.Add(this.m_panelListePorts);
            this.m_linkFournisseur.SetLinkField(this.m_splitContainerPorts.Panel2, "");
            this.m_linkConstructeur.SetLinkField(this.m_splitContainerPorts.Panel2, "");
            this.m_linkStock.SetLinkField(this.m_splitContainerPorts.Panel2, "");
            this.m_linkRemplacement.SetLinkField(this.m_splitContainerPorts.Panel2, "");
            this.m_extLinkField.SetLinkField(this.m_splitContainerPorts.Panel2, "");
            this.m_linkSousType.SetLinkField(this.m_splitContainerPorts.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainerPorts.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainerPorts.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerPorts.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerPorts.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerPorts.Size = new System.Drawing.Size(792, 369);
            this.m_splitContainerPorts.SplitterDistance = 171;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainerPorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainerPorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainerPorts.TabIndex = 3;
            // 
            // m_linkEditPorts
            // 
            this.m_linkEditPorts.AutoSize = true;
            this.m_linkSousType.SetLinkField(this.m_linkEditPorts, "");
            this.m_linkFournisseur.SetLinkField(this.m_linkEditPorts, "");
            this.m_linkStock.SetLinkField(this.m_linkEditPorts, "");
            this.m_linkConstructeur.SetLinkField(this.m_linkEditPorts, "");
            this.m_extLinkField.SetLinkField(this.m_linkEditPorts, "");
            this.m_linkRemplacement.SetLinkField(this.m_linkEditPorts, "");
            this.m_linkEditPorts.Location = new System.Drawing.Point(205, 102);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_linkEditPorts, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_linkEditPorts, "");
            this.m_linkEditPorts.Name = "m_linkEditPorts";
            this.m_linkEditPorts.Size = new System.Drawing.Size(131, 15);
            this.m_extStyle.SetStyleBackColor(this.m_linkEditPorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_linkEditPorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_linkEditPorts.TabIndex = 2;
            this.m_linkEditPorts.TabStop = true;
            this.m_linkEditPorts.Text = "Edit Port position|30341";
            this.m_linkEditPorts.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_linkEditPorts_LinkClicked);
            // 
            // m_panelSymbole
            // 
            this.m_panelSymbole.AutoSize = true;
            this.m_panelSymbole.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_panelSymbole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_linkFournisseur.SetLinkField(this.m_panelSymbole, "");
            this.m_extLinkField.SetLinkField(this.m_panelSymbole, "");
            this.m_linkConstructeur.SetLinkField(this.m_panelSymbole, "");
            this.m_linkSousType.SetLinkField(this.m_panelSymbole, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelSymbole, "");
            this.m_linkStock.SetLinkField(this.m_panelSymbole, "");
            this.m_panelSymbole.Location = new System.Drawing.Point(0, 0);
            this.m_panelSymbole.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSymbole, "");
            this.m_panelSymbole.Name = "m_panelSymbole";
            this.m_panelSymbole.Size = new System.Drawing.Size(792, 171);
            this.m_extStyle.SetStyleBackColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSymbole.TabIndex = 1;
            // 
            // m_panelListePorts
            // 
            this.m_panelListePorts.AllowArbre = true;
            this.m_panelListePorts.AllowCustomisation = true;
            this.m_panelListePorts.AutoSize = true;
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "ColLibelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelListePorts.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListePorts.ContexteUtilisation = "";
            this.m_panelListePorts.ControlFiltreStandard = null;
            this.m_panelListePorts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListePorts.ElementSelectionne = null;
            this.m_panelListePorts.EnableCustomisation = true;
            this.m_panelListePorts.FiltreDeBase = null;
            this.m_panelListePorts.FiltreDeBaseEnAjout = false;
            this.m_panelListePorts.FiltrePrefere = null;
            this.m_panelListePorts.FiltreRapide = null;
            this.m_panelListePorts.HasImages = false;
            this.m_linkStock.SetLinkField(this.m_panelListePorts, "");
            this.m_linkConstructeur.SetLinkField(this.m_panelListePorts, "");
            this.m_linkRemplacement.SetLinkField(this.m_panelListePorts, "");
            this.m_linkFournisseur.SetLinkField(this.m_panelListePorts, "");
            this.m_extLinkField.SetLinkField(this.m_panelListePorts, "");
            this.m_linkSousType.SetLinkField(this.m_panelListePorts, "");
            this.m_panelListePorts.ListeObjets = null;
            this.m_panelListePorts.Location = new System.Drawing.Point(0, 0);
            this.m_panelListePorts.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListePorts, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListePorts.ModeQuickSearch = false;
            this.m_panelListePorts.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListePorts, "");
            this.m_panelListePorts.MultiSelect = true;
            this.m_panelListePorts.Name = "m_panelListePorts";
            this.m_panelListePorts.Navigateur = null;
            this.m_panelListePorts.ProprieteObjetAEditer = null;
            this.m_panelListePorts.QuickSearchText = "";
            this.m_panelListePorts.Size = new System.Drawing.Size(792, 194);
            this.m_extStyle.SetStyleBackColor(this.m_panelListePorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListePorts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListePorts.TabIndex = 0;
            this.m_panelListePorts.TrierAuClicSurEnteteColonne = true;
            this.m_panelListePorts.UseCheckBoxes = false;
            // 
            // m_wndListeRestrictionsSurChamp
            // 
            this.m_wndListeRestrictionsSurChamp.CheckBoxes = true;
            this.m_wndListeRestrictionsSurChamp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn3});
            this.m_wndListeRestrictionsSurChamp.EnableCustomisation = true;
            this.m_wndListeRestrictionsSurChamp.FullRowSelect = true;
            this.m_wndListeRestrictionsSurChamp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_linkRemplacement.SetLinkField(this.m_wndListeRestrictionsSurChamp, "");
            this.m_linkConstructeur.SetLinkField(this.m_wndListeRestrictionsSurChamp, "");
            this.m_linkFournisseur.SetLinkField(this.m_wndListeRestrictionsSurChamp, "");
            this.m_linkSousType.SetLinkField(this.m_wndListeRestrictionsSurChamp, "");
            this.m_linkStock.SetLinkField(this.m_wndListeRestrictionsSurChamp, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeRestrictionsSurChamp, "");
            this.m_wndListeRestrictionsSurChamp.Location = new System.Drawing.Point(8, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeRestrictionsSurChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeRestrictionsSurChamp, "");
            this.m_wndListeRestrictionsSurChamp.MultiSelect = false;
            this.m_wndListeRestrictionsSurChamp.Name = "m_wndListeRestrictionsSurChamp";
            this.m_wndListeRestrictionsSurChamp.Size = new System.Drawing.Size(216, 232);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeRestrictionsSurChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeRestrictionsSurChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeRestrictionsSurChamp.TabIndex = 3;
            this.m_wndListeRestrictionsSurChamp.UseCompatibleStateImageBehavior = false;
            this.m_wndListeRestrictionsSurChamp.View = System.Windows.Forms.View.Details;
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
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_comboFamille);
            this.m_panTop.Controls.Add(this.m_txtNom);
            this.m_panTop.Controls.Add(this.m_lblLabel);
            this.m_panTop.Controls.Add(this.c2iTextBox3);
            this.m_panTop.Controls.Add(this.m_lblMnemonic);
            this.m_panTop.Controls.Add(this.m_lnkFamilles);
            this.m_panTop.Controls.Add(this.c2iTextBox2);
            this.m_panTop.Controls.Add(this.m_lblCodeInterne);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_linkFournisseur.SetLinkField(this.m_panTop, "");
            this.m_linkStock.SetLinkField(this.m_panTop, "");
            this.m_linkRemplacement.SetLinkField(this.m_panTop, "");
            this.m_linkConstructeur.SetLinkField(this.m_panTop, "");
            this.m_linkSousType.SetLinkField(this.m_panTop, "");
            this.m_panTop.Location = new System.Drawing.Point(16, 32);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(814, 88);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_comboFamille
            // 
            this.m_comboFamille.BackColor = System.Drawing.Color.White;
            this.m_comboFamille.ElementSelectionne = null;
            this.m_linkStock.SetLinkField(this.m_comboFamille, "");
            this.m_linkFournisseur.SetLinkField(this.m_comboFamille, "");
            this.m_linkConstructeur.SetLinkField(this.m_comboFamille, "");
            this.m_linkSousType.SetLinkField(this.m_comboFamille, "");
            this.m_linkRemplacement.SetLinkField(this.m_comboFamille, "");
            this.m_extLinkField.SetLinkField(this.m_comboFamille, "");
            this.m_comboFamille.Location = new System.Drawing.Point(80, 38);
            this.m_comboFamille.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_comboFamille, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_comboFamille, "");
            this.m_comboFamille.Name = "m_comboFamille";
            this.m_comboFamille.NullAutorise = false;
            this.m_comboFamille.Size = new System.Drawing.Size(328, 21);
            this.m_extStyle.SetStyleBackColor(this.m_comboFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_comboFamille, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_comboFamille.TabIndex = 3;
            this.m_comboFamille.TextNull = "[None]";
            this.m_comboFamille.ElementSelectionneChanged += new System.EventHandler(this.m_comboFamille_ElementSelectionneChanged);
            // 
            // m_txtNom
            // 
            this.m_linkFournisseur.SetLinkField(this.m_txtNom, "");
            this.m_linkStock.SetLinkField(this.m_txtNom, "");
            this.m_linkRemplacement.SetLinkField(this.m_txtNom, "");
            this.m_extLinkField.SetLinkField(this.m_txtNom, "Libelle");
            this.m_linkConstructeur.SetLinkField(this.m_txtNom, "");
            this.m_linkSousType.SetLinkField(this.m_txtNom, "");
            this.m_txtNom.Location = new System.Drawing.Point(80, 12);
            this.m_txtNom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtNom, "");
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(328, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNom.TabIndex = 0;
            this.m_txtNom.Text = "[Libelle]";
            this.m_txtNom.TextChanged += new System.EventHandler(this.m_txtNom_TextChanged);
            // 
            // m_lblLabel
            // 
            this.m_extLinkField.SetLinkField(this.m_lblLabel, "");
            this.m_linkFournisseur.SetLinkField(this.m_lblLabel, "");
            this.m_linkStock.SetLinkField(this.m_lblLabel, "");
            this.m_linkSousType.SetLinkField(this.m_lblLabel, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblLabel, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblLabel, "");
            this.m_lblLabel.Location = new System.Drawing.Point(7, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLabel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLabel, "");
            this.m_lblLabel.Name = "m_lblLabel";
            this.m_lblLabel.Size = new System.Drawing.Size(67, 12);
            this.m_extStyle.SetStyleBackColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLabel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLabel.TabIndex = 4009;
            this.m_lblLabel.Text = "Label|50";
            // 
            // c2iTextBox3
            // 
            this.m_linkFournisseur.SetLinkField(this.c2iTextBox3, "");
            this.m_linkStock.SetLinkField(this.c2iTextBox3, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBox3, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBox3, "Mnemonique");
            this.m_linkConstructeur.SetLinkField(this.c2iTextBox3, "");
            this.m_linkSousType.SetLinkField(this.c2iTextBox3, "");
            this.c2iTextBox3.Location = new System.Drawing.Point(525, 39);
            this.c2iTextBox3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox3, "");
            this.c2iTextBox3.Name = "c2iTextBox3";
            this.c2iTextBox3.Size = new System.Drawing.Size(257, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox3.TabIndex = 2;
            this.c2iTextBox3.Text = "[Mnemonique]";
            // 
            // m_lblMnemonic
            // 
            this.m_extLinkField.SetLinkField(this.m_lblMnemonic, "");
            this.m_linkFournisseur.SetLinkField(this.m_lblMnemonic, "");
            this.m_linkStock.SetLinkField(this.m_lblMnemonic, "");
            this.m_linkSousType.SetLinkField(this.m_lblMnemonic, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblMnemonic, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblMnemonic, "");
            this.m_lblMnemonic.Location = new System.Drawing.Point(430, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblMnemonic, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblMnemonic, "");
            this.m_lblMnemonic.Name = "m_lblMnemonic";
            this.m_lblMnemonic.Size = new System.Drawing.Size(89, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblMnemonic, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMnemonic, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMnemonic.TabIndex = 9;
            this.m_lblMnemonic.Text = "Mnemonic|222";
            // 
            // m_lnkFamilles
            // 
            this.m_lnkFamilles.ForeColor = System.Drawing.Color.Black;
            this.m_linkSousType.SetLinkField(this.m_lnkFamilles, "");
            this.m_linkFournisseur.SetLinkField(this.m_lnkFamilles, "");
            this.m_linkStock.SetLinkField(this.m_lnkFamilles, "");
            this.m_linkConstructeur.SetLinkField(this.m_lnkFamilles, "");
            this.m_extLinkField.SetLinkField(this.m_lnkFamilles, "");
            this.m_linkRemplacement.SetLinkField(this.m_lnkFamilles, "");
            this.m_lnkFamilles.Location = new System.Drawing.Point(7, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkFamilles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkFamilles, "");
            this.m_lnkFamilles.Name = "m_lnkFamilles";
            this.m_lnkFamilles.Size = new System.Drawing.Size(67, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkFamilles, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_lnkFamilles.TabIndex = 4012;
            this.m_lnkFamilles.TabStop = true;
            this.m_lnkFamilles.Text = "Family|197";
            this.m_lnkFamilles.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkFamilles_LinkClicked);
            // 
            // c2iTextBox2
            // 
            this.m_linkConstructeur.SetLinkField(this.c2iTextBox2, "");
            this.m_linkRemplacement.SetLinkField(this.c2iTextBox2, "");
            this.m_linkStock.SetLinkField(this.c2iTextBox2, "");
            this.m_linkFournisseur.SetLinkField(this.c2iTextBox2, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBox2, "Code");
            this.m_linkSousType.SetLinkField(this.c2iTextBox2, "");
            this.c2iTextBox2.Location = new System.Drawing.Point(525, 12);
            this.c2iTextBox2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox2, "");
            this.c2iTextBox2.Name = "c2iTextBox2";
            this.c2iTextBox2.Size = new System.Drawing.Size(257, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox2.TabIndex = 1;
            this.c2iTextBox2.Text = "[Code]";
            // 
            // m_lblCodeInterne
            // 
            this.m_extLinkField.SetLinkField(this.m_lblCodeInterne, "");
            this.m_linkFournisseur.SetLinkField(this.m_lblCodeInterne, "");
            this.m_linkStock.SetLinkField(this.m_lblCodeInterne, "");
            this.m_linkSousType.SetLinkField(this.m_lblCodeInterne, "");
            this.m_linkRemplacement.SetLinkField(this.m_lblCodeInterne, "");
            this.m_linkConstructeur.SetLinkField(this.m_lblCodeInterne, "");
            this.m_lblCodeInterne.Location = new System.Drawing.Point(430, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCodeInterne, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblCodeInterne, "");
            this.m_lblCodeInterne.Name = "m_lblCodeInterne";
            this.m_lblCodeInterne.Size = new System.Drawing.Size(89, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblCodeInterne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblCodeInterne, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCodeInterne.TabIndex = 7;
            this.m_lblCodeInterne.Text = "Internal code|221";
            // 
            // listViewAutoFilled1
            // 
            this.listViewAutoFilled1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.listViewAutoFilled1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn9});
            this.listViewAutoFilled1.EnableCustomisation = true;
            this.listViewAutoFilled1.FullRowSelect = true;
            this.listViewAutoFilled1.HideSelection = false;
            this.m_linkRemplacement.SetLinkField(this.listViewAutoFilled1, "");
            this.m_linkConstructeur.SetLinkField(this.listViewAutoFilled1, "");
            this.m_linkFournisseur.SetLinkField(this.listViewAutoFilled1, "");
            this.m_linkSousType.SetLinkField(this.listViewAutoFilled1, "");
            this.m_linkStock.SetLinkField(this.listViewAutoFilled1, "");
            this.m_extLinkField.SetLinkField(this.listViewAutoFilled1, "");
            this.listViewAutoFilled1.Location = new System.Drawing.Point(11, 51);
            this.m_gestionnaireModeEdition.SetModeEdition(this.listViewAutoFilled1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.listViewAutoFilled1, "");
            this.listViewAutoFilled1.MultiSelect = false;
            this.listViewAutoFilled1.Name = "listViewAutoFilled1";
            this.listViewAutoFilled1.Size = new System.Drawing.Size(297, 406);
            this.m_extStyle.SetStyleBackColor(this.listViewAutoFilled1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.listViewAutoFilled1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.listViewAutoFilled1.TabIndex = 2;
            this.listViewAutoFilled1.UseCompatibleStateImageBehavior = false;
            this.listViewAutoFilled1.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn9
            // 
            this.listViewAutoFilledColumn9.Field = "Fournisseur.Acteur.Libelle";
            this.listViewAutoFilledColumn9.PrecisionWidth = 0;
            this.listViewAutoFilledColumn9.ProportionnalSize = false;
            this.listViewAutoFilledColumn9.Text = "Label|50";
            this.listViewAutoFilledColumn9.Visible = true;
            this.listViewAutoFilledColumn9.Width = 200;
            // 
            // m_timerMAJOnglets
            // 
            this.m_timerMAJOnglets.Interval = 300;
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
            // listViewColumn6
            // 
            this.listViewColumn6.Field = "Nom";
            this.listViewColumn6.PrecisionWidth = 0;
            this.listViewColumn6.ProportionnalSize = false;
            this.listViewColumn6.Text = "Name|164";
            this.listViewColumn6.Visible = true;
            this.listViewColumn6.Width = 156;
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
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 312;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_linkFournisseur.SetLinkField(this.label1, "");
            this.m_linkStock.SetLinkField(this.label1, "");
            this.m_linkSousType.SetLinkField(this.label1, "");
            this.m_linkRemplacement.SetLinkField(this.label1, "");
            this.m_linkConstructeur.SetLinkField(this.label1, "");
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
            // m_gestionnaireEditionFournisseurs
            // 
            this.m_gestionnaireEditionFournisseurs.ListeAssociee = this.m_wndListeFournisseurs;
            this.m_gestionnaireEditionFournisseurs.ObjetEdite = null;
            this.m_gestionnaireEditionFournisseurs.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionFournisseurs_InitChamp);
            this.m_gestionnaireEditionFournisseurs.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionFournisseurs_MAJ_Champs);
            // 
            // m_gestionnaireEditionStock
            // 
            this.m_gestionnaireEditionStock.ListeAssociee = this.m_wndListeTypesStocks;
            this.m_gestionnaireEditionStock.ObjetEdite = null;
            this.m_gestionnaireEditionStock.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionStock_InitChamp);
            this.m_gestionnaireEditionStock.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionStock_MAJ_Champs);
            // 
            // m_gestionnaireTypesInclus
            // 
            this.m_gestionnaireTypesInclus.ListeAssociee = this.m_wndListeEquipementsInclus;
            this.m_gestionnaireTypesInclus.ObjetEdite = null;
            this.m_gestionnaireTypesInclus.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTypesInclus_InitChamp);
            this.m_gestionnaireTypesInclus.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionTypesInclus_MAJ_Champs);
            // 
            // m_gestionEditionTypeDonnateur
            // 
            this.m_gestionEditionTypeDonnateur.ListeAssociee = this.m_wndListeTypeDonnateurs;
            this.m_gestionEditionTypeDonnateur.ObjetEdite = null;
            this.m_gestionEditionTypeDonnateur.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionEditionTypeDonnateur_InitChamp);
            this.m_gestionEditionTypeDonnateur.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionEditionTypeDonnateur_MAJ_Champs);
            // 
            // m_gestionnaireTypesIncluant
            // 
            this.m_gestionnaireTypesIncluant.ListeAssociee = this.m_wndListeEquipementsIncluants;
            this.m_gestionnaireTypesIncluant.ObjetEdite = null;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Label|50";
            // 
            // m_gestionRelationsRemplacement
            // 
            this.m_gestionRelationsRemplacement.ListeAssociee = this.m_listeRelationsRemplacement;
            this.m_gestionRelationsRemplacement.ObjetEdite = null;
            this.m_gestionRelationsRemplacement.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionRelationsRemplacement_InitChamp);
            this.m_gestionRelationsRemplacement.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionRelationsRemplacement_MAJ_Champs);
            // 
            // m_gestionEditionParametrageNiveau
            // 
            this.m_gestionEditionParametrageNiveau.ObjetEdite = null;
            // 
            // m_gestionnaireEditionConstructeurs
            // 
            this.m_gestionnaireEditionConstructeurs.ListeAssociee = this.m_wndListeConstructeurs;
            this.m_gestionnaireEditionConstructeurs.ObjetEdite = null;
            this.m_gestionnaireEditionConstructeurs.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionConstructeurs_InitChamp);
            this.m_gestionnaireEditionConstructeurs.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionConstructeurs_MAJ_Champs);
            // 
            // CFormEditionTypeEquipement
            // 
            this.ClientSize = new System.Drawing.Size(830, 540);
            this.Controls.Add(this.m_panTop);
            this.Controls.Add(this.m_tabControl);
            this.m_linkRemplacement.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_linkSousType.SetLinkField(this, "");
            this.m_linkStock.SetLinkField(this, "");
            this.m_linkConstructeur.SetLinkField(this, "");
            this.m_linkFournisseur.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeEquipement";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEquipement_OnInitPage);
            this.Load += new System.EventHandler(this.CFormEditionTypeEquipement_Load);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEquipement_OnMajChampsPage);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormEditionTypeEquipement_Closing);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageTablesParametrables.ResumeLayout(false);
            this.m_pageFiche.ResumeLayout(false);
            this.m_pageFabricant.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.m_panelConstructeur.ResumeLayout(false);
            this.m_panelConstructeur.PerformLayout();
            this.m_pageFournisseurs.ResumeLayout(false);
            this.m_pageFournisseurs.PerformLayout();
            this.m_panelFournisseur.ResumeLayout(false);
            this.m_panelFournisseur.PerformLayout();
            this.m_pageComportementStock.ResumeLayout(false);
            this.m_pageComportementStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.m_panelStock.ResumeLayout(false);
            this.m_panelStock.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.m_pagePeutInclure.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.m_pageEOs.ResumeLayout(false);
            this.m_pageInstallation.ResumeLayout(false);
            this.m_tabParametreEquipements.ResumeLayout(false);
            this.m_tabParametreEquipements.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.m_pageEquivalences.ResumeLayout(false);
            this.m_pageEquivalences.PerformLayout();
            this.m_conteneurRemplacement.ResumeLayout(false);
            this.m_conteneurRemplacement.PerformLayout();
            this.m_pageOptions.ResumeLayout(false);
            this.m_panelOccupation.ResumeLayout(false);
            this.m_pagePorts.ResumeLayout(false);
            this.m_splitContainerPorts.Panel1.ResumeLayout(false);
            this.m_splitContainerPorts.Panel1.PerformLayout();
            this.m_splitContainerPorts.Panel2.ResumeLayout(false);
            this.m_splitContainerPorts.Panel2.PerformLayout();
            this.m_splitContainerPorts.ResumeLayout(false);
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

       



		//-------------------------------------------------------------------------
		public CFormEditionTypeEquipement()
			: base()
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEquipement(CTypeEquipement groupe)
			: base(groupe)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeEquipement(CTypeEquipement groupe, CListeObjetsDonnees liste)
			: base(groupe, liste)
		{
			InitializeComponent();
		}
		//-------------------------------------------------------------------------

		private CTypeEquipement TypeEquipement
		{
			get
			{
				return (CTypeEquipement)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		private void CFormEditionTypeEquipement_Load(object sender, System.EventArgs e)
		{
            m_extModulesAssociator.AppliquerConfiguration(CTimosApp.ConfigurationModules);    
		}
		//-------------------------------------------------------------------------
		private void CFormEditionTypeEquipement_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		}

		
		
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T("Equipment type|194") +" " + ((CTypeEquipement)ObjetEdite).Libelle);

            
			InitComboFamille();
        
			m_comboFamille.ElementSelectionne = TypeEquipement.Famille;

            ManageOnglets();

			// Par défaut le panel Remplacment n'est pas affiché

			return result;
		}

        //-------------------------------------------------------------------------
        private void ManageOnglets()
        {

            if (TypeEquipement.GetFormulaires().Length == 0)
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
        private void InitPanelChampsCustom()
        {
            m_panelDefinisseurChampsPhysiques.InitPanel(
                TypeEquipement.GetDefinisseurPourEquipementPhysique(),
                typeof(CFormListeChampsCustom),
                typeof(CFormListeFormulaires));

			m_panelDefinisseurChampsLogiques.InitPanel( 
				TypeEquipement.GetDefinisseurPourEquipementLogique(),
				typeof(CFormListeChampsCustom),
				typeof(CFormListeFormulaires));

        }
		

        //-------------------------------------------------------------------------
        private void InitTypesTableParametrables()
		{
			m_tableParametrablesLstSelec.Init(
			new CListeObjetsDonnees(TypeEquipement.ContexteDonnee, typeof(CTypeTableParametrable)),
			TypeEquipement.RelationsTypesTableParametrables,
			TypeEquipement,
			"TypeEquipement",
			"TypeTableParametrable");
			m_tableParametrablesLstSelec.RemplirGrille();

		}

		//-------------------------------------------------------------------------
		private void InitComboFamille()
		{
			CFamilleEquipement lastFamille = (CFamilleEquipement)m_comboFamille.ElementSelectionne; ;
			m_comboFamille.Init(
				typeof(CFamilleEquipement),
				"FamillesFilles",
				CFamilleEquipement.c_champIdParent,
				"Libelle",
				typeof(CFormEditionFamilleEquipement),
				null,
                new CFiltreData(CFamilleEquipement.c_champNoEquipment + "=@1", false));
			m_comboFamille.ElementSelectionne = lastFamille;			
		}



    


		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs() 
		{
           
			CResultAErreur result = base.MAJ_Champs();


          





			return result;
		}
		
		//-------------------------------------------------------------------------
		private void m_lnkFamilles_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			CFormNavigateurPopup.Show(new CFormListeFamillesEquipement());
			InitComboFamille();
		}


		//-------------------------------------------------------------------------
		private void m_comboFamille_ElementSelectionneChanged(object sender, EventArgs e)
		{
			TypeEquipement.Famille = (CFamilleEquipement)m_comboFamille.ElementSelectionne;
            ManageOnglets();
            m_panelChamps.ElementEdite = TypeEquipement;
        }

        #region Fournisseurs

        //-------------------------------------------------------------------------------------
		private void m_gestionnaireEditionFournisseurs_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
            CRelationTypeEquipement_Fournisseurs relation = args.Objet as CRelationTypeEquipement_Fournisseurs;

			if (relation == null)
			{
				m_panelFournisseur.Visible = false;
				return;
			}
			m_panelFournisseur.Visible = true;
            m_linkFournisseur.FillDialogFromObjet(relation);
            if (relation.Fournisseur != null)
                m_txtSelectFournisseur2.ElementSelectionne = relation.Fournisseur.Acteur;

		}

		//-------------------------------------------------------------------------------------
		private void m_gestionnaireEditionFournisseurs_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
            CRelationTypeEquipement_Fournisseurs relation = args.Objet as CRelationTypeEquipement_Fournisseurs;
            if (relation != null)
			{
                CActeur acteur = (CActeur)m_txtSelectFournisseur2.ElementSelectionne;
                if (acteur != null)
                    relation.Fournisseur = acteur.Fournisseur;
                CResultAErreur result = m_linkFournisseur.FillObjetFromDialog(relation);
				if (!result)
				{
					args.Result = result;
					return;
				}
			}
		}

		//-------------------------------------------------------------------------------------
		private void InitSelectFournisseur()
		{
            CFiltreData filtre = new CFiltreDataAvance ( 
				    CActeur.c_nomTable,
				    "Has("+CDonneesActeurFournisseur.c_nomTable+"."+
				    CDonneesActeurFournisseur.c_champId+")");

            m_txtSelectFournisseur.InitAvecFiltreDeBase<CActeur>(
                "Nom",
                filtre,
                true);

            m_txtSelectFournisseur2.InitAvecFiltreDeBase<CActeur>(
                "Nom",
                filtre,
                true);

        }

		private void m_lnkAjouterFournisseur_LinkClicked(object sender, EventArgs e)
		{
			if ( m_txtSelectFournisseur.ElementSelectionne == null )
			{
				CFormAlerte.Afficher(I.T( "Select the supplier to add|203"), EFormAlerteType.Exclamation);
				return;
			}
			CActeur acteur = (CActeur)m_txtSelectFournisseur.ElementSelectionne;
			CDonneesActeurFournisseur fournisseur = acteur.Fournisseur;
			if ( fournisseur == null )
				return;

			m_txtSelectFournisseur.ElementSelectionne = null;
			CRelationTypeEquipement_Fournisseurs rel = new CRelationTypeEquipement_Fournisseurs(TypeEquipement.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.Fournisseur = fournisseur;
			rel.TypeEquipement = TypeEquipement;
			
			ListViewItem item = new ListViewItem();
			m_wndListeFournisseurs.Items.Add ( item );
			m_wndListeFournisseurs.UpdateItemWithObject(item, rel);
			foreach ( ListViewItem itemSel in m_wndListeFournisseurs.SelectedItems )
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectFournisseur();
			//m_lnkAjouterEntree_LinkClicked(m_lnkAjouterEntree, null);
		}

		private void m_lnkSupprimerFournisseur_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeFournisseurs.SelectedItems.Count != 1)
				return;

			CRelationTypeEquipement_Fournisseurs rel = (CRelationTypeEquipement_Fournisseurs)m_wndListeFournisseurs.SelectedItems[0].Tag;

			m_gestionnaireEditionFournisseurs.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeFournisseurs.SelectedItems.Count == 1)
			{
				if (m_wndListeFournisseurs.SelectedItems[0] != null)
					m_wndListeFournisseurs.SelectedItems[0].Remove();
			}
			InitSelectFournisseur();
		}

		#endregion

		#region Stocks

		//-------------------------------------------------------------------------------------
		private void m_gestionnaireEditionStock_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet == null)
			{
				m_panelStock.Visible = false;
				return;
			}
			m_panelStock.Visible = true;
			m_linkStock.FillDialogFromObjet(args.Objet);
		}

		//-------------------------------------------------------------------------------------
		private void m_gestionnaireEditionStock_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
			if (args.Objet != null)
			{
				CResultAErreur result = m_linkStock.FillObjetFromDialog(args.Objet);
				if (!result)
				{
					args.Result = result;
					return;
				}
			}
		}

		//-------------------------------------------------------------------------------------
		private void InitSelectTypeStock()
		{
            CFiltreData filtre = null;

			string strIds = "";
			foreach (CRelationTypeEquipement_TypeStock rel in TypeEquipement.RelationsTypesStocks)
			{
				if (rel.TypeStock!= null)
					strIds += rel.TypeStock.Id + ",";
			}
			if (strIds.Length > 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = new CFiltreData ( CTypeStock.c_champId +" not in ("+strIds+")");
			}
			m_txtSelectTypeStock.InitAvecFiltreDeBase<CTypeStock>(
				"Libelle",
				filtre,
				true);
		}

		private void m_lnkAjouterTypeStock_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectTypeStock.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the stock type to add|215"), EFormAlerteType.Exclamation);
				return;
			}
			CTypeStock  tpStock = (CTypeStock)m_txtSelectTypeStock.ElementSelectionne;
			CListeObjetsDonnees listeExistants = TypeEquipement.RelationsTypesStocks;
			listeExistants.Filtre = new CFiltreData(CTypeStock.c_champId + "=@1",
				tpStock.Id);
			if (listeExistants.Count != 0)
			{
				CFormAlerte.Afficher(I.T( "Can not add this stock type|216"), EFormAlerteType.Erreur);
				return;
			}
			m_txtSelectTypeStock.ElementSelectionne = null;
			CRelationTypeEquipement_TypeStock rel = new CRelationTypeEquipement_TypeStock(TypeEquipement.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeStock = tpStock;
			rel.TypeEquipement = TypeEquipement;

			ListViewItem item = new ListViewItem();
			m_wndListeTypesStocks.Items.Add(item);
			m_wndListeTypesStocks.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeTypesStocks.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectTypeStock();
		}

		private void m_lnkSupprimerTypeStock_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeTypesStocks.SelectedItems.Count != 1)
				return;

			CRelationTypeEquipement_TypeStock rel = (CRelationTypeEquipement_TypeStock)m_wndListeTypesStocks.SelectedItems[0].Tag;

			m_gestionnaireEditionStock.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeTypesStocks.SelectedItems.Count == 1)
			{
				if (m_wndListeTypesStocks.SelectedItems[0] != null)
					m_wndListeTypesStocks.SelectedItems[0].Remove();
			}
			InitSelectTypeStock();
		}
		#endregion

		#region Types incluables

		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesInclus_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesInclus_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_lnkAddTypeInclu_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectTypeInclu.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the equipment type to add|219"), EFormAlerteType.Exclamation);
				return;
			}
			CTypeEquipement tpEquipement = (CTypeEquipement)m_txtSelectTypeInclu.ElementSelectionne;
			CListeObjetsDonnees listeExistants = TypeEquipement.RelationsTypesInclus;
			listeExistants.Filtre = new CFiltreData(CRelationTypeEquipement_TypesIncluables.c_champIdTypeInclu + "=@1",
				tpEquipement.Id);
			if (listeExistants.Count != 0)
			{
				CFormAlerte.Afficher(I.T( "Can not add this equipment type|220"), EFormAlerteType.Erreur);
				return;
			}
			m_txtSelectTypeInclu.ElementSelectionne = null;
			
			CRelationTypeEquipement_TypesIncluables rel = new CRelationTypeEquipement_TypesIncluables(TypeEquipement.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeInclu = tpEquipement;
			rel.TypeIncluant = TypeEquipement;

			ListViewItem item = new ListViewItem();
			m_wndListeEquipementsInclus.Items.Add(item);
			m_wndListeEquipementsInclus.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeEquipementsInclus.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectTypeInclu();
		}

		//-------------------------------------------------------------------------
		private void m_lnkDeleteTypeInclu_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeEquipementsInclus.SelectedItems.Count != 1)
				return;

			CRelationTypeEquipement_TypesIncluables rel = (CRelationTypeEquipement_TypesIncluables)m_wndListeEquipementsInclus.SelectedItems[0].Tag;

			m_gestionnaireTypesInclus.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeEquipementsInclus.SelectedItems.Count == 1)
			{
				if (m_wndListeEquipementsInclus.SelectedItems[0] != null)
					m_wndListeEquipementsInclus.SelectedItems[0].Remove();
			}
			InitSelectTypeInclu();
		}

		//-------------------------------------------------------------------------------------
		private void InitSelectTypeInclu()
		{
            CFiltreData filtre = null;


			string strIds = "";
			foreach (CRelationTypeEquipement_TypesIncluables rel in TypeEquipement.RelationsTypesInclus)
			{
				if (rel.TypeInclu != null)
					strIds += rel.TypeInclu.Id + ",";
			}
			if (strIds.Length > 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = new CFiltreData(CTypeEquipement.c_champId + " not in (" + strIds + ")");
			}
			m_txtSelectTypeInclu.InitAvecFiltreDeBase<CTypeEquipement>(
			    "Libelle",
				filtre,
				true);
		}

		#endregion

		#region Types donnateurs

		//-------------------------------------------------------------------------
		private void m_gestionEditionTypeDonnateur_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_gestionEditionTypeDonnateur_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_lnkAddTypeDonnateur_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectTypeDonnateur.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the equipment type to add|219"), EFormAlerteType.Exclamation);
				return;
			}
			CTypeEquipement tpEquipement = (CTypeEquipement)m_txtSelectTypeDonnateur.ElementSelectionne;
			CTypeEquipement[] typesParents = TypeEquipement.TousLesTypesParents;
			foreach (CTypeEquipement tp in typesParents)
			{
				if (tpEquipement.Equals(tp))
				{
					CFormAlerte.Afficher(I.T( "Can not add this equipment type|220"), EFormAlerteType.Erreur);
					return;
				}
			}
			m_txtSelectTypeDonnateur.ElementSelectionne = null;

			CRelationTypeEquipement_Heritage rel = new CRelationTypeEquipement_Heritage(TypeEquipement.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeParent = tpEquipement;
			rel.TypeFils = TypeEquipement;

			ListViewItem item = new ListViewItem();
			m_wndListeTypeDonnateurs.Items.Add(item);
			m_wndListeTypeDonnateurs.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeTypeDonnateurs.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectTypeDonnateur();
		}

		//-------------------------------------------------------------------------
		private void m_lnkDeleteTypeDonnateur_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeTypeDonnateurs.SelectedItems.Count != 1)
				return;

			CRelationTypeEquipement_Heritage rel = (CRelationTypeEquipement_Heritage)m_wndListeTypeDonnateurs.SelectedItems[0].Tag;

			m_gestionEditionTypeDonnateur.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeTypeDonnateurs.SelectedItems.Count == 1)
			{
				if (m_wndListeTypeDonnateurs.SelectedItems[0] != null)
					m_wndListeTypeDonnateurs.SelectedItems[0].Remove();
			}
			InitSelectTypeDonnateur();
		}

		//-------------------------------------------------------------------------------------
		private void InitSelectTypeDonnateur()
		{
            CFiltreData filtre = null;

			string strIds = "";
			foreach (CRelationTypeEquipement_Heritage rel in TypeEquipement.RelationsTypesParents)
			{
				if (rel.TypeParent!= null)
					strIds += rel.TypeParent.Id + ",";
			}
			if (strIds.Length > 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = new CFiltreData(CTypeEquipement.c_champId + " not in (" + strIds + ")");
			}
            m_txtSelectTypeDonnateur.InitAvecFiltreDeBase<CTypeEquipement>(
                "Libelle",
                filtre,
                true);
		}

		#endregion

		#region Types incluants

		///////////////////////////////////////////////////////
		///TYPES INCLUANTS
		//////////////////////////////////////////////////////
		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesIncluAnt_InitChamp(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_gestionnaireEditionTypesIncluant_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
		{
		}

		//-------------------------------------------------------------------------
		private void m_lnkAddTypeIncluant_LinkClicked(object sender, EventArgs e)
		{
			if (m_txtSelectTypeIncluant.ElementSelectionne == null)
			{
				CFormAlerte.Afficher(I.T( "Select the equipment type to add|219"), EFormAlerteType.Exclamation);
				return;
			}
			CTypeEquipement tpEquipement = (CTypeEquipement)m_txtSelectTypeIncluant.ElementSelectionne;
			CListeObjetsDonnees listeExistants = TypeEquipement.RelationsTypesIncluant;
			listeExistants.Filtre = new CFiltreData(CRelationTypeEquipement_TypesIncluables.c_champIdTypeIncluant + "=@1",
				tpEquipement.Id);
			if (listeExistants.Count != 0)
			{
				CFormAlerte.Afficher(I.T( "Can not add this equipment type|220"), EFormAlerteType.Erreur);
				return;
			}
			m_txtSelectTypeIncluant.ElementSelectionne = null;

			CRelationTypeEquipement_TypesIncluables rel = new CRelationTypeEquipement_TypesIncluables(TypeEquipement.ContexteDonnee);
			rel.CreateNewInCurrentContexte();
			rel.TypeIncluant = tpEquipement;
			rel.TypeInclu = TypeEquipement;

			ListViewItem item = new ListViewItem();
			m_wndListeEquipementsIncluants.Items.Add(item);
			m_wndListeEquipementsIncluants.UpdateItemWithObject(item, rel);
			foreach (ListViewItem itemSel in m_wndListeEquipementsIncluants.SelectedItems)
				itemSel.Selected = false;
			item.Selected = true;
			InitSelectTypeIncluant();
		}

		//-------------------------------------------------------------------------
		private void m_lnkDeleteTypeIncluant_LinkClicked(object sender, EventArgs e)
		{
			if (m_wndListeEquipementsIncluants.SelectedItems.Count != 1)
				return;

			CRelationTypeEquipement_TypesIncluables rel = (CRelationTypeEquipement_TypesIncluables)m_wndListeEquipementsIncluants.SelectedItems[0].Tag;

			m_gestionnaireTypesIncluant.SetObjetEnCoursToNull();
			CResultAErreur result = rel.Delete();
			if (!result)
			{
				CFormAlerte.Afficher(result.Erreur);
				return;
			}

			if (m_wndListeEquipementsIncluants.SelectedItems.Count == 1)
			{
				if (m_wndListeEquipementsIncluants.SelectedItems[0] != null)
					m_wndListeEquipementsIncluants.SelectedItems[0].Remove();
			}
			InitSelectTypeIncluant();
		}

		//-------------------------------------------------------------------------------------
		private void InitSelectTypeIncluant()
		{
			CFiltreData filtre = null;


			string strIds = "";
			foreach (CRelationTypeEquipement_TypesIncluables rel in TypeEquipement.RelationsTypesIncluant)
			{
				if (rel.TypeIncluant != null)
					strIds += rel.TypeIncluant.Id + ",";
			}
			if (strIds.Length > 0)
			{
				strIds = strIds.Substring(0, strIds.Length - 1);
				filtre = new CFiltreData(CTypeEquipement.c_champId + " not in (" + strIds + ")");
			}
			m_txtSelectTypeIncluant.InitAvecFiltreDeBase<CTypeEquipement>(
				"Libelle",
				filtre,
				true);
		}

		#endregion

        #region Types remplacement

        //---------------------------------------------------------------------------
        private void InitSelectTypeRemplacement()
        {
            m_txtSelectTypeRemplacement.Init<CTypeEquipement>(
                "Libelle",
                true);
        }

        private void InitListeRemplacement()
        {
            List<CEditeurRemplacementTypeEquipement> m_relationsTypesRemplacement = new List<CEditeurRemplacementTypeEquipement>();
    
            foreach (CRelationTypeEquipement_TypeRemplacement rel in TypeEquipement.RelationsTypesRemplacables)
            {
                CEditeurRemplacementTypeEquipement newEditeur =
                    new CEditeurRemplacementTypeEquipement(TypeEquipement, rel);
                m_relationsTypesRemplacement.Add(newEditeur);
            }
            foreach (CRelationTypeEquipement_TypeRemplacement rel in TypeEquipement.RelationsTypesRemplacants)
            {
                CEditeurRemplacementTypeEquipement newEditeur =
                    new CEditeurRemplacementTypeEquipement(TypeEquipement, rel);
                m_relationsTypesRemplacement.Add(newEditeur);
            }

            m_gestionRelationsRemplacement.ObjetEdite = m_relationsTypesRemplacement;
        }

        //---------------------------------------------------------------------------
        private void m_gestionRelationsRemplacement_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_conteneurRemplacement.Visible = false;
                return;
            }
            m_conteneurRemplacement.Visible = true;

            m_linkRemplacement.FillDialogFromObjet(args.Objet);
            CEditeurRemplacementTypeEquipement editeur = (CEditeurRemplacementTypeEquipement)args.Objet;
            // Gestion des radios/sens
            switch (editeur.SensRelation)
            {
                case -1:
                    m_radSens1vers2.Checked = true; break;
                case 0:
                    m_radSensBijective.Checked = true; break;
                case 1:
                    m_radSens2vers1.Checked = true; break;
                default:
                    m_radSens1vers2.Checked = true; break;
            }

        }

        //---------------------------------------------------------------------------
        private void m_gestionRelationsRemplacement_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CResultAErreur result = m_linkRemplacement.FillObjetFromDialog(args.Objet);
                if (!result)
                {
                    args.Result = result;
                    return;
                }
                // Gestion des radios/sens
                CEditeurRemplacementTypeEquipement editeur = (CEditeurRemplacementTypeEquipement)args.Objet;
                if (m_radSensBijective.Checked)
                    editeur.SensRelation = 0;
                else if (m_radSens2vers1.Checked)
                    editeur.SensRelation = 1;
                else editeur.SensRelation = -1;

            }
        }
        
        //------------------------------ AJOUTER RELATION ------------------------------------------
        private void m_lnkAjouterRelRemplacement_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectTypeRemplacement.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T( "Please select an Equipment Type to add|296"), EFormAlerteType.Exclamation);
                return;
            }
            CTypeEquipement newTpEqpt = (CTypeEquipement)m_txtSelectTypeRemplacement.ElementSelectionne;
            CListeObjetsDonnees listeRel = new CListeObjetsDonnees(TypeEquipement.ContexteDonnee,
                typeof(CRelationTypeEquipement_TypeRemplacement));

            listeRel.Filtre = new CFiltreData("("  +
                CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacable+" = @1 AND " +
                CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacant +" = @2) OR (" +
                CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacable + " = @2 AND " +
                CRelationTypeEquipement_TypeRemplacement.c_champIdTypeRemplacant + " = @1)",
                TypeEquipement.Id,
                newTpEqpt.Id);

            listeRel.InterditLectureInDB = true;

            if (listeRel.Count != 0)
            {
                CFormAlerte.Afficher(I.T( "This Equipement Type is already added|297"), EFormAlerteType.Erreur);
                return;
            }
            m_txtSelectTypeRemplacement.ElementSelectionne = null;
            // Créer la nouvelle relation par défaut le nouveau type est remplaçant
            CRelationTypeEquipement_TypeRemplacement newRel = new CRelationTypeEquipement_TypeRemplacement(
                TypeEquipement.ContexteDonnee);
            newRel.CreateNewInCurrentContexte();
            newRel.TypeRemplacable = TypeEquipement;
            newRel.TypeRemplacant = newTpEqpt;
            newRel.Bijective = false;

            //newRel.VerifieDonnees();

            // Ajoute la relation à la liste de CEditeurRemplacementTypeEquipement
            CEditeurRemplacementTypeEquipement newEditeur = new CEditeurRemplacementTypeEquipement(
                TypeEquipement, newRel);
            //m_relationsTypesRemplacement.Add(newEditeur);

            // Met à jour l'affichage de la listye des relations
            ListViewItem newItem = new ListViewItem();
            m_listeRelationsRemplacement.Items.Add(newItem);
            m_listeRelationsRemplacement.UpdateItemWithObject(newItem, newEditeur);
            foreach (ListViewItem item in m_listeRelationsRemplacement.SelectedItems)
                item.Selected = false;
            newItem.Selected = true;

        }

        //------------------------------ SUPPRIMER RELATION ------------------------------------------
        private void m_lnkSupprimerRelRemplacement_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeRelationsRemplacement.SelectedItems.Count == 0)
            {
                CFormAlerte.Afficher(I.T( "Please select an element to remove|303"), EFormAlerteType.Exclamation);
                return;
            }

            CEditeurRemplacementTypeEquipement edit = (CEditeurRemplacementTypeEquipement)m_listeRelationsRemplacement.SelectedItems[0].Tag;
            
            CResultAErreur result = edit.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeRelationsRemplacement.SelectedItems.Count != 0 && m_listeRelationsRemplacement.SelectedItems[0] != null)
            {
                m_listeRelationsRemplacement.SelectedItems[0].Remove();
            }

        }
        
        // Affiche toutes les relations des types d'équipements parents

        private void m_linkShowAllParentsRelations_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            string strRemplacants = "\r\nPEUT ETRE REMPLACE PAR:\r\n";


            foreach (CTypeEquipement typeEqpt in TypeEquipement.TousLesTypesRemplacants)
            {
                strRemplacants += typeEqpt.Libelle + "\r\n";
            }

            CFormAlerte.Afficher(strRemplacants, EFormAlerteType.Erreur);

        }


        #endregion

        #region Classe CEditeurRemplacementTypeEquipement


        //----------------------------------------------------------
        /// <summary>
        /// Classe membre qui se charge de préparer
        /// l'édition des relations pour le formulaire
        /// </summary>
        private class CEditeurRemplacementTypeEquipement : CRelationTypeEquipement_TypeRemplacement
        {
            // Constructeurs
            public CEditeurRemplacementTypeEquipement(CTypeEquipement typeEdite, CRelationTypeEquipement_TypeRemplacement rel)
                :base(rel.Row.Row)
            {
               
                m_typeEdite = typeEdite;
                
                // Init
                if (m_typeEdite != null)
                {
                    // Si le type édité est un remplaçable
                    if (m_typeEdite == TypeRemplacable)
                    {
                        m_typeLie = TypeRemplacant;
                        m_sensRelation = -1;
                    }
                    // Si le type édité est un remplaçant
                    if (m_typeEdite == TypeRemplacant)
                    {
                        m_typeLie = TypeRemplacable;
                        m_sensRelation = 1;
                    }

                    if (Bijective)
                        m_sensRelation = 0;

                }
            }

            public CEditeurRemplacementTypeEquipement(CContexteDonnee contexte)
                : base(contexte)
            {
            }

            public CEditeurRemplacementTypeEquipement(DataRow row)
                : base(row)
            {
            }


            /// <summary>
            /// Variables membres
            /// </summary>
            CTypeEquipement m_typeEdite;
            CTypeEquipement m_typeLie;
            int m_sensRelation = 0;


            ///////////////////////////// PROPRIETES ////////////////////////////////
            /// <summary>
            /// Renvoie le type d'Equipement lié au Type édité
            /// par une relation Remplaçable ou Remplaçant
            /// </summary>
            public CTypeEquipement TypeLie // Lire Type lié
            {
                get
                {
                    return m_typeLie;
                }
            }

            //----------------------------------------------------------------
            public int SensRelation
            {
                get
                {
                    return m_sensRelation;
                }
                set
                {
                    switch (value)
                    {
                        case -1:
                            if(m_sensRelation != -1)
                            {
                                m_sensRelation = -1;
                                TypeRemplacable = m_typeEdite;
                                TypeRemplacant = m_typeLie;
                                Bijective = false;
                            }
                            break;
                        case 1:
                            if (m_sensRelation != 1)
                            {
                                m_sensRelation = 1;
                                TypeRemplacable = m_typeLie;
                                TypeRemplacant = m_typeEdite;
                                Bijective = false;
                            }
                            break;
                        default:
                            m_sensRelation = 0;
                            Bijective = true;
                            break;
                        
                    }
                }
            }

            //----------------------------------------------------------------
            public string Libelle
            {
                get
                {
                    string strRelation = "";
                    switch (m_sensRelation)
                    {
                        case -1:
                            strRelation = I.T( " can be subtituted by |304")+m_typeLie.Libelle;
                            break;
                        case 0:
                            strRelation = I.T( " can be swaped with |305")+m_typeLie.Libelle;
                            break;
                        case 1: 
                            strRelation = I.T( " can replace |306")+m_typeLie.Libelle;
                            break;
                    }
                    
                    return strRelation;
                }
            }

           
        }
        # endregion

        private void m_txtNom_TextChanged(object sender, EventArgs e)
        {
           /*if (m_txtNom.Text != "")
                TypeEquipement.Libelle = m_txtNom.Text;
            m_extLinkField.FillDialogFromObjet(TypeEquipement);*/
		}


        #region Constructeurs

        //-------------------------------------------------------------------------------------
        private void m_gestionnaireEditionConstructeurs_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            CRelationTypeEquipement_Constructeurs relation = args.Objet as CRelationTypeEquipement_Constructeurs;

            if (relation == null)
            {
                m_panelConstructeur.Visible = false;
                return;
            }
            m_panelConstructeur.Visible = true;
            m_linkConstructeur.FillDialogFromObjet(relation);

            if(relation.Constructeur != null)
                m_txtSelectConstructeur2.ElementSelectionne = relation.Constructeur.Acteur;
        }

        //-------------------------------------------------------------------------------------
        private void m_gestionnaireEditionConstructeurs_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            CRelationTypeEquipement_Constructeurs relation = args.Objet as CRelationTypeEquipement_Constructeurs;
            if (relation != null)
            {
                CActeur acteur = (CActeur)m_txtSelectConstructeur2.ElementSelectionne;
                if (acteur != null)
                    relation.Constructeur = acteur.Constructeur;
                CResultAErreur result = m_linkConstructeur.FillObjetFromDialog(relation);
                if (!result)
                {
                    args.Result = result;
                    return;
                }
            }
        }

        //-------------------------------------------------------------------------------------
        private void InitSelectConstructeur()
        {
            CFiltreData filtre = new CFiltreDataAvance(
                CActeur.c_nomTable,
                "Has(" + CDonneesActeurConstructeur.c_nomTable + "." +
                CDonneesActeurConstructeur.c_champId + ")");

            m_txtSelectConstructeur.InitAvecFiltreDeBase<CActeur>(
                "Nom",
                filtre,
                true);

            m_txtSelectConstructeur2.InitAvecFiltreDeBase<CActeur>(
                "Nom",
                filtre,
                true);
            
        }

        private void m_lnkAjouterConstructeur_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectConstructeur.ElementSelectionne == null)
            {
                CFormAlerte.Afficher(I.T( "Select the supplier to add|203"), EFormAlerteType.Exclamation);
                return;
            }
            CActeur acteur = (CActeur)m_txtSelectConstructeur.ElementSelectionne;
            CDonneesActeurConstructeur Constructeur = acteur.Constructeur;
            if (Constructeur == null)
                return;

            m_txtSelectConstructeur.ElementSelectionne = null;
            CRelationTypeEquipement_Constructeurs rel = new CRelationTypeEquipement_Constructeurs(TypeEquipement.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.Constructeur = Constructeur;
            rel.TypeEquipement = TypeEquipement;

            ListViewItem item = new ListViewItem();
            m_wndListeConstructeurs.Items.Add(item);
            m_wndListeConstructeurs.UpdateItemWithObject(item, rel);
            foreach (ListViewItem itemSel in m_wndListeConstructeurs.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            InitSelectConstructeur();
        }

        private void m_lnkSupprimerConstructeur_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeConstructeurs.SelectedItems.Count != 1)
                return;

            CRelationTypeEquipement_Constructeurs rel = (CRelationTypeEquipement_Constructeurs)m_wndListeConstructeurs.SelectedItems[0].Tag;

            m_gestionnaireEditionConstructeurs.SetObjetEnCoursToNull();
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_wndListeConstructeurs.SelectedItems.Count == 1)
            {
                if (m_wndListeConstructeurs.SelectedItems[0] != null)
                    m_wndListeConstructeurs.SelectedItems[0].Remove();
            }
            InitSelectConstructeur();
        }

        #endregion

		private CResultAErreur CFormEditionTypeEquipement_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == m_pageComportementStock)
				{
					m_gestionnaireEditionStock.ObjetEdite = TypeEquipement.RelationsTypesStocks;
					InitSelectTypeStock();

				}
				else if (page == m_pageEOs)
				{
					m_panelEOS.Init(TypeEquipement);

				}
				else if (page == m_pageEquivalences)
				{
					m_conteneurRemplacement.Visible = m_gestionRelationsRemplacement.ObjetEnCours is CRelationTypeEquipement_TypeRemplacement;
					InitListeRemplacement();
					InitSelectTypeRemplacement();
				}
				else if(page == m_pageFabricant)
				{
					m_gestionnaireEditionConstructeurs.ObjetEdite = TypeEquipement.RelationsConstructeurs;

					m_panelConstructeur.Visible = m_gestionnaireEditionConstructeurs.ObjetEnCours is CRelationTypeEquipement_Constructeurs;
					InitSelectConstructeur();


				}
				else if (page == m_pageFiche)
				{
					m_panelChamps.ElementEdite = TypeEquipement;

				}
				else if (page == m_pageFournisseurs)
				{
					m_gestionnaireEditionFournisseurs.ObjetEdite = TypeEquipement.RelationsFournisseurs;
					m_panelFournisseur.Visible = m_gestionnaireEditionFournisseurs.ObjetEnCours is CRelationTypeEquipement_Fournisseurs;
					InitSelectFournisseur();

				}
				else if (page == m_pageInstallation)
				{
					m_gestionEditionTypeDonnateur.ObjetEdite = TypeEquipement.RelationsTypesParents;

					InitPanelChampsCustom();
					InitSelectTypeDonnateur();
				}
				else if (page == m_pagePeutInclure)
                {
                    m_gestionnaireTypesInclus.ObjetEdite = TypeEquipement.RelationsTypesInclus;
                    m_gestionnaireTypesIncluant.ObjetEdite = TypeEquipement.RelationsTypesIncluant;

                    InitSelectTypeInclu();
                    InitSelectTypeIncluant();
                }
				else if (page == m_pageOptions)
				{
					result = m_panelSystemeCoordonnees.Init(TypeEquipement);
					if (result)
						result = m_panelOptionsControle.Init(TypeEquipement);
                    if ( result )
                        result = m_panelOccupation.Init(TypeEquipement);
                    

                       
				}
				else if (page == m_pageTablesParametrables)
				{
					InitTypesTableParametrables();

				}
                else if(page == m_pagePorts)
                {
                    m_panelListePorts.InitFromListeObjets(TypeEquipement.Ports,
                        typeof(CPort),
                        typeof(CFormEditionPort),
                        TypeEquipement,
                        "TypeEquipement");
                   

                 result = m_panelSymbole.InitChamps(TypeEquipement,null);
				}


			}
			return result;
		}

		private CResultAErreur CFormEditionTypeEquipement_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == m_pageComportementStock)
			{
				result = m_gestionnaireEditionStock.ValideModifs();
			}
			else if (page == m_pageEOs)
			{
				result = m_panelEOS.MajChamps();
			}
			else if (page == m_pageEquivalences)
			{
				result = m_gestionRelationsRemplacement.ValideModifs();
			}
			else if (page == m_pageFabricant)
			{
				result = m_gestionnaireEditionConstructeurs.ValideModifs();
			}
			else if (page == m_pageFiche)
			{
				result = m_panelChamps.MAJ_Champs();
			}
			else if (page == m_pageFournisseurs)
			{
				result = m_gestionnaireEditionFournisseurs.ValideModifs();
			}
			else if (page == m_pageInstallation)
			{
				result = m_panelDefinisseurChampsPhysiques.MAJ_Champs();
				if (result)
					result = m_panelDefinisseurChampsLogiques.MAJ_Champs();
			}
			else if (page == m_pagePeutInclure)
			{
			}
			else if (page == m_pageOptions)
			{
				result = m_panelSystemeCoordonnees.MajChamps();
				if (result)
					result = m_panelOptionsControle.MajChamps();
                if (result)
                    result = m_panelOccupation.MajChamps();
           
			}
			else if (page == m_pageTablesParametrables)
			{
				m_tableParametrablesLstSelec.ApplyModifs();
			}

            else if (page == m_pagePorts)
            {
                m_panelSymbole.MAJ_Champs();
            }
			return result;
		}

        private void m_linkEditPorts_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            C2iSymbole symbolePorts = new C2iSymbole();

            timos.Equipement.CPositionneurPorts.PositionnePorts(TypeEquipement);
            m_panelSymbole.RefreshSymbole();

        }

        private void m_selectComposantPhysique_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            //UpdatePanelVuePhysique();
        }

        //private void UpdatePanelVuePhysique()
        //{
        //    m_panelFormulaireComposant.Visible = false;
        //    CComposantPhysiqueInDb composant = m_selectComposantPhysique.ElementSelectionne as CComposantPhysiqueInDb;
        //    if (composant != null)
        //    {
        //        if (m_panelFormulaireComposant.ElementEdite != null)
        //            m_panelFormulaireComposant.AffecteValeursToElement();
        //        if (composant.FormulaireAssocie != null)
        //        {
        //            m_panelFormulaireComposant.InitPanel(composant.FormulaireAssocie.Formulaire, TypeEquipement);
        //            m_panelFormulaireComposant.Visible = true;
        //        }
        //        C2iComposant3D composant3D = composant.Composant;
        //        if (composant3D != null)
        //        {
        //            composant3D.SetElementToEvalFormules(TypeEquipement);
        //        }
        //        m_vue3D.Composant = composant3D;
        //        m_vue3D.Refresh3D();
        //        m_vue3D.Visible = true;
        //    }    
        //    else
        //    {
        //        m_panelFormulaireComposant.ElementEdite = null;
        //        m_panelFormulaireComposant.Visible = false;
        //        m_vue3D.Visible = false;
        //    }
        //}

        private void m_lnkRefresh_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Update3D();
        }

        private void Update3D()
        {
        //    CComposantPhysiqueInDb composant = m_selectComposantPhysique.ElementSelectionne as CComposantPhysiqueInDb;
        //    MAJ_Champs();
        //    C2iComposant3D composant3D = composant.Composant;
        //    if (composant3D != null)
        //    {
        //        composant3D.SetElementToEvalFormules(TypeEquipement);
        //    }
        //    m_vue3D.Composant = composant3D;
        //    m_vue3D.Refresh3D();
        }


       
	}
}

