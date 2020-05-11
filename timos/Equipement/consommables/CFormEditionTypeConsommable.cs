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
using timos.Equipement;
using timos.data.equipement.consommables;
using sc2i.common.unites;

namespace timos
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeConsommable))]
    public class CFormEditionTypeConsommable : CFormEditionStdTimos, IFormNavigable
    {
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre m_panTop;
        private C2iTabControl m_tabControl;
        private ListViewAutoFilledColumn listViewAutoFilledColumn5;
        private Crownwood.Magic.Controls.TabPage m_pageOptions;
        private Label label3;
        private Label label2;
        private CComboboxAutoFilled m_cmbSelectUnite;
        private sc2i.win32.data.dynamic.CComboBoxArbreObjetDonneesHierarchique m_cmbSelectFamilleHierarchique;
        private Label label4;
        private CheckBox m_chkGestionParLot;
        private CheckBox m_chkSortieDefinitive;
        private Crownwood.Magic.Controls.TabPage m_pageConditionnement;
        private Crownwood.Magic.Controls.TabPage m_pageLots;
        private CPanelListeSpeedStandard m_panelListLots;
        private Crownwood.Magic.Controls.TabPage m_pageFormulaires;
        private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelChamps;
        private timos.Equipement.consommables.CPanelEditConditionnement m_panelEditConditionnements;
        private Panel m_panelSetupLot;
        private Panel panel1;
        private Label label5;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelChampsLot;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionTypeConsommable()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionTypeConsommable(CTypeConsommable TypeConsommable)
            : base(TypeConsommable)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionTypeConsommable(CTypeConsommable TypeConsommable, CListeObjetsDonnees liste)
            : base(TypeConsommable, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeConsommable));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_panTop = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbSelectFamilleHierarchique = new sc2i.win32.data.dynamic.CComboBoxArbreObjetDonneesHierarchique();
            this.m_cmbSelectUnite = new sc2i.win32.common.CComboboxAutoFilled();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageFormulaires = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.m_pageOptions = new Crownwood.Magic.Controls.TabPage();
            this.label4 = new System.Windows.Forms.Label();
            this.m_chkSortieDefinitive = new System.Windows.Forms.CheckBox();
            this.m_chkGestionParLot = new System.Windows.Forms.CheckBox();
            this.m_pageConditionnement = new Crownwood.Magic.Controls.TabPage();
            this.m_panelEditConditionnements = new timos.Equipement.consommables.CPanelEditConditionnement();
            this.m_pageLots = new Crownwood.Magic.Controls.TabPage();
            this.m_panelListLots = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.listViewAutoFilledColumn5 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelSetupLot = new System.Windows.Forms.Panel();
            this.m_panelChampsLot = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.m_panTop.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageFormulaires.SuspendLayout();
            this.m_pageOptions.SuspendLayout();
            this.m_pageConditionnement.SuspendLayout();
            this.m_pageLots.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panelSetupLot.SuspendLayout();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(620, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 28);
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
            this.m_panelCle.Location = new System.Drawing.Point(533, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(773, 28);
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
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(16, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label1, "");
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(104, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(328, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // m_panTop
            // 
            this.m_panTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTop.Controls.Add(this.m_cmbSelectFamilleHierarchique);
            this.m_panTop.Controls.Add(this.m_cmbSelectUnite);
            this.m_panTop.Controls.Add(this.label2);
            this.m_panTop.Controls.Add(this.label3);
            this.m_panTop.Controls.Add(this.label1);
            this.m_panTop.Controls.Add(this.m_txtLibelle);
            this.m_panTop.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panTop, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panTop, false);
            this.m_panTop.Location = new System.Drawing.Point(8, 52);
            this.m_panTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panTop, "");
            this.m_panTop.Name = "m_panTop";
            this.m_panTop.Size = new System.Drawing.Size(486, 100);
            this.m_extStyle.SetStyleBackColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panTop.TabIndex = 0;
            // 
            // m_cmbSelectFamilleHierarchique
            // 
            this.m_cmbSelectFamilleHierarchique.AutoriserFilsDeAutorises = true;
            this.m_cmbSelectFamilleHierarchique.BackColor = System.Drawing.Color.White;
            this.m_cmbSelectFamilleHierarchique.ElementSelectionne = null;
            this.m_extLinkField.SetLinkField(this.m_cmbSelectFamilleHierarchique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbSelectFamilleHierarchique, false);
            this.m_cmbSelectFamilleHierarchique.Location = new System.Drawing.Point(104, 34);
            this.m_cmbSelectFamilleHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSelectFamilleHierarchique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbSelectFamilleHierarchique, "");
            this.m_cmbSelectFamilleHierarchique.Name = "m_cmbSelectFamilleHierarchique";
            this.m_cmbSelectFamilleHierarchique.NullAutorise = false;
            this.m_cmbSelectFamilleHierarchique.Size = new System.Drawing.Size(328, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSelectFamilleHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSelectFamilleHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSelectFamilleHierarchique.TabIndex = 4007;
            this.m_cmbSelectFamilleHierarchique.TextNull = "None";
            this.m_cmbSelectFamilleHierarchique.ElementSelectionneChanged += new System.EventHandler(this.m_cmbSelectFamilleHierarchique_ElementSelectionneChanged);
            // 
            // m_cmbSelectUnite
            // 
            this.m_cmbSelectUnite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSelectUnite.FormattingEnabled = true;
            this.m_cmbSelectUnite.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbSelectUnite, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbSelectUnite, false);
            this.m_cmbSelectUnite.ListDonnees = null;
            this.m_cmbSelectUnite.Location = new System.Drawing.Point(104, 59);
            this.m_cmbSelectUnite.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSelectUnite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbSelectUnite, "");
            this.m_cmbSelectUnite.Name = "m_cmbSelectUnite";
            this.m_cmbSelectUnite.NullAutorise = false;
            this.m_cmbSelectUnite.ProprieteAffichee = null;
            this.m_cmbSelectUnite.Size = new System.Drawing.Size(165, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSelectUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSelectUnite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSelectUnite.TabIndex = 4006;
            this.m_cmbSelectUnite.TextNull = "(empty)";
            this.m_cmbSelectUnite.Tri = true;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4004;
            this.label2.Text = "Unité|10376";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(16, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Family|10375";
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
            this.m_tabControl.SelectedIndex = 1;
            this.m_tabControl.SelectedTab = this.m_pageOptions;
            this.m_tabControl.Size = new System.Drawing.Size(765, 326);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageFormulaires,
            this.m_pageOptions,
            this.m_pageConditionnement,
            this.m_pageLots});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // m_pageFormulaires
            // 
            this.m_pageFormulaires.Controls.Add(this.m_panelChamps);
            this.m_extLinkField.SetLinkField(this.m_pageFormulaires, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFormulaires, false);
            this.m_pageFormulaires.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFormulaires, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFormulaires, "");
            this.m_pageFormulaires.Name = "m_pageFormulaires";
            this.m_pageFormulaires.Selected = false;
            this.m_pageFormulaires.Size = new System.Drawing.Size(749, 285);
            this.m_extStyle.SetStyleBackColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFormulaires, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFormulaires.TabIndex = 13;
            this.m_pageFormulaires.Title = "Properties|1234";
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
            this.m_panelChamps.Size = new System.Drawing.Size(749, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 10;
            // 
            // m_pageOptions
            // 
            this.m_pageOptions.Controls.Add(this.m_panelSetupLot);
            this.m_pageOptions.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_pageOptions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageOptions, false);
            this.m_pageOptions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageOptions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageOptions, "");
            this.m_pageOptions.Name = "m_pageOptions";
            this.m_pageOptions.Size = new System.Drawing.Size(749, 285);
            this.m_extStyle.SetStyleBackColor(this.m_pageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageOptions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageOptions.TabIndex = 10;
            this.m_pageOptions.Title = "Options|56";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(326, 22);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 1;
            this.label4.Text = "Stock management options|10378";
            // 
            // m_chkSortieDefinitive
            // 
            this.m_extLinkField.SetLinkField(this.m_chkSortieDefinitive, "SortieDefinitive");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkSortieDefinitive, true);
            this.m_chkSortieDefinitive.Location = new System.Drawing.Point(52, 41);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSortieDefinitive, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkSortieDefinitive, "");
            this.m_chkSortieDefinitive.Name = "m_chkSortieDefinitive";
            this.m_chkSortieDefinitive.Size = new System.Drawing.Size(326, 20);
            this.m_extStyle.SetStyleBackColor(this.m_chkSortieDefinitive, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSortieDefinitive, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSortieDefinitive.TabIndex = 0;
            this.m_chkSortieDefinitive.Text = "Stock final output (not reusable)|10380";
            this.m_chkSortieDefinitive.UseVisualStyleBackColor = true;
            // 
            // m_chkGestionParLot
            // 
            this.m_extLinkField.SetLinkField(this.m_chkGestionParLot, "GestionParLot");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkGestionParLot, true);
            this.m_chkGestionParLot.Location = new System.Drawing.Point(52, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkGestionParLot, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkGestionParLot, "");
            this.m_chkGestionParLot.Name = "m_chkGestionParLot";
            this.m_chkGestionParLot.Size = new System.Drawing.Size(326, 20);
            this.m_extStyle.SetStyleBackColor(this.m_chkGestionParLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkGestionParLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkGestionParLot.TabIndex = 0;
            this.m_chkGestionParLot.Text = "Management by Lot|10379";
            this.m_chkGestionParLot.UseVisualStyleBackColor = true;
            this.m_chkGestionParLot.CheckedChanged += new System.EventHandler(this.m_chkGestionParLot_CheckedChanged);
            // 
            // m_pageConditionnement
            // 
            this.m_pageConditionnement.Controls.Add(this.m_panelEditConditionnements);
            this.m_extLinkField.SetLinkField(this.m_pageConditionnement, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageConditionnement, false);
            this.m_pageConditionnement.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageConditionnement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageConditionnement, "");
            this.m_pageConditionnement.Name = "m_pageConditionnement";
            this.m_pageConditionnement.Selected = false;
            this.m_pageConditionnement.Size = new System.Drawing.Size(749, 285);
            this.m_extStyle.SetStyleBackColor(this.m_pageConditionnement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageConditionnement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageConditionnement.TabIndex = 11;
            this.m_pageConditionnement.Title = "Packaging|10381";
            // 
            // m_panelEditConditionnements
            // 
            this.m_panelEditConditionnements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelEditConditionnements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditConditionnements, false);
            this.m_panelEditConditionnements.Location = new System.Drawing.Point(0, 0);
            this.m_panelEditConditionnements.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditConditionnements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditConditionnements, "");
            this.m_panelEditConditionnements.Name = "m_panelEditConditionnements";
            this.m_panelEditConditionnements.Size = new System.Drawing.Size(749, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditConditionnements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditConditionnements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditConditionnements.TabIndex = 0;
            // 
            // m_pageLots
            // 
            this.m_pageLots.Controls.Add(this.m_panelListLots);
            this.m_extLinkField.SetLinkField(this.m_pageLots, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageLots, false);
            this.m_pageLots.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageLots, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageLots, "");
            this.m_pageLots.Name = "m_pageLots";
            this.m_pageLots.Selected = false;
            this.m_pageLots.Size = new System.Drawing.Size(749, 285);
            this.m_extStyle.SetStyleBackColor(this.m_pageLots, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageLots, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageLots.TabIndex = 12;
            this.m_pageLots.Title = "Lots|10382";
            // 
            // m_panelListLots
            // 
            this.m_panelListLots.AllowArbre = true;
            this.m_panelListLots.AllowCustomisation = true;
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "m_colReferenceLot";
            glColumn2.Propriete = "Reference";
            glColumn2.Text = "Lot Reference|10383";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 250;
            this.m_panelListLots.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_panelListLots.ContexteUtilisation = "";
            this.m_panelListLots.ControlFiltreStandard = null;
            this.m_panelListLots.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelListLots.ElementSelectionne = null;
            this.m_panelListLots.EnableCustomisation = true;
            this.m_panelListLots.FiltreDeBase = null;
            this.m_panelListLots.FiltreDeBaseEnAjout = false;
            this.m_panelListLots.FiltrePrefere = null;
            this.m_panelListLots.FiltreRapide = null;
            this.m_panelListLots.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelListLots, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListLots, false);
            this.m_panelListLots.ListeObjets = null;
            this.m_panelListLots.Location = new System.Drawing.Point(0, 0);
            this.m_panelListLots.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListLots, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelListLots.ModeQuickSearch = false;
            this.m_panelListLots.ModeSelection = true;
            this.m_extModulesAssociator.SetModules(this.m_panelListLots, "");
            this.m_panelListLots.MultiSelect = false;
            this.m_panelListLots.Name = "m_panelListLots";
            this.m_panelListLots.Navigateur = null;
            this.m_panelListLots.ProprieteObjetAEditer = null;
            this.m_panelListLots.QuickSearchText = "";
            this.m_panelListLots.Size = new System.Drawing.Size(749, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelListLots, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListLots, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListLots.TabIndex = 0;
            this.m_panelListLots.TrierAuClicSurEnteteColonne = true;
            this.m_panelListLots.UseCheckBoxes = false;
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
            // panel1
            // 
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.m_chkGestionParLot);
            this.panel1.Controls.Add(this.m_chkSortieDefinitive);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, true);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(749, 65);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 2;
            // 
            // m_panelSetupLot
            // 
            this.m_panelSetupLot.Controls.Add(this.m_panelChampsLot);
            this.m_panelSetupLot.Controls.Add(this.label5);
            this.m_panelSetupLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelSetupLot, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSetupLot, true);
            this.m_panelSetupLot.Location = new System.Drawing.Point(0, 65);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSetupLot, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelSetupLot, "");
            this.m_panelSetupLot.Name = "m_panelSetupLot";
            this.m_panelSetupLot.Size = new System.Drawing.Size(749, 220);
            this.m_extStyle.SetStyleBackColor(this.m_panelSetupLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSetupLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSetupLot.TabIndex = 3;
            // 
            // m_panelChampsLot
            // 
            this.m_panelChampsLot.AvecAffectationDirecteDeChamps = false;
            this.m_panelChampsLot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelChampsLot, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChampsLot, false);
            this.m_panelChampsLot.Location = new System.Drawing.Point(0, 23);
            this.m_panelChampsLot.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChampsLot, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChampsLot, "");
            this.m_panelChampsLot.Name = "m_panelChampsLot";
            this.m_panelChampsLot.Size = new System.Drawing.Size(749, 197);
            this.m_extStyle.SetStyleBackColor(this.m_panelChampsLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChampsLot, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChampsLot.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, true);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(749, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 3;
            this.label5.Text = "Lots setup|20646";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CFormEditionTypeConsommable
            // 
            this.ClientSize = new System.Drawing.Size(773, 495);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.m_panTop);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeConsommable";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeConsommable_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeConsommable_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.m_panTop, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.m_panTop.ResumeLayout(false);
            this.m_panTop.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageFormulaires.ResumeLayout(false);
            this.m_pageOptions.ResumeLayout(false);
            this.m_pageConditionnement.ResumeLayout(false);
            this.m_pageLots.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_panelSetupLot.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CTypeConsommable TypeConsommable
        {
            get
            {
                return (CTypeConsommable)ObjetEdite;
            }
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            DisplayOrHidePanelChamps();
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Consumable Type|10384") + " " + TypeConsommable.Libelle);

            m_cmbSelectFamilleHierarchique.Init(
                typeof(CFamilleEquipement), 
                "FamillesFilles", 
                CFamilleEquipement.c_champIdParent, 
                "Libelle", 
                null,
                new CFiltreData(CFamilleEquipement.c_champNoConsommable + "=@1", false));
            m_cmbSelectUnite.Fill(CGestionnaireUnites.Unites, "LibelleLong", true);
            m_cmbSelectUnite.TextNull = I.T("(None|10377");

            if (TypeConsommable!= null)
            {
                m_cmbSelectFamilleHierarchique.ElementSelectionne = TypeConsommable.Famille;
                m_cmbSelectUnite.SelectedValue = TypeConsommable.Unite;
            }
            m_panelSetupLot.Visible = m_chkGestionParLot.Checked;

            return result;
        }
     
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();

            if (TypeConsommable != null)
            {
                TypeConsommable.Famille = m_cmbSelectFamilleHierarchique.ElementSelectionne as CFamilleEquipement;
                TypeConsommable.Unite = m_cmbSelectUnite.SelectedValue as IUnite;
            }

            return result;
        }

        private CResultAErreur CFormEditionTypeConsommable_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_pageFormulaires)
                m_panelChamps.ElementEdite = TypeConsommable;
            if (page == m_pageOptions)
            {
                m_panelChampsLot.InitPanel(TypeConsommable,
                    typeof(CFormListeChampsCustom),
                    typeof(CFormListeFormulaires));
            }
            if (page == m_pageConditionnement)
            {
                m_panelEditConditionnements.Init(TypeConsommable);
            }
            if (page == m_pageLots)
            {
                m_panelListLots.InitFromListeObjets(
                    TypeConsommable.LotsConsommable,
                    typeof(CLotConsommable),
                    TypeConsommable,
                    "TypeConsommable");
            }

            return result;
        }

        private CResultAErreur CFormEditionTypeConsommable_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageFormulaires)
                result = m_panelChamps.MAJ_Champs();
            if (page == m_pageOptions)
            {
                result = m_panelChampsLot.MAJ_Champs();
            }
            if (page == m_pageConditionnement)
            {
                result += m_panelEditConditionnements.MajChamps();
            }
            if (page == m_pageLots)
            {
               
            }

            return result;
        }

        //------------------------------------------------------------------------------------
        private void m_cmbSelectFamilleHierarchique_ElementSelectionneChanged(object sender, EventArgs e)
        {
            TypeConsommable.Famille = m_cmbSelectFamilleHierarchique.ElementSelectionne as CFamilleEquipement;
            DisplayOrHidePanelChamps();
            m_panelChamps.ElementEdite = TypeConsommable;
        }

        //------------------------------------------------------------------------------------
        private void DisplayOrHidePanelChamps()
        {
            if (TypeConsommable.GetFormulaires().Length == 0)
            {
                if (m_tabControl.TabPages.Contains(m_pageFormulaires))
                    m_tabControl.TabPages.Remove(m_pageFormulaires);
            }
            else
            {
                if (!m_tabControl.TabPages.Contains(m_pageFormulaires))
                    m_tabControl.TabPages.Insert(0, m_pageFormulaires);
            }
        }


        //------------------------------------------------------------------------------------
        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        //------------------------------------------------------------------------------------
        private void m_chkGestionParLot_CheckedChanged(object sender, EventArgs e)
        {
            m_panelSetupLot.Visible = m_chkGestionParLot.Checked;
        }


    
    }
}

