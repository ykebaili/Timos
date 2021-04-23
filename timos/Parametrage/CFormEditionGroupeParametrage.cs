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

using sc2i.process;
using sc2i.expression;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CGroupeParametrage))]
    public class CFormEditionGroupeParametrage : CFormEditionStdTimos, IFormNavigable
    {
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private sc2i.win32.common.C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeActions;
        private sc2i.win32.data.navigation.CPanelListeSpeedStandard m_panelListeEvenements;
        private Label label2;
        private C2iTextBox m_txtDescription;
        private Crownwood.Magic.Controls.TabPage tabPage4;
        private Crownwood.Magic.Controls.TabPage tabPage3;
        private C2iPanel m_panelConditionDeclenchement;
        private sc2i.win32.expression.CControlAideFormule m_wndAide;
        private sc2i.win32.expression.CControleEditeFormule m_txtCondition;
        private Label label6;
        private CPanelListeSpeedStandard m_panelListeExports;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionGroupeParametrage()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionGroupeParametrage(CGroupeParametrage GroupeParametrage)
            : base(GroupeParametrage)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionGroupeParametrage(CGroupeParametrage GroupeParametrage, CListeObjetsDonnees liste)
            : base(GroupeParametrage, liste)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
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

        #region Designer generated code
        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionGroupeParametrage));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtDescription = new sc2i.win32.common.C2iTextBox();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage3 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelConditionDeclenchement = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtCondition = new sc2i.win32.expression.CControleEditeFormule();
            this.label6 = new System.Windows.Forms.Label();
            this.m_wndAide = new sc2i.win32.expression.CControlAideFormule();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeActions = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeEvenements = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.tabPage4 = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListeExports = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.m_panelConditionDeclenchement.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage4.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(730, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(622, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(937, 28);
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
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(3, 12);
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
            this.m_txtLibelle.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtLibelle, true);
            this.m_txtLibelle.Location = new System.Drawing.Point(97, 9);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(299, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtDescription);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(609, 115);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(4, 40);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Description";
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtDescription, "Description");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtDescription, true);
            this.m_txtDescription.Location = new System.Drawing.Point(97, 37);
            this.m_txtDescription.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtDescription, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtDescription, "");
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(479, 47);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 0;
            this.m_txtDescription.Text = "[Description]";
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.c2iTabControl1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTabControl1, false);
            this.c2iTabControl1.Location = new System.Drawing.Point(8, 173);
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTabControl1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iTabControl1, "");
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 3;
            this.c2iTabControl1.SelectedTab = this.tabPage4;
            this.c2iTabControl1.Size = new System.Drawing.Size(921, 378);
            this.m_extStyle.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iTabControl1.TabIndex = 4004;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage3,
            this.tabPage1,
            this.tabPage2,
            this.tabPage4});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.m_panelConditionDeclenchement);
            this.tabPage3.Controls.Add(this.m_wndAide);
            this.m_extLinkField.SetLinkField(this.tabPage3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage3, false);
            this.tabPage3.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage3, "");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Selected = false;
            this.tabPage3.Size = new System.Drawing.Size(905, 337);
            this.m_extStyle.SetStyleBackColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage3.TabIndex = 14;
            this.tabPage3.Title = "Options";
            // 
            // m_panelConditionDeclenchement
            // 
            this.m_panelConditionDeclenchement.Controls.Add(this.m_txtCondition);
            this.m_panelConditionDeclenchement.Controls.Add(this.label6);
            this.m_panelConditionDeclenchement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelConditionDeclenchement, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelConditionDeclenchement, false);
            this.m_panelConditionDeclenchement.Location = new System.Drawing.Point(0, 0);
            this.m_panelConditionDeclenchement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConditionDeclenchement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelConditionDeclenchement, "");
            this.m_panelConditionDeclenchement.Name = "m_panelConditionDeclenchement";
            this.m_panelConditionDeclenchement.Size = new System.Drawing.Size(670, 243);
            this.m_extStyle.SetStyleBackColor(this.m_panelConditionDeclenchement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConditionDeclenchement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConditionDeclenchement.TabIndex = 2;
            // 
            // m_txtCondition
            // 
            this.m_txtCondition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtCondition.BackColor = System.Drawing.Color.White;
            this.m_txtCondition.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_txtCondition.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtCondition, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtCondition, false);
            this.m_txtCondition.Location = new System.Drawing.Point(8, 26);
            this.m_txtCondition.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtCondition, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtCondition, "");
            this.m_txtCondition.Name = "m_txtCondition";
            this.m_txtCondition.Size = new System.Drawing.Size(656, 205);
            this.m_extStyle.SetStyleBackColor(this.m_txtCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCondition.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(5, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 0;
            this.label6.Text = "Condition";
            // 
            // m_wndAide
            // 
            this.m_wndAide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndAide.FournisseurProprietes = null;
            this.m_extLinkField.SetLinkField(this.m_wndAide, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndAide, false);
            this.m_wndAide.Location = new System.Drawing.Point(670, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndAide, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndAide, "");
            this.m_wndAide.Name = "m_wndAide";
            this.m_wndAide.ObjetInterroge = null;
            this.m_wndAide.SendIdChamps = false;
            this.m_wndAide.Size = new System.Drawing.Size(235, 337);
            this.m_extStyle.SetStyleBackColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndAide, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndAide.TabIndex = 4004;
            this.m_wndAide.OnSendCommande += new sc2i.win32.expression.SendCommande(this.m_wndAide_OnSendCommande);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.m_panelListeActions);
            this.m_extLinkField.SetLinkField(this.tabPage1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage1, false);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage1, "");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Selected = false;
            this.tabPage1.Size = new System.Drawing.Size(905, 337);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Actions|169";
            // 
            // m_panelListeActions
            // 
            this.m_panelListeActions.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeActions.AffectationsPourNouveauxElements")));
            this.m_panelListeActions.AllowArbre = true;
            this.m_panelListeActions.AllowCustomisation = true;
            this.m_panelListeActions.AllowSerializePreferences = true;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Name";
            glColumn2.Propriete = "Libelle";
            glColumn2.Text = "Label|50";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 350;
            this.m_panelListeActions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListeActions.ContexteUtilisation = "";
            this.m_panelListeActions.ControlFiltreStandard = null;
            this.m_panelListeActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeActions.ElementSelectionne = null;
            this.m_panelListeActions.EnableCustomisation = true;
            this.m_panelListeActions.FiltreDeBase = null;
            this.m_panelListeActions.FiltreDeBaseEnAjout = false;
            this.m_panelListeActions.FiltrePrefere = null;
            this.m_panelListeActions.FiltreRapide = null;
            this.m_panelListeActions.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeActions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeActions, false);
            this.m_panelListeActions.ListeObjets = null;
            this.m_panelListeActions.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeActions.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeActions, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeActions.ModeQuickSearch = false;
            this.m_panelListeActions.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeActions, "");
            this.m_panelListeActions.MultiSelect = false;
            this.m_panelListeActions.Name = "m_panelListeActions";
            this.m_panelListeActions.Navigateur = null;
            this.m_panelListeActions.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListeActions.ProprieteObjetAEditer = null;
            this.m_panelListeActions.QuickSearchText = "";
            this.m_panelListeActions.ShortIcons = false;
            this.m_panelListeActions.Size = new System.Drawing.Size(905, 337);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeActions.TabIndex = 0;
            this.m_panelListeActions.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeActions.UseCheckBoxes = false;
            this.m_panelListeActions.Load += new System.EventHandler(this.m_panelListeActions_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_panelListeEvenements);
            this.m_extLinkField.SetLinkField(this.tabPage2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage2, false);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage2, "");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(905, 337);
            this.m_extStyle.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Events|183";
            // 
            // m_panelListeEvenements
            // 
            this.m_panelListeEvenements.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeEvenements.AffectationsPourNouveauxElements")));
            this.m_panelListeEvenements.AllowArbre = true;
            this.m_panelListeEvenements.AllowCustomisation = true;
            this.m_panelListeEvenements.AllowSerializePreferences = true;
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Name";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text = "Label|50";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 350;
            this.m_panelListeEvenements.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3});
            this.m_panelListeEvenements.ContexteUtilisation = "";
            this.m_panelListeEvenements.ControlFiltreStandard = null;
            this.m_panelListeEvenements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeEvenements.ElementSelectionne = null;
            this.m_panelListeEvenements.EnableCustomisation = true;
            this.m_panelListeEvenements.FiltreDeBase = null;
            this.m_panelListeEvenements.FiltreDeBaseEnAjout = false;
            this.m_panelListeEvenements.FiltrePrefere = null;
            this.m_panelListeEvenements.FiltreRapide = null;
            this.m_panelListeEvenements.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeEvenements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeEvenements, false);
            this.m_panelListeEvenements.ListeObjets = null;
            this.m_panelListeEvenements.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeEvenements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeEvenements, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeEvenements.ModeQuickSearch = false;
            this.m_panelListeEvenements.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeEvenements, "");
            this.m_panelListeEvenements.MultiSelect = false;
            this.m_panelListeEvenements.Name = "m_panelListeEvenements";
            this.m_panelListeEvenements.Navigateur = null;
            this.m_panelListeEvenements.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListeEvenements.ProprieteObjetAEditer = null;
            this.m_panelListeEvenements.QuickSearchText = "";
            this.m_panelListeEvenements.ShortIcons = false;
            this.m_panelListeEvenements.Size = new System.Drawing.Size(905, 337);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeEvenements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeEvenements.TabIndex = 1;
            this.m_panelListeEvenements.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeEvenements.UseCheckBoxes = false;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.m_panelListeExports);
            this.m_extLinkField.SetLinkField(this.tabPage4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.tabPage4, false);
            this.tabPage4.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.tabPage4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.tabPage4, "");
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(905, 337);
            this.m_extStyle.SetStyleBackColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage4.TabIndex = 13;
            this.tabPage4.Title = "Exports";
            // 
            // m_panelListeExports
            // 
            this.m_panelListeExports.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelListeExports.AffectationsPourNouveauxElements")));
            this.m_panelListeExports.AllowArbre = true;
            this.m_panelListeExports.AllowCustomisation = true;
            this.m_panelListeExports.AllowSerializePreferences = true;
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
            glColumn1.Width = 350;
            this.m_panelListeExports.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_panelListeExports.ContexteUtilisation = "";
            this.m_panelListeExports.ControlFiltreStandard = null;
            this.m_panelListeExports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListeExports.ElementSelectionne = null;
            this.m_panelListeExports.EnableCustomisation = true;
            this.m_panelListeExports.FiltreDeBase = null;
            this.m_panelListeExports.FiltreDeBaseEnAjout = false;
            this.m_panelListeExports.FiltrePrefere = null;
            this.m_panelListeExports.FiltreRapide = null;
            this.m_panelListeExports.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeExports, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeExports, false);
            this.m_panelListeExports.ListeObjets = null;
            this.m_panelListeExports.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeExports.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeExports, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListeExports.ModeQuickSearch = false;
            this.m_panelListeExports.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelListeExports, "");
            this.m_panelListeExports.MultiSelect = false;
            this.m_panelListeExports.Name = "m_panelListeExports";
            this.m_panelListeExports.Navigateur = null;
            this.m_panelListeExports.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelListeExports.ProprieteObjetAEditer = null;
            this.m_panelListeExports.QuickSearchText = "";
            this.m_panelListeExports.ShortIcons = false;
            this.m_panelListeExports.Size = new System.Drawing.Size(905, 337);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeExports, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeExports, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeExports.TabIndex = 2;
            this.m_panelListeExports.TrierAuClicSurEnteteColonne = true;
            this.m_panelListeExports.UseCheckBoxes = false;
            // 
            // CFormEditionGroupeParametrage
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(937, 547);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionGroupeParametrage";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.c2iTabControl1, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.m_panelConditionDeclenchement.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CGroupeParametrage GroupeParametrage
        {
            get
            {
                return (CGroupeParametrage)ObjetEdite;
            }
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Settings group|30219") + GroupeParametrage.Libelle);

            m_wndAide.FournisseurProprietes = new CFournisseurPropDynStd(true);
            m_wndAide.ObjetInterroge = GroupeParametrage.GetType();
            m_txtCondition.Init(m_wndAide.FournisseurProprietes, m_wndAide.ObjetInterroge);

            if (GroupeParametrage.FormuleCondition != null)
                m_txtCondition.Text = GroupeParametrage.FormuleCondition.GetString();
            else
                m_txtCondition.Text = "";

            CListeObjetsDonnees listeActions = new CListeObjetsDonnees(
                GroupeParametrage.ContexteDonnee,
                typeof(CProcessInDb),
                new CFiltreData(CGroupeParametrage.c_champId + " = @1", GroupeParametrage.Id));

            m_panelListeActions.InitFromListeObjets(
                listeActions,
                typeof(CProcessInDb),
                typeof(CFormEditionProcess),
                GroupeParametrage,
                "GroupeParametrage");

            CListeObjetsDonnees listeEvenements = new CListeObjetsDonnees(
                GroupeParametrage.ContexteDonnee,
                typeof(CEvenement),
                new CFiltreData(CGroupeParametrage.c_champId + " = @1", GroupeParametrage.Id));

            m_panelListeEvenements.InitFromListeObjets(
                listeEvenements,
                typeof(CEvenement),
                typeof(CFormEditionEvenement),
                GroupeParametrage,
                "GroupeParametrage");

            CListeObjetsDonnees listeExport = new CListeObjetsDonnees(
                GroupeParametrage.ContexteDonnee,
                typeof(C2iStructureExportInDB),
                new CFiltreData(CGroupeParametrage.c_champId + " = @1", GroupeParametrage.Id));

            m_panelListeExports.InitFromListeObjets(
                listeExport,
                typeof(C2iStructureExportInDB),
                typeof(CFormEditionStructureDonnee),
                GroupeParametrage,
                "GroupeParametrage");


            return result;
        }

        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            CContexteAnalyse2iExpression contexteAnalyse = new CContexteAnalyse2iExpression(new CFournisseurPropDynStd(true), GroupeParametrage.GetType());
            CAnalyseurSyntaxique analyseur = new CAnalyseurSyntaxiqueExpression(contexteAnalyse);
            result = analyseur.AnalyseChaine(m_txtCondition.Text);
            if(!result)
            {
                result.EmpileErreur("Error in Condition Formula");
                return result;
            }
            else
            {
                GroupeParametrage.FormuleCondition = (C2iExpression)result.Data;
            }

            return result;
        }

        private void m_panelListeActions_Load(object sender, System.EventArgs e)
        {

        }

        private void m_wndAide_OnSendCommande(string strCommande, int nPosCurseur)
        {
            m_wndAide.InsereInTextBox(m_txtCondition, nPosCurseur, strCommande);
        }
    }
}

