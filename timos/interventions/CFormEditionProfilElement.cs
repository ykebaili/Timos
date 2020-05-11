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
using sc2i.expression;

using timos.data;
using sc2i.win32.expression;
using timos.securite;
using sc2i.win32.data.dynamic;

namespace timos
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CProfilElement))]
	public class CFormEditionProfilElement : CFormEditionStdTimos, IFormNavigable
	{
		#region composants
		private CFiltreDynamique m_filtreDynamique = null;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private sc2i.win32.common.C2iTabControl m_tabControl;
		private CGestionnaireEditionSousObjetDonnee m_gestionnaireOperations;
		private CExtLinkField m_linkOperation;
		private ListViewAutoFilled m_wndListeOperations;
		private ListViewAutoFilledColumn listViewAutoFilledColumn4;
		private ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private Crownwood.Magic.Controls.TabPage tb_Contraintes;
		private CPanelListeSpeedStandard m_panelListeContraintes;
		private Label lbl_instruccontrainte;
		private ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private Crownwood.Magic.Controls.TabPage tb_ssprofils;
		private CPanelListeSpeedStandard m_panelSousProfils;
		private CArbreObjetHierarchique m_arbreProfilsParents;
		private Crownwood.Magic.Controls.TabPage tb_EOS;
		private Label label3;
		private ImageList m_imagesArbre;
		private ContextMenuStrip m_menuArbreEO;
		private ToolStripMenuItem m_menuFillesSeulement;
		private ToolStripMenuItem m_menuParentsSeulement;
		private ToolStripMenuItem m_menuEgaliteStricte;
		private ToolStripMenuItem m_menuBrancheComplete;
		private timos.interventions.CArbreFiltreCorrespondanceEO m_arbreEOS;
		private Crownwood.Magic.Controls.TabPage tb_inclusion;
		private Label lbl_inclusioninstruc;
		private TreeView m_arbreInclusion;
		private ContextMenuStrip m_menuArbreInclusion;
		private ToolStripMenuItem m_menuAjouterInclusion;
		private ToolStripMenuItem m_menuAjouterEt;
		private ToolStripMenuItem m_menuAjouterOu;
		private ToolStripMenuItem m_menuAjouterProfil;
		private ToolStripMenuItem m_menuSupprimerInclusion;
		private ToolStripMenuItem m_menuInsererInclusion;
		private ToolStripMenuItem m_menuInsererEt;
		private ToolStripMenuItem m_menuInsererOu;
		private ToolStripMenuItem m_menuSupprimerAvecFils;
		private ToolStripMenuItem m_menuSupprimerEtDecaler;
		private C2iComboSelectDynamicClass m_cmbTypeSource;
		private Label lbl_src;
		private C2iComboSelectDynamicClass m_cmbTypeElements;
		private Label lbl_elefiltres;
		private Label label5;
		private Crownwood.Magic.Controls.TabPage tb_filtre;
		private sc2i.win32.data.dynamic.CPanelEditFiltreDynamique m_panelFiltre;
		private Label lbl_filtreinstruc;
		private ToolStripMenuItem m_menuChangerDeProfil;
		private Crownwood.Magic.Controls.TabPage tb_formule;
		private sc2i.win32.expression.CControlAideFormule m_wndAideFormule;
		private Label lbl_instrucformule;
		private sc2i.win32.expression.CControleEditeFormule m_wndFormuleIntegration;
		private sc2i.win32.expression.CControleEditeFormule m_wndFormuleApplication;
		private Label label10;
		private Crownwood.Magic.Controls.TabPage tb_tester;
		private LinkLabel m_lnkTester;
		private LinkLabel m_lnkSelectSourceTest;
		private GlacialList m_wndListeTest;
		private Label lbl_sourceacomparer;
		private CTextBoxZoomFormule m_txtFormuleEOSource;
		private LinkLabel m_lnkProfilStandard;
		private ContextMenuStrip m_menuProfilsStandard;
		private ToolStripMenuItem profilDintervenantPourLesInterventionsToolStripMenuItem;
		private ToolStripMenuItem profilDeRessourcePourLesInterventionsToolStripMenuItem;
		private ToolStripMenuItem contactsPourLesInterventionsToolStripMenuItem;
		private ToolStripMenuItem contactsPourLesPhasesDeTicketToolStripMenuItem;
		private ToolStripMenuItem responsableDePhaseDeTicketToolStripMenuItem;
		private ToolStripMenuItem responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem;
		private Label lbl_eleacomparer;
		private Label lbl_videsource;
		private Label lbl_videele;
		private sc2i.win32.data.dynamic.CControlSelectDefinitionPropriete m_cmbSelectChemin;
        private ToolStripMenuItem profilDeSitesLiesAunContratCLientToolStripMenuItem;
        private ToolStripMenuItem profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem;
        private ToolStripMenuItem profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem;
        private ToolStripMenuItem profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem;
		private System.ComponentModel.IContainer components = null;

		#endregion

		public CFormEditionProfilElement()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionProfilElement(CProfilElement ProfilElement)
			:base(ProfilElement)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionProfilElement(CProfilElement ProfilElement, CListeObjetsDonnees liste)
			:base(ProfilElement, liste)
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
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionProfilElement));
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lnkProfilStandard = new System.Windows.Forms.LinkLabel();
            this.m_cmbTypeSource = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.lbl_src = new System.Windows.Forms.Label();
            this.m_cmbTypeElements = new sc2i.win32.common.C2iComboSelectDynamicClass(this.components);
            this.lbl_elefiltres = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_arbreProfilsParents = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.tb_EOS = new Crownwood.Magic.Controls.TabPage();
            this.m_cmbSelectChemin = new sc2i.win32.data.dynamic.CControlSelectDefinitionPropriete();
            this.lbl_videsource = new System.Windows.Forms.Label();
            this.lbl_videele = new System.Windows.Forms.Label();
            this.lbl_eleacomparer = new System.Windows.Forms.Label();
            this.m_txtFormuleEOSource = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.lbl_sourceacomparer = new System.Windows.Forms.Label();
            this.m_arbreEOS = new timos.interventions.CArbreFiltreCorrespondanceEO();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_ssprofils = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSousProfils = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.tb_inclusion = new Crownwood.Magic.Controls.TabPage();
            this.lbl_inclusioninstruc = new System.Windows.Forms.Label();
            this.m_arbreInclusion = new System.Windows.Forms.TreeView();
            this.tb_filtre = new Crownwood.Magic.Controls.TabPage();
            this.m_panelFiltre = new sc2i.win32.data.dynamic.CPanelEditFiltreDynamique();
            this.lbl_filtreinstruc = new System.Windows.Forms.Label();
            this.tb_formule = new Crownwood.Magic.Controls.TabPage();
            this.m_wndFormuleApplication = new sc2i.win32.expression.CControleEditeFormule();
            this.label10 = new System.Windows.Forms.Label();
            this.lbl_instrucformule = new System.Windows.Forms.Label();
            this.m_wndFormuleIntegration = new sc2i.win32.expression.CControleEditeFormule();
            this.m_wndAideFormule = new sc2i.win32.expression.CControlAideFormule();
            this.tb_Contraintes = new Crownwood.Magic.Controls.TabPage();
            this.lbl_instruccontrainte = new System.Windows.Forms.Label();
            this.m_panelListeContraintes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.tb_tester = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeTest = new sc2i.win32.common.GlacialList();
            this.m_lnkTester = new System.Windows.Forms.LinkLabel();
            this.m_lnkSelectSourceTest = new System.Windows.Forms.LinkLabel();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_imagesArbre = new System.Windows.Forms.ImageList(this.components);
            this.m_wndListeOperations = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn4 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gestionnaireOperations = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_linkOperation = new sc2i.win32.common.CExtLinkField();
            this.m_menuArbreEO = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuFillesSeulement = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuParentsSeulement = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuEgaliteStricte = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuBrancheComplete = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuArbreInclusion = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuAjouterInclusion = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAjouterEt = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAjouterOu = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAjouterProfil = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuInsererInclusion = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuInsererEt = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuInsererOu = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSupprimerInclusion = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSupprimerAvecFils = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSupprimerEtDecaler = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuChangerDeProfil = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuProfilsStandard = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.profilDintervenantPourLesInterventionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilDeRessourcePourLesInterventionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsPourLesInterventionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contactsPourLesPhasesDeTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.responsableDePhaseDeTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilDeSitesLiesAunContratCLientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.tb_EOS.SuspendLayout();
            this.tb_ssprofils.SuspendLayout();
            this.tb_inclusion.SuspendLayout();
            this.tb_filtre.SuspendLayout();
            this.tb_formule.SuspendLayout();
            this.tb_Contraintes.SuspendLayout();
            this.tb_tester.SuspendLayout();
            this.m_menuArbreEO.SuspendLayout();
            this.m_menuArbreInclusion.SuspendLayout();
            this.m_menuProfilsStandard.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_linkOperation.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_linkOperation.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_linkOperation.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_linkOperation.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_linkOperation.SetLinkField(this.m_panelNavigation, "");
            this.m_panelNavigation.Location = new System.Drawing.Point(655, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extLinkField.SetLinkField(this.m_lblNbListes, "");
            this.m_linkOperation.SetLinkField(this.m_lblNbListes, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extLinkField.SetLinkField(this.m_btnPrecedent, "");
            this.m_linkOperation.SetLinkField(this.m_btnPrecedent, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSuivant, "");
            this.m_linkOperation.SetLinkField(this.m_btnSuivant, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAjout, "");
            this.m_linkOperation.SetLinkField(this.m_btnAjout, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extLinkField.SetLinkField(this.m_lblId, "Id");
            this.m_linkOperation.SetLinkField(this.m_lblId, "");
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_linkOperation.SetLinkField(this.m_panelCle, "");
            this.m_panelCle.Location = new System.Drawing.Point(547, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_linkOperation.SetLinkField(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_linkOperation.SetLinkField(this.m_btnHistorique, "");
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_linkOperation.SetLinkField(this.m_imageCle, "");
            this.m_extLinkField.SetLinkField(this.m_imageCle, "");
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_linkOperation.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_linkOperation.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(9, 141);
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
            this.m_linkOperation.SetLinkField(this.m_txtLibelle, "");
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_txtLibelle.Location = new System.Drawing.Point(83, 132);
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
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkProfilStandard);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbTypeSource);
            this.c2iPanelOmbre4.Controls.Add(this.lbl_src);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbTypeElements);
            this.c2iPanelOmbre4.Controls.Add(this.lbl_elefiltres);
            this.c2iPanelOmbre4.Controls.Add(this.label5);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_arbreProfilsParents);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_linkOperation.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 30);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(640, 175);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_lnkProfilStandard
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkProfilStandard, "");
            this.m_linkOperation.SetLinkField(this.m_lnkProfilStandard, "");
            this.m_lnkProfilStandard.Location = new System.Drawing.Point(502, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkProfilStandard, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkProfilStandard, "");
            this.m_lnkProfilStandard.Name = "m_lnkProfilStandard";
            this.m_lnkProfilStandard.Size = new System.Drawing.Size(120, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProfilStandard, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProfilStandard, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProfilStandard.TabIndex = 4007;
            this.m_lnkProfilStandard.TabStop = true;
            this.m_lnkProfilStandard.Text = "Standard profiles|576";
            this.m_lnkProfilStandard.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkProfilStandard_LinkClicked);
            // 
            // m_cmbTypeSource
            // 
            this.m_cmbTypeSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeSource.FormattingEnabled = true;
            this.m_cmbTypeSource.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeSource, "");
            this.m_linkOperation.SetLinkField(this.m_cmbTypeSource, "");
            this.m_cmbTypeSource.Location = new System.Drawing.Point(104, 30);
            this.m_cmbTypeSource.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeSource, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeSource, "");
            this.m_cmbTypeSource.Name = "m_cmbTypeSource";
            this.m_cmbTypeSource.Size = new System.Drawing.Size(391, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSource.TabIndex = 4006;
            this.m_cmbTypeSource.TypeSelectionne = null;
            this.m_cmbTypeSource.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeSource_SelectionChangeCommitted);
            // 
            // lbl_src
            // 
            this.m_extLinkField.SetLinkField(this.lbl_src, "");
            this.m_linkOperation.SetLinkField(this.lbl_src, "");
            this.lbl_src.Location = new System.Drawing.Point(9, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_src, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_src, "");
            this.lbl_src.Name = "lbl_src";
            this.lbl_src.Size = new System.Drawing.Size(89, 14);
            this.m_extStyle.SetStyleBackColor(this.lbl_src, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_src, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_src.TabIndex = 4005;
            this.lbl_src.Text = "Source|578";
            // 
            // m_cmbTypeElements
            // 
            this.m_cmbTypeElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElements.FormattingEnabled = true;
            this.m_cmbTypeElements.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeElements, "");
            this.m_linkOperation.SetLinkField(this.m_cmbTypeElements, "");
            this.m_cmbTypeElements.Location = new System.Drawing.Point(104, 4);
            this.m_cmbTypeElements.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeElements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeElements, "");
            this.m_cmbTypeElements.Name = "m_cmbTypeElements";
            this.m_cmbTypeElements.Size = new System.Drawing.Size(391, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElements.TabIndex = 4004;
            this.m_cmbTypeElements.TypeSelectionne = null;
            this.m_cmbTypeElements.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeElements_SelectionChangeCommitted);
            // 
            // lbl_elefiltres
            // 
            this.m_extLinkField.SetLinkField(this.lbl_elefiltres, "");
            this.m_linkOperation.SetLinkField(this.lbl_elefiltres, "");
            this.lbl_elefiltres.Location = new System.Drawing.Point(9, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_elefiltres, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_elefiltres, "");
            this.lbl_elefiltres.Name = "lbl_elefiltres";
            this.lbl_elefiltres.Size = new System.Drawing.Size(119, 15);
            this.m_extStyle.SetStyleBackColor(this.lbl_elefiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_elefiltres, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_elefiltres.TabIndex = 4002;
            this.lbl_elefiltres.Text = "Filtered elements|577";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_linkOperation.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(9, 135);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4002;
            this.label5.Text = "Label|50";
            // 
            // m_arbreProfilsParents
            // 
            this.m_arbreProfilsParents.AutoriseReaffectation = true;
            this.m_arbreProfilsParents.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_arbreProfilsParents, "");
            this.m_linkOperation.SetLinkField(this.m_arbreProfilsParents, "");
            this.m_arbreProfilsParents.Location = new System.Drawing.Point(12, 57);
            this.m_arbreProfilsParents.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreProfilsParents, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_arbreProfilsParents, "");
            this.m_arbreProfilsParents.Name = "m_arbreProfilsParents";
            this.m_arbreProfilsParents.Size = new System.Drawing.Size(483, 69);
            this.m_extStyle.SetStyleBackColor(this.m_arbreProfilsParents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreProfilsParents, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreProfilsParents.TabIndex = 4003;
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
            this.m_linkOperation.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(8, 211);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tb_ssprofils;
            this.m_tabControl.Size = new System.Drawing.Size(822, 323);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tb_ssprofils,
            this.tb_inclusion,
            this.tb_filtre,
            this.tb_formule,
            this.tb_EOS,
            this.tb_Contraintes,
            this.tb_tester});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.c2iTabControl1_SelectionChanged);
            // 
            // tb_EOS
            // 
            this.tb_EOS.Controls.Add(this.m_cmbSelectChemin);
            this.tb_EOS.Controls.Add(this.lbl_videsource);
            this.tb_EOS.Controls.Add(this.lbl_videele);
            this.tb_EOS.Controls.Add(this.lbl_eleacomparer);
            this.tb_EOS.Controls.Add(this.m_txtFormuleEOSource);
            this.tb_EOS.Controls.Add(this.lbl_sourceacomparer);
            this.tb_EOS.Controls.Add(this.m_arbreEOS);
            this.tb_EOS.Controls.Add(this.label3);
            this.m_extLinkField.SetLinkField(this.tb_EOS, "");
            this.m_linkOperation.SetLinkField(this.tb_EOS, "");
            this.tb_EOS.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_EOS, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_EOS, "");
            this.tb_EOS.Name = "tb_EOS";
            this.tb_EOS.Selected = false;
            this.tb_EOS.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.tb_EOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tb_EOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_EOS.TabIndex = 16;
            this.tb_EOS.Title = "Organizational entities|53";
            // 
            // m_cmbSelectChemin
            // 
            this.m_cmbSelectChemin.DefinitionSelectionnee = null;
            this.m_linkOperation.SetLinkField(this.m_cmbSelectChemin, "");
            this.m_extLinkField.SetLinkField(this.m_cmbSelectChemin, "");
            this.m_cmbSelectChemin.Location = new System.Drawing.Point(149, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSelectChemin, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbSelectChemin, "");
            this.m_cmbSelectChemin.Name = "m_cmbSelectChemin";
            this.m_cmbSelectChemin.Size = new System.Drawing.Size(239, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSelectChemin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSelectChemin, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSelectChemin.TabIndex = 12;
            // 
            // lbl_videsource
            // 
            this.m_extLinkField.SetLinkField(this.lbl_videsource, "");
            this.m_linkOperation.SetLinkField(this.lbl_videsource, "");
            this.lbl_videsource.Location = new System.Drawing.Point(398, 49);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_videsource, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_videsource, "");
            this.lbl_videsource.Name = "lbl_videsource";
            this.lbl_videsource.Size = new System.Drawing.Size(269, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_videsource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_videsource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_videsource.TabIndex = 11;
            this.lbl_videsource.Text = "(empty for direct comparation of the source)|590";
            // 
            // lbl_videele
            // 
            this.m_extLinkField.SetLinkField(this.lbl_videele, "");
            this.m_linkOperation.SetLinkField(this.lbl_videele, "");
            this.lbl_videele.Location = new System.Drawing.Point(398, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_videele, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_videele, "");
            this.lbl_videele.Name = "lbl_videele";
            this.lbl_videele.Size = new System.Drawing.Size(288, 15);
            this.m_extStyle.SetStyleBackColor(this.lbl_videele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_videele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_videele.TabIndex = 10;
            this.lbl_videele.Text = "(empty for direct comparation of the element)|589";
            // 
            // lbl_eleacomparer
            // 
            this.m_extLinkField.SetLinkField(this.lbl_eleacomparer, "");
            this.m_linkOperation.SetLinkField(this.lbl_eleacomparer, "");
            this.lbl_eleacomparer.Location = new System.Drawing.Point(9, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_eleacomparer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_eleacomparer, "");
            this.lbl_eleacomparer.Name = "lbl_eleacomparer";
            this.lbl_eleacomparer.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.lbl_eleacomparer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_eleacomparer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_eleacomparer.TabIndex = 8;
            this.lbl_eleacomparer.Text = "Element to be compared|587";
            // 
            // m_txtFormuleEOSource
            // 
            this.m_txtFormuleEOSource.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleEOSource, "");
            this.m_linkOperation.SetLinkField(this.m_txtFormuleEOSource, "");
            this.m_txtFormuleEOSource.Location = new System.Drawing.Point(149, 49);
            this.m_txtFormuleEOSource.LockEdition = false;
            this.m_txtFormuleEOSource.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleEOSource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleEOSource, "");
            this.m_txtFormuleEOSource.Name = "m_txtFormuleEOSource";
            this.m_txtFormuleEOSource.Size = new System.Drawing.Size(243, 19);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleEOSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleEOSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleEOSource.TabIndex = 7;
            // 
            // lbl_sourceacomparer
            // 
            this.m_extLinkField.SetLinkField(this.lbl_sourceacomparer, "");
            this.m_linkOperation.SetLinkField(this.lbl_sourceacomparer, "");
            this.lbl_sourceacomparer.Location = new System.Drawing.Point(9, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_sourceacomparer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_sourceacomparer, "");
            this.lbl_sourceacomparer.Name = "lbl_sourceacomparer";
            this.lbl_sourceacomparer.Size = new System.Drawing.Size(155, 20);
            this.m_extStyle.SetStyleBackColor(this.lbl_sourceacomparer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_sourceacomparer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_sourceacomparer.TabIndex = 6;
            this.lbl_sourceacomparer.Text = "Source to be compared|588";
            // 
            // m_arbreEOS
            // 
            this.m_arbreEOS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.m_arbreEOS, "");
            this.m_linkOperation.SetLinkField(this.m_arbreEOS, "");
            this.m_arbreEOS.Location = new System.Drawing.Point(7, 74);
            this.m_arbreEOS.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreEOS, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_arbreEOS, "");
            this.m_arbreEOS.Name = "m_arbreEOS";
            this.m_arbreEOS.Size = new System.Drawing.Size(385, 205);
            this.m_extStyle.SetStyleBackColor(this.m_arbreEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreEOS, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreEOS.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_linkOperation.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(4, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(782, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "To be included in the profile, elements must have these Organizational Entities i" +
                "n common with the source, or an element of the source|395";
            // 
            // tb_ssprofils
            // 
            this.tb_ssprofils.Controls.Add(this.m_panelSousProfils);
            this.m_extLinkField.SetLinkField(this.tb_ssprofils, "");
            this.m_linkOperation.SetLinkField(this.tb_ssprofils, "");
            this.tb_ssprofils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_ssprofils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_ssprofils, "");
            this.tb_ssprofils.Name = "tb_ssprofils";
            this.tb_ssprofils.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.tb_ssprofils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tb_ssprofils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_ssprofils.TabIndex = 15;
            this.tb_ssprofils.Title = "Sub profiles|386";
            // 
            // m_panelSousProfils
            // 
            this.m_panelSousProfils.AllowArbre = true;
            this.m_panelSousProfils.AllowCustomisation = true;
            this.m_panelSousProfils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "ColumnLabel";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text = "Label|50";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 300;
            this.m_panelSousProfils.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelSousProfils.ContexteUtilisation = "";
            this.m_panelSousProfils.ControlFiltreStandard = null;
            this.m_panelSousProfils.ElementSelectionne = null;
            this.m_panelSousProfils.EnableCustomisation = true;
            this.m_panelSousProfils.FiltreDeBase = null;
            this.m_panelSousProfils.FiltreDeBaseEnAjout = false;
            this.m_panelSousProfils.FiltrePrefere = null;
            this.m_panelSousProfils.FiltreRapide = null;
            this.m_panelSousProfils.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelSousProfils, "");
            this.m_linkOperation.SetLinkField(this.m_panelSousProfils, "");
            this.m_panelSousProfils.ListeObjets = null;
            this.m_panelSousProfils.Location = new System.Drawing.Point(0, 0);
            this.m_panelSousProfils.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousProfils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelSousProfils.ModeQuickSearch = false;
            this.m_panelSousProfils.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelSousProfils, "");
            this.m_panelSousProfils.MultiSelect = false;
            this.m_panelSousProfils.Name = "m_panelSousProfils";
            this.m_panelSousProfils.Navigateur = null;
            this.m_panelSousProfils.ProprieteObjetAEditer = null;
            this.m_panelSousProfils.QuickSearchText = "";
            this.m_panelSousProfils.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousProfils.TabIndex = 2;
            this.m_panelSousProfils.TrierAuClicSurEnteteColonne = true;
            this.m_panelSousProfils.UseCheckBoxes = false;
            // 
            // tb_inclusion
            // 
            this.tb_inclusion.Controls.Add(this.lbl_inclusioninstruc);
            this.tb_inclusion.Controls.Add(this.m_arbreInclusion);
            this.m_extLinkField.SetLinkField(this.tb_inclusion, "");
            this.m_linkOperation.SetLinkField(this.tb_inclusion, "");
            this.tb_inclusion.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_inclusion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_inclusion, "");
            this.tb_inclusion.Name = "tb_inclusion";
            this.tb_inclusion.Selected = false;
            this.tb_inclusion.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.tb_inclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tb_inclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_inclusion.TabIndex = 17;
            this.tb_inclusion.Title = "Inclusion|580";
            // 
            // lbl_inclusioninstruc
            // 
            this.m_extLinkField.SetLinkField(this.lbl_inclusioninstruc, "");
            this.m_linkOperation.SetLinkField(this.lbl_inclusioninstruc, "");
            this.lbl_inclusioninstruc.Location = new System.Drawing.Point(9, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_inclusioninstruc, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_inclusioninstruc, "");
            this.lbl_inclusioninstruc.Name = "lbl_inclusioninstruc";
            this.lbl_inclusioninstruc.Size = new System.Drawing.Size(486, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_inclusioninstruc, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_inclusioninstruc, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_inclusioninstruc.TabIndex = 1;
            this.lbl_inclusioninstruc.Text = "Add the following profiles to the main Profile (use right click to modify)|579";
            // 
            // m_arbreInclusion
            // 
            this.m_arbreInclusion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_linkOperation.SetLinkField(this.m_arbreInclusion, "");
            this.m_extLinkField.SetLinkField(this.m_arbreInclusion, "");
            this.m_arbreInclusion.Location = new System.Drawing.Point(7, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreInclusion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_arbreInclusion, "");
            this.m_arbreInclusion.Name = "m_arbreInclusion";
            this.m_arbreInclusion.Size = new System.Drawing.Size(409, 254);
            this.m_extStyle.SetStyleBackColor(this.m_arbreInclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreInclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreInclusion.TabIndex = 0;
            this.m_arbreInclusion.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_arbreInclusion_MouseUp);
            // 
            // tb_filtre
            // 
            this.tb_filtre.Controls.Add(this.m_panelFiltre);
            this.tb_filtre.Controls.Add(this.lbl_filtreinstruc);
            this.m_extLinkField.SetLinkField(this.tb_filtre, "");
            this.m_linkOperation.SetLinkField(this.tb_filtre, "");
            this.tb_filtre.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_filtre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_filtre, "");
            this.tb_filtre.Name = "tb_filtre";
            this.tb_filtre.Selected = false;
            this.tb_filtre.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.tb_filtre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tb_filtre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_filtre.TabIndex = 18;
            this.tb_filtre.Title = "Filter|581";
            // 
            // m_panelFiltre
            // 
            this.m_panelFiltre.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFiltre.BackColor = System.Drawing.Color.White;
            this.m_panelFiltre.DefinitionRacineDeChampsFiltres = null;
            this.m_panelFiltre.FiltreDynamique = null;
            this.m_linkOperation.SetLinkField(this.m_panelFiltre, "");
            this.m_extLinkField.SetLinkField(this.m_panelFiltre, "");
            this.m_panelFiltre.Location = new System.Drawing.Point(10, 20);
            this.m_panelFiltre.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFiltre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFiltre.ModeFiltreExpression = false;
            this.m_panelFiltre.ModeSansType = true;
            this.m_extModulesAssociator.SetModules(this.m_panelFiltre, "");
            this.m_panelFiltre.Name = "m_panelFiltre";
            this.m_panelFiltre.Size = new System.Drawing.Size(796, 262);
            this.m_extStyle.SetStyleBackColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFiltre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFiltre.TabIndex = 1;
            // 
            // lbl_filtreinstruc
            // 
            this.m_extLinkField.SetLinkField(this.lbl_filtreinstruc, "");
            this.m_linkOperation.SetLinkField(this.lbl_filtreinstruc, "");
            this.lbl_filtreinstruc.Location = new System.Drawing.Point(9, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_filtreinstruc, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_filtreinstruc, "");
            this.lbl_filtreinstruc.Name = "lbl_filtreinstruc";
            this.lbl_filtreinstruc.Size = new System.Drawing.Size(455, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_filtreinstruc, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_filtreinstruc, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_filtreinstruc.TabIndex = 0;
            this.lbl_filtreinstruc.Text = "To belong to this profile, elements must match the following filter|584";
            // 
            // tb_formule
            // 
            this.tb_formule.Controls.Add(this.m_wndFormuleApplication);
            this.tb_formule.Controls.Add(this.label10);
            this.tb_formule.Controls.Add(this.lbl_instrucformule);
            this.tb_formule.Controls.Add(this.m_wndFormuleIntegration);
            this.tb_formule.Controls.Add(this.m_wndAideFormule);
            this.m_extLinkField.SetLinkField(this.tb_formule, "");
            this.m_linkOperation.SetLinkField(this.tb_formule, "");
            this.tb_formule.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_formule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_formule, "");
            this.tb_formule.Name = "tb_formule";
            this.tb_formule.Selected = false;
            this.tb_formule.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.tb_formule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tb_formule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_formule.TabIndex = 19;
            this.tb_formule.Title = "Formula|582";
            // 
            // m_wndFormuleApplication
            // 
            this.m_wndFormuleApplication.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormuleApplication.BackColor = System.Drawing.Color.White;
            this.m_wndFormuleApplication.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndFormuleApplication.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_wndFormuleApplication, "");
            this.m_linkOperation.SetLinkField(this.m_wndFormuleApplication, "");
            this.m_wndFormuleApplication.Location = new System.Drawing.Point(4, 149);
            this.m_wndFormuleApplication.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndFormuleApplication, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndFormuleApplication, "");
            this.m_wndFormuleApplication.Name = "m_wndFormuleApplication";
            this.m_wndFormuleApplication.Size = new System.Drawing.Size(610, 133);
            this.m_extStyle.SetStyleBackColor(this.m_wndFormuleApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndFormuleApplication, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndFormuleApplication.TabIndex = 4;
            this.m_wndFormuleApplication.Enter += new System.EventHandler(this.m_wndFormuleApplication_Enter);
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_linkOperation.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(4, 133);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(435, 13);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 3;
            this.label10.Text = "Profile will be applied only if the source element matches this formula|586";
            // 
            // lbl_instrucformule
            // 
            this.m_extLinkField.SetLinkField(this.lbl_instrucformule, "");
            this.m_linkOperation.SetLinkField(this.lbl_instrucformule, "");
            this.lbl_instrucformule.Location = new System.Drawing.Point(9, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_instrucformule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_instrucformule, "");
            this.lbl_instrucformule.Name = "lbl_instrucformule";
            this.lbl_instrucformule.Size = new System.Drawing.Size(435, 18);
            this.m_extStyle.SetStyleBackColor(this.lbl_instrucformule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_instrucformule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_instrucformule.TabIndex = 2;
            this.lbl_instrucformule.Text = "Only elements for which the formula returns TRUE will be included in the profile|" +
                "585";
            // 
            // m_wndFormuleIntegration
            // 
            this.m_wndFormuleIntegration.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormuleIntegration.BackColor = System.Drawing.Color.White;
            this.m_wndFormuleIntegration.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndFormuleIntegration.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_wndFormuleIntegration, "");
            this.m_linkOperation.SetLinkField(this.m_wndFormuleIntegration, "");
            this.m_wndFormuleIntegration.Location = new System.Drawing.Point(4, 32);
            this.m_wndFormuleIntegration.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndFormuleIntegration, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndFormuleIntegration, "");
            this.m_wndFormuleIntegration.Name = "m_wndFormuleIntegration";
            this.m_wndFormuleIntegration.Size = new System.Drawing.Size(610, 84);
            this.m_extStyle.SetStyleBackColor(this.m_wndFormuleIntegration, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndFormuleIntegration, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndFormuleIntegration.TabIndex = 1;
            this.m_wndFormuleIntegration.Enter += new System.EventHandler(this.m_wndFormuleIntegration_Enter);
            // 
            // m_wndAideFormule
            // 
            this.m_wndAideFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndAideFormule.FournisseurProprietes = null;
            this.m_linkOperation.SetLinkField(this.m_wndAideFormule, "");
            this.m_extLinkField.SetLinkField(this.m_wndAideFormule, "");
            this.m_wndAideFormule.Location = new System.Drawing.Point(616, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndAideFormule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndAideFormule, "");
            this.m_wndAideFormule.Name = "m_wndAideFormule";
            this.m_wndAideFormule.ObjetInterroge = null;
            this.m_wndAideFormule.SendIdChamps = false;
            this.m_wndAideFormule.Size = new System.Drawing.Size(190, 282);
            this.m_extStyle.SetStyleBackColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAideFormule, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAideFormule.TabIndex = 0;
            this.m_wndAideFormule.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAideFormule_OnSendCommande);
            // 
            // tb_Contraintes
            // 
            this.tb_Contraintes.Controls.Add(this.lbl_instruccontrainte);
            this.tb_Contraintes.Controls.Add(this.m_panelListeContraintes);
            this.m_extLinkField.SetLinkField(this.tb_Contraintes, "");
            this.m_linkOperation.SetLinkField(this.tb_Contraintes, "");
            this.tb_Contraintes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_Contraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_Contraintes, "");
            this.tb_Contraintes.Name = "tb_Contraintes";
            this.tb_Contraintes.Selected = false;
            this.tb_Contraintes.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.tb_Contraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tb_Contraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_Contraintes.TabIndex = 13;
            this.tb_Contraintes.Title = "Constraints|255";
            // 
            // lbl_instruccontrainte
            // 
            this.m_extLinkField.SetLinkField(this.lbl_instruccontrainte, "");
            this.m_linkOperation.SetLinkField(this.lbl_instruccontrainte, "");
            this.lbl_instruccontrainte.Location = new System.Drawing.Point(4, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_instruccontrainte, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.lbl_instruccontrainte, "");
            this.lbl_instruccontrainte.Name = "lbl_instruccontrainte";
            this.lbl_instruccontrainte.Size = new System.Drawing.Size(441, 13);
            this.m_extStyle.SetStyleBackColor(this.lbl_instruccontrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.lbl_instruccontrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.lbl_instruccontrainte.TabIndex = 2;
            this.lbl_instruccontrainte.Text = "Actors of this profile must have resources to raise following constraints||383";
            // 
            // m_panelListeContraintes
            // 
            this.m_panelListeContraintes.AllowArbre = true;
            this.m_panelListeContraintes.AllowCustomisation = true;
            this.m_panelListeContraintes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "ColumnLabel";
            glColumn4.Propriete = "Libelle";
            glColumn4.Text = "Label|50";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 300;
            this.m_panelListeContraintes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn4});
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
            this.m_linkOperation.SetLinkField(this.m_panelListeContraintes, "");
            this.m_panelListeContraintes.ListeObjets = null;
            this.m_panelListeContraintes.Location = new System.Drawing.Point(0, 20);
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
            this.m_panelListeContraintes.Size = new System.Drawing.Size(806, 262);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeContraintes.TabIndex = 1;
            this.m_panelListeContraintes.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeContraintes.UseCheckBoxes = false;
            // 
            // tb_tester
            // 
            this.tb_tester.Controls.Add(this.m_wndListeTest);
            this.tb_tester.Controls.Add(this.m_lnkTester);
            this.tb_tester.Controls.Add(this.m_lnkSelectSourceTest);
            this.m_extLinkField.SetLinkField(this.tb_tester, "");
            this.m_linkOperation.SetLinkField(this.tb_tester, "");
            this.tb_tester.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tb_tester, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tb_tester, "");
            this.tb_tester.Name = "tb_tester";
            this.tb_tester.Selected = false;
            this.tb_tester.Size = new System.Drawing.Size(806, 282);
            this.m_extStyle.SetStyleBackColor(this.tb_tester, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tb_tester, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tb_tester.TabIndex = 20;
            this.tb_tester.Title = "Test|583";
            // 
            // m_wndListeTest
            // 
            this.m_wndListeTest.AllowColumnResize = true;
            this.m_wndListeTest.AllowMultiselect = false;
            this.m_wndListeTest.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeTest.AlternatingColors = false;
            this.m_wndListeTest.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeTest.AutoHeight = true;
            this.m_wndListeTest.AutoSort = true;
            this.m_wndListeTest.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeTest.CanChangeActivationCheckBoxes = false;
            this.m_wndListeTest.CheckBoxes = false;
            this.m_wndListeTest.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeTest.CheckedItems")));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Desc";
            glColumn1.Propriete = "DescriptionElement";
            glColumn1.Text = "";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 500;
            this.m_wndListeTest.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_wndListeTest.ContexteUtilisation = "";
            this.m_wndListeTest.EnableCustomisation = true;
            this.m_wndListeTest.FocusedItem = null;
            this.m_wndListeTest.FullRowSelect = true;
            this.m_wndListeTest.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeTest.GridColor = System.Drawing.Color.Gray;
            this.m_wndListeTest.HasImages = false;
            this.m_wndListeTest.HeaderHeight = 22;
            this.m_wndListeTest.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeTest.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeTest.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeTest.HeaderVisible = true;
            this.m_wndListeTest.HeaderWordWrap = false;
            this.m_wndListeTest.HotColumnIndex = -1;
            this.m_wndListeTest.HotItemIndex = -1;
            this.m_wndListeTest.HotTracking = false;
            this.m_wndListeTest.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeTest.ImageList = null;
            this.m_wndListeTest.ItemHeight = 18;
            this.m_wndListeTest.ItemWordWrap = false;
            this.m_linkOperation.SetLinkField(this.m_wndListeTest, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeTest, "");
            this.m_wndListeTest.ListeSource = null;
            this.m_wndListeTest.Location = new System.Drawing.Point(12, 27);
            this.m_wndListeTest.MaxHeight = 18;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeTest, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeTest, "");
            this.m_wndListeTest.Name = "m_wndListeTest";
            this.m_wndListeTest.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeTest.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeTest.ShowBorder = true;
            this.m_wndListeTest.ShowFocusRect = true;
            this.m_wndListeTest.Size = new System.Drawing.Size(779, 252);
            this.m_wndListeTest.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeTest.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeTest.TabIndex = 4009;
            this.m_wndListeTest.Text = "glacialList1";
            this.m_wndListeTest.TrierAuClicSurEnteteColonne = true;
            // 
            // m_lnkTester
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkTester, "");
            this.m_linkOperation.SetLinkField(this.m_lnkTester, "");
            this.m_lnkTester.Location = new System.Drawing.Point(161, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTester, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkTester, "");
            this.m_lnkTester.Name = "m_lnkTester";
            this.m_lnkTester.Size = new System.Drawing.Size(79, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTester, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTester, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTester.TabIndex = 4008;
            this.m_lnkTester.TabStop = true;
            this.m_lnkTester.Text = "Test|583";
            this.m_lnkTester.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTester_LinkClicked);
            // 
            // m_lnkSelectSourceTest
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkSelectSourceTest, "");
            this.m_linkOperation.SetLinkField(this.m_lnkSelectSourceTest, "");
            this.m_lnkSelectSourceTest.Location = new System.Drawing.Point(9, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSelectSourceTest, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSelectSourceTest, "");
            this.m_lnkSelectSourceTest.Name = "m_lnkSelectSourceTest";
            this.m_lnkSelectSourceTest.Size = new System.Drawing.Size(146, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSelectSourceTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSelectSourceTest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSelectSourceTest.TabIndex = 4007;
            this.m_lnkSelectSourceTest.TabStop = true;
            this.m_lnkSelectSourceTest.Text = "Select source|591";
            this.m_lnkSelectSourceTest.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSelectSourceTest_LinkClicked);
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "Nom";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label|50";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 350;
            // 
            // m_imagesArbre
            // 
            this.m_imagesArbre.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_imagesArbre.ImageStream")));
            this.m_imagesArbre.TransparentColor = System.Drawing.Color.Transparent;
            this.m_imagesArbre.Images.SetKeyName(0, "vide.bmp");
            this.m_imagesArbre.Images.SetKeyName(1, "childsonly.bmp");
            this.m_imagesArbre.Images.SetKeyName(2, "parentsOnly.bmp");
            this.m_imagesArbre.Images.SetKeyName(3, "egalitearbre.bmp");
            this.m_imagesArbre.Images.SetKeyName(4, "branchecomplete.bmp");
            // 
            // m_wndListeOperations
            // 
            this.m_wndListeOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_wndListeOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn4,
            this.listViewAutoFilledColumn1});
            this.m_wndListeOperations.EnableCustomisation = true;
            this.m_wndListeOperations.FullRowSelect = true;
            this.m_wndListeOperations.HideSelection = false;
            this.m_linkOperation.SetLinkField(this.m_wndListeOperations, "");
            this.m_extLinkField.SetLinkField(this.m_wndListeOperations, "");
            this.m_wndListeOperations.Location = new System.Drawing.Point(9, 47);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeOperations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeOperations, "");
            this.m_wndListeOperations.MultiSelect = false;
            this.m_wndListeOperations.Name = "m_wndListeOperations";
            this.m_wndListeOperations.Size = new System.Drawing.Size(297, 264);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeOperations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeOperations.TabIndex = 5;
            this.m_wndListeOperations.UseCompatibleStateImageBehavior = false;
            this.m_wndListeOperations.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn4
            // 
            this.listViewAutoFilledColumn4.Field = "TypeOperation.Code";
            this.listViewAutoFilledColumn4.PrecisionWidth = 0;
            this.listViewAutoFilledColumn4.ProportionnalSize = false;
            this.listViewAutoFilledColumn4.Text = "Code|369";
            this.listViewAutoFilledColumn4.Visible = true;
            this.listViewAutoFilledColumn4.Width = 70;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "TypeOperation.Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 200;
            // 
            // m_gestionnaireOperations
            // 
            this.m_gestionnaireOperations.ListeAssociee = this.m_wndListeOperations;
            this.m_gestionnaireOperations.ObjetEdite = null;
            // 
            // m_menuArbreEO
            // 
            this.m_menuArbreEO.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuFillesSeulement,
            this.m_menuParentsSeulement,
            this.m_menuEgaliteStricte,
            this.m_menuBrancheComplete});
            this.m_extLinkField.SetLinkField(this.m_menuArbreEO, "");
            this.m_linkOperation.SetLinkField(this.m_menuArbreEO, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuArbreEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuArbreEO, "");
            this.m_menuArbreEO.Name = "m_menuArbreEO";
            this.m_menuArbreEO.Size = new System.Drawing.Size(182, 92);
            this.m_extStyle.SetStyleBackColor(this.m_menuArbreEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuArbreEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_menuFillesSeulement
            // 
            this.m_menuFillesSeulement.Name = "m_menuFillesSeulement";
            this.m_menuFillesSeulement.Size = new System.Drawing.Size(181, 22);
            this.m_menuFillesSeulement.Text = "Filles uniquement";
            // 
            // m_menuParentsSeulement
            // 
            this.m_menuParentsSeulement.Name = "m_menuParentsSeulement";
            this.m_menuParentsSeulement.Size = new System.Drawing.Size(181, 22);
            this.m_menuParentsSeulement.Text = "Parents uniquement";
            // 
            // m_menuEgaliteStricte
            // 
            this.m_menuEgaliteStricte.Name = "m_menuEgaliteStricte";
            this.m_menuEgaliteStricte.Size = new System.Drawing.Size(181, 22);
            this.m_menuEgaliteStricte.Text = "Egalité stricte";
            // 
            // m_menuBrancheComplete
            // 
            this.m_menuBrancheComplete.Name = "m_menuBrancheComplete";
            this.m_menuBrancheComplete.Size = new System.Drawing.Size(181, 22);
            this.m_menuBrancheComplete.Text = "Branche complète";
            // 
            // m_menuArbreInclusion
            // 
            this.m_menuArbreInclusion.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuAjouterInclusion,
            this.m_menuInsererInclusion,
            this.m_menuSupprimerInclusion,
            this.m_menuChangerDeProfil});
            this.m_extLinkField.SetLinkField(this.m_menuArbreInclusion, "");
            this.m_linkOperation.SetLinkField(this.m_menuArbreInclusion, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuArbreInclusion, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuArbreInclusion, "");
            this.m_menuArbreInclusion.Name = "m_menuArbreInclusion";
            this.m_menuArbreInclusion.Size = new System.Drawing.Size(169, 92);
            this.m_extStyle.SetStyleBackColor(this.m_menuArbreInclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuArbreInclusion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_menuArbreInclusion.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuArbreInclusion_Opening);
            // 
            // m_menuAjouterInclusion
            // 
            this.m_menuAjouterInclusion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuAjouterEt,
            this.m_menuAjouterOu,
            this.m_menuAjouterProfil});
            this.m_menuAjouterInclusion.Name = "m_menuAjouterInclusion";
            this.m_menuAjouterInclusion.Size = new System.Drawing.Size(168, 22);
            this.m_menuAjouterInclusion.Text = "Ajouter";
            // 
            // m_menuAjouterEt
            // 
            this.m_menuAjouterEt.Name = "m_menuAjouterEt";
            this.m_menuAjouterEt.Size = new System.Drawing.Size(109, 22);
            this.m_menuAjouterEt.Text = "Et";
            this.m_menuAjouterEt.Click += new System.EventHandler(this.m_menuAjouterEt_Click);
            // 
            // m_menuAjouterOu
            // 
            this.m_menuAjouterOu.Name = "m_menuAjouterOu";
            this.m_menuAjouterOu.Size = new System.Drawing.Size(109, 22);
            this.m_menuAjouterOu.Text = "Ou";
            this.m_menuAjouterOu.Click += new System.EventHandler(this.m_menuAjouterOu_Click);
            // 
            // m_menuAjouterProfil
            // 
            this.m_menuAjouterProfil.Name = "m_menuAjouterProfil";
            this.m_menuAjouterProfil.Size = new System.Drawing.Size(109, 22);
            this.m_menuAjouterProfil.Text = "Profil";
            this.m_menuAjouterProfil.Click += new System.EventHandler(this.m_menuAjouterProfil_Click);
            // 
            // m_menuInsererInclusion
            // 
            this.m_menuInsererInclusion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuInsererEt,
            this.m_menuInsererOu});
            this.m_menuInsererInclusion.Name = "m_menuInsererInclusion";
            this.m_menuInsererInclusion.Size = new System.Drawing.Size(168, 22);
            this.m_menuInsererInclusion.Text = "Insérer";
            // 
            // m_menuInsererEt
            // 
            this.m_menuInsererEt.Name = "m_menuInsererEt";
            this.m_menuInsererEt.Size = new System.Drawing.Size(99, 22);
            this.m_menuInsererEt.Text = "Et";
            this.m_menuInsererEt.Click += new System.EventHandler(this.m_menuInsererEt_Click);
            // 
            // m_menuInsererOu
            // 
            this.m_menuInsererOu.Name = "m_menuInsererOu";
            this.m_menuInsererOu.Size = new System.Drawing.Size(99, 22);
            this.m_menuInsererOu.Text = "Ou";
            this.m_menuInsererOu.Click += new System.EventHandler(this.m_menuInsererOu_Click);
            // 
            // m_menuSupprimerInclusion
            // 
            this.m_menuSupprimerInclusion.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuSupprimerAvecFils,
            this.m_menuSupprimerEtDecaler});
            this.m_menuSupprimerInclusion.Name = "m_menuSupprimerInclusion";
            this.m_menuSupprimerInclusion.Size = new System.Drawing.Size(168, 22);
            this.m_menuSupprimerInclusion.Text = "Supprimer";
            // 
            // m_menuSupprimerAvecFils
            // 
            this.m_menuSupprimerAvecFils.Name = "m_menuSupprimerAvecFils";
            this.m_menuSupprimerAvecFils.Size = new System.Drawing.Size(213, 22);
            this.m_menuSupprimerAvecFils.Text = "L\'élément et ses fils";
            this.m_menuSupprimerAvecFils.Click += new System.EventHandler(this.m_menuSupprimerAvecFils_Click);
            // 
            // m_menuSupprimerEtDecaler
            // 
            this.m_menuSupprimerEtDecaler.Name = "m_menuSupprimerEtDecaler";
            this.m_menuSupprimerEtDecaler.Size = new System.Drawing.Size(213, 22);
            this.m_menuSupprimerEtDecaler.Text = "Décaler les fils vers le haut";
            this.m_menuSupprimerEtDecaler.Click += new System.EventHandler(this.décalerLesFilsVersLeHautToolStripMenuItem_Click);
            // 
            // m_menuChangerDeProfil
            // 
            this.m_menuChangerDeProfil.Name = "m_menuChangerDeProfil";
            this.m_menuChangerDeProfil.Size = new System.Drawing.Size(168, 22);
            this.m_menuChangerDeProfil.Text = "Changer de profil";
            this.m_menuChangerDeProfil.Click += new System.EventHandler(this.m_menuChangerDeProfil_Click);
            // 
            // m_menuProfilsStandard
            // 
            this.m_menuProfilsStandard.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilDintervenantPourLesInterventionsToolStripMenuItem,
            this.profilDeRessourcePourLesInterventionsToolStripMenuItem,
            this.contactsPourLesInterventionsToolStripMenuItem,
            this.contactsPourLesPhasesDeTicketToolStripMenuItem,
            this.responsableDePhaseDeTicketToolStripMenuItem,
            this.responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem,
            this.profilDeSitesLiesAunContratCLientToolStripMenuItem,
            this.profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem,
            this.profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem,
            this.profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem});
            this.m_extLinkField.SetLinkField(this.m_menuProfilsStandard, "");
            this.m_linkOperation.SetLinkField(this.m_menuProfilsStandard, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuProfilsStandard, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuProfilsStandard, "");
            this.m_menuProfilsStandard.Name = "m_menuProfilsStandard";
            this.m_menuProfilsStandard.Size = new System.Drawing.Size(313, 224);
            this.m_extStyle.SetStyleBackColor(this.m_menuProfilsStandard, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuProfilsStandard, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // profilDintervenantPourLesInterventionsToolStripMenuItem
            // 
            this.profilDintervenantPourLesInterventionsToolStripMenuItem.Name = "profilDintervenantPourLesInterventionsToolStripMenuItem";
            this.profilDintervenantPourLesInterventionsToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.profilDintervenantPourLesInterventionsToolStripMenuItem.Text = "Human resource for intervention|20217";
            this.profilDintervenantPourLesInterventionsToolStripMenuItem.Click += new System.EventHandler(this.profilDintervenantPourLesInterventionsToolStripMenuItem_Click);
            // 
            // profilDeRessourcePourLesInterventionsToolStripMenuItem
            // 
            this.profilDeRessourcePourLesInterventionsToolStripMenuItem.Name = "profilDeRessourcePourLesInterventionsToolStripMenuItem";
            this.profilDeRessourcePourLesInterventionsToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.profilDeRessourcePourLesInterventionsToolStripMenuItem.Text = "Resource for intervention|20218";
            this.profilDeRessourcePourLesInterventionsToolStripMenuItem.Click += new System.EventHandler(this.profilDeRessourcePourLesInterventionsToolStripMenuItem_Click);
            // 
            // contactsPourLesInterventionsToolStripMenuItem
            // 
            this.contactsPourLesInterventionsToolStripMenuItem.Name = "contactsPourLesInterventionsToolStripMenuItem";
            this.contactsPourLesInterventionsToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.contactsPourLesInterventionsToolStripMenuItem.Text = "Intervention\'s contacts|20219";
            this.contactsPourLesInterventionsToolStripMenuItem.Click += new System.EventHandler(this.contactsPourLesInterventionsToolStripMenuItem_Click);
            // 
            // contactsPourLesPhasesDeTicketToolStripMenuItem
            // 
            this.contactsPourLesPhasesDeTicketToolStripMenuItem.Name = "contactsPourLesPhasesDeTicketToolStripMenuItem";
            this.contactsPourLesPhasesDeTicketToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.contactsPourLesPhasesDeTicketToolStripMenuItem.Text = "Ticket phase\'s contacts|20220";
            this.contactsPourLesPhasesDeTicketToolStripMenuItem.Click += new System.EventHandler(this.contactsPourLesPhasesDeTicketToolStripMenuItem_Click);
            // 
            // responsableDePhaseDeTicketToolStripMenuItem
            // 
            this.responsableDePhaseDeTicketToolStripMenuItem.Name = "responsableDePhaseDeTicketToolStripMenuItem";
            this.responsableDePhaseDeTicketToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.responsableDePhaseDeTicketToolStripMenuItem.Text = "Ticket phase\'s person in charge |20221";
            this.responsableDePhaseDeTicketToolStripMenuItem.Click += new System.EventHandler(this.responsableDePhaseDeTicketToolStripMenuItem_Click);
            // 
            // responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem
            // 
            this.responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem.Name = "responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem";
            this.responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem.Text = "Intervention planning\'s person in charge|20222";
            this.responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem.Click += new System.EventHandler(this.responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem_Click);
            // 
            // profilDeSitesLiesAunContratCLientToolStripMenuItem
            // 
            this.profilDeSitesLiesAunContratCLientToolStripMenuItem.Name = "profilDeSitesLiesAunContratCLientToolStripMenuItem";
            this.profilDeSitesLiesAunContratCLientToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.profilDeSitesLiesAunContratCLientToolStripMenuItem.Text = "Sites for contract|20223";
            this.profilDeSitesLiesAunContratCLientToolStripMenuItem.Click += new System.EventHandler(this.profilDeSitesLiesAunContratCLientToolStripMenuItem_Click);
            // 
            // profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem
            // 
            this.profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem.Name = "profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem";
            this.profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem.Text = "Sites for contract / Operation list|20224";
            this.profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem.Click += new System.EventHandler(this.profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem_Click);
            // 
            // profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem
            // 
            this.profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem.Name = "profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem";
            this.profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem.Size = new System.Drawing.Size(312, 22);
            this.profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem.Text = "Replacement operation\'s equipments|20226";
            this.profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem.Click += new System.EventHandler(this.profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem_Click);
            // 
            // profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem
            // 
            this.profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem.Name = "profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem";
            this.profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem.Size = new System.Drawing.Size(397, 22);
            this.profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem.Text = "Sites for contrat / Ticket type|20225";
            this.profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem.Click += new System.EventHandler(this.profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem_Click);
            // 
            // CFormEditionProfilElement
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_linkOperation.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionProfilElement";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
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
            this.tb_EOS.ResumeLayout(false);
            this.tb_ssprofils.ResumeLayout(false);
            this.tb_inclusion.ResumeLayout(false);
            this.tb_filtre.ResumeLayout(false);
            this.tb_formule.ResumeLayout(false);
            this.tb_Contraintes.ResumeLayout(false);
            this.tb_tester.ResumeLayout(false);
            this.m_menuArbreEO.ResumeLayout(false);
            this.m_menuArbreInclusion.ResumeLayout(false);
            this.m_menuProfilsStandard.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CProfilElement ProfilElement
		{
			get
			{
				return (CProfilElement)ObjetEdite;
			}
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
			AffecterTitre(I.T( "Operator profil|382") + " "+ProfilElement.Libelle);

			m_cmbTypeElements.Init();
			m_cmbTypeSource.Init();




			m_cmbTypeElements.TypeSelectionne = ProfilElement.TypeElements;
			m_cmbTypeSource.TypeSelectionne = ProfilElement.TypeSource;

			if ( !ProfilElement.IsNew() )
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeElements, TypeModeEdition.Autonome );
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeSource, TypeModeEdition.Autonome );
				m_cmbTypeElements.LockEdition = true;
				m_cmbTypeSource.LockEdition = true;
				m_lnkProfilStandard.Visible = false;
			}
			else
			{
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeElements, TypeModeEdition.EnableSurEdition );
				m_gestionnaireModeEdition.SetModeEdition ( m_cmbTypeSource, TypeModeEdition.EnableSurEdition );
				m_cmbTypeElements.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
				m_cmbTypeSource.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
				m_lnkProfilStandard.Visible = true;
			}

			m_filtreDynamique = ProfilElement.FiltreDynamiqueElementsSuivisPossibles;
			if (m_filtreDynamique == null)
			{
				m_filtreDynamique = ProfilElement.GetNewFiltreElements();
				m_filtreDynamique.TypeElements = m_cmbTypeElements.TypeSelectionne;
				ProfilElement.AssureVariableSourceInFiltre(m_filtreDynamique, m_cmbTypeSource.TypeSelectionne);
				m_panelFiltre.Init(m_filtreDynamique);
			}
			else
			{
				m_filtreDynamique = (CFiltreDynamique)m_filtreDynamique.Clone();
				m_panelFiltre.Init(m_filtreDynamique);
			}


			UpdateVisuAfterChangeTypes();

			m_panelListeContraintes.InitFromListeObjets(
				ProfilElement.Contraintes,
				typeof(CContrainte),
				typeof(CFormEditionContrainte),
				ProfilElement,
				"ProfilElement");

			m_panelSousProfils.InitFromListeObjets(
				ProfilElement.ProfilElementsFils,
				typeof(CProfilElement),
				typeof(CFormEditionProfilElement),
				ProfilElement,
				"ProfilElementParent");


			m_arbreProfilsParents.AfficheHierarchie(ProfilElement);

			if ( result )
				result =m_arbreEOS.InitChamps(ProfilElement);

			InitArbreInclusions();

			m_wndFormuleApplication.Formule = ProfilElement.FormuleApplication;
			m_wndFormuleIntegration.Formule = ProfilElement.FormuleIntegration;

			m_txtFormuleEOSource.Formule = ProfilElement.FormuleElementAEOSource;

			m_cmbSelectChemin.DefinitionSelectionnee = ProfilElement.ProprieteCheminToEOElement;


			return result;
		}

		//-------------------------------------------------------------------------
		private void UpdateVisuAfterChangeTypes()
		{
			Type tpElements = m_cmbTypeElements.TypeSelectionne;
			Type tpSource = m_cmbTypeSource.TypeSelectionne;


			if ( !typeof(IPossesseurRessource).IsAssignableFrom ( tpElements ) )
			{
				if ( m_tabControl.TabPages.Contains ( tb_Contraintes ) )
					m_tabControl.TabPages.Remove ( tb_Contraintes );
			}
			else
			{
				if ( !m_tabControl.TabPages.Contains ( tb_Contraintes ) )
					m_tabControl.TabPages.Add ( tb_Contraintes );
			}

			if (m_cmbTypeElements.TypeSelectionne != null)
			{
				ProfilElement.TypeElements = tpElements;
				m_filtreDynamique.TypeElements = m_cmbTypeElements.TypeSelectionne;
				if (m_cmbTypeSource.TypeSelectionne != null)
				{
					ProfilElement.AssureVariableSourceInFiltre(m_filtreDynamique, m_cmbTypeSource.TypeSelectionne);
					CElementAVariablesDynamiques elt = CElementAVariablesDynamiques.GetElementAUneVariableType(m_cmbTypeSource.TypeSelectionne, "Source");
				}
				m_panelFiltre.Init(m_filtreDynamique);
				
			}
			if (m_cmbTypeSource.TypeSelectionne == null ||
				m_cmbTypeElements.TypeSelectionne == null)
				m_panelFiltre.Visible = false;
			else
				m_panelFiltre.Visible = true;

			if (m_cmbTypeSource.SelectedValue != null)
			{
				CElementAVariablesDynamiques eltForEos = ProfilElement.GetElementInterrogePourApplication(m_cmbTypeSource.TypeSelectionne);
				m_txtFormuleEOSource.Init(eltForEos, eltForEos.GetType());
			}
			if (m_cmbTypeElements.SelectedValue != null)
			{
				m_cmbSelectChemin.Init(new CFournisseurProprietesForFiltreDynamique(),
					m_cmbTypeElements.TypeSelectionne,
					null);
			}
		
		}

		//-------------------------------------------------------------------------
		protected override CResultAErreur MAJ_Champs()
		{
			CResultAErreur result = base.MAJ_Champs();

			Hashtable tableToDelete = new Hashtable();
			Hashtable tableExistants = new Hashtable();
			foreach (CProfilElement_TypeEO rel in ProfilElement.TypesEO)
			{
				tableToDelete[rel] = true;
				tableExistants[rel.TypeEntiteOrganisationnelle] = rel;
			}
			if (result)
				result = m_arbreEOS.MajChamps();

			if (m_cmbTypeElements.TypeSelectionne == null)
			{
				result.EmpileErreur("Sélectionnez un type d'élément");
			}
			if (m_cmbTypeSource.TypeSelectionne == null)
			{
				result.EmpileErreur("Sélectionne un type source");
			}
			if (!result) return result;
			ProfilElement.TypeElements = m_cmbTypeElements.TypeSelectionne;
			ProfilElement.TypeSource = m_cmbTypeSource.TypeSelectionne;

			//Les modifs de l'arbre des profils inclus sont normallement appliquées

			//Applique le filtre
			m_filtreDynamique.TypeElements = ProfilElement.TypeElements;

			if (m_filtreDynamique.ComposantPrincipal != null)
				ProfilElement.FiltreDynamiqueElementsSuivisPossibles = m_filtreDynamique;
			else
				ProfilElement.FiltreDynamiqueElementsSuivisPossibles = null;

			if (m_wndFormuleIntegration.Formule == null)
			{
				result |= (m_wndFormuleIntegration.ResultAnalyse);
				result.EmpileErreur("Erreur dans le formule d'intégration");
			}
			else
				ProfilElement.FormuleIntegration = m_wndFormuleIntegration.Formule;

			if (m_wndFormuleApplication.Formule == null)
			{
				result |= (m_wndFormuleApplication.ResultAnalyse);
				result.EmpileErreur("Erreur dans la formule d'application");
			}
			else
				ProfilElement.FormuleApplication = m_wndFormuleApplication.Formule;

			ProfilElement.FormuleElementAEOSource = m_txtFormuleEOSource.Formule;

			ProfilElement.ProprieteCheminToEOElement = m_cmbSelectChemin.DefinitionSelectionnee;
			
			return result;
		}

		//-------------------------------------------------------------------------
		public void InitArbreInclusions()
		{
			m_arbreInclusion.Nodes.Clear();
			foreach ( CProfilElement_ProfilInclu inclusion in ProfilElement.ProfilsInclus )
			{
				TreeNode node = CreateNodeForInclusion(inclusion);
				m_arbreInclusion.Nodes.Add(node);
			}
		}

		//-------------------------------------------------------------------------
		private TreeNode CreateNodeForInclusion(CProfilElement_ProfilInclu inclusion)
		{
			TreeNode node = new TreeNode();
			node.Tag = inclusion;
			RefreshNode ( node );
			if (inclusion.ModeInclusion != EModeInclusionProfilElement.Profil)
			{
				foreach (CProfilElement_ProfilInclu sousProf in inclusion.InclusionsFilles)
				{
					TreeNode nodeFils = CreateNodeForInclusion(sousProf);
					node.Nodes.Add(nodeFils);
				}
				node.Expand();
				
			}
			return node;
		}

		//-------------------------------------------------------------------------
		private void RefreshNode(TreeNode node)
		{
			CProfilElement_ProfilInclu inc = (CProfilElement_ProfilInclu)node.Tag;
			if (inc.ModeInclusion == EModeInclusionProfilElement.Et)
				node.Text = "Et";
			else if (inc.ModeInclusion == EModeInclusionProfilElement.Ou)
				node.Text = "Ou";
			else if (inc.ProfilInclu != null)
				node.Text = inc.ProfilInclu.Libelle;
			else
				node.Text = "<Clic droit pour définir cette inclusion>";
		}





		

		//-------------------------------------------------------------------------
		private void m_panelListeActions_Load(object sender, System.EventArgs e)
		{
		
		}

		//-------------------------------------------------------------------------
		private void c2iTabControl1_SelectionChanged(object sender, EventArgs e)
		{
		}

		//-------------------------------------------------------------------------
		private TreeNode CreateAndAddNewInclusion()
		{
			CProfilElement_ProfilInclu newInc = new CProfilElement_ProfilInclu(ProfilElement.ContexteDonnee);
			newInc.CreateNewInCurrentContexte();
			if (m_nodeConcerneParLeMenu != null)
				newInc.ProfilInclusionParent = (CProfilElement_ProfilInclu)m_nodeConcerneParLeMenu.Tag;
			else
				newInc.ProfilIncluant = ProfilElement;
			TreeNode node = CreateNodeForInclusion(newInc);
			if (m_nodeConcerneParLeMenu == null)
				m_arbreInclusion.Nodes.Add(node);
			else
			{
				m_nodeConcerneParLeMenu.Nodes.Add(node);
				m_nodeConcerneParLeMenu.Expand();
			}
			return node;
		}

		//-------------------------------------------------------------------------
		private TreeNode CreateAndInsertNewInclusion()
		{
			CProfilElement_ProfilInclu newInc = new CProfilElement_ProfilInclu(ProfilElement.ContexteDonnee);
			newInc.CreateNewInCurrentContexte();
			if (m_nodeConcerneParLeMenu != null && m_nodeConcerneParLeMenu.Parent != null)
				newInc.ProfilInclusionParent = (CProfilElement_ProfilInclu)m_nodeConcerneParLeMenu.Parent.Tag;
			else
				newInc.ProfilIncluant = ProfilElement;
			TreeNode node = CreateNodeForInclusion(newInc);
			TreeNode nodeParent = m_nodeConcerneParLeMenu.Parent;
			if ( m_nodeConcerneParLeMenu != null  )
			{
				TreeNodeCollection coll = m_arbreInclusion.Nodes;
				if (m_nodeConcerneParLeMenu.Parent != null)
					coll = m_nodeConcerneParLeMenu.Parent.Nodes;
				coll.Remove ( m_nodeConcerneParLeMenu );
				CProfilElement_ProfilInclu profilInclu = (CProfilElement_ProfilInclu)m_nodeConcerneParLeMenu.Tag;
				profilInclu.ProfilIncluant = null;
				profilInclu.ProfilInclusionParent = newInc;
				node.Nodes.Add ( m_nodeConcerneParLeMenu );
			}
			if (nodeParent == null)
				m_arbreInclusion.Nodes.Add(node);
			else
				nodeParent.Nodes.Add(node);
			node.Expand();
			return node;
		}

		//-------------------------------------------------------------------------
		private void m_menuAjouterEt_Click(object sender, EventArgs e)
		{
			TreeNode node = CreateAndAddNewInclusion();
			CProfilElement_ProfilInclu newInc = (CProfilElement_ProfilInclu)node.Tag;
			newInc.ModeInclusion = EModeInclusionProfilElement.Et;
			RefreshNode(node);
		}

		//-------------------------------------------------------------------------
		private void m_menuAjouterOu_Click(object sender, EventArgs e)
		{
			TreeNode node = CreateAndAddNewInclusion();
			CProfilElement_ProfilInclu newInc = (CProfilElement_ProfilInclu)node.Tag;
			newInc.ModeInclusion = EModeInclusionProfilElement.Ou;
			RefreshNode(node);
		}

		//-------------------------------------------------------------------------
		private void m_menuAjouterProfil_Click(object sender, EventArgs e)
		{
			TreeNode node = CreateAndAddNewInclusion();
			CProfilElement_ProfilInclu newInc = (CProfilElement_ProfilInclu)node.Tag;
			newInc.ModeInclusion = EModeInclusionProfilElement.Profil;
			RefreshNode(node);
			EditeNodeInclusion ( node );
		}

		//-------------------------------------------------------------------------
		private bool EditeNodeInclusion ( TreeNode node )
		{
			if ( node == null )
				return false;
			CProfilElement_ProfilInclu inclusion = (CProfilElement_ProfilInclu)node.Tag;
			if ( inclusion.ModeInclusion != EModeInclusionProfilElement.Profil )
				return false;
			CFiltreData filtre = new CFiltreData(
				CProfilElement.c_champTypeElements + "=@1 and " +
				CProfilElement.c_champTypeSource + "=@2",
				m_cmbTypeElements.TypeSelectionne.ToString(),
				m_cmbTypeSource.TypeSelectionne.ToString());
			CListeObjetsDonnees liste = new CListeObjetsDonnees(ProfilElement.ContexteDonnee, typeof(CProfilElement), filtre);
			CProfilElement profil = (CProfilElement)CFormNavigateurPopupListe.SelectObject(new CFormListeProfilElement(liste), inclusion.ProfilInclu, "SELECT_PROFIL_IN_PROFIL");
			if (profil != null)
			{
				if (profil.Equals ( ProfilElement ) || profil.UtiliseLeProfil(ProfilElement))
				{
					CFormAlerte.Afficher(I.T("Impossible to add this profile, cyclic dependancy|30197"), EFormAlerteType.Erreur);
					return false;
				}
				inclusion.ProfilInclu = profil;
				RefreshNode(node);
			}
			return true;
		}
			
			


		//-------------------------------------------------------------------------
		private TreeNode m_nodeConcerneParLeMenu = null;
		private void m_arbreInclusion_MouseUp(object sender, MouseEventArgs e)
		{
			if ( !m_gestionnaireModeEdition.ModeEdition || e.Button != MouseButtons.Right)
				return;
			TreeViewHitTestInfo info = m_arbreInclusion.HitTest(new Point(e.X, e.Y));
			if ( info.Node == null )
			{
				m_menuSupprimerInclusion.Visible = false;
				m_menuInsererInclusion.Visible = false;
				m_menuAjouterInclusion.Visible = true;
				m_menuChangerDeProfil.Visible = false;
				m_nodeConcerneParLeMenu = null;
			}
			else
			{
				m_menuSupprimerInclusion.Visible = true;
				m_menuInsererInclusion.Visible = true;
				m_nodeConcerneParLeMenu = info.Node;
				CProfilElement_ProfilInclu incl = (CProfilElement_ProfilInclu)info.Node.Tag;
				if (incl.ModeInclusion != EModeInclusionProfilElement.Profil)
				{
					m_menuAjouterInclusion.Visible = true;
					m_menuChangerDeProfil.Visible = false;
				}
				else
				{
					m_menuAjouterInclusion.Visible = false;
					m_menuChangerDeProfil.Visible = true;
				}
			}
			m_menuArbreInclusion.Show ( m_arbreInclusion, new Point ( e.X, e.Y ));
		}

		//-------------------------------------------------------------------------
		private void m_menuInsererEt_Click(object sender, EventArgs e)
		{
			TreeNode node = CreateAndInsertNewInclusion();
			CProfilElement_ProfilInclu newInc = (CProfilElement_ProfilInclu)node.Tag;
			newInc.ModeInclusion = EModeInclusionProfilElement.Et;
			RefreshNode(node);
		}

		//-------------------------------------------------------------------------
		private void m_menuInsererOu_Click(object sender, EventArgs e)
		{
			TreeNode node = CreateAndInsertNewInclusion();
			CProfilElement_ProfilInclu newInc = (CProfilElement_ProfilInclu)node.Tag;
			newInc.ModeInclusion = EModeInclusionProfilElement.Ou;
			RefreshNode(node);
			InitArbreInclusions();
			
		}

		//-------------------------------------------------------------------------
		private void décalerLesFilsVersLeHautToolStripMenuItem_Click(object sender, EventArgs e)
		{
			TreeNode node = m_nodeConcerneParLeMenu;
			if ( node == null )
				return;
			TreeNodeCollection collection = m_arbreInclusion.Nodes;
			CProfilElement_ProfilInclu profilParent = null;
			if ( node.Parent != null )
			{
				collection = node.Parent.Nodes;
				profilParent = (CProfilElement_ProfilInclu)node.Parent.Tag;
			}
			foreach ( TreeNode nodeFils in new ArrayList(node.Nodes) )
			{
				node.Nodes.Remove ( nodeFils );
				CProfilElement_ProfilInclu profil = ( CProfilElement_ProfilInclu)nodeFils.Tag;
				if (profilParent != null)
					profil.ProfilInclusionParent = profilParent;
				else
				{
					profil.ProfilInclusionParent = null;
					profil.ProfilIncluant = ProfilElement;
				}
				collection.Add ( nodeFils );
			}
			if (node.Parent != null)
				node.Parent.Nodes.Remove(node);
			else
				m_arbreInclusion.Nodes.Remove(node);
			CProfilElement_ProfilInclu inc = (CProfilElement_ProfilInclu)node.Tag;
			inc.Delete();
		}

		//-------------------------------------------------------------------------
		private void m_menuSupprimerAvecFils_Click(object sender, EventArgs e)
		{
			TreeNode node = m_nodeConcerneParLeMenu;
			if ( node == null )
				return;
			CProfilElement_ProfilInclu profilASupprimer = (CProfilElement_ProfilInclu)node.Tag;
			CResultAErreur  result = profilASupprimer.Delete();
			if ( !result )
				CFormAlerte.Afficher ( result.Erreur );
			else
			{
				if ( m_nodeConcerneParLeMenu.Parent != null )
					m_nodeConcerneParLeMenu.Nodes.Remove ( m_nodeConcerneParLeMenu );
				else
					m_arbreInclusion.Nodes.Remove ( m_nodeConcerneParLeMenu );
			}
		}

		//---------------------------------------------------------------------
		private void m_cmbTypeElements_SelectionChangeCommitted(object sender, EventArgs e)
		{
			UpdateVisuAfterChangeTypes();
		}

		//---------------------------------------------------------------------
		private void m_cmbTypeSource_SelectionChangeCommitted(object sender, EventArgs e)
		{
			UpdateVisuAfterChangeTypes();
		}

		private void m_menuArbreInclusion_Opening(object sender, CancelEventArgs e)
		{

		}

		private void m_menuChangerDeProfil_Click(object sender, EventArgs e)
		{
			if (m_nodeConcerneParLeMenu != null)
				EditeNodeInclusion(m_nodeConcerneParLeMenu);
		}

		private CControleEditeFormule m_controleFormule = null;
		private void m_wndFormuleIntegration_Enter(object sender, EventArgs e)
		{
			if (m_wndFormuleIntegration != m_controleFormule)
			{
				m_wndFormuleApplication.BackColor = Color.White;
				m_wndFormuleIntegration.BackColor = Color.LightGreen;
				m_controleFormule = m_wndFormuleIntegration;
				CElementAVariablesDynamiques eltAVariables = ProfilElement.GetElementInterrogePourIntegration(m_cmbTypeElements.TypeSelectionne, m_cmbTypeSource.TypeSelectionne);
				m_wndAideFormule.FournisseurProprietes = eltAVariables;
				m_wndFormuleIntegration.Init(eltAVariables, typeof(CElementAVariablesDynamiques));
				m_wndAideFormule.ObjetInterroge = typeof(CElementAVariablesDynamiques);
			}
			
		}

		private void m_wndFormuleApplication_Enter(object sender, EventArgs e)
		{
			if (m_wndFormuleApplication != m_controleFormule)
			{
				m_wndFormuleIntegration.BackColor = Color.White;
				m_wndFormuleApplication.BackColor = Color.LightGreen;
				m_controleFormule = m_wndFormuleApplication;
				CElementAVariablesDynamiques eltAVariables = ProfilElement.GetElementInterrogePourApplication(m_cmbTypeSource.TypeSelectionne);
				m_wndAideFormule.FournisseurProprietes = eltAVariables;
				m_wndFormuleApplication.Init(eltAVariables, typeof(CElementAVariablesDynamiques));
				m_wndAideFormule.ObjetInterroge = typeof(CElementAVariablesDynamiques);
			}
		}

		private void m_wndAideFormule_OnSendCommande(string strCommande, int nPosCurseur)
		{
			if (m_controleFormule != null)
			{
				m_wndAideFormule.InsereInTextBox(m_controleFormule, nPosCurseur, strCommande);
			}
		}


		private CObjetDonneeAIdNumerique m_objetDeTest = null;
		private void m_lnkSelectSourceTest_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			SelectObjetDeTest();			
		}

		//------------------------------------------------------------
		private void SelectObjetDeTest()
		{
			if (m_cmbTypeSource.TypeSelectionne == null)
			{
				CFormAlerte.Afficher(I.T("Selec a source type|30198"), EFormAlerteType.Exclamation);
				return;
			}
			m_objetDeTest = (CObjetDonneeAIdNumerique)CFormSelectUnObjetDonnee.SelectObjetDonnee(
                I.T("Select an element for test|20735"),
                m_cmbTypeSource.TypeSelectionne);
		}

		//------------------------------------------------------------
		private void m_lnkTester_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (m_gestionnaireModeEdition.ModeEdition)
			{
				CResultAErreur result = MAJ_Champs();
				if (!result)
				{
					CFormAlerte.Afficher(result.Erreur);
					return;
				}
			}
			if(  m_objetDeTest == null || m_objetDeTest.GetType() != m_cmbTypeSource.TypeSelectionne ) 
			{
				SelectObjetDeTest();
			}
			if ( m_objetDeTest == null )
				return;

			CListeObjetsDonnees liste = ProfilElement.GetElementsForSource ( m_objetDeTest, null );
			m_wndListeTest.ListeSource = liste;
			m_wndListeTest.Refresh();

		}

		//-------------------------------------------------------------------
		private void profilDintervenantPourLesInterventionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_cmbTypeElements.TypeSelectionne = typeof(CActeur);
			m_cmbTypeSource.TypeSelectionne = typeof(CIntervention);
			UpdateVisuAfterChangeTypes();
		}

		//-------------------------------------------------------------------
		private void m_lnkProfilStandard_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			m_menuProfilsStandard.Show(m_lnkProfilStandard, new Point(0, m_lnkProfilStandard.Height));
		}

		private void profilDeRessourcePourLesInterventionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_cmbTypeElements.TypeSelectionne = typeof(CRessourceMaterielle);
			m_cmbTypeSource.TypeSelectionne = typeof(CIntervention);
			UpdateVisuAfterChangeTypes();
		}

		private void contactsPourLesInterventionsToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_cmbTypeElements.TypeSelectionne = typeof(CActeur);
			m_cmbTypeSource.TypeSelectionne = typeof(CIntervention);
			UpdateVisuAfterChangeTypes();
		}

		private void contactsPourLesPhasesDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_cmbTypeElements.TypeSelectionne = typeof(CActeur);
			m_cmbTypeSource.TypeSelectionne = typeof(CPhaseTicket);
			UpdateVisuAfterChangeTypes();
		}

		private void responsableDePhaseDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_cmbTypeElements.TypeSelectionne = typeof(CDonneesActeurUtilisateur);
			m_cmbTypeSource.TypeSelectionne = typeof(CPhaseTicket);
			UpdateVisuAfterChangeTypes();
		}

		private void responsablePlanificationEtPréplanificationDinterventionToolStripMenuItem_Click(object sender, EventArgs e)
		{
			m_cmbTypeElements.TypeSelectionne = typeof(CDonneesActeurUtilisateur);
			m_cmbTypeSource.TypeSelectionne = typeof(CIntervention);
			UpdateVisuAfterChangeTypes();
        }

        private void profilDeSitesLiesAunContratCLientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_cmbTypeElements.TypeSelectionne = typeof(CSite);
            m_cmbTypeSource.TypeSelectionne = typeof(CContrat);
            UpdateVisuAfterChangeTypes();
        }

        private void profilDeSitesLiesAUnContratEtUneListeDOperationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_cmbTypeElements.TypeSelectionne = typeof(CSite);
            m_cmbTypeSource.TypeSelectionne = typeof(CContrat_ListeOperations);
            UpdateVisuAfterChangeTypes();
        }

        private void profilDEquipementsDeRemplacementPourUneOperationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_cmbTypeElements.TypeSelectionne = typeof(CEquipement);
            m_cmbTypeSource.TypeSelectionne = typeof(CIntervention);
            UpdateVisuAfterChangeTypes();

        }

        private void profilDeSitesLiésÀUnContratEtUnTypeDeTicketToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_cmbTypeElements.TypeSelectionne = typeof(CSite);
            m_cmbTypeSource.TypeSelectionne = typeof(CTypeTicketContrat);
            UpdateVisuAfterChangeTypes();
        }

		
	}
}

