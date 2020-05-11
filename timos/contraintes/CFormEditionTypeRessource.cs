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
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeRessource))]
    public class CFormEditionTypeRessource : CFormEditionStdTimos
    {
        private C2iPanelOmbre c2iPanelOmbre1;
        private C2iTextBox m_txtBoxLibelle;
        private Label label1;
        private C2iTabControl m_TabControl;
        private Crownwood.Magic.Controls.TabPage pageCommentaire;
        private C2iTextBox c2iTextBox1;
        private Label m_labelLibelle;
        private Crownwood.Magic.Controls.TabPage pageRelTypeContrainte;
        private Label m_lblChoixTypeContrainte;
        private ListViewAutoFilledColumn colLibelle;
        private Crownwood.Magic.Controls.TabPage pageDefChampsCustom;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_PanelEditDefinisseurChampsCustom;
        private CPanelEditRelationTypeContrainteTypeRessource m_PanelEditRelations;
        private C2iTextBoxSelectionne m_txtSelectTypeContrainte;
        private CWndLinkStd m_lnkAjouter;
        private Label m_labelCodeSysteme;
        private Label m_lblCodeSystemeComplet;
        private CArbreObjetHierarchique m_arbreRessourceHierarchique;
        private Crownwood.Magic.Controls.TabPage pageTypesFils;
        private CPanelListeSpeedStandard m_panelListeTypesFils;
        private Label label2;
        private Label label3;
        private CheckBox m_chkEmplacementSite;
        private CheckBox m_chkBoxeEmplacementActeur;
        private Panel panel1;
        private Panel panel2;
        private Label label4;
        private CheckBox m_chkRessourceDeplacable;
        private Crownwood.Magic.Controls.TabPage pageEO;
        private CPanelAffectationEO m_panelAffectationEO;
        private Label label5;
        private CheckBox m_chkAfficherAgenda;
        private Panel panel4;
        private Panel panel3;
        private Crownwood.Magic.Controls.TabPage pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public CFormEditionTypeRessource()
            :base()
        {
            InitializeComponent();
        }

        public CFormEditionTypeRessource(CTypeRessource TypeCle)
            : base(TypeCle)
        {
            InitializeComponent();
        }

        public CFormEditionTypeRessource(CTypeRessource TypeCle, CListeObjetsDonnees liste)
            : base(TypeCle, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeRessource));
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_arbreRessourceHierarchique = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.m_labelCodeSysteme = new System.Windows.Forms.Label();
            this.m_lblCodeSystemeComplet = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.m_labelLibelle = new System.Windows.Forms.Label();
            this.m_txtBoxLibelle = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.pageTypesFils = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeTypesFils = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.pageRelTypeContrainte = new Crownwood.Magic.Controls.TabPage();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_PanelEditRelations = new timos.CPanelEditRelationTypeContrainteTypeRessource();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lblChoixTypeContrainte = new System.Windows.Forms.Label();
            this.m_txtSelectTypeContrainte = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.pageEO = new Crownwood.Magic.Controls.TabPage();
            this.m_panelAffectationEO = new timos.CPanelAffectationEO();
            this.pageDefChampsCustom = new Crownwood.Magic.Controls.TabPage();
            this.m_PanelEditDefinisseurChampsCustom = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.pageCommentaire = new Crownwood.Magic.Controls.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_chkAfficherAgenda = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkBoxeEmplacementActeur = new System.Windows.Forms.CheckBox();
            this.m_chkRessourceDeplacable = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chkEmplacementSite = new System.Windows.Forms.CheckBox();
            this.colLibelle = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.pageTypesFils.SuspendLayout();
            this.pageRelTypeContrainte.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.pageEO.SuspendLayout();
            this.pageDefChampsCustom.SuspendLayout();
            this.pageCommentaire.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pageFormulaires.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(623, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(515, 0);
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
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_arbreRessourceHierarchique);
            this.c2iPanelOmbre1.Controls.Add(this.m_labelCodeSysteme);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblCodeSystemeComplet);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre1.Controls.Add(this.m_labelLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtBoxLibelle);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre1, false);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(0, 43);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(814, 200);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 4003;
            // 
            // m_arbreRessourceHierarchique
            // 
            this.m_arbreRessourceHierarchique.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_arbreRessourceHierarchique.AutoriseReaffectation = true;
            this.m_arbreRessourceHierarchique.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_arbreRessourceHierarchique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_arbreRessourceHierarchique, false);
            this.m_arbreRessourceHierarchique.Location = new System.Drawing.Point(3, 3);
            this.m_arbreRessourceHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_arbreRessourceHierarchique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_arbreRessourceHierarchique, "");
            this.m_arbreRessourceHierarchique.Name = "m_arbreRessourceHierarchique";
            this.m_arbreRessourceHierarchique.Size = new System.Drawing.Size(783, 98);
            this.m_extStyle.SetStyleBackColor(this.m_arbreRessourceHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_arbreRessourceHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_arbreRessourceHierarchique.TabIndex = 10;
            // 
            // m_labelCodeSysteme
            // 
            this.m_labelCodeSysteme.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_labelCodeSysteme.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_labelCodeSysteme, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelCodeSysteme, false);
            this.m_labelCodeSysteme.Location = new System.Drawing.Point(540, 113);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelCodeSysteme, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelCodeSysteme, "");
            this.m_labelCodeSysteme.Name = "m_labelCodeSysteme";
            this.m_labelCodeSysteme.Size = new System.Drawing.Size(88, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelCodeSysteme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelCodeSysteme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelCodeSysteme.TabIndex = 8;
            this.m_labelCodeSysteme.Text = "System code|121";
            // 
            // m_lblCodeSystemeComplet
            // 
            this.m_lblCodeSystemeComplet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblCodeSystemeComplet.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblCodeSystemeComplet, "CodeSystemeComplet");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblCodeSystemeComplet, true);
            this.m_lblCodeSystemeComplet.Location = new System.Drawing.Point(640, 113);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblCodeSystemeComplet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblCodeSystemeComplet, "");
            this.m_lblCodeSystemeComplet.Name = "m_lblCodeSystemeComplet";
            this.m_lblCodeSystemeComplet.Size = new System.Drawing.Size(116, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lblCodeSystemeComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblCodeSystemeComplet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblCodeSystemeComplet.TabIndex = 9;
            this.m_lblCodeSystemeComplet.Text = "[CodeSystemeComplet]";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(12, 139);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 11;
            this.label2.Text = "Comments|51";
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Commentaire");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(104, 136);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Multiline = true;
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(682, 41);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 0;
            this.c2iTextBox1.Text = "[Commentaire]";
            // 
            // m_labelLibelle
            // 
            this.m_labelLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_labelLibelle.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_labelLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_labelLibelle, false);
            this.m_labelLibelle.Location = new System.Drawing.Point(12, 113);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelLibelle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_labelLibelle, "");
            this.m_labelLibelle.Name = "m_labelLibelle";
            this.m_labelLibelle.Size = new System.Drawing.Size(47, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelLibelle.TabIndex = 4;
            this.m_labelLibelle.Text = "Label|50";
            // 
            // m_txtBoxLibelle
            // 
            this.m_txtBoxLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtBoxLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtBoxLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtBoxLibelle, true);
            this.m_txtBoxLibelle.Location = new System.Drawing.Point(104, 110);
            this.m_txtBoxLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBoxLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtBoxLibelle, "");
            this.m_txtBoxLibelle.Name = "m_txtBoxLibelle";
            this.m_txtBoxLibelle.Size = new System.Drawing.Size(431, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBoxLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBoxLibelle.TabIndex = 3;
            this.m_txtBoxLibelle.Text = "[Libelle]";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
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
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_TabControl, false);
            this.m_TabControl.Location = new System.Drawing.Point(0, 249);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_TabControl, "");
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.pageFormulaires;
            this.m_TabControl.Size = new System.Drawing.Size(830, 285);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_TabControl.TabIndex = 4005;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.pageFormulaires,
            this.pageTypesFils,
            this.pageRelTypeContrainte,
            this.pageEO,
            this.pageDefChampsCustom,
            this.pageCommentaire});
            this.m_TabControl.TextColor = System.Drawing.Color.Black;
            // 
            // pageTypesFils
            // 
            this.pageTypesFils.Controls.Add(this.m_panelListeTypesFils);
            this.m_extLinkField.SetLinkField(this.pageTypesFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageTypesFils, false);
            this.pageTypesFils.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageTypesFils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageTypesFils, "");
            this.pageTypesFils.Name = "pageTypesFils";
            this.pageTypesFils.Selected = false;
            this.pageTypesFils.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.pageTypesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageTypesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageTypesFils.TabIndex = 13;
            this.pageTypesFils.Title = "Child Types|279";
            // 
            // m_panelListeTypesFils
            // 
            this.m_panelListeTypesFils.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeTypesFils.AffectationsPourNouveauxElements")));
            this.m_panelListeTypesFils.AllowArbre = true;
            this.m_panelListeTypesFils.AllowCustomisation = true;
            this.m_panelListeTypesFils.AllowSerializePreferences = true;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Libelle";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 100;
            this.m_panelListeTypesFils.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListeTypesFils.ContexteUtilisation = "";
            this.m_panelListeTypesFils.ControlFiltreStandard = null;
            this.m_panelListeTypesFils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeTypesFils.ElementSelectionne = null;
            this.m_panelListeTypesFils.EnableCustomisation = true;
            this.m_panelListeTypesFils.FiltreDeBase = null;
            this.m_panelListeTypesFils.FiltreDeBaseEnAjout = false;
            this.m_panelListeTypesFils.FiltrePrefere = null;
            this.m_panelListeTypesFils.FiltreRapide = null;
            this.m_panelListeTypesFils.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeTypesFils, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeTypesFils, false);
            this.m_panelListeTypesFils.ListeObjets = null;
            this.m_panelListeTypesFils.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeTypesFils.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeTypesFils, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeTypesFils.ModeQuickSearch = false;
            this.m_panelListeTypesFils.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeTypesFils, "");
            this.m_panelListeTypesFils.MultiSelect = false;
            this.m_panelListeTypesFils.Name = "m_panelListeTypesFils";
            this.m_panelListeTypesFils.Navigateur = null;
            this.m_panelListeTypesFils.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListeTypesFils.ProprieteObjetAEditer = null;
            this.m_panelListeTypesFils.QuickSearchText = "";
            this.m_panelListeTypesFils.ShortIcons = false;
            this.m_panelListeTypesFils.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeTypesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeTypesFils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeTypesFils.TabIndex = 0;
            this.m_panelListeTypesFils.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeTypesFils.UseCheckBoxes = false;
            // 
            // pageRelTypeContrainte
            // 
            this.pageRelTypeContrainte.Controls.Add(this.panel4);
            this.pageRelTypeContrainte.Controls.Add(this.panel3);
            this.m_extLinkField.SetLinkField(this.pageRelTypeContrainte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageRelTypeContrainte, false);
            this.pageRelTypeContrainte.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageRelTypeContrainte, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageRelTypeContrainte, "");
            this.pageRelTypeContrainte.Name = "pageRelTypeContrainte";
            this.pageRelTypeContrainte.Selected = false;
            this.pageRelTypeContrainte.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.pageRelTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageRelTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageRelTypeContrainte.TabIndex = 11;
            this.pageRelTypeContrainte.Title = "Related Constraints types|269";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_PanelEditRelations);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel4, false);
            this.panel4.Location = new System.Drawing.Point(0, 81);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel4, "");
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(814, 193);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 5;
            // 
            // m_PanelEditRelations
            // 
            this.m_extLinkField.SetLinkField(this.m_PanelEditRelations, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelEditRelations, false);
            this.m_PanelEditRelations.Location = new System.Drawing.Point(12, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelEditRelations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_PanelEditRelations, "");
            this.m_PanelEditRelations.Name = "m_PanelEditRelations";
            this.m_PanelEditRelations.Size = new System.Drawing.Size(782, 157);
            this.m_extStyle.SetStyleBackColor(this.m_PanelEditRelations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelEditRelations, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelEditRelations.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lblChoixTypeContrainte);
            this.panel3.Controls.Add(this.m_txtSelectTypeContrainte);
            this.panel3.Controls.Add(this.m_lnkAjouter);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel3, false);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(814, 81);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 4;
            // 
            // m_lblChoixTypeContrainte
            // 
            this.m_lblChoixTypeContrainte.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblChoixTypeContrainte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblChoixTypeContrainte, false);
            this.m_lblChoixTypeContrainte.Location = new System.Drawing.Point(9, 14);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblChoixTypeContrainte, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblChoixTypeContrainte, "");
            this.m_lblChoixTypeContrainte.Name = "m_lblChoixTypeContrainte";
            this.m_lblChoixTypeContrainte.Size = new System.Drawing.Size(193, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblChoixTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblChoixTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblChoixTypeContrainte.TabIndex = 0;
            this.m_lblChoixTypeContrainte.Text = "Select Constraints Types to add|270";
            // 
            // m_txtSelectTypeContrainte
            // 
            this.m_txtSelectTypeContrainte.ElementSelectionne = null;
            this.m_txtSelectTypeContrainte.FonctionTextNull = null;
            this.m_txtSelectTypeContrainte.HasLink = true;
            this.m_txtSelectTypeContrainte.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectTypeContrainte, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectTypeContrainte, false);
            this.m_txtSelectTypeContrainte.Location = new System.Drawing.Point(12, 30);
            this.m_txtSelectTypeContrainte.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectTypeContrainte, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectTypeContrainte, "");
            this.m_txtSelectTypeContrainte.Name = "m_txtSelectTypeContrainte";
            this.m_txtSelectTypeContrainte.SelectedObject = null;
            this.m_txtSelectTypeContrainte.Size = new System.Drawing.Size(280, 23);
            this.m_txtSelectTypeContrainte.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectTypeContrainte, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectTypeContrainte.TabIndex = 3;
            this.m_txtSelectTypeContrainte.TextNull = "";
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAjouter.CustomImage")));
            this.m_lnkAjouter.CustomText = "Add";
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouter, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouter, false);
            this.m_lnkAjouter.Location = new System.Drawing.Point(12, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouter, "");
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.ShortMode = false;
            this.m_lnkAjouter.Size = new System.Drawing.Size(60, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouter.TabIndex = 2;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // pageEO
            // 
            this.pageEO.Controls.Add(this.m_panelAffectationEO);
            this.m_extLinkField.SetLinkField(this.pageEO, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageEO, false);
            this.pageEO.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageEO, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageEO, "");
            this.pageEO.Name = "pageEO";
            this.pageEO.Selected = false;
            this.pageEO.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.pageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageEO.TabIndex = 14;
            this.pageEO.Title = "Organizational Entities|53";
            // 
            // m_panelAffectationEO
            // 
            this.m_panelAffectationEO.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_panelAffectationEO, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelAffectationEO, false);
            this.m_panelAffectationEO.Location = new System.Drawing.Point(3, 3);
            this.m_panelAffectationEO.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelAffectationEO, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelAffectationEO, "");
            this.m_panelAffectationEO.Name = "m_panelAffectationEO";
            this.m_panelAffectationEO.Size = new System.Drawing.Size(808, 231);
            this.m_extStyle.SetStyleBackColor(this.m_panelAffectationEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelAffectationEO, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelAffectationEO.TabIndex = 0;
            // 
            // pageDefChampsCustom
            // 
            this.pageDefChampsCustom.Controls.Add(this.m_PanelEditDefinisseurChampsCustom);
            this.m_extLinkField.SetLinkField(this.pageDefChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageDefChampsCustom, false);
            this.pageDefChampsCustom.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageDefChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageDefChampsCustom, "");
            this.pageDefChampsCustom.Name = "pageDefChampsCustom";
            this.pageDefChampsCustom.Selected = false;
            this.pageDefChampsCustom.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.pageDefChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageDefChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageDefChampsCustom.TabIndex = 12;
            this.pageDefChampsCustom.Title = "Custom fields definition|278";
            // 
            // m_PanelEditDefinisseurChampsCustom
            // 
            this.m_PanelEditDefinisseurChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_PanelEditDefinisseurChampsCustom.AvecAffectationDirecteDeChamps = false;
            this.m_extLinkField.SetLinkField(this.m_PanelEditDefinisseurChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_PanelEditDefinisseurChampsCustom, false);
            this.m_PanelEditDefinisseurChampsCustom.Location = new System.Drawing.Point(12, 14);
            this.m_PanelEditDefinisseurChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_PanelEditDefinisseurChampsCustom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_PanelEditDefinisseurChampsCustom, "");
            this.m_PanelEditDefinisseurChampsCustom.Name = "m_PanelEditDefinisseurChampsCustom";
            this.m_PanelEditDefinisseurChampsCustom.Size = new System.Drawing.Size(790, 219);
            this.m_extStyle.SetStyleBackColor(this.m_PanelEditDefinisseurChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_PanelEditDefinisseurChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_PanelEditDefinisseurChampsCustom.TabIndex = 0;
            // 
            // pageCommentaire
            // 
            this.pageCommentaire.Controls.Add(this.panel2);
            this.pageCommentaire.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.pageCommentaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageCommentaire, false);
            this.pageCommentaire.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageCommentaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageCommentaire, "");
            this.pageCommentaire.Name = "pageCommentaire";
            this.pageCommentaire.Selected = false;
            this.pageCommentaire.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.pageCommentaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageCommentaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageCommentaire.TabIndex = 10;
            this.pageCommentaire.Title = "Options|56";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.m_chkAfficherAgenda);
            this.panel2.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel2, false);
            this.panel2.Location = new System.Drawing.Point(352, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(311, 137);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 5;
            // 
            // m_chkAfficherAgenda
            // 
            this.m_chkAfficherAgenda.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAfficherAgenda, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkAfficherAgenda, false);
            this.m_chkAfficherAgenda.Location = new System.Drawing.Point(23, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAfficherAgenda, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkAfficherAgenda, "");
            this.m_chkAfficherAgenda.Name = "m_chkAfficherAgenda";
            this.m_chkAfficherAgenda.Size = new System.Drawing.Size(287, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkAfficherAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAfficherAgenda, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAfficherAgenda.TabIndex = 1;
            this.m_chkAfficherAgenda.Text = "Display Agenda on the Resources of this Type|393";
            this.m_chkAfficherAgenda.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(20, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 15);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 0;
            this.label5.Text = "Other options|392";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_chkBoxeEmplacementActeur);
            this.panel1.Controls.Add(this.m_chkRessourceDeplacable);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_chkEmplacementSite);
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(15, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(313, 137);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(14, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(286, 15);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 1;
            this.label4.Text = "Defines if the Resources of this Type are movable|363";
            // 
            // m_chkBoxeEmplacementActeur
            // 
            this.m_chkBoxeEmplacementActeur.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkBoxeEmplacementActeur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkBoxeEmplacementActeur, false);
            this.m_chkBoxeEmplacementActeur.Location = new System.Drawing.Point(15, 79);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkBoxeEmplacementActeur, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkBoxeEmplacementActeur, "");
            this.m_chkBoxeEmplacementActeur.Name = "m_chkBoxeEmplacementActeur";
            this.m_chkBoxeEmplacementActeur.Size = new System.Drawing.Size(92, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkBoxeEmplacementActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkBoxeEmplacementActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkBoxeEmplacementActeur.TabIndex = 1;
            this.m_chkBoxeEmplacementActeur.Text = "Member|265";
            this.m_chkBoxeEmplacementActeur.UseVisualStyleBackColor = true;
            // 
            // m_chkRessourceDeplacable
            // 
            this.m_chkRessourceDeplacable.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkRessourceDeplacable, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkRessourceDeplacable, false);
            this.m_chkRessourceDeplacable.Location = new System.Drawing.Point(17, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkRessourceDeplacable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkRessourceDeplacable, "");
            this.m_chkRessourceDeplacable.Name = "m_chkRessourceDeplacable";
            this.m_chkRessourceDeplacable.Size = new System.Drawing.Size(150, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkRessourceDeplacable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkRessourceDeplacable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkRessourceDeplacable.TabIndex = 0;
            this.m_chkRessourceDeplacable.Text = "Movable if checked|364";
            this.m_chkRessourceDeplacable.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(14, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 0;
            this.label3.Text = "Possible Locations:|350";
            // 
            // m_chkEmplacementSite
            // 
            this.m_chkEmplacementSite.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkEmplacementSite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkEmplacementSite, false);
            this.m_chkEmplacementSite.Location = new System.Drawing.Point(15, 99);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkEmplacementSite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkEmplacementSite, "");
            this.m_chkEmplacementSite.Name = "m_chkEmplacementSite";
            this.m_chkEmplacementSite.Size = new System.Drawing.Size(93, 19);
            this.m_extStyle.SetStyleBackColor(this.m_chkEmplacementSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkEmplacementSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkEmplacementSite.TabIndex = 2;
            this.m_chkEmplacementSite.Text = "Location|228";
            this.m_chkEmplacementSite.UseVisualStyleBackColor = true;
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
            // pageFormulaires
            // 
            this.pageFormulaires.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.pageFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pageFormulaires, true);
            this.pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pageFormulaires, "");
            this.pageFormulaires.Name = "pageFormulaires";
            this.pageFormulaires.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pageFormulaires.TabIndex = 15;
            this.pageFormulaires.Title = "Form|60";
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(0, 0);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Ombre = false;
            this.m_panelChamps.PositionTop = true;
            this.m_panelChamps.Size = new System.Drawing.Size(814, 244);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelChamps.TabIndex = 3;
            this.m_panelChamps.TextColor = System.Drawing.Color.Black;
            // 
            // CFormEditionTypeRessource
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_TabControl);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeRessource";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_TabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeRessource_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeRessource_OnMajChampsPage);
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
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.pageTypesFils.ResumeLayout(false);
            this.pageRelTypeContrainte.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.pageEO.ResumeLayout(false);
            this.pageDefChampsCustom.ResumeLayout(false);
            this.pageCommentaire.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pageFormulaires.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        //---------------------- Objet édité ----------------------------------------
        private CTypeRessource TypeRessource
        {
            get
            {
                return (CTypeRessource)ObjetEdite;
            }
        }
        
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            if (!result) return result;

            AffecterTitre(I.T( "Resource Type: |252") + " " + TypeRessource.Libelle);

            // Visibilité de l'onglet Formulaires
            bool bHasFormulaires = false;
            foreach (IDefinisseurChampCustom def in TypeRessource.DefinisseursDeChamps)
            {
                if (def.RelationsFormulaires.Length > 0)
                {
                    bHasFormulaires = true;
                    break;
                }
            }
            if (!bHasFormulaires)
            {
                if (m_TabControl.TabPages.Contains(pageFormulaires))
                    m_TabControl.TabPages.Remove(pageFormulaires);
            }
            else
            {
                if (!m_TabControl.TabPages.Contains(pageFormulaires))
                    m_TabControl.TabPages.Insert(0, pageFormulaires);
            }

            m_arbreRessourceHierarchique.AfficheHierarchie(TypeRessource);

            return result;
        }

        private void InitSelectTypeContrainte()
        {
            m_txtSelectTypeContrainte.Init<CTypeContrainte>("Libelle", true);

        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
           
            return result;

        }

        private void m_lnkAjouter_LinkClicked(object sender, EventArgs e)
        {
            if (m_txtSelectTypeContrainte.Text == "")
            {
				CFormAlerte.Afficher(I.T("Please select a Constraint Type to add|288"), EFormAlerteType.Exclamation);
                return;
            }

            m_PanelEditRelations.AddRelation(
                TypeRessource.RelationsTypesContraintesListe,
                TypeRessource,
                (CTypeContrainte)m_txtSelectTypeContrainte.ElementSelectionne);


        }

		private CResultAErreur CFormEditionTypeRessource_OnInitPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;
			using (CWaitCursor waiter = new CWaitCursor())
			{
                if (page == pageFormulaires)
                {
                    m_panelChamps.ElementEdite = TypeRessource;
                }
				else if (page == pageCommentaire)
				{
					// Init page Options (Misc.)
					m_chkEmplacementSite.Checked = TypeRessource.EmplacementSitePossible;
					m_chkBoxeEmplacementActeur.Checked = TypeRessource.EmplacementActeurPossible;
					m_chkRessourceDeplacable.Checked = TypeRessource.OptionDeplacable;
					m_chkAfficherAgenda.Checked = TypeRessource.OptionAfficherAgenda;
				}
				else if (page == pageDefChampsCustom)
				{
					m_PanelEditDefinisseurChampsCustom.InitPanel(
					TypeRessource,
					typeof(CFormListeChampsCustom),
					typeof(CFormListeFormulaires));
				}
				else if (page == pageEO)
				{
					m_panelAffectationEO.Init(TypeRessource);

				}
				else if (page == pageRelTypeContrainte)
				{
					// Init page Types de Contraintes levées
					InitSelectTypeContrainte();

					m_PanelEditRelations.InitPanel(TypeRessource.RelationsTypesContraintesListe, "TypeContrainte.Libelle");
				}
				else if (page == pageTypesFils)
				{
					m_panelListeTypesFils.InitFromListeObjets(
						   TypeRessource.TypesRessourcesFils,
						   typeof(CTypeRessource),
						   typeof(CFormEditionTypeRessource),
						   TypeRessource,
						   "TypeRessourceParent");

				}
			}
			return result;
		}

		private CResultAErreur CFormEditionTypeRessource_OnMajChampsPage(object page)
		{
			CResultAErreur result = CResultAErreur.True;

            if (page == pageFormulaires)
            {
                result = m_panelChamps.MAJ_Champs();
            }
			else if (page == pageCommentaire)
			{
				TypeRessource.EmplacementSitePossible = m_chkEmplacementSite.Checked;
				TypeRessource.EmplacementActeurPossible = m_chkBoxeEmplacementActeur.Checked;
				TypeRessource.OptionDeplacable = m_chkRessourceDeplacable.Checked;
				TypeRessource.OptionAfficherAgenda = m_chkAfficherAgenda.Checked;
			}
			else if (page == pageDefChampsCustom)
			{
				result = m_PanelEditDefinisseurChampsCustom.MAJ_Champs();
			}
			else if (page == pageEO)
			{
				result = m_panelAffectationEO.MajChamps();
			}
			else if (page == pageRelTypeContrainte)
			{
				result = m_PanelEditRelations.MAJ_Champs();
			}
			//else if (page == pageTypesFils)
			//{
			//}
			return result;
		}


    }
}

