using System.Diagnostics;
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

using timos.data;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeContrainte))]
    public class CFormEditionTypeContrainte : CFormEditionStdTimos
    {
		private Color m_couleurDeFond = Color.White;
        private C2iPanelOmbre c2iPanelOmbre1;
        private C2iTextBox m_txtBoxLibelle;
        private Label label1;
        private C2iTabControl m_TabControl;
        private Crownwood.Magic.Controls.TabPage m_pageTypesFils;
        private Label m_labelLibelle;
        private CArbreObjetHierarchique m_ArbreTypesContHierarchiques;
        private Label m_labelCodeSysteme;
        private Label m_lblCodeSystemeComplet;
        private CPanelListeSpeedStandard m_panelListeTypesContraintesFils;
        private Crownwood.Magic.Controls.TabPage m_pageSelectRelKeyTypes;
        private Label m_lblSelectResType;
        private ListViewAutoFilledColumn colLibelle;
        private Crownwood.Magic.Controls.TabPage m_pageDefChampCustom;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_PanelEditDefinisseurChampsCustom;
        private C2iTextBoxSelectionne m_txtSelectTypeRessource;
        private CWndLinkStd m_lnkAjouter;
        private ListViewAutoFilledColumn columnLibelle;
        private CPanelEditRelationTypeContrainteTypeRessource m_PanelEditRelations;
        private Crownwood.Magic.Controls.TabPage m_pageAttributs;
        private C2iTextBox m_txtAttributLibelle;
        private ListViewAutoFilled m_listeAttributTypeContrainte;
        private ListViewAutoFilledColumn listeAttributLibelle;
        private Label label2;
        private Label label4;
        private CWndLinkStd c_lnkSupprimerAttribut;
        private CWndLinkStd c_lnkAjouterAttribut;
        private GroupBox m_groupBoxOptionsAttributs;
        private Label label5;
        private RadioButton m_radUnSeulAttribut;
        private RadioButton m_radTousLesAttributs;
        private CheckBox m_chkOptionAttributLibre;
        private CheckBox m_chkOptionAttributListe;
        private Label label3;
        private Panel m_panelEditionAttribut;
        private Label label6;
        private C2iTextBox m_txtModifierAttributLibelle;
        private CExtLinkField m_extLinkEditionAttribut;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionAttribut;
        private CheckBox m_chkOptionAuPlusUnAttributType;
        private CheckBox m_chkOptionAuMoinUnAttributType;
		private LinkLabel m_lnkCouleurFond;
		private Button m_btnNoImage;
		private Button m_btnSelectImage;
		private Label label7;
		private Panel m_panelImage;
		private PictureBox m_wndImage;
		private CheckBox checkBox2;
		private CheckBox checkBox1;
		private CheckBox checkBox3;
        private Crownwood.Magic.Controls.TabPage m_pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CFormEditionTypeContrainte()
            :base()
        {
            InitializeComponent();
        }

        public CFormEditionTypeContrainte(CTypeContrainte TypeContrainte)
            : base(TypeContrainte)
        {
            InitializeComponent();
        }

        public CFormEditionTypeContrainte(CTypeContrainte TypeContrainte, CListeObjetsDonnees liste)
            : base(TypeContrainte, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeContrainte));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelImage = new System.Windows.Forms.Panel();
            this.m_wndImage = new System.Windows.Forms.PictureBox();
            this.m_lnkCouleurFond = new System.Windows.Forms.LinkLabel();
            this.m_btnNoImage = new System.Windows.Forms.Button();
            this.m_btnSelectImage = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.m_ArbreTypesContHierarchiques = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.m_lblCodeSystemeComplet = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.m_txtBoxLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_labelCodeSysteme = new System.Windows.Forms.Label();
            this.m_labelLibelle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageDefChampCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelEditDefinisseurChampsCustom = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.m_pageAttributs = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditionAttribut = new System.Windows.Forms.Panel();
            this.m_txtModifierAttributLibelle = new sc2i.win32.common.C2iTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_groupBoxOptionsAttributs = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.m_chkOptionAuPlusUnAttributType = new System.Windows.Forms.CheckBox();
            this.m_chkOptionAuMoinUnAttributType = new System.Windows.Forms.CheckBox();
            this.m_chkOptionAttributLibre = new System.Windows.Forms.CheckBox();
            this.m_chkOptionAttributListe = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_radUnSeulAttribut = new System.Windows.Forms.RadioButton();
            this.m_radTousLesAttributs = new System.Windows.Forms.RadioButton();
            this.c_lnkSupprimerAttribut = new sc2i.win32.common.CWndLinkStd();
            this.c_lnkAjouterAttribut = new sc2i.win32.common.CWndLinkStd();
            this.label4 = new System.Windows.Forms.Label();
            this.m_listeAttributTypeContrainte = new sc2i.win32.common.ListViewAutoFilled();
            this.listeAttributLibelle = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtAttributLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_pageTypesFils = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeTypesContraintesFils = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageSelectRelKeyTypes = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelEditRelations = new timos.CPanelEditRelationTypeContrainteTypeRessource();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_txtSelectTypeRessource = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lblSelectResType = new System.Windows.Forms.Label();
            this.columnLibelle = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.colLibelle = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_gestionnaireEditionAttribut = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_extLinkEditionAttribut = new sc2i.win32.common.CExtLinkField();
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImage)).BeginInit();
            this.m_TabControl.SuspendLayout();
            this.m_pageDefChampCustom.SuspendLayout();
            this.m_pageAttributs.SuspendLayout();
            this.m_panelEditionAttribut.SuspendLayout();
            this.m_groupBoxOptionsAttributs.SuspendLayout();
            this.m_pageTypesFils.SuspendLayout();
            this.m_pageSelectRelKeyTypes.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnAnnulerModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnValiderModifications, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnSupprimerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnEditerObjet, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_extLinkField.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelNavigation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelNavigation, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_panelNavigation, false);
            this.m_panelNavigation.Location = new System.Drawing.Point(623, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(175, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelNavigation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblNbListes
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblNbListes, "");
            this.m_extLinkField.SetLinkField(this.m_lblNbListes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblNbListes, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_lblNbListes, true);
            this.m_extStyle.SetStyleBackColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNbListes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnPrecedent
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnPrecedent, "");
            this.m_extLinkField.SetLinkField(this.m_btnPrecedent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnPrecedent, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnPrecedent, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPrecedent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSuivant
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnSuivant, "");
            this.m_extLinkField.SetLinkField(this.m_btnSuivant, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSuivant, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnSuivant, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSuivant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnAjout
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnAjout, "");
            this.m_extLinkField.SetLinkField(this.m_btnAjout, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAjout, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnAjout, true);
            this.m_extStyle.SetStyleBackColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAjout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lblId
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblId, "");
            this.m_extLinkField.SetLinkField(this.m_lblId, "Id");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblId, true);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_lblId, true);
            this.m_extStyle.SetStyleBackColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblId, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelCle
            // 
            this.m_extLinkField.SetLinkField(this.m_panelCle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelCle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelCle, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_panelCle, false);
            this.m_panelCle.Location = new System.Drawing.Point(515, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_extLinkField.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelMenu, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMenu, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_panelMenu, false);
            this.m_panelMenu.Size = new System.Drawing.Size(830, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnHistorique
            // 
            this.m_extLinkField.SetLinkField(this.m_btnHistorique, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnHistorique, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnHistorique, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnHistorique, false);
            this.m_extStyle.SetStyleBackColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnHistorique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_imageCle
            // 
            this.m_extLinkField.SetLinkField(this.m_imageCle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_imageCle, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_imageCle, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_imageCle, false);
            this.m_extStyle.SetStyleBackColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_imageCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnChercherObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnChercherObjet, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnChercherObjet, true);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnChercherObjet, false);
            this.m_extStyle.SetStyleBackColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnChercherObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_panelImage);
            this.c2iPanelOmbre1.Controls.Add(this.m_lnkCouleurFond);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnNoImage);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnSelectImage);
            this.c2iPanelOmbre1.Controls.Add(this.label7);
            this.c2iPanelOmbre1.Controls.Add(this.m_ArbreTypesContHierarchiques);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblCodeSystemeComplet);
            this.c2iPanelOmbre1.Controls.Add(this.checkBox2);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtBoxLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.m_labelCodeSysteme);
            this.c2iPanelOmbre1.Controls.Add(this.m_labelLibelle);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 43);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(830, 147);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4003;
            // 
            // m_panelImage
            // 
            this.m_panelImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelImage.Controls.Add(this.m_wndImage);
            this.m_extLinkField.SetLinkField(this.m_panelImage, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelImage, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelImage, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_panelImage, false);
            this.m_panelImage.Location = new System.Drawing.Point(91, 99);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelImage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelImage, "");
            this.m_panelImage.Name = "m_panelImage";
            this.m_panelImage.Size = new System.Drawing.Size(32, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelImage.TabIndex = 4020;
            // 
            // m_wndImage
            // 
            this.m_extLinkField.SetLinkField(this.m_wndImage, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_wndImage, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_wndImage, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndImage, false);
            this.m_wndImage.Location = new System.Drawing.Point(6, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndImage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndImage, "");
            this.m_wndImage.Name = "m_wndImage";
            this.m_wndImage.Size = new System.Drawing.Size(16, 16);
            this.m_wndImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_extStyle.SetStyleBackColor(this.m_wndImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndImage.TabIndex = 4008;
            this.m_wndImage.TabStop = false;
            // 
            // m_lnkCouleurFond
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkCouleurFond, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkCouleurFond, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkCouleurFond, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_lnkCouleurFond, false);
            this.m_lnkCouleurFond.Location = new System.Drawing.Point(184, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCouleurFond, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkCouleurFond, "");
            this.m_lnkCouleurFond.Name = "m_lnkCouleurFond";
            this.m_lnkCouleurFond.Size = new System.Drawing.Size(168, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCouleurFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCouleurFond, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCouleurFond.TabIndex = 4019;
            this.m_lnkCouleurFond.TabStop = true;
            this.m_lnkCouleurFond.Text = "Image back color|810";
            this.m_lnkCouleurFond.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkCouleurFond.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCouleurFond_LinkClicked);
            // 
            // m_btnNoImage
            // 
            this.m_btnNoImage.Image = ((System.Drawing.Image)(resources.GetObject("m_btnNoImage.Image")));
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnNoImage, "");
            this.m_extLinkField.SetLinkField(this.m_btnNoImage, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnNoImage, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnNoImage, false);
            this.m_btnNoImage.Location = new System.Drawing.Point(154, 101);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnNoImage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnNoImage, "");
            this.m_btnNoImage.Name = "m_btnNoImage";
            this.m_btnNoImage.Size = new System.Drawing.Size(24, 29);
            this.m_extStyle.SetStyleBackColor(this.m_btnNoImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnNoImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnNoImage.TabIndex = 4018;
            this.m_btnNoImage.Text = "...";
            this.m_btnNoImage.Click += new System.EventHandler(this.m_btnNoImage_Click);
            // 
            // m_btnSelectImage
            // 
            this.m_extLinkEditionAttribut.SetLinkField(this.m_btnSelectImage, "");
            this.m_extLinkField.SetLinkField(this.m_btnSelectImage, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnSelectImage, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_btnSelectImage, false);
            this.m_btnSelectImage.Location = new System.Drawing.Point(124, 101);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSelectImage, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnSelectImage, "");
            this.m_btnSelectImage.Name = "m_btnSelectImage";
            this.m_btnSelectImage.Size = new System.Drawing.Size(24, 29);
            this.m_extStyle.SetStyleBackColor(this.m_btnSelectImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSelectImage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSelectImage.TabIndex = 4017;
            this.m_btnSelectImage.Text = "...";
            this.m_btnSelectImage.Click += new System.EventHandler(this.m_btnSelectImage_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(12, 106);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4015;
            this.label7.Text = "Image|809";
            // 
            // m_ArbreTypesContHierarchiques
            // 
            this.m_ArbreTypesContHierarchiques.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_ArbreTypesContHierarchiques.AutoriseReaffectation = true;
            this.m_ArbreTypesContHierarchiques.BackColor = System.Drawing.Color.White;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_ArbreTypesContHierarchiques, "");
            this.m_extLinkField.SetLinkField(this.m_ArbreTypesContHierarchiques, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_ArbreTypesContHierarchiques, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ArbreTypesContHierarchiques, false);
            this.m_ArbreTypesContHierarchiques.Location = new System.Drawing.Point(3, 3);
            this.m_ArbreTypesContHierarchiques.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ArbreTypesContHierarchiques, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ArbreTypesContHierarchiques, "");
            this.m_ArbreTypesContHierarchiques.Name = "m_ArbreTypesContHierarchiques";
            this.m_ArbreTypesContHierarchiques.Size = new System.Drawing.Size(802, 70);
            this.m_extStyle.SetStyleBackColor(this.m_ArbreTypesContHierarchiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ArbreTypesContHierarchiques, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ArbreTypesContHierarchiques.TabIndex = 5;
            // 
            // m_lblCodeSystemeComplet
            // 
            this.m_lblCodeSystemeComplet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblCodeSystemeComplet.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblCodeSystemeComplet, "");
            this.m_extLinkField.SetLinkField(this.m_lblCodeSystemeComplet, "CodeSystemeComplet");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblCodeSystemeComplet, true);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_lblCodeSystemeComplet, false);
            this.m_lblCodeSystemeComplet.Location = new System.Drawing.Point(648, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCodeSystemeComplet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblCodeSystemeComplet, "");
            this.m_lblCodeSystemeComplet.Name = "m_lblCodeSystemeComplet";
            this.m_lblCodeSystemeComplet.Size = new System.Drawing.Size(116, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblCodeSystemeComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblCodeSystemeComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCodeSystemeComplet.TabIndex = 7;
            this.m_lblCodeSystemeComplet.Text = "[CodeSystemeComplet]";
            // 
            // checkBox2
            // 
            this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.checkBox2, "");
            this.m_extLinkField.SetLinkField(this.checkBox2, "IsInCheckList");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.checkBox2, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox2, true);
            this.checkBox2.Location = new System.Drawing.Point(424, 107);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox2, "");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(381, 19);
            this.m_extStyle.SetStyleBackColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox2.TabIndex = 7;
            this.checkBox2.Text = "Constraints of this type appears on a chek list|811";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // m_txtBoxLibelle
            // 
            this.m_txtBoxLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtBoxLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtBoxLibelle, "Libelle");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtBoxLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtBoxLibelle, true);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_txtBoxLibelle, false);
            this.m_txtBoxLibelle.Location = new System.Drawing.Point(91, 76);
            this.m_txtBoxLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtBoxLibelle, "");
            this.m_txtBoxLibelle.Name = "m_txtBoxLibelle";
            this.m_txtBoxLibelle.Size = new System.Drawing.Size(449, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxLibelle.TabIndex = 3;
            this.m_txtBoxLibelle.Text = "[Libelle]";
            // 
            // m_labelCodeSysteme
            // 
            this.m_labelCodeSysteme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelCodeSysteme.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_labelCodeSysteme, "");
            this.m_extLinkField.SetLinkField(this.m_labelCodeSysteme, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelCodeSysteme, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_labelCodeSysteme, false);
            this.m_labelCodeSysteme.Location = new System.Drawing.Point(548, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelCodeSysteme, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelCodeSysteme, "");
            this.m_labelCodeSysteme.Name = "m_labelCodeSysteme";
            this.m_labelCodeSysteme.Size = new System.Drawing.Size(88, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelCodeSysteme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelCodeSysteme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelCodeSysteme.TabIndex = 6;
            this.m_labelCodeSysteme.Text = "System code|121";
            // 
            // m_labelLibelle
            // 
            this.m_labelLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_labelLibelle.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_labelLibelle, "");
            this.m_extLinkField.SetLinkField(this.m_labelLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelLibelle, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_labelLibelle, false);
            this.m_labelLibelle.Location = new System.Drawing.Point(12, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelLibelle, "");
            this.m_labelLibelle.Name = "m_labelLibelle";
            this.m_labelLibelle.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelLibelle.TabIndex = 4;
            this.m_labelLibelle.Text = "Label|50";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkEditionAttribut.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.label1.TabIndex = 4;
            this.label1.Text = "Label|50";
            // 
            // m_TabControl
            // 
            this.m_TabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.ForeColor = System.Drawing.Color.Black;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_TabControl, "");
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(0, 190);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageFormulaires;
            this.m_TabControl.Size = new System.Drawing.Size(830, 361);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4005;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFormulaires,
            this.m_pageAttributs,
            this.m_pageTypesFils,
            this.m_pageSelectRelKeyTypes,
            this.m_pageDefChampCustom});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageDefChampCustom
            // 
            this.m_pageDefChampCustom.Controls.Add(this.m_PanelEditDefinisseurChampsCustom);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageDefChampCustom, "");
            this.m_extLinkField.SetLinkField(this.m_pageDefChampCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageDefChampCustom, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_pageDefChampCustom, false);
            this.m_pageDefChampCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageDefChampCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageDefChampCustom, "");
            this.m_pageDefChampCustom.Name = "m_pageDefChampCustom";
            this.m_pageDefChampCustom.Selected = false;
            this.m_pageDefChampCustom.Size = new System.Drawing.Size(814, 320);
            this.m_extStyle.SetStyleBackColor(this.m_pageDefChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageDefChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageDefChampCustom.TabIndex = 12;
            this.m_pageDefChampCustom.Title = "Custom fileds definition|278";
            // 
            // m_PanelEditDefinisseurChampsCustom
            // 
            this.m_PanelEditDefinisseurChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PanelEditDefinisseurChampsCustom.AvecAffectationDirecteDeChamps = false;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_PanelEditDefinisseurChampsCustom, "");
            this.m_extLinkField.SetLinkField(this.m_PanelEditDefinisseurChampsCustom, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_PanelEditDefinisseurChampsCustom, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelEditDefinisseurChampsCustom, false);
            this.m_PanelEditDefinisseurChampsCustom.Location = new System.Drawing.Point(3, 3);
            this.m_PanelEditDefinisseurChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelEditDefinisseurChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelEditDefinisseurChampsCustom, "");
            this.m_PanelEditDefinisseurChampsCustom.Name = "m_PanelEditDefinisseurChampsCustom";
            this.m_PanelEditDefinisseurChampsCustom.Size = new System.Drawing.Size(808, 314);
            this.m_extStyle.SetStyleBackColor(this.m_PanelEditDefinisseurChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelEditDefinisseurChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelEditDefinisseurChampsCustom.TabIndex = 0;
            // 
            // m_pageAttributs
            // 
            this.m_pageAttributs.Controls.Add(this.m_panelEditionAttribut);
            this.m_pageAttributs.Controls.Add(this.m_groupBoxOptionsAttributs);
            this.m_pageAttributs.Controls.Add(this.c_lnkSupprimerAttribut);
            this.m_pageAttributs.Controls.Add(this.c_lnkAjouterAttribut);
            this.m_pageAttributs.Controls.Add(this.label4);
            this.m_pageAttributs.Controls.Add(this.m_listeAttributTypeContrainte);
            this.m_pageAttributs.Controls.Add(this.label2);
            this.m_pageAttributs.Controls.Add(this.m_txtAttributLibelle);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageAttributs, "");
            this.m_extLinkField.SetLinkField(this.m_pageAttributs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageAttributs, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_pageAttributs, false);
            this.m_pageAttributs.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageAttributs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageAttributs, "");
            this.m_pageAttributs.Name = "m_pageAttributs";
            this.m_pageAttributs.Selected = false;
            this.m_pageAttributs.Size = new System.Drawing.Size(814, 320);
            this.m_extStyle.SetStyleBackColor(this.m_pageAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageAttributs.TabIndex = 13;
            this.m_pageAttributs.Title = "Attribute Definition|330";
            // 
            // m_panelEditionAttribut
            // 
            this.m_panelEditionAttribut.Controls.Add(this.m_txtModifierAttributLibelle);
            this.m_panelEditionAttribut.Controls.Add(this.label6);
            this.m_extLinkField.SetLinkField(this.m_panelEditionAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelEditionAttribut, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditionAttribut, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_panelEditionAttribut, false);
            this.m_panelEditionAttribut.Location = new System.Drawing.Point(412, 210);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditionAttribut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelEditionAttribut, "");
            this.m_panelEditionAttribut.Name = "m_panelEditionAttribut";
            this.m_panelEditionAttribut.Size = new System.Drawing.Size(361, 63);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditionAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditionAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditionAttribut.TabIndex = 4018;
            // 
            // m_txtModifierAttributLibelle
            // 
            this.m_txtModifierAttributLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtModifierAttributLibelle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtModifierAttributLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtModifierAttributLibelle, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_txtModifierAttributLibelle, true);
            this.m_txtModifierAttributLibelle.Location = new System.Drawing.Point(10, 25);
            this.m_txtModifierAttributLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtModifierAttributLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtModifierAttributLibelle, "");
            this.m_txtModifierAttributLibelle.Name = "m_txtModifierAttributLibelle";
            this.m_txtModifierAttributLibelle.Size = new System.Drawing.Size(334, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtModifierAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtModifierAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtModifierAttributLibelle.TabIndex = 1;
            this.m_txtModifierAttributLibelle.Text = "[Libelle]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(7, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 15);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "Edit attribute Label|375";
            // 
            // m_groupBoxOptionsAttributs
            // 
            this.m_groupBoxOptionsAttributs.Controls.Add(this.checkBox3);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.checkBox1);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.m_chkOptionAuPlusUnAttributType);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.m_chkOptionAuMoinUnAttributType);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.m_chkOptionAttributLibre);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.m_chkOptionAttributListe);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.label3);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.label5);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.m_radUnSeulAttribut);
            this.m_groupBoxOptionsAttributs.Controls.Add(this.m_radTousLesAttributs);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_groupBoxOptionsAttributs, "");
            this.m_extLinkField.SetLinkField(this.m_groupBoxOptionsAttributs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_groupBoxOptionsAttributs, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_groupBoxOptionsAttributs, false);
            this.m_groupBoxOptionsAttributs.Location = new System.Drawing.Point(8, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_groupBoxOptionsAttributs, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_groupBoxOptionsAttributs, "");
            this.m_groupBoxOptionsAttributs.Name = "m_groupBoxOptionsAttributs";
            this.m_groupBoxOptionsAttributs.Size = new System.Drawing.Size(773, 129);
            this.m_extStyle.SetStyleBackColor(this.m_groupBoxOptionsAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_groupBoxOptionsAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_groupBoxOptionsAttributs.TabIndex = 4017;
            this.m_groupBoxOptionsAttributs.TabStop = false;
            this.m_groupBoxOptionsAttributs.Text = "General Options|320";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.checkBox3, "");
            this.m_extLinkField.SetLinkField(this.checkBox3, "IsContrainteNecessaireActeur");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.checkBox3, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox3, true);
            this.checkBox3.Location = new System.Drawing.Point(13, 110);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox3, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox3, "");
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(559, 19);
            this.m_extStyle.SetStyleBackColor(this.checkBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox3.TabIndex = 9;
            this.checkBox3.Text = "Members must raise this constaint to operate an intervention (example: must have " +
    "a qualification)|808";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.checkBox1, "");
            this.m_extLinkField.SetLinkField(this.checkBox1, "OptionToutesRessourcesDeTypeLevant");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.checkBox1, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox1, true);
            this.checkBox1.Location = new System.Drawing.Point(331, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(353, 35);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "If the constraint has no attributes, all the resources with the right type raises" +
    " the constraint|807";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // m_chkOptionAuPlusUnAttributType
            // 
            this.m_chkOptionAuPlusUnAttributType.AutoSize = true;
            this.m_chkOptionAuPlusUnAttributType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_chkOptionAuPlusUnAttributType, "");
            this.m_extLinkField.SetLinkField(this.m_chkOptionAuPlusUnAttributType, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_chkOptionAuPlusUnAttributType, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkOptionAuPlusUnAttributType, false);
            this.m_chkOptionAuPlusUnAttributType.Location = new System.Drawing.Point(45, 72);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkOptionAuPlusUnAttributType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkOptionAuPlusUnAttributType, "");
            this.m_chkOptionAuPlusUnAttributType.Name = "m_chkOptionAuPlusUnAttributType";
            this.m_chkOptionAuPlusUnAttributType.Size = new System.Drawing.Size(233, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkOptionAuPlusUnAttributType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkOptionAuPlusUnAttributType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkOptionAuPlusUnAttributType.TabIndex = 6;
            this.m_chkOptionAuPlusUnAttributType.Text = "One attribute maximum of this type|379";
            this.m_chkOptionAuPlusUnAttributType.UseVisualStyleBackColor = true;
            // 
            // m_chkOptionAuMoinUnAttributType
            // 
            this.m_chkOptionAuMoinUnAttributType.AutoSize = true;
            this.m_chkOptionAuMoinUnAttributType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_chkOptionAuMoinUnAttributType, "");
            this.m_extLinkField.SetLinkField(this.m_chkOptionAuMoinUnAttributType, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_chkOptionAuMoinUnAttributType, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkOptionAuMoinUnAttributType, false);
            this.m_chkOptionAuMoinUnAttributType.Location = new System.Drawing.Point(45, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkOptionAuMoinUnAttributType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkOptionAuMoinUnAttributType, "");
            this.m_chkOptionAuMoinUnAttributType.Name = "m_chkOptionAuMoinUnAttributType";
            this.m_chkOptionAuMoinUnAttributType.Size = new System.Drawing.Size(216, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkOptionAuMoinUnAttributType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkOptionAuMoinUnAttributType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkOptionAuMoinUnAttributType.TabIndex = 5;
            this.m_chkOptionAuMoinUnAttributType.Text = "At least one attribute of this type|378";
            this.m_chkOptionAuMoinUnAttributType.UseVisualStyleBackColor = true;
            // 
            // m_chkOptionAttributLibre
            // 
            this.m_chkOptionAttributLibre.AutoSize = true;
            this.m_chkOptionAttributLibre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_chkOptionAttributLibre, "");
            this.m_extLinkField.SetLinkField(this.m_chkOptionAttributLibre, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_chkOptionAttributLibre, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkOptionAttributLibre, false);
            this.m_chkOptionAttributLibre.Location = new System.Drawing.Point(13, 90);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkOptionAttributLibre, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkOptionAttributLibre, "");
            this.m_chkOptionAttributLibre.Name = "m_chkOptionAttributLibre";
            this.m_chkOptionAttributLibre.Size = new System.Drawing.Size(162, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkOptionAttributLibre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkOptionAttributLibre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkOptionAttributLibre.TabIndex = 4;
            this.m_chkOptionAttributLibre.Text = "Free defined attributes|368";
            this.m_chkOptionAttributLibre.UseVisualStyleBackColor = true;
            // 
            // m_chkOptionAttributListe
            // 
            this.m_chkOptionAttributListe.AutoSize = true;
            this.m_chkOptionAttributListe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_chkOptionAttributListe, "");
            this.m_extLinkField.SetLinkField(this.m_chkOptionAttributListe, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_chkOptionAttributListe, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkOptionAttributListe, false);
            this.m_chkOptionAttributListe.Location = new System.Drawing.Point(13, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkOptionAttributListe, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkOptionAttributListe, "");
            this.m_chkOptionAttributListe.Name = "m_chkOptionAttributListe";
            this.m_chkOptionAttributListe.Size = new System.Drawing.Size(209, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkOptionAttributListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkOptionAttributListe, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkOptionAttributListe.TabIndex = 3;
            this.m_chkOptionAttributListe.Text = "Attributes selected from the list|367";
            this.m_chkOptionAttributListe.UseVisualStyleBackColor = true;
            this.m_chkOptionAttributListe.CheckedChanged += new System.EventHandler(this.m_chkOptionAttributListe_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(9, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 2;
            this.label3.Text = "The Constraints of this type can have :|366";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(331, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(323, 15);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "The resources raising constraints of this type must have:|321";
            // 
            // m_radUnSeulAttribut
            // 
            this.m_radUnSeulAttribut.AutoSize = true;
            this.m_radUnSeulAttribut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_radUnSeulAttribut, "");
            this.m_extLinkField.SetLinkField(this.m_radUnSeulAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_radUnSeulAttribut, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radUnSeulAttribut, false);
            this.m_radUnSeulAttribut.Location = new System.Drawing.Point(331, 54);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radUnSeulAttribut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radUnSeulAttribut, "");
            this.m_radUnSeulAttribut.Name = "m_radUnSeulAttribut";
            this.m_radUnSeulAttribut.Size = new System.Drawing.Size(155, 19);
            this.m_extStyle.SetStyleBackColor(this.m_radUnSeulAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radUnSeulAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radUnSeulAttribut.TabIndex = 1;
            this.m_radUnSeulAttribut.TabStop = true;
            this.m_radUnSeulAttribut.Text = "At least one attribute|361";
            this.m_radUnSeulAttribut.UseVisualStyleBackColor = true;
            // 
            // m_radTousLesAttributs
            // 
            this.m_radTousLesAttributs.AutoSize = true;
            this.m_radTousLesAttributs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_radTousLesAttributs, "");
            this.m_extLinkField.SetLinkField(this.m_radTousLesAttributs, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_radTousLesAttributs, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_radTousLesAttributs, false);
            this.m_radTousLesAttributs.Location = new System.Drawing.Point(331, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_radTousLesAttributs, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_radTousLesAttributs, "");
            this.m_radTousLesAttributs.Name = "m_radTousLesAttributs";
            this.m_radTousLesAttributs.Size = new System.Drawing.Size(112, 19);
            this.m_extStyle.SetStyleBackColor(this.m_radTousLesAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_radTousLesAttributs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radTousLesAttributs.TabIndex = 0;
            this.m_radTousLesAttributs.TabStop = true;
            this.m_radTousLesAttributs.Text = "All attributes|360";
            this.m_radTousLesAttributs.UseVisualStyleBackColor = true;
            // 
            // c_lnkSupprimerAttribut
            // 
            this.c_lnkSupprimerAttribut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.c_lnkSupprimerAttribut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.c_lnkSupprimerAttribut.CustomImage = ((System.Drawing.Image)(resources.GetObject("c_lnkSupprimerAttribut.CustomImage")));
            this.c_lnkSupprimerAttribut.CustomText = "Remove";
            this.c_lnkSupprimerAttribut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.c_lnkSupprimerAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.c_lnkSupprimerAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.c_lnkSupprimerAttribut, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c_lnkSupprimerAttribut, false);
            this.c_lnkSupprimerAttribut.Location = new System.Drawing.Point(20, 282);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c_lnkSupprimerAttribut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c_lnkSupprimerAttribut, "");
            this.c_lnkSupprimerAttribut.Name = "c_lnkSupprimerAttribut";
            this.c_lnkSupprimerAttribut.ShortMode = false;
            this.c_lnkSupprimerAttribut.Size = new System.Drawing.Size(116, 22);
            this.m_extStyle.SetStyleBackColor(this.c_lnkSupprimerAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c_lnkSupprimerAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c_lnkSupprimerAttribut.TabIndex = 7;
            this.c_lnkSupprimerAttribut.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.c_lnkSupprimerAttribut.LinkClicked += new System.EventHandler(this.c_lnkSupprimerAttribut_LinkClicked);
            // 
            // c_lnkAjouterAttribut
            // 
            this.c_lnkAjouterAttribut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.c_lnkAjouterAttribut.CustomImage = ((System.Drawing.Image)(resources.GetObject("c_lnkAjouterAttribut.CustomImage")));
            this.c_lnkAjouterAttribut.CustomText = "Add";
            this.c_lnkAjouterAttribut.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.c_lnkAjouterAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.c_lnkAjouterAttribut, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.c_lnkAjouterAttribut, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c_lnkAjouterAttribut, false);
            this.c_lnkAjouterAttribut.Location = new System.Drawing.Point(57, 172);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c_lnkAjouterAttribut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c_lnkAjouterAttribut, "");
            this.c_lnkAjouterAttribut.Name = "c_lnkAjouterAttribut";
            this.c_lnkAjouterAttribut.ShortMode = false;
            this.c_lnkAjouterAttribut.Size = new System.Drawing.Size(58, 19);
            this.m_extStyle.SetStyleBackColor(this.c_lnkAjouterAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c_lnkAjouterAttribut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c_lnkAjouterAttribut.TabIndex = 6;
            this.c_lnkAjouterAttribut.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.c_lnkAjouterAttribut.LinkClicked += new System.EventHandler(this.c_lnkAjouterAttribut_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(17, 194);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(181, 15);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 1;
            this.label4.Text = "Constraint Type attribute List|346";
            // 
            // m_listeAttributTypeContrainte
            // 
            this.m_listeAttributTypeContrainte.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_listeAttributTypeContrainte.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listeAttributLibelle});
            this.m_listeAttributTypeContrainte.EnableCustomisation = true;
            this.m_listeAttributTypeContrainte.FullRowSelect = true;
            this.m_listeAttributTypeContrainte.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_listeAttributTypeContrainte, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_listeAttributTypeContrainte, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_listeAttributTypeContrainte, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_listeAttributTypeContrainte, false);
            this.m_listeAttributTypeContrainte.Location = new System.Drawing.Point(20, 210);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_listeAttributTypeContrainte, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_listeAttributTypeContrainte, "");
            this.m_listeAttributTypeContrainte.MultiSelect = false;
            this.m_listeAttributTypeContrainte.Name = "m_listeAttributTypeContrainte";
            this.m_listeAttributTypeContrainte.Size = new System.Drawing.Size(376, 66);
            this.m_extStyle.SetStyleBackColor(this.m_listeAttributTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_listeAttributTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_listeAttributTypeContrainte.TabIndex = 0;
            this.m_listeAttributTypeContrainte.UseCompatibleStateImageBehavior = false;
            this.m_listeAttributTypeContrainte.View = System.Windows.Forms.View.Details;
            // 
            // listeAttributLibelle
            // 
            this.listeAttributLibelle.Field = "Libelle";
            this.listeAttributLibelle.PrecisionWidth = 0D;
            this.listeAttributLibelle.ProportionnalSize = false;
            this.listeAttributLibelle.Text = "Label|50";
            this.listeAttributLibelle.Visible = true;
            this.listeAttributLibelle.Width = 348;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(18, 135);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 15);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Enter attribute label to add|347";
            // 
            // m_txtAttributLibelle
            // 
            this.m_txtAttributLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtAttributLibelle, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtAttributLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtAttributLibelle, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_txtAttributLibelle, false);
            this.m_txtAttributLibelle.Location = new System.Drawing.Point(53, 149);
            this.m_txtAttributLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtAttributLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtAttributLibelle, "");
            this.m_txtAttributLibelle.Name = "m_txtAttributLibelle";
            this.m_txtAttributLibelle.Size = new System.Drawing.Size(343, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAttributLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAttributLibelle.TabIndex = 0;
            // 
            // m_pageTypesFils
            // 
            this.m_pageTypesFils.Controls.Add(this.m_panelListeTypesContraintesFils);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageTypesFils, "");
            this.m_extLinkField.SetLinkField(this.m_pageTypesFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageTypesFils, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_pageTypesFils, false);
            this.m_pageTypesFils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageTypesFils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageTypesFils, "");
            this.m_pageTypesFils.Name = "m_pageTypesFils";
            this.m_pageTypesFils.Selected = false;
            this.m_pageTypesFils.Size = new System.Drawing.Size(814, 320);
            this.m_extStyle.SetStyleBackColor(this.m_pageTypesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageTypesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageTypesFils.TabIndex = 10;
            this.m_pageTypesFils.Title = "Child Types|279";
            // 
            // m_panelListeTypesContraintesFils
            // 
            this.m_panelListeTypesContraintesFils.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeTypesContraintesFils.AffectationsPourNouveauxElements")));
            this.m_panelListeTypesContraintesFils.AllowArbre = true;
            this.m_panelListeTypesContraintesFils.AllowCustomisation = true;
            this.m_panelListeTypesContraintesFils.AllowSerializePreferences = true;
            this.m_panelListeTypesContraintesFils.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "ColumnLabel";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_panelListeTypesContraintesFils.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListeTypesContraintesFils.ContexteUtilisation = "";
            this.m_panelListeTypesContraintesFils.ControlFiltreStandard = null;
            this.m_panelListeTypesContraintesFils.ElementSelectionne = null;
            this.m_panelListeTypesContraintesFils.EnableCustomisation = true;
            this.m_panelListeTypesContraintesFils.FiltreDeBase = null;
            this.m_panelListeTypesContraintesFils.FiltreDeBaseEnAjout = false;
            this.m_panelListeTypesContraintesFils.FiltrePrefere = null;
            this.m_panelListeTypesContraintesFils.FiltreRapide = null;
            this.m_panelListeTypesContraintesFils.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeTypesContraintesFils, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelListeTypesContraintesFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeTypesContraintesFils, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_panelListeTypesContraintesFils, false);
            this.m_panelListeTypesContraintesFils.ListeObjets = null;
            this.m_panelListeTypesContraintesFils.Location = new System.Drawing.Point(3, 3);
            this.m_panelListeTypesContraintesFils.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeTypesContraintesFils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeTypesContraintesFils.ModeQuickSearch = false;
            this.m_panelListeTypesContraintesFils.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeTypesContraintesFils, "");
            this.m_panelListeTypesContraintesFils.MultiSelect = false;
            this.m_panelListeTypesContraintesFils.Name = "m_panelListeTypesContraintesFils";
            this.m_panelListeTypesContraintesFils.Navigateur = null;
            this.m_panelListeTypesContraintesFils.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListeTypesContraintesFils.ProprieteObjetAEditer = null;
            this.m_panelListeTypesContraintesFils.QuickSearchText = "";
            this.m_panelListeTypesContraintesFils.ShortIcons = false;
            this.m_panelListeTypesContraintesFils.Size = new System.Drawing.Size(808, 314);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeTypesContraintesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeTypesContraintesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeTypesContraintesFils.TabIndex = 0;
            this.m_panelListeTypesContraintesFils.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeTypesContraintesFils.UseCheckBoxes = false;
            // 
            // m_pageSelectRelKeyTypes
            // 
            this.m_pageSelectRelKeyTypes.Controls.Add(this.m_PanelEditRelations);
            this.m_pageSelectRelKeyTypes.Controls.Add(this.m_lnkAjouter);
            this.m_pageSelectRelKeyTypes.Controls.Add(this.m_txtSelectTypeRessource);
            this.m_pageSelectRelKeyTypes.Controls.Add(this.m_lblSelectResType);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageSelectRelKeyTypes, "");
            this.m_extLinkField.SetLinkField(this.m_pageSelectRelKeyTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSelectRelKeyTypes, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_pageSelectRelKeyTypes, false);
            this.m_pageSelectRelKeyTypes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSelectRelKeyTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSelectRelKeyTypes, "");
            this.m_pageSelectRelKeyTypes.Name = "m_pageSelectRelKeyTypes";
            this.m_pageSelectRelKeyTypes.Selected = false;
            this.m_pageSelectRelKeyTypes.Size = new System.Drawing.Size(814, 320);
            this.m_extStyle.SetStyleBackColor(this.m_pageSelectRelKeyTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSelectRelKeyTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSelectRelKeyTypes.TabIndex = 11;
            this.m_pageSelectRelKeyTypes.Title = "Related Resources Types|271";
            // 
            // m_PanelEditRelations
            // 
            this.m_PanelEditRelations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_PanelEditRelations, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_PanelEditRelations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelEditRelations, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_PanelEditRelations, false);
            this.m_PanelEditRelations.Location = new System.Drawing.Point(15, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelEditRelations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_PanelEditRelations, "");
            this.m_PanelEditRelations.Name = "m_PanelEditRelations";
            this.m_PanelEditRelations.Size = new System.Drawing.Size(779, 230);
            this.m_extStyle.SetStyleBackColor(this.m_PanelEditRelations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelEditRelations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelEditRelations.TabIndex = 5;
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAjouter.CustomImage")));
            this.m_lnkAjouter.CustomText = "Add";
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouter, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lnkAjouter, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_lnkAjouter, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouter, false);
            this.m_lnkAjouter.Location = new System.Drawing.Point(15, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouter, "");
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.ShortMode = false;
            this.m_lnkAjouter.Size = new System.Drawing.Size(104, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouter.TabIndex = 4;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_txtSelectTypeRessource
            // 
            this.m_txtSelectTypeRessource.ElementSelectionne = null;
            this.m_txtSelectTypeRessource.FonctionTextNull = null;
            this.m_txtSelectTypeRessource.HasLink = true;
            this.m_txtSelectTypeRessource.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeRessource, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_txtSelectTypeRessource, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_txtSelectTypeRessource, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectTypeRessource, false);
            this.m_txtSelectTypeRessource.Location = new System.Drawing.Point(15, 27);
            this.m_txtSelectTypeRessource.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeRessource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeRessource, "");
            this.m_txtSelectTypeRessource.Name = "m_txtSelectTypeRessource";
            this.m_txtSelectTypeRessource.SelectedObject = null;
            this.m_txtSelectTypeRessource.Size = new System.Drawing.Size(320, 20);
            this.m_txtSelectTypeRessource.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeRessource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeRessource.TabIndex = 3;
            this.m_txtSelectTypeRessource.TextNull = "";
            // 
            // m_lblSelectResType
            // 
            this.m_lblSelectResType.AutoSize = true;
            this.m_extLinkEditionAttribut.SetLinkField(this.m_lblSelectResType, "");
            this.m_extLinkField.SetLinkField(this.m_lblSelectResType, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblSelectResType, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_lblSelectResType, false);
            this.m_lblSelectResType.Location = new System.Drawing.Point(16, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblSelectResType, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblSelectResType, "");
            this.m_lblSelectResType.Name = "m_lblSelectResType";
            this.m_lblSelectResType.Size = new System.Drawing.Size(178, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblSelectResType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblSelectResType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblSelectResType.TabIndex = 0;
            this.m_lblSelectResType.Text = "Select related Resource Type|272";
            // 
            // columnLibelle
            // 
            this.columnLibelle.Field = "TypeCle.Libelle";
            this.columnLibelle.PrecisionWidth = 0D;
            this.columnLibelle.ProportionnalSize = false;
            this.columnLibelle.Text = "Label|50";
            this.columnLibelle.Visible = true;
            this.columnLibelle.Width = 120;
            // 
            // colLibelle
            // 
            this.colLibelle.Field = "Libelle";
            this.colLibelle.PrecisionWidth = 0D;
            this.colLibelle.ProportionnalSize = false;
            this.colLibelle.Text = "Label|50";
            this.colLibelle.Visible = true;
            this.colLibelle.Width = 120;
            // 
            // m_gestionnaireEditionAttribut
            // 
            this.m_gestionnaireEditionAttribut.ListeAssociee = this.m_listeAttributTypeContrainte;
            this.m_gestionnaireEditionAttribut.ObjetEdite = null;
            this.m_gestionnaireEditionAttribut.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionAttribut_InitChamp);
            this.m_gestionnaireEditionAttribut.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionAttribut_MAJ_Champs);
            // 
            // m_extLinkEditionAttribut
            // 
            this.m_extLinkEditionAttribut.SourceTypeString = "";
            // 
            // m_pageFormulaires
            // 
            this.m_pageFormulaires.Controls.Add(this.m_panelChamps);
            this.m_extLinkEditionAttribut.SetLinkField(this.m_pageFormulaires, "");
            this.m_extLinkField.SetLinkField(this.m_pageFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_pageFormulaires, true);
            this.m_pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulaires, "");
            this.m_pageFormulaires.Name = "m_pageFormulaires";
            this.m_pageFormulaires.Size = new System.Drawing.Size(814, 320);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaires.TabIndex = 14;
            this.m_pageFormulaires.Title = "Form|60";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelChamps.BoldSelectedPage = true;
            this.m_panelChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChamps.ElementEdite = null;
            this.m_panelChamps.ForeColor = System.Drawing.Color.Black;
            this.m_panelChamps.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkEditionAttribut.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this.m_panelChamps, true);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(814, 320);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 3;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // CFormEditionTypeContrainte
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 550);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkEditionAttribut.SetLinkField(this, "");
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkEditionAttribut.SetLinkFieldAutoUpdate(this, false);
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeContrainte";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeContrainte_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeContrainte_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre1, 0);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_wndImage)).EndInit();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageDefChampCustom.ResumeLayout(false);
            this.m_pageAttributs.ResumeLayout(false);
            this.m_pageAttributs.PerformLayout();
            this.m_panelEditionAttribut.ResumeLayout(false);
            this.m_panelEditionAttribut.PerformLayout();
            this.m_groupBoxOptionsAttributs.ResumeLayout(false);
            this.m_groupBoxOptionsAttributs.PerformLayout();
            this.m_pageTypesFils.ResumeLayout(false);
            this.m_pageSelectRelKeyTypes.ResumeLayout(false);
            this.m_pageSelectRelKeyTypes.PerformLayout();
            this.m_pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //---------------------- Objet édité ----------------------------------------
        private CTypeContrainte TypeContrainte
        {
            get
            {
                return (CTypeContrainte)ObjetEdite;
            }
        }
        
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();

            AffecterTitre(I.T( "Constraint Type|258") + " " + TypeContrainte.Libelle);

            // Visibilité de l'onglet Formulaires
            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeContrainte.DefinisseursDeChamps)
            {
                if (def.RelationsFormulaires.Length > 0)
                {
                    bHasFormulaires = true;
                    break;
                }
            }
            if (!bHasFormulaires)
            {
                if (m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Remove(m_pageFormulaires);
            }
            else
            {
                if (!m_TabControl.TabPages.Contains(m_pageFormulaires))
                    m_TabControl.TabPages.Insert(0, m_pageFormulaires);
            }
			

            // Initialise l'affichage de l'arbre hiérarchique
            m_ArbreTypesContHierarchiques.AfficheHierarchie(TypeContrainte);

            //Init page défintion des Atributs
            //InitListeAttributs();

			//if (TypeContrainte.OptionTousAttributsRessourceLevant)
			//    m_radTousLesAttributs.Checked = true;
			//else
			//    m_radUnSeulAttribut.Checked = true;

			//m_chkOptionAttributListe.Checked = TypeContrainte.OptionChoixAttributDansListe;
			//m_chkOptionAuMoinUnAttributType.Checked = TypeContrainte.OptionAuMoinsUnAttributListe;
			//m_chkOptionAuPlusUnAttributType.Checked = TypeContrainte.OptionAuPlusUnAttributListe;
			//InitSousOptions();

			//m_chkOptionAttributLibre.Checked = TypeContrainte.OptionChoixAttributLibre;

			//m_gestionnaireEditionAttribut.ObjetEdite = TypeContrainte.AttributsTypeContrainte;
			//m_panelEditionAttribut.Visible = false;

			//// Initialise la liste des types fils
			//m_panelListeTypesContraintesFils.InitFromListeObjets(
			//    TypeContrainte.TypesContraintesFils,
			//    typeof(CTypeContrainte),
			//    typeof(CFormEditionTypeContrainte),
			//    TypeContrainte,
			//    "TypeContrainteParent");

			//// Init champs custom
			//m_PanelEditDefinisseurChampsCustom.InitPanel(
			//    TypeContrainte,
			//    typeof(CFormListeChampsCustom),
			//    typeof(CFormListeFormulaires));

			//// Init la liste des relations avec les types de ressource
			//m_PanelEditRelations.InitPanel(TypeContrainte.RelationsTypesRessourcesListe, "TypeRessource.Libelle");
			//InitSelectTypeRessource();

			m_wndImage.Image = TypeContrainte.ImagePropre;


            return result;
        }

		//-------------------------------------------------------------------------
		private void UpdateCouleurDeFond()
		{
			m_panelImage.BackColor = m_couleurDeFond;
			m_wndImage.BackColor = m_couleurDeFond;
		}

        private void InitListeAttributs()
        {
            m_listeAttributTypeContrainte.Items.Clear();

            foreach (CAttributTypeContrainte att in TypeContrainte.AttributsTypeContrainte)
            {
                ListViewItem item = new ListViewItem();
                m_listeAttributTypeContrainte.Items.Add(item);
                m_listeAttributTypeContrainte.UpdateItemWithObject(item, att);
            }
            foreach (ListViewItem itemSel in m_listeAttributTypeContrainte.SelectedItems)
                itemSel.Selected = false;
 
       }


        //-------------------------------------------------------------------------
        private void InitSelectTypeRessource()
        {
            m_txtSelectTypeRessource.Init<CTypeRessource>(
                "Libelle", 
                false);

        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            
			//if (result)
			//    result = m_PanelEditDefinisseurChampsCustom.MAJ_Champs();
			//if (result)
			//    result = m_PanelEditRelations.MAJ_Champs();
			//if (result)
			//{

			//    // Options
			//    if (m_radTousLesAttributs.Checked)
			//        TypeContrainte.OptionTousAttributsRessourceLevant = true;
			//    else
			//        TypeContrainte.OptionTousAttributsRessourceLevant = false;

			//    TypeContrainte.OptionChoixAttributDansListe = m_chkOptionAttributListe.Checked;
			//    TypeContrainte.OptionAuMoinsUnAttributListe = m_chkOptionAuMoinUnAttributType.Checked;
			//    TypeContrainte.OptionAuPlusUnAttributListe = m_chkOptionAuPlusUnAttributType.Checked;

			//    TypeContrainte.OptionChoixAttributLibre = m_chkOptionAttributLibre.Checked;
			//}

			//if ( result )
			//    result = m_gestionnaireEditionAttribut.ValideModifs();

			if (m_wndImage.Image != null)
			{
				Image img = m_wndImage.Image;
				Bitmap bmp = new Bitmap(img.Width, img.Height);
				Graphics g = Graphics.FromImage(bmp);
				Brush br = new SolidBrush(m_couleurDeFond);
				g.FillRectangle(br, 0, 0, img.Width, img.Height);
				br.Dispose();
				g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height), 0, 0, img.Width, img.Height, GraphicsUnit.Pixel);
				TypeContrainte.ImagePropre = bmp;
				g.Dispose();
				bmp.Dispose();
			}
			else
				TypeContrainte.ImagePropre = null;

            return result;

        }

		//-------------------------------------------------------------------------
		private void m_btnSelectImage_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = I.T("All images|*.jpg;*.bmp;*.gif;*.tif;*.ico|Bitmap|*.bmp|Jpeg|*.jpg;*.jpeg|Gif|*.gif|Tif|*.tif|Icon|*.ico|All files|*.*|30233");
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				string strFile = dlg.FileName;
				try
				{
					Image img = Image.FromFile(strFile, true);
					if (!(img is Bitmap))
						throw new Exception(I.T("Incorrect Format|30049"));
					if (img.Width > 16 || img.Height > 16)
					{
						CFormAlerte.Afficher(I.T("A maximal image size of 16x16 is recommended|30050"));
					}
					m_wndImage.Image = img;
				}
				catch (Exception exp)
				{
					CResultAErreur result = CResultAErreur.True;
					result.EmpileErreur(new CErreurException(exp));
					result.EmpileErreur(I.T("File reading error|30051"));
					CFormAlerte.Afficher(result.Erreur);
				}
			}
		}

		//-------------------------------------------------------------------------
		private void m_btnNoImage_Click(object sender, System.EventArgs e)
		{
			m_wndImage.Image = null;
		}

		//-------------------------------------------------------------------------
		private void m_lnkCouleurFond_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			ColorDialog dlg = new ColorDialog();
			if (dlg.ShowDialog() == DialogResult.OK)
			{
				m_couleurDeFond = dlg.Color;
				UpdateCouleurDeFond();
			}
		}


 
        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            
            if (m_txtSelectTypeRessource.Text == "")
            {
				CFormAlerte.Afficher(I.T("Please select a Resource Type to add|285"), EFormAlerteType.Exclamation);
                return;
            }

            m_PanelEditRelations.AddRelation(
                TypeContrainte.RelationsTypesRessourcesListe,
                (CTypeRessource) m_txtSelectTypeRessource.ElementSelectionne,
                TypeContrainte);



        }


        private void c_lnkAjouterAttribut_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtAttributLibelle.Text == "")
            {
				CFormAlerte.Afficher(I.T("Enter attribute label to add|348"), EFormAlerteType.Exclamation);
                return;
            }

            string strLibelle = m_txtAttributLibelle.Text;
            CListeObjetsDonnees listeAttrib = TypeContrainte.AttributsTypeContrainte;

            listeAttrib.Filtre = new CFiltreData(CAttributTypeContrainte.c_champLibelle + " = @1 ", strLibelle);
            if(listeAttrib.Count != 0)
            {
				CFormAlerte.Afficher(I.T("This attribute is already in the list|349"), EFormAlerteType.Erreur);
                return;
            }
            m_txtAttributLibelle.Text = "";
            CAttributTypeContrainte attTypeCont = new CAttributTypeContrainte(TypeContrainte.ContexteDonnee);
            attTypeCont.CreateNewInCurrentContexte();
            attTypeCont.Libelle = strLibelle;
            attTypeCont.TypeContrainte = TypeContrainte;

            // Mise à Jour de la liste
            ListViewItem item = new ListViewItem();
            m_listeAttributTypeContrainte.Items.Add(item);
            m_listeAttributTypeContrainte.UpdateItemWithObject(item, attTypeCont);
            foreach (ListViewItem itemSel in m_listeAttributTypeContrainte.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;

        }

        private void c_lnkSupprimerAttribut_LinkClicked(object sender, EventArgs e)
        {
            if(m_listeAttributTypeContrainte.SelectedItems.Count != 1)
                return;

            CAttributTypeContrainte att = (CAttributTypeContrainte) m_listeAttributTypeContrainte.SelectedItems[0].Tag;

            CResultAErreur result = att.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }

            if (m_listeAttributTypeContrainte.SelectedItems.Count == 1)
            {
                if (m_listeAttributTypeContrainte.SelectedItems[0] != null)
                    m_listeAttributTypeContrainte.SelectedItems[0].Remove();
            }


        }

        private void m_gestionnaireEditionAttribut_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            if (args.Objet == null)
            {
                m_panelEditionAttribut.Visible = false;
                return;
            }
            m_panelEditionAttribut.Visible = true;
            m_extLinkEditionAttribut.FillDialogFromObjet(args.Objet);
        }

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

        //----------------------------------------------------------------------------------------------
        private void m_chkOptionAttributListe_CheckedChanged(object sender, EventArgs e)
        {
            InitSousOptions();
        }

        private void InitSousOptions()
        {
            if (!m_chkOptionAttributListe.Checked)
            {
                m_chkOptionAuMoinUnAttributType.Enabled = m_chkOptionAuPlusUnAttributType.Enabled = false;
                m_chkOptionAuMoinUnAttributType.Checked = m_chkOptionAuPlusUnAttributType.Checked = false;
            }
            else
                m_chkOptionAuMoinUnAttributType.Enabled = m_chkOptionAuPlusUnAttributType.Enabled =
                    m_gestionnaireModeEdition.ModeEdition;
        }

		private CResultAErreur CFormEditionTypeContrainte_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
                if (page == m_pageFormulaires)
                {
                    m_panelChamps.ElementEdite = TypeContrainte;
                }
				else if (page == m_pageAttributs)
				{
					InitListeAttributs();

					if (TypeContrainte.OptionTousAttributsRessourceLevant)
						m_radTousLesAttributs.Checked = true;
					else
						m_radUnSeulAttribut.Checked = true;

					m_chkOptionAttributListe.Checked = TypeContrainte.OptionChoixAttributDansListe;
					m_chkOptionAuMoinUnAttributType.Checked = TypeContrainte.OptionAuMoinsUnAttributListe;
					m_chkOptionAuPlusUnAttributType.Checked = TypeContrainte.OptionAuPlusUnAttributListe;
					InitSousOptions();

					m_chkOptionAttributLibre.Checked = TypeContrainte.OptionChoixAttributLibre;

					m_gestionnaireEditionAttribut.ObjetEdite = TypeContrainte.AttributsTypeContrainte;
					m_panelEditionAttribut.Visible = false;
				}
				else if (page == m_pageTypesFils)
				{
					// Initialise la liste des types fils
					m_panelListeTypesContraintesFils.InitFromListeObjets(
						TypeContrainte.TypesContraintesFils,
						typeof(CTypeContrainte),
						typeof(CFormEditionTypeContrainte),
						TypeContrainte,
						"TypeContrainteParent");
				}
				else if (page == m_pageSelectRelKeyTypes)
				{
					// Init la liste des relations avec les types de ressource
					m_PanelEditRelations.InitPanel(TypeContrainte.RelationsTypesRessourcesListe, "TypeRessource.Libelle");
					InitSelectTypeRessource();
				}
				else if (page == m_pageDefChampCustom)
				{
					// Init champs custom
					m_PanelEditDefinisseurChampsCustom.InitPanel(
						TypeContrainte,
						typeof(CFormListeChampsCustom),
						typeof(CFormListeFormulaires));
				}
			}
			return result;
		}

		private CResultAErreur CFormEditionTypeContrainte_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

            if (page == m_pageFormulaires)
            {
                result = m_panelChamps.MAJ_Champs();
            }
			else if (page == m_pageAttributs)
			{
				// Options
				if (m_radTousLesAttributs.Checked)
					TypeContrainte.OptionTousAttributsRessourceLevant = true;
				else
					TypeContrainte.OptionTousAttributsRessourceLevant = false;

				TypeContrainte.OptionChoixAttributDansListe = m_chkOptionAttributListe.Checked;
				TypeContrainte.OptionAuMoinsUnAttributListe = m_chkOptionAuMoinUnAttributType.Checked;
				TypeContrainte.OptionAuPlusUnAttributListe = m_chkOptionAuPlusUnAttributType.Checked;

				TypeContrainte.OptionChoixAttributLibre = m_chkOptionAttributLibre.Checked;

				result = m_gestionnaireEditionAttribut.ValideModifs();
			}
			else if (page == m_pageTypesFils)
			{
			}
			else if (page == m_pageSelectRelKeyTypes)
			{
				result = m_PanelEditRelations.MAJ_Champs();
			}
			else if (page == m_pageDefChampCustom)
			{
				result = m_PanelEditDefinisseurChampsCustom.MAJ_Champs();
			}
			return result;
		}


    }
}

