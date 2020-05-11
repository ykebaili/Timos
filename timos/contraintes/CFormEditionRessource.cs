using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using sc2i.data.dynamic;
using sc2i.data;
using sc2i.win32.navigation;
using sc2i.win32.data.navigation;
using sc2i.common;
using sc2i.win32.data;
using sc2i.win32.common;
using timos.acteurs;

using timos.data;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CRessourceMaterielle))]
    public class CFormEditionRessource : CFormEditionStdTimos
    {
        private C2iPanelOmbre c2iPanelOmbre1;
        private C2iTextBox m_txtBoxLibelle;
        private Label label1;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage pageInfoEmplacement;
        private C2iTextBox c2iTextBox1;
        private CComboBoxLinkListeObjetsDonnees m_cmbxTypeRessource;
        private Label m_labelTypeCle;
        private Label m_labelSN;
        private C2iTextBox m_txtSerialNumber;
        private Label m_labelLibelle;
        private Crownwood.Magic.Controls.TabPage pageChampsCustom;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_PanelChampsCustom;
        private Label m_lblMoreInfo;
        private SplitContainer m_splitContainer;
        private Label m_lblChoixEmplacement;
        private Crownwood.Magic.Controls.TabPage pageAttribut;
        private ListViewAutoFilled m_listeAttributs;
        private ListViewAutoFilledColumn colAttrib;
        private CWndLinkStd m_lnkSupprimer;
        private CWndLinkStd m_lnkAjouterAttribut;
        private C2iTextBox m_txtAttributLibre;
        private Label m_lblSaisie;
        private LinkLabel m_lnkEmplacementDescription;
        private CPanelListeSpeedStandard m_panelMouvements;
        private Label label6;
        private LinkLabel m_lnkDeplacerRessource;
        private Crownwood.Magic.Controls.TabPage pageContraintes;
        private Label m_lblSelect;
        private CWndLinkStd m_LinkSupprCont;
        private CWndLinkStd m_LinkAjoutCont;
        private ListViewAutoFilled m_listeContraintes;
        private ListViewAutoFilledColumn colLibelle;
        private C2iTextBoxSelectionne m_txtSelectContrainte;
        private Label label2;
        private CComboBoxListeObjetsDonnees m_cmbxSelectAttributTypeCont;
        private Label label4;
        private CWndLinkStd m_lnkAjouterAttributTypeCont;
        private Panel m_panelEditionAttribut;
        private C2iTextBox m_txtModifierAttributLibelle;
        private Label label5;
        private CExtLinkField m_extLinkEditionAttribut;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionAttribut;
        private Crownwood.Magic.Controls.TabPage pageAgenda;
        private timos.win32.composants.CcontrolAgenda m_controlAgenda;
        private TreeView m_arbreRessourceParent;
        private Crownwood.Magic.Controls.TabPage pageRessourcesContenus;
        private CPanelListeSpeedStandard m_panelListeRessourceContenues;
        private Crownwood.Magic.Controls.TabPage pageEO;
        private CPanelAffectationEO m_panelAffectationEO;
        private Label label7;
		private CComboboxAutoFilled m_cmbxEtatRessource;
        private Panel panel2;
        private Panel panel1;
        private Panel panel4;
        private Panel panel3;
        private Label label3;
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CFormEditionRessource()
            :base()
        {
            InitializeComponent();
        }

        public CFormEditionRessource(CRessourceMaterielle Ressource)
            : base(Ressource)
        {
            InitializeComponent();
        }

        public CFormEditionRessource(CRessourceMaterielle Ressource, CListeObjetsDonnees liste)
            : base(Ressource, liste)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionRessource));
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_txtSerialNumber = new sc2i.win32.common.C2iTextBox();
            this.m_labelSN = new System.Windows.Forms.Label();
            this.m_labelLibelle = new System.Windows.Forms.Label();
            this.m_labelTypeCle = new System.Windows.Forms.Label();
            this.m_txtBoxLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_cmbxTypeRessource = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelChampsCustom = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.pageInfoEmplacement = new Crownwood.Magic.Controls.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_panelMouvements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_arbreRessourceParent = new System.Windows.Forms.TreeView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_splitContainer = new System.Windows.Forms.SplitContainer();
            this.m_cmbxEtatRessource = new sc2i.win32.common.CComboboxAutoFilled();
            this.label7 = new System.Windows.Forms.Label();
            this.m_lnkDeplacerRessource = new System.Windows.Forms.LinkLabel();
            this.m_lnkEmplacementDescription = new System.Windows.Forms.LinkLabel();
            this.m_lblChoixEmplacement = new System.Windows.Forms.Label();
            this.m_lblMoreInfo = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.pageRessourcesContenus = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeRessourceContenues = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.pageEO = new Crownwood.Magic.Controls.TabPage();
            this.m_panelAffectationEO = new timos.CPanelAffectationEO();
            this.pageAttribut = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditionAttribut = new System.Windows.Forms.Panel();
            this.m_txtModifierAttributLibelle = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cmbxSelectAttributTypeCont = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lnkAjouterAttributTypeCont = new sc2i.win32.common.CWndLinkStd();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lblSaisie = new System.Windows.Forms.Label();
            this.m_lnkSupprimer = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAjouterAttribut = new sc2i.win32.common.CWndLinkStd();
            this.m_txtAttributLibre = new sc2i.win32.common.C2iTextBox();
            this.m_listeAttributs = new sc2i.win32.common.ListViewAutoFilled();
            this.colAttrib = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.pageContraintes = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_listeContraintes = new sc2i.win32.common.ListViewAutoFilled();
            this.colLibelle = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_LinkSupprCont = new sc2i.win32.common.CWndLinkStd();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lblSelect = new System.Windows.Forms.Label();
            this.m_txtSelectContrainte = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_LinkAjoutCont = new sc2i.win32.common.CWndLinkStd();
            this.pageAgenda = new Crownwood.Magic.Controls.TabPage();
            this.m_controlAgenda = new timos.win32.composants.CcontrolAgenda();
            this.m_gestionnaireEditionAttribut = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_extLinkEditionAttribut = new sc2i.win32.common.CExtLinkField();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.pageChampsCustom.SuspendLayout();
            this.pageInfoEmplacement.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.m_splitContainer.Panel1.SuspendLayout();
            this.m_splitContainer.Panel2.SuspendLayout();
            this.m_splitContainer.SuspendLayout();
            this.pageRessourcesContenus.SuspendLayout();
            this.pageEO.SuspendLayout();
            this.pageAttribut.SuspendLayout();
            this.m_panelEditionAttribut.SuspendLayout();
            this.pageContraintes.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pageAgenda.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelNavigation, "");
            this.m_panelNavigation.Location = new System.Drawing.Point(694, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelCle, "");
            this.m_panelCle.Location = new System.Drawing.Point(610, 0);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelMenu, "");
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnHistorique, "");
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_txtSerialNumber);
            this.c2iPanelOmbre1.Controls.Add(this.m_labelSN);
            this.c2iPanelOmbre1.Controls.Add(this.m_labelLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.m_labelTypeCle);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtBoxLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbxTypeRessource);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkEditionAttribut.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 51);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(611, 94);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4003;
            // 
            // m_txtSerialNumber
            // 
            this.m_txtSerialNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtSerialNumber, "");
            this.m_extLinkField.SetLinkField(this.m_txtSerialNumber, "SerialNumber");
            this.m_txtSerialNumber.Location = new System.Drawing.Point(140, 52);
            this.m_txtSerialNumber.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSerialNumber, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSerialNumber, "");
            this.m_txtSerialNumber.Name = "m_txtSerialNumber";
            this.m_txtSerialNumber.Size = new System.Drawing.Size(399, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtSerialNumber, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSerialNumber, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSerialNumber.TabIndex = 4007;
            this.m_txtSerialNumber.Text = "[SerialNumber]";
            // 
            // m_labelSN
            // 
            this.m_extLinkField.SetLinkField(this.m_labelSN, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_labelSN, "");
            this.m_labelSN.Location = new System.Drawing.Point(5, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelSN, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelSN, "");
            this.m_labelSN.Name = "m_labelSN";
            this.m_labelSN.Size = new System.Drawing.Size(129, 14);
            this.m_extStyle.SetStyleBackColor(this.m_labelSN, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelSN, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelSN.TabIndex = 4006;
            this.m_labelSN.Text = "Serial Number|223";
            // 
            // m_labelLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_labelLibelle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_labelLibelle, "");
            this.m_labelLibelle.Location = new System.Drawing.Point(5, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelLibelle, "");
            this.m_labelLibelle.Name = "m_labelLibelle";
            this.m_labelLibelle.Size = new System.Drawing.Size(129, 14);
            this.m_extStyle.SetStyleBackColor(this.m_labelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelLibelle.TabIndex = 4008;
            this.m_labelLibelle.Text = "Label|50";
            // 
            // m_labelTypeCle
            // 
            this.m_extLinkField.SetLinkField(this.m_labelTypeCle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_labelTypeCle, "");
            this.m_labelTypeCle.Location = new System.Drawing.Point(5, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelTypeCle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelTypeCle, "");
            this.m_labelTypeCle.Name = "m_labelTypeCle";
            this.m_labelTypeCle.Size = new System.Drawing.Size(129, 14);
            this.m_extStyle.SetStyleBackColor(this.m_labelTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelTypeCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelTypeCle.TabIndex = 4005;
            this.m_labelTypeCle.Text = "Resource Type|252";
            // 
            // m_txtBoxLibelle
            // 
            this.m_txtBoxLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtBoxLibelle, "");
            this.m_extLinkField.SetLinkField(this.m_txtBoxLibelle, "Libelle");
            this.m_txtBoxLibelle.Location = new System.Drawing.Point(140, 5);
            this.m_txtBoxLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtBoxLibelle, "");
            this.m_txtBoxLibelle.Name = "m_txtBoxLibelle";
            this.m_txtBoxLibelle.Size = new System.Drawing.Size(399, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxLibelle.TabIndex = 3;
            this.m_txtBoxLibelle.Text = "[Label]|30324";
            // 
            // m_cmbxTypeRessource
            // 
            this.m_cmbxTypeRessource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxTypeRessource.ComportementLinkStd = true;
            this.m_cmbxTypeRessource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxTypeRessource.ElementSelectionne = null;
            this.m_cmbxTypeRessource.FormattingEnabled = true;
            this.m_cmbxTypeRessource.IsLink = true;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeRessource, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_cmbxTypeRessource, "");
            this.m_cmbxTypeRessource.LinkProperty = "";
            this.m_cmbxTypeRessource.ListDonnees = null;
            this.m_cmbxTypeRessource.Location = new System.Drawing.Point(140, 28);
            this.m_cmbxTypeRessource.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeRessource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxTypeRessource, "");
            this.m_cmbxTypeRessource.Name = "m_cmbxTypeRessource";
            this.m_cmbxTypeRessource.NullAutorise = false;
            this.m_cmbxTypeRessource.ProprieteAffichee = null;
            this.m_cmbxTypeRessource.ProprieteParentListeObjets = null;
            this.m_cmbxTypeRessource.SelectionneurParent = null;
            this.m_cmbxTypeRessource.Size = new System.Drawing.Size(399, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeRessource.TabIndex = 4004;
            this.m_cmbxTypeRessource.TextNull = I.T("(empty)|30195");
            this.m_cmbxTypeRessource.Tri = true;
            this.m_cmbxTypeRessource.TypeFormEdition = null;
            this.m_cmbxTypeRessource.SelectedValueChanged += new System.EventHandler(this.m_cmbxTypeRessource_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Label|50";
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
            this.m_extLinkEditionAttribut.SetLinkField(this.m_tabControl, "");
            this.m_tabControl.Location = new System.Drawing.Point(0, 151);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 4;
            this.m_tabControl.SelectedTab = this.pageAttribut;
            this.m_tabControl.Size = new System.Drawing.Size(830, 378);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4005;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageChampsCustom,
            this.pageInfoEmplacement,
            this.pageRessourcesContenus,
            this.pageEO,
            this.pageAttribut,
            this.pageContraintes,
            this.pageAgenda});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageChampsCustom
            // 
            this.pageChampsCustom.Controls.Add(this.m_PanelChampsCustom);
            this.m_extLinkEditionAttribut.SetLinkField(this.pageChampsCustom, "");
            this.m_extLinkField.SetLinkField(this.pageChampsCustom, "");
            this.pageChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageChampsCustom, "");
            this.pageChampsCustom.Name = "pageChampsCustom";
            this.pageChampsCustom.Selected = false;
            this.pageChampsCustom.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageChampsCustom.TabIndex = 11;
            this.pageChampsCustom.Title = "Form|60";
            // 
            // m_PanelChampsCustom
            // 
            this.m_PanelChampsCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_PanelChampsCustom.BoldSelectedPage = true;
            this.m_PanelChampsCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_PanelChampsCustom.ElementEdite = null;
            this.m_PanelChampsCustom.ForeColor = System.Drawing.Color.Black;
            this.m_PanelChampsCustom.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_PanelChampsCustom, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_PanelChampsCustom, "");
            this.m_PanelChampsCustom.Location = new System.Drawing.Point(0, 0);
            this.m_PanelChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelChampsCustom, "");
            this.m_PanelChampsCustom.Name = "m_PanelChampsCustom";
            this.m_PanelChampsCustom.Ombre = false;
            this.m_PanelChampsCustom.PositionTop = true;
            this.m_PanelChampsCustom.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.m_PanelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_PanelChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_PanelChampsCustom.TabIndex = 0;
            this.m_PanelChampsCustom.TextColor = System.Drawing.Color.Black;
            // 
            // pageInfoEmplacement
            // 
            this.pageInfoEmplacement.Controls.Add(this.panel4);
            this.pageInfoEmplacement.Controls.Add(this.m_arbreRessourceParent);
            this.pageInfoEmplacement.Controls.Add(this.panel3);
            this.m_extLinkEditionAttribut.SetLinkField(this.pageInfoEmplacement, "");
            this.m_extLinkField.SetLinkField(this.pageInfoEmplacement, "");
            this.pageInfoEmplacement.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageInfoEmplacement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageInfoEmplacement, "");
            this.pageInfoEmplacement.Name = "pageInfoEmplacement";
            this.pageInfoEmplacement.Selected = false;
            this.pageInfoEmplacement.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.pageInfoEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageInfoEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageInfoEmplacement.TabIndex = 10;
            this.pageInfoEmplacement.Title = "Location|228";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.m_panelMouvements);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.panel4, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.panel4, "");
            this.panel4.Location = new System.Drawing.Point(0, 156);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel4, "");
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(814, 181);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 4026;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Beige;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(84, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(162, 19);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label6.TabIndex = 4023;
            this.label6.Text = "Movements|30048";
            // 
            // m_panelMouvements
            // 
            this.m_panelMouvements.AllowArbre = true;
            this.m_panelMouvements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelMouvements.BoutonAjouterVisible = false;
            this.m_panelMouvements.BoutonExporterVisible = false;
            this.m_panelMouvements.BoutonModifierVisible = false;
            this.m_panelMouvements.BoutonSupprimerVisible = false;
            this.m_panelMouvements.CausesValidation = false;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Name";
            glColumn4.Propriete = "DateMouvement";
            glColumn4.Text = "Date|246";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Namex";
            glColumn5.Propriete = "EmplacementOrigine.DescriptionElement";
            glColumn5.Text = "Origin|654";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 300;
            this.m_panelMouvements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn4,
            glColumn5});
            this.m_panelMouvements.ContexteUtilisation = "";
            this.m_panelMouvements.ControlFiltreStandard = null;
            this.m_panelMouvements.ElementSelectionne = null;
            this.m_panelMouvements.EnableCustomisation = true;
            this.m_panelMouvements.FiltreDeBase = null;
            this.m_panelMouvements.FiltreDeBaseEnAjout = false;
            this.m_panelMouvements.FiltrePrefere = null;
            this.m_panelMouvements.FiltreRapide = null;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelMouvements, "");
            this.m_extLinkField.SetLinkField(this.m_panelMouvements, "");
            this.m_panelMouvements.ListeObjets = null;
            this.m_panelMouvements.Location = new System.Drawing.Point(5, 3);
            this.m_panelMouvements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMouvements, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMouvements.ModeQuickSearch = false;
            this.m_panelMouvements.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelMouvements, "");
            this.m_panelMouvements.MultiSelect = false;
            this.m_panelMouvements.Name = "m_panelMouvements";
            this.m_panelMouvements.Navigateur = null;
            this.m_panelMouvements.ProprieteObjetAEditer = null;
            this.m_panelMouvements.QuickSearchText = "";
            this.m_panelMouvements.Size = new System.Drawing.Size(796, 181);
            this.m_extStyle.SetStyleBackColor(this.m_panelMouvements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMouvements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMouvements.TabIndex = 4021;
            this.m_panelMouvements.TrierAuClicSurEnteteColonne = true;
            // 
            // m_arbreRessourceParent
            // 
            this.m_arbreRessourceParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_arbreRessourceParent, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_arbreRessourceParent, "");
            this.m_arbreRessourceParent.Location = new System.Drawing.Point(0, 103);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreRessourceParent, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_arbreRessourceParent, "");
            this.m_arbreRessourceParent.Name = "m_arbreRessourceParent";
            this.m_arbreRessourceParent.Size = new System.Drawing.Size(814, 53);
            this.m_extStyle.SetStyleBackColor(this.m_arbreRessourceParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreRessourceParent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreRessourceParent.TabIndex = 4024;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_splitContainer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkEditionAttribut.SetLinkField(this.panel3, "");
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 103);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 4025;
            // 
            // m_splitContainer
            // 
            this.m_splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_splitContainer, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_splitContainer, "");
            this.m_splitContainer.Location = new System.Drawing.Point(9, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer, "");
            this.m_splitContainer.Name = "m_splitContainer";
            // 
            // m_splitContainer.Panel1
            // 
            this.m_splitContainer.Panel1.Controls.Add(this.m_cmbxEtatRessource);
            this.m_splitContainer.Panel1.Controls.Add(this.label7);
            this.m_splitContainer.Panel1.Controls.Add(this.m_lnkDeplacerRessource);
            this.m_splitContainer.Panel1.Controls.Add(this.m_lnkEmplacementDescription);
            this.m_splitContainer.Panel1.Controls.Add(this.m_lblChoixEmplacement);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_splitContainer.Panel1, "");
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel1, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_splitContainer.Panel2
            // 
            this.m_splitContainer.Panel2.Controls.Add(this.m_lblMoreInfo);
            this.m_splitContainer.Panel2.Controls.Add(this.c2iTextBox1);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_splitContainer.Panel2, "");
            this.m_extLinkField.SetLinkField(this.m_splitContainer.Panel2, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_splitContainer.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_splitContainer.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.Size = new System.Drawing.Size(799, 94);
            this.m_splitContainer.SplitterDistance = 399;
            this.m_extStyle.SetStyleBackColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_splitContainer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitContainer.TabIndex = 3;
            // 
            // m_cmbxEtatRessource
            // 
            this.m_cmbxEtatRessource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbxEtatRessource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxEtatRessource.FormattingEnabled = true;
            this.m_cmbxEtatRessource.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxEtatRessource, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_cmbxEtatRessource, "");
            this.m_cmbxEtatRessource.ListDonnees = null;
            this.m_cmbxEtatRessource.Location = new System.Drawing.Point(155, 3);
            this.m_cmbxEtatRessource.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxEtatRessource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxEtatRessource, "");
            this.m_cmbxEtatRessource.Name = "m_cmbxEtatRessource";
            this.m_cmbxEtatRessource.NullAutorise = false;
            this.m_cmbxEtatRessource.ProprieteAffichee = null;
            this.m_cmbxEtatRessource.Size = new System.Drawing.Size(237, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxEtatRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxEtatRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxEtatRessource.TabIndex = 4026;
            this.m_cmbxEtatRessource.TextNull = I.T("(empty)|30195");
            this.m_cmbxEtatRessource.Tri = true;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(8, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4025;
            this.label7.Text = "Resource Status|394";
            // 
            // m_lnkDeplacerRessource
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkDeplacerRessource, "");
            this.m_extLinkField.SetLinkField(this.m_lnkDeplacerRessource, "");
            this.m_lnkDeplacerRessource.Location = new System.Drawing.Point(8, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDeplacerRessource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDeplacerRessource, "");
            this.m_lnkDeplacerRessource.Name = "m_lnkDeplacerRessource";
            this.m_lnkDeplacerRessource.Size = new System.Drawing.Size(140, 14);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDeplacerRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDeplacerRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDeplacerRessource.TabIndex = 4024;
            this.m_lnkDeplacerRessource.TabStop = true;
            this.m_lnkDeplacerRessource.Text = "Move this Resource|319";
            this.m_lnkDeplacerRessource.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDeplacer_LinkClicked);
            // 
            // m_lnkEmplacementDescription
            // 
            this.m_lnkEmplacementDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_lnkEmplacementDescription, "Emplacement.DescriptionElement");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkEmplacementDescription, "");
            this.m_lnkEmplacementDescription.Location = new System.Drawing.Point(30, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEmplacementDescription, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkEmplacementDescription, "");
            this.m_lnkEmplacementDescription.Name = "m_lnkEmplacementDescription";
            this.m_lnkEmplacementDescription.Size = new System.Drawing.Size(362, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEmplacementDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEmplacementDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEmplacementDescription.TabIndex = 2;
            this.m_lnkEmplacementDescription.TabStop = true;
            this.m_lnkEmplacementDescription.Text = "[Emplacement.DescriptionElement]";
            this.m_lnkEmplacementDescription.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEmplacementDescription_LinkClicked);
            // 
            // m_lblChoixEmplacement
            // 
            this.m_extLinkField.SetLinkField(this.m_lblChoixEmplacement, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblChoixEmplacement, "");
            this.m_lblChoixEmplacement.Location = new System.Drawing.Point(8, 44);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblChoixEmplacement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblChoixEmplacement, "");
            this.m_lblChoixEmplacement.Name = "m_lblChoixEmplacement";
            this.m_lblChoixEmplacement.Size = new System.Drawing.Size(178, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lblChoixEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblChoixEmplacement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblChoixEmplacement.TabIndex = 1;
            this.m_lblChoixEmplacement.Text = "The Resource is located in:|266";
            // 
            // m_lblMoreInfo
            // 
            this.m_lblMoreInfo.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblMoreInfo, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblMoreInfo, "");
            this.m_lblMoreInfo.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblMoreInfo, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblMoreInfo, "");
            this.m_lblMoreInfo.Name = "m_lblMoreInfo";
            this.m_lblMoreInfo.Size = new System.Drawing.Size(150, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblMoreInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMoreInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMoreInfo.TabIndex = 1;
            this.m_lblMoreInfo.Text = "More location information|264";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkEditionAttribut.SetLinkField(this.c2iTextBox1, "");
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "InfoEmplacement");
            this.c2iTextBox1.Location = new System.Drawing.Point(6, 16);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(383, 71);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 0;
            this.c2iTextBox1.Text = "[InfoEmplacement]";
            // 
            // pageRessourcesContenus
            // 
            this.pageRessourcesContenus.Controls.Add(this.m_panelListeRessourceContenues);
            this.m_extLinkEditionAttribut.SetLinkField(this.pageRessourcesContenus, "");
            this.m_extLinkField.SetLinkField(this.pageRessourcesContenus, "");
            this.pageRessourcesContenus.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageRessourcesContenus, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageRessourcesContenus, "");
            this.pageRessourcesContenus.Name = "pageRessourcesContenus";
            this.pageRessourcesContenus.Selected = false;
            this.pageRessourcesContenus.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.pageRessourcesContenus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageRessourcesContenus, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageRessourcesContenus.TabIndex = 15;
            this.pageRessourcesContenus.Title = "Contains|528";
            // 
            // m_panelListeRessourceContenues
            // 
            this.m_panelListeRessourceContenues.AllowArbre = true;
            this.m_panelListeRessourceContenues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "colRessourceContenueLibelle";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Label|50";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 100;
            this.m_panelListeRessourceContenues.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListeRessourceContenues.ContexteUtilisation = "";
            this.m_panelListeRessourceContenues.ControlFiltreStandard = null;
            this.m_panelListeRessourceContenues.ElementSelectionne = null;
            this.m_panelListeRessourceContenues.EnableCustomisation = true;
            this.m_panelListeRessourceContenues.FiltreDeBase = null;
            this.m_panelListeRessourceContenues.FiltreDeBaseEnAjout = false;
            this.m_panelListeRessourceContenues.FiltrePrefere = null;
            this.m_panelListeRessourceContenues.FiltreRapide = null;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelListeRessourceContenues, "");
            this.m_extLinkField.SetLinkField(this.m_panelListeRessourceContenues, "");
            this.m_panelListeRessourceContenues.ListeObjets = null;
            this.m_panelListeRessourceContenues.Location = new System.Drawing.Point(3, 3);
            this.m_panelListeRessourceContenues.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeRessourceContenues, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeRessourceContenues.ModeQuickSearch = false;
            this.m_panelListeRessourceContenues.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeRessourceContenues, "");
            this.m_panelListeRessourceContenues.MultiSelect = false;
            this.m_panelListeRessourceContenues.Name = "m_panelListeRessourceContenues";
            this.m_panelListeRessourceContenues.Navigateur = null;
            this.m_panelListeRessourceContenues.ProprieteObjetAEditer = null;
            this.m_panelListeRessourceContenues.QuickSearchText = "";
            this.m_panelListeRessourceContenues.Size = new System.Drawing.Size(808, 331);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeRessourceContenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeRessourceContenues, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeRessourceContenues.TabIndex = 0;
            this.m_panelListeRessourceContenues.TrierAuClicSurEnteteColonne = true;
            // 
            // pageEO
            // 
            this.pageEO.Controls.Add(this.m_panelAffectationEO);
            this.m_extLinkEditionAttribut.SetLinkField(this.pageEO, "");
            this.m_extLinkField.SetLinkField(this.pageEO, "");
            this.pageEO.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageEO, "");
            this.pageEO.Name = "pageEO";
            this.pageEO.Selected = false;
            this.pageEO.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.pageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageEO.TabIndex = 16;
            this.pageEO.Title = "Organizational Entities|53";
            // 
            // m_panelAffectationEO
            // 
            this.m_panelAffectationEO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelAffectationEO, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelAffectationEO, "");
            this.m_panelAffectationEO.Location = new System.Drawing.Point(8, 8);
            this.m_panelAffectationEO.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAffectationEO, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelAffectationEO, "");
            this.m_panelAffectationEO.Name = "m_panelAffectationEO";
            this.m_panelAffectationEO.Size = new System.Drawing.Size(799, 316);
            this.m_extStyle.SetStyleBackColor(this.m_panelAffectationEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAffectationEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAffectationEO.TabIndex = 0;
            // 
            // pageAttribut
            // 
            this.pageAttribut.Controls.Add(this.m_panelEditionAttribut);
            this.pageAttribut.Controls.Add(this.m_cmbxSelectAttributTypeCont);
            this.pageAttribut.Controls.Add(this.label4);
            this.pageAttribut.Controls.Add(this.m_lnkAjouterAttributTypeCont);
            this.pageAttribut.Controls.Add(this.label3);
            this.pageAttribut.Controls.Add(this.m_lblSaisie);
            this.pageAttribut.Controls.Add(this.m_lnkSupprimer);
            this.pageAttribut.Controls.Add(this.m_lnkAjouterAttribut);
            this.pageAttribut.Controls.Add(this.m_txtAttributLibre);
            this.pageAttribut.Controls.Add(this.m_listeAttributs);
            this.m_extLinkEditionAttribut.SetLinkField(this.pageAttribut, "");
            this.m_extLinkField.SetLinkField(this.pageAttribut, "");
            this.pageAttribut.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageAttribut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageAttribut, "");
            this.pageAttribut.Name = "pageAttribut";
            this.pageAttribut.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.pageAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageAttribut.TabIndex = 12;
            this.pageAttribut.Title = "Attribute management|280";
            // 
            // m_panelEditionAttribut
            // 
            this.m_panelEditionAttribut.Controls.Add(this.m_txtModifierAttributLibelle);
            this.m_panelEditionAttribut.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.m_panelEditionAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelEditionAttribut, "");
            this.m_panelEditionAttribut.Location = new System.Drawing.Point(397, 120);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionAttribut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEditionAttribut, "");
            this.m_panelEditionAttribut.Name = "m_panelEditionAttribut";
            this.m_panelEditionAttribut.Size = new System.Drawing.Size(276, 129);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionAttribut.TabIndex = 4018;
            // 
            // m_txtModifierAttributLibelle
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtModifierAttributLibelle, "Libelle");
            this.m_extLinkField.SetLinkField(this.m_txtModifierAttributLibelle, "");
            this.m_txtModifierAttributLibelle.Location = new System.Drawing.Point(8, 26);
            this.m_txtModifierAttributLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtModifierAttributLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtModifierAttributLibelle, "");
            this.m_txtModifierAttributLibelle.Name = "m_txtModifierAttributLibelle";
            this.m_txtModifierAttributLibelle.Size = new System.Drawing.Size(252, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtModifierAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtModifierAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtModifierAttributLibelle.TabIndex = 2;
            this.m_txtModifierAttributLibelle.Text = "[Label]|30324";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(5, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(182, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Edit attribute Label|375";
            // 
            // m_cmbxSelectAttributTypeCont
            // 
            this.m_cmbxSelectAttributTypeCont.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxSelectAttributTypeCont.ElementSelectionne = null;
            this.m_cmbxSelectAttributTypeCont.FormattingEnabled = true;
            this.m_cmbxSelectAttributTypeCont.IsLink = false;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_cmbxSelectAttributTypeCont, "");
            this.m_extLinkField.SetLinkField(this.m_cmbxSelectAttributTypeCont, "");
            this.m_cmbxSelectAttributTypeCont.ListDonnees = null;
            this.m_cmbxSelectAttributTypeCont.Location = new System.Drawing.Point(355, 41);
            this.m_cmbxSelectAttributTypeCont.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxSelectAttributTypeCont, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxSelectAttributTypeCont, "");
            this.m_cmbxSelectAttributTypeCont.Name = "m_cmbxSelectAttributTypeCont";
            this.m_cmbxSelectAttributTypeCont.NullAutorise = false;
            this.m_cmbxSelectAttributTypeCont.ProprieteAffichee = null;
            this.m_cmbxSelectAttributTypeCont.ProprieteParentListeObjets = null;
            this.m_cmbxSelectAttributTypeCont.SelectionneurParent = null;
            this.m_cmbxSelectAttributTypeCont.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxSelectAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxSelectAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxSelectAttributTypeCont.TabIndex = 4017;
            this.m_cmbxSelectAttributTypeCont.TextNull = I.T("(empty)|30195");
            this.m_cmbxSelectAttributTypeCont.Tri = true;
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(356, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4015;
            this.label4.Text = "Select attribute from list|357";
            // 
            // m_lnkAjouterAttributTypeCont
            // 
            this.m_lnkAjouterAttributTypeCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterAttributTypeCont.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterAttributTypeCont, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkAjouterAttributTypeCont, "");
            this.m_lnkAjouterAttributTypeCont.Location = new System.Drawing.Point(355, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterAttributTypeCont, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterAttributTypeCont, "");
            this.m_lnkAjouterAttributTypeCont.Name = "m_lnkAjouterAttributTypeCont";
            this.m_lnkAjouterAttributTypeCont.Size = new System.Drawing.Size(63, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterAttributTypeCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterAttributTypeCont.TabIndex = 4016;
            this.m_lnkAjouterAttributTypeCont.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterAttributTypeCont.LinkClicked += new System.EventHandler(this.m_lnkAjouterAttributTypeCont_LinkClicked);
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(29, 101);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(259, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 5;
            this.label3.Text = "Attribute List|374";
            // 
            // m_lblSaisie
            // 
            this.m_extLinkField.SetLinkField(this.m_lblSaisie, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblSaisie, "");
            this.m_lblSaisie.Location = new System.Drawing.Point(32, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSaisie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblSaisie, "");
            this.m_lblSaisie.Name = "m_lblSaisie";
            this.m_lblSaisie.Size = new System.Drawing.Size(185, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSaisie.TabIndex = 4;
            this.m_lblSaisie.Text = "Enter free attribute (string)|282";
            // 
            // m_lnkSupprimer
            // 
            this.m_lnkSupprimer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimer.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimer, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkSupprimer, "");
            this.m_lnkSupprimer.Location = new System.Drawing.Point(32, 306);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimer, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimer, "");
            this.m_lnkSupprimer.Name = "m_lnkSupprimer";
            this.m_lnkSupprimer.Size = new System.Drawing.Size(104, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimer, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimer.TabIndex = 3;
            this.m_lnkSupprimer.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimer.LinkClicked += new System.EventHandler(this.m_lnkSupprimer_LinkClicked);
            // 
            // m_lnkAjouterAttribut
            // 
            this.m_lnkAjouterAttribut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterAttribut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkAjouterAttribut, "");
            this.m_lnkAjouterAttribut.Location = new System.Drawing.Point(32, 68);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterAttribut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterAttribut, "");
            this.m_lnkAjouterAttribut.Name = "m_lnkAjouterAttribut";
            this.m_lnkAjouterAttribut.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterAttribut.TabIndex = 2;
            this.m_lnkAjouterAttribut.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterAttribut.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_txtAttributLibre
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtAttributLibre, "");
            this.m_extLinkField.SetLinkField(this.m_txtAttributLibre, "");
            this.m_txtAttributLibre.Location = new System.Drawing.Point(32, 41);
            this.m_txtAttributLibre.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtAttributLibre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtAttributLibre, "");
            this.m_txtAttributLibre.Name = "m_txtAttributLibre";
            this.m_txtAttributLibre.Size = new System.Drawing.Size(272, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtAttributLibre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAttributLibre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAttributLibre.TabIndex = 1;
            // 
            // m_listeAttributs
            // 
            this.m_listeAttributs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeAttributs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttrib});
            this.m_listeAttributs.EnableCustomisation = true;
            this.m_listeAttributs.FullRowSelect = true;
            this.m_listeAttributs.HideSelection = false;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_listeAttributs, "");
            this.m_extLinkField.SetLinkField(this.m_listeAttributs, "");
            this.m_listeAttributs.Location = new System.Drawing.Point(30, 120);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeAttributs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeAttributs, "");
            this.m_listeAttributs.MultiSelect = false;
            this.m_listeAttributs.Name = "m_listeAttributs";
            this.m_listeAttributs.Size = new System.Drawing.Size(330, 180);
            this.m_extStyle.SetStyleBackColor(this.m_listeAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeAttributs.TabIndex = 0;
            this.m_listeAttributs.UseCompatibleStateImageBehavior = false;
            this.m_listeAttributs.View = System.Windows.Forms.View.Details;
            // 
            // colAttrib
            // 
            this.colAttrib.Field = "AttributString";
            this.colAttrib.PrecisionWidth = 0;
            this.colAttrib.ProportionnalSize = false;
            this.colAttrib.Text = "Label|50";
            this.colAttrib.Visible = true;
            this.colAttrib.Width = 485;
            // 
            // pageContraintes
            // 
            this.pageContraintes.Controls.Add(this.panel2);
            this.pageContraintes.Controls.Add(this.panel1);
            this.m_extLinkEditionAttribut.SetLinkField(this.pageContraintes, "");
            this.m_extLinkField.SetLinkField(this.pageContraintes, "");
            this.pageContraintes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageContraintes, "");
            this.pageContraintes.Name = "pageContraintes";
            this.pageContraintes.Selected = false;
            this.pageContraintes.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageContraintes.TabIndex = 13;
            this.pageContraintes.Title = "Constraints Management|324";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.m_listeContraintes);
            this.panel2.Controls.Add(this.m_LinkSupprCont);
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.panel2, "");
            this.panel2.Location = new System.Drawing.Point(0, 82);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(814, 255);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(18, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 11;
            this.label2.Text = "List of Constraints raised by this Resource|373";
            // 
            // m_listeContraintes
            // 
            this.m_listeContraintes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeContraintes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colLibelle});
            this.m_listeContraintes.EnableCustomisation = true;
            this.m_listeContraintes.FullRowSelect = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_listeContraintes, "");
            this.m_extLinkField.SetLinkField(this.m_listeContraintes, "");
            this.m_listeContraintes.Location = new System.Drawing.Point(21, 26);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeContraintes, "");
            this.m_listeContraintes.MultiSelect = false;
            this.m_listeContraintes.Name = "m_listeContraintes";
            this.m_listeContraintes.Size = new System.Drawing.Size(762, 209);
            this.m_extStyle.SetStyleBackColor(this.m_listeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeContraintes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeContraintes.TabIndex = 7;
            this.m_listeContraintes.UseCompatibleStateImageBehavior = false;
            this.m_listeContraintes.View = System.Windows.Forms.View.Details;
            // 
            // colLibelle
            // 
            this.colLibelle.Field = "Contrainte.Libelle";
            this.colLibelle.PrecisionWidth = 0;
            this.colLibelle.ProportionnalSize = false;
            this.colLibelle.Text = "Label|50";
            this.colLibelle.Visible = true;
            this.colLibelle.Width = 437;
            // 
            // m_LinkSupprCont
            // 
            this.m_LinkSupprCont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_LinkSupprCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_LinkSupprCont.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_LinkSupprCont, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_LinkSupprCont, "");
            this.m_LinkSupprCont.Location = new System.Drawing.Point(20, 236);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_LinkSupprCont, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_LinkSupprCont, "");
            this.m_LinkSupprCont.Name = "m_LinkSupprCont";
            this.m_LinkSupprCont.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_LinkSupprCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_LinkSupprCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_LinkSupprCont.TabIndex = 9;
            this.m_LinkSupprCont.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_LinkSupprCont.LinkClicked += new System.EventHandler(this.m_LinkSupprCont_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lblSelect);
            this.panel1.Controls.Add(this.m_txtSelectContrainte);
            this.panel1.Controls.Add(this.m_LinkAjoutCont);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(814, 82);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 12;
            // 
            // m_lblSelect
            // 
            this.m_lblSelect.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblSelect, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblSelect, "");
            this.m_lblSelect.Location = new System.Drawing.Point(39, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSelect, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblSelect, "");
            this.m_lblSelect.Name = "m_lblSelect";
            this.m_lblSelect.Size = new System.Drawing.Size(145, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSelect, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSelect.TabIndex = 10;
            this.m_lblSelect.Text = "Select Constraint to add|325";
            // 
            // m_txtSelectContrainte
            // 
            this.m_txtSelectContrainte.ElementSelectionne = null;
            this.m_txtSelectContrainte.FonctionTextNull = null;
            this.m_txtSelectContrainte.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_txtSelectContrainte, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtSelectContrainte, "");
            this.m_txtSelectContrainte.Location = new System.Drawing.Point(35, 31);
            this.m_txtSelectContrainte.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectContrainte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectContrainte, "");
            this.m_txtSelectContrainte.Name = "m_txtSelectContrainte";
            this.m_txtSelectContrainte.SelectedObject = null;
            this.m_txtSelectContrainte.Size = new System.Drawing.Size(425, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectContrainte.TabIndex = 6;
            this.m_txtSelectContrainte.TextNull = "";
            // 
            // m_LinkAjoutCont
            // 
            this.m_LinkAjoutCont.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_LinkAjoutCont.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_LinkAjoutCont, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_LinkAjoutCont, "");
            this.m_LinkAjoutCont.Location = new System.Drawing.Point(35, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_LinkAjoutCont, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_LinkAjoutCont, "");
            this.m_LinkAjoutCont.Name = "m_LinkAjoutCont";
            this.m_LinkAjoutCont.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_LinkAjoutCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_LinkAjoutCont, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_LinkAjoutCont.TabIndex = 8;
            this.m_LinkAjoutCont.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_LinkAjoutCont.LinkClicked += new System.EventHandler(this.m_LinkAjoutCont_LinkClicked);
            // 
            // pageAgenda
            // 
            this.pageAgenda.Controls.Add(this.m_controlAgenda);
            this.m_extLinkEditionAttribut.SetLinkField(this.pageAgenda, "");
            this.m_extLinkField.SetLinkField(this.pageAgenda, "");
            this.pageAgenda.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageAgenda, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageAgenda, "");
            this.pageAgenda.Name = "pageAgenda";
            this.pageAgenda.Selected = false;
            this.pageAgenda.Size = new System.Drawing.Size(814, 337);
            this.m_extStyle.SetStyleBackColor(this.pageAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageAgenda.TabIndex = 14;
            this.pageAgenda.Title = "Diary|80";
            // 
            // m_controlAgenda
            // 
            this.m_controlAgenda.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_controlAgenda.DateEnCours = new System.DateTime(2009, 3, 6, 11, 7, 47, 375);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_controlAgenda, "");
            this.m_extLinkField.SetLinkField(this.m_controlAgenda, "");
            this.m_controlAgenda.Location = new System.Drawing.Point(12, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlAgenda, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_controlAgenda, "");
            this.m_controlAgenda.Name = "m_controlAgenda";
            this.m_controlAgenda.Size = new System.Drawing.Size(784, 309);
            this.m_extStyle.SetStyleBackColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlAgenda.TabIndex = 0;
            // 
            // m_gestionnaireEditionAttribut
            // 
            this.m_gestionnaireEditionAttribut.ListeAssociee = this.m_listeAttributs;
            this.m_gestionnaireEditionAttribut.ObjetEdite = null;
            this.m_gestionnaireEditionAttribut.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionAttribut_InitChamp);
            this.m_gestionnaireEditionAttribut.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionAttribut_MAJ_Champs);
            // 
            // CFormEditionRessource
            // 
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkEditionAttribut.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionRessource";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionRessource_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionRessource_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.pageChampsCustom.ResumeLayout(false);
            this.pageInfoEmplacement.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.m_splitContainer.Panel1.ResumeLayout(false);
            this.m_splitContainer.Panel2.ResumeLayout(false);
            this.m_splitContainer.Panel2.PerformLayout();
            this.m_splitContainer.ResumeLayout(false);
            this.pageRessourcesContenus.ResumeLayout(false);
            this.pageEO.ResumeLayout(false);
            this.pageAttribut.ResumeLayout(false);
            this.pageAttribut.PerformLayout();
            this.m_panelEditionAttribut.ResumeLayout(false);
            this.m_panelEditionAttribut.PerformLayout();
            this.pageContraintes.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pageAgenda.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //---------------------- Objet édité ----------------------------------------
        private CRessourceMaterielle Ressource
        {
            get
            {
                return (CRessourceMaterielle)ObjetEdite;
            }
        }
        
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {

            AffecterTitre(I.T( "Resource|253") + " " + Ressource.Libelle);

            //Init la combo selection du type de ressource
            CListeObjetsDonnees liste_type = new CListeObjetsDonnees(Ressource.ContexteDonnee, typeof(CTypeRessource));
            liste_type.Filtre = m_filtreListeType;
            m_cmbxTypeRessource.Init(liste_type, "Libelle", typeof(CFormEditionTypeRessource), false);
            if(Ressource.TypeRessource != null)
                m_cmbxTypeRessource.ElementSelectionne = Ressource.TypeRessource;

            
            MenageOnglets();

            CResultAErreur result = base.MyInitChamps();
			return result;
        }
        //------------------------------------------------------------------------------
        private void MenageOnglets()
        {
            if (Ressource.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(pageChampsCustom))
                    m_tabControl.TabPages.Remove(pageChampsCustom);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(pageChampsCustom))
                    m_tabControl.TabPages.Insert(0, pageChampsCustom);
            }

            if (Ressource.TypeRessource != null)
            {
                if (!Ressource.TypeRessource.OptionAfficherAgenda)
                {
                    //int index = m_tabControl.TabPages.IndexOf(pageAgenda);
                    if(m_tabControl.TabPages.Contains(pageAgenda))
                        m_tabControl.TabPages.Remove(pageAgenda);
                }
                else
                {
                    if (!m_tabControl.TabPages.Contains(pageAgenda))
                        m_tabControl.TabPages.Add(pageAgenda);
                }
            }
        }

        //-----------------------------------------------------------------------------
        private TreeNode CreateNode(CRessourceMaterielle res)
        {
            TreeNodeCollection nodes = m_arbreRessourceParent.Nodes;
            if (res.RessourceParente != null)
                nodes = CreateNode(res.RessourceParente).Nodes;
            TreeNode newNode = new TreeNode(res.Libelle);
            newNode.Tag = res;
            return newNode;
        }

        //----------------------------------------------------------------------------------------
        private void InitSelectAttributTypeContrainte()
        {
            CListeObjetsDonnees liste = new CListeObjetsDonnees(Ressource.ContexteDonnee, typeof(CAttributTypeContrainte));

            if (Ressource.TypeRessource == null)
            {
                if (m_cmbxTypeRessource.ElementSelectionne == null)
                    return;
                MAJ_Champs();
            }

            ArrayList tousLesAttributs = new ArrayList();
            CTypeContrainte[] typesContraintes = Ressource.TypeRessource.GetTousLesTypesContraintes();
            if (typesContraintes.Length != 0)
            {
                m_cmbxSelectAttributTypeCont.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                m_lnkAjouterAttributTypeCont.Enabled = m_gestionnaireModeEdition.ModeEdition;
                foreach (CTypeContrainte typeCont in typesContraintes)
                {
                    tousLesAttributs.AddRange(typeCont.GetTousLesAttributsTypeContrainte());
                }

                string strFiltreIds = "";
                foreach (CAttributTypeContrainte att in tousLesAttributs.ToArray(typeof(CAttributTypeContrainte)))
                {
                    strFiltreIds += att.Id;
                    strFiltreIds += ",";
                }
                if (strFiltreIds.Length != 0)
                    strFiltreIds = strFiltreIds.Substring(0, (strFiltreIds.Length) - 1);
				if (strFiltreIds == "")
					strFiltreIds = "-1";

                liste.Filtre = new CFiltreData(CAttributTypeContrainte.c_champId + " in (" + strFiltreIds + ")");
                m_cmbxSelectAttributTypeCont.Init(liste, "Libelle", true);
            }
            else
            {
                m_cmbxSelectAttributTypeCont.LockEdition = true;
                m_lnkAjouterAttributTypeCont.Enabled = false;
            }

        }

        //----------------------------------------------------------------------------------------
        private void InitListeAttributs()
        {
            m_listeAttributs.Items.Clear();

            foreach (CAttributRessource att in Ressource.AttributsListe)
            {
                ListViewItem item = new ListViewItem();
                m_listeAttributs.Items.Add(item);
                m_listeAttributs.UpdateItemWithObject(item, att);
            }
            foreach (ListViewItem itemSel in m_listeAttributs.Items)
                itemSel.Selected = false;
        }

        //--------------------------------------------------------------------------------
        private void InitSelectContrainte()
        {
            CFiltreData filtre = null;

            string strIds = "";

            if (Ressource.TypeRessource != null)
            {
                foreach (CTypeContrainte typeCont in Ressource.TypeRessource.GetTousLesTypesContraintes())
                {
                    strIds += typeCont.Id + ",";
                }
                if (strIds.Length > 0)
                {
                    strIds = strIds.Substring(0, strIds.Length - 1);
                    filtre = new CFiltreData(CTypeContrainte.c_champId + " in (" + strIds + ")");
                }
            }

            m_txtSelectContrainte.InitAvecFiltreDeBase<CContrainte>(
                "Libelle", 
                filtre, 
                true);

        }

        //------------------------------------------------------------------------------------
        private void InitListeContraintes()
        {
            // Vide la liste
            m_listeContraintes.Items.Clear();
            
            // Init la liste des relations avec les clés
            foreach (CRelationContrainte_Ressource rel in Ressource.RelationContrainteListe)
            {
                ListViewItem item = new ListViewItem();
                m_listeContraintes.Items.Add(item);
                m_listeContraintes.UpdateItemWithObject(item, rel);
            }
        }
 
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (!result) return result;

            

            return result;
        }

        // Gestion des boutons radio
        private void m_radSite_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void m_radActeur_CheckedChanged(object sender, EventArgs e)
        {
        }



        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtAttributLibre.Text == "")
            {
				CFormAlerte.Afficher(I.T("Please enter a string to add|283"));
                return;
            }

            string str = m_txtAttributLibre.Text;
            CListeObjetsDonnees liste = Ressource.AttributsListe;
            liste.Filtre = new CFiltreData(CAttributRessource.c_champLibelle + " = @1 ", str);
            if(liste.Count != 0)
            {
				CFormAlerte.Afficher(I.T("This Attribut already exists|285"), EFormAlerteType.Erreur);
                return;
            }
            m_txtAttributLibre.Text = "";

            // Initialise lenouvel attribut
            CAttributRessource newAttrib = new CAttributRessource(Ressource.ContexteDonnee);
            newAttrib.Libelle = str;
            newAttrib.Ressource = Ressource;
            newAttrib.AttributTypeContrainte = null;

            ListViewItem item = new ListViewItem();
            m_listeAttributs.Items.Add(item);
            m_listeAttributs.UpdateItemWithObject(item, newAttrib);


            InitListeAttributs();
        }

        private void m_lnkSupprimer_LinkClicked(object sender, EventArgs e)
        {
            if(m_listeAttributs.SelectedItems.Count == 0)
            {
				CFormAlerte.Afficher(I.T("Please select an Attribut to remove|284"));
                return;
            }

            CAttributRessource supprAttrib = (CAttributRessource) m_listeAttributs.SelectedItems[0].Tag;
            CResultAErreur result = supprAttrib.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeAttributs.SelectedItems.Count != 0 && m_listeAttributs.SelectedItems[0] != null)
            {
                m_listeAttributs.SelectedItems[0].Remove();
            }
            InitListeAttributs();
        }


        //---------------------------------------------------------------------------------------
        private CFiltreData m_filtreListeType;
        // Propriété 
        public CFiltreData FiltreListeType
        {
            get
            {
                return m_filtreListeType;
            }
            set
            {
                if(value != null)
                    m_filtreListeType = value;
            }
        }

        //---------------------------------------------------------------------------------------
        private void m_lnkDeplacer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreur result = MAJ_Champs();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            if (CFormDeplacerRessource.DeplaceRessource(Ressource))
                InitChamps();
        }

        //---------------------------------------------------------------------------------------
        private void m_lnkEmplacementDescription_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IPossesseurRessource emplacement = Ressource.Emplacement;
            if (emplacement != null)
            {
                //Type tp = CFormFinder.GetTypeFormToEdit(emplacement.GetType());
                CReferenceTypeForm refTypeForm = CFormFinder.GetRefFormToEdit(emplacement.GetType());
                try
                {
                    //CTimosApp.Navigateur.AffichePage((IFormNavigable)Activator.CreateInstance(tp, new object[] { emplacement }));
                    CTimosApp.Navigateur.AffichePage(refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)emplacement) as CFormEditionStandard);
                }
                catch
                { }
            }
        }


        //---------------------------------------------------------------------------------------
        private void m_LinkAjoutCont_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectContrainte.ElementSelectionne == null)
            {
				CFormAlerte.Afficher(I.T("Select Constraint to add|326"), EFormAlerteType.Exclamation);
                return;
            }
            CContrainte cont = (CContrainte)m_txtSelectContrainte.ElementSelectionne;

            //Vérifie la liste des relations existantes
            CListeObjetsDonnees listeExistant = Ressource.RelationContrainteListe;
            listeExistant.Filtre = new CFiltreData(CContrainte.c_champId + " = @1", cont.Id);
            if (listeExistant.Count != 0)
            {
				CFormAlerte.Afficher(I.T("This Constraint is already in the list|328"), EFormAlerteType.Erreur);
                return;
            }

            m_txtSelectContrainte.ElementSelectionne = null;

            CRelationContrainte_Ressource rel = new CRelationContrainte_Ressource(Ressource.ContexteDonnee);
            rel.CreateNewInCurrentContexte();
            rel.Contrainte = cont;
            rel.Ressource = Ressource;

            MAJ_Champs();
            CResultAErreur result = rel.VerifieDonnees(true);
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                rel.Delete();
                return;
            }

            // MAJ affichage liste relations
            ListViewItem item = new ListViewItem();
            m_listeContraintes.Items.Add(item);
            m_listeContraintes.UpdateItemWithObject(item, rel);
            foreach (ListViewItem itemSel in m_listeContraintes.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;

            InitSelectContrainte();

        }

        //---------------------------------------------------------------------------------------
        private void m_LinkSupprCont_LinkClicked(object sender, EventArgs e)
        {
            if (m_listeContraintes.SelectedItems.Count == 0)
            {
				CFormAlerte.Afficher(I.T("Select Constraint from the list to remove|327"), EFormAlerteType.Exclamation);
                return;
            }

            CRelationContrainte_Ressource rel = (CRelationContrainte_Ressource)m_listeContraintes.SelectedItems[0].Tag;
            CResultAErreur result = rel.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeContraintes.SelectedItems.Count == 1 && m_listeContraintes.SelectedItems[0] != null)
            {
                m_listeContraintes.SelectedItems[0].Remove();
            }

        }

        //---------------------------------------------------------------------------------------
        private void m_lnkAjouterAttributTypeCont_LinkClicked(object sender, EventArgs e)
        {
            if (m_cmbxSelectAttributTypeCont.ElementSelectionne == null)
            {
				CFormAlerte.Afficher(I.T("Select Attribute to add|359"), EFormAlerteType.Exclamation);
                return;
            }
            CAttributTypeContrainte selAttrib = (CAttributTypeContrainte)m_cmbxSelectAttributTypeCont.ElementSelectionne;
            CListeObjetsDonnees listeExistant = Ressource.AttributsListe;
            listeExistant.Filtre = new CFiltreData(CAttributTypeContrainte.c_champId + " = @1", selAttrib.Id);
            if (listeExistant.Count != 0)
            {
				CFormAlerte.Afficher(I.T("This attribute is already in the list|349"), EFormAlerteType.Erreur);
                return;
            }

            CAttributRessource newAttribut = new CAttributRessource(Ressource.ContexteDonnee);
            newAttribut.CreateNewInCurrentContexte();
            newAttribut.Ressource = Ressource;
            newAttribut.AttributTypeContrainte = selAttrib;
            newAttribut.Libelle = "";

            // Mise à jour de la liste
            ListViewItem item = new ListViewItem();
            m_listeAttributs.Items.Add(item);
            m_listeAttributs.UpdateItemWithObject(item, newAttribut);

        }

        //---------------------------------------------------------------------------------------
        private void m_gestionnaireEditionAttribut_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {

            if (args.Objet == null)
            {
                m_panelEditionAttribut.Visible = false;
                return;
            }
            CAttributRessource attribut = (CAttributRessource)args.Objet;
            if (attribut.AttributTypeContrainte == null)
            {
                m_panelEditionAttribut.Visible = true;
                m_extLinkEditionAttribut.FillDialogFromObjet(args.Objet);
            }

        }

        //---------------------------------------------------------------------------------------
        private void m_gestionnaireEditionAttribut_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet != null)
            {
                CResultAErreur result = m_extLinkEditionAttribut.FillObjetFromDialog(args.Objet);
                if (!result)
                {
                    args.Result = result;
                    return;
                }
            }

        }

        //---------------------------------------------------------------------------------------
        private void m_cmbxTypeRessource_SelectedValueChanged(object sender, EventArgs e)
        {
            if (m_cmbxTypeRessource.ElementSelectionne != null)
                Ressource.TypeRessource = (CTypeRessource) m_cmbxTypeRessource.ElementSelectionne;

            InitSelectAttributTypeContrainte();
            InitSelectContrainte();
            m_panelAffectationEO.Init(Ressource);
            m_PanelChampsCustom.ElementEdite = Ressource;
            MenageOnglets();

        }

		private void m_lnkEvenement_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Ressource.EnregistreEvenement(CRessourceMaterielle.c_evenementAffectation, true);
		}

		private CResultAErreur CFormEditionRessource_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
				if (page == pageAgenda)
				{
					// Init page Agenda
					m_controlAgenda.SetElementAAgenda(Ressource);

				}
				else if (page == pageAttribut)
				{
					// Init page Attributs
					m_gestionnaireEditionAttribut.ObjetEdite = Ressource.AttributsListe;
					m_panelEditionAttribut.Visible = false;
					InitListeAttributs();
					InitSelectAttributTypeContrainte();
				}
				else if (page == pageChampsCustom)
				{
					// Init page Champs Custom
					m_PanelChampsCustom.ElementEdite = Ressource;
				}
				else if (page == pageContraintes)
				{
					// Init page gestion des contraintes
					InitSelectContrainte();
					InitListeContraintes();
				}
				else if (page == pageEO)
				{
					// Init page EO
					m_panelAffectationEO.Init(Ressource);
				}
				else if (page == pageInfoEmplacement)
				{
					m_cmbxEtatRessource.Fill(
                        CUtilSurEnum.GetEnumsALibelle(typeof(CEtatRessource)),
                        "Libelle",
                        true);
					m_cmbxEtatRessource.SelectedValue = (CEtatRessource) Ressource.Etat;

					CRessourceMaterielle ressourceParente = Ressource.RessourceParente;
					m_arbreRessourceParent.Visible = ressourceParente != null;
					if (ressourceParente != null)
					{
						m_arbreRessourceParent.Nodes.Clear();
						TreeNode node = CreateNode(ressourceParente);
						m_arbreRessourceParent.Nodes.Add(node);
					}

					if ((Ressource.TypeRessource != null && !Ressource.TypeRessource.OptionDeplacable) ||
						ressourceParente != null)
					{

						m_lnkDeplacerRessource.Enabled = false;

					}
					else
					{
						m_lnkDeplacerRessource.Enabled = m_gestionnaireModeEdition.ModeEdition;
					}

					if (Ressource.Emplacement == null)
						m_lnkDeplacerRessource.Text = I.T("Set initial location|318");
					else
						m_lnkDeplacerRessource.Text = I.T("Move this Resource|319");

					m_panelMouvements.InitFromListeObjets(
						Ressource.Mouvements,
						typeof(CMouvementRessource),
						null,
						Ressource,
						"RessourceDeplace");
				}
				else if (page == pageRessourcesContenus)
				{
					// Page contains (ressources contenues)
					m_panelListeRessourceContenues.InitFromListeObjets(
						Ressource.RessourcesFilles,
						typeof(CRessourceMaterielle),
						typeof(CFormEditionRessource),
						Ressource,
						"RessourceParenteInitiale");
				}
			}
			
			return result;
		}

		private CResultAErreur CFormEditionRessource_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			if (page == pageAgenda)
			{
			}
			else if (page == pageAttribut)
			{
				result = m_gestionnaireEditionAttribut.ValideModifs();
			}
			else if (page == pageChampsCustom)
			{
				result = m_PanelChampsCustom.MAJ_Champs();

			}
			else if (page == pageContraintes)
			{
			}
			else if (page == pageEO)
			{
				result = m_panelAffectationEO.MajChamps();
			}
			else if (page == pageInfoEmplacement)
			{
				Ressource.TypeRessource = (CTypeRessource)m_cmbxTypeRessource.ElementSelectionne;
				Ressource.Etat = (CEtatRessource)m_cmbxEtatRessource.SelectedValue;
			}
			else if (page == pageRessourcesContenus)
			{
			}

			return result;
		}

    }
}

