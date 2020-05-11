using System;
using System.Linq;
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
using timos.data.snmp;
using futurocom.snmp;
using futurocom.snmp.entitesnmp;
using sc2i.expression;
using futurocom.easyquery;
using sc2i.drawing;
using futurocom.win32.snmp;
using futurocom.snmp.dynamic;
using futurocom.easyquery.snmp;
using System.Collections.Generic;
using timos.data.supervision;
using sc2i.win32.data.dynamic;

namespace timos.snmp
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeEntiteSnmp))]
    public class CFormEditionTypeEntiteSnmp : CFormEditionStdTimos, IFormNavigable
    {
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private CArbreObjetHierarchique m_ArbreHierarchique;
        private Label label2;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageSousTypes;
        private Crownwood.Magic.Controls.TabPage m_pageChamps;
        private timos.win32.composants.CPanelEditDefinisseurChampsCustom m_panelEditChamps;
        private CPanelListeSpeedStandard m_panelSousTypes;
        private Crownwood.Magic.Controls.TabPage m_pageSetupEntitesSnmp;
        private Label label5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleLibelle;
        private Panel m_panelConteneurGererChamps;
        private LinkLabel m_lnkNewChampCustom;
        private C2iNumericUpDown m_numUpDownOrdre;
        private Label label7;
        private CPanelListeRelationSelection m_panelListeChampsCustom;
        private C2iPanel m_panelChamps;
        private PictureBox pictureBox5;
        private CheckBox m_chkKey;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Label label3;
        private Crownwood.Magic.Controls.TabPage m_pageSource;
        private Label m_lblRequeteSource;
        private Label label6;
        private GlacialList m_wndListeChamps;
        private C2iPanel c2iPanel2;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleIndex;
        private Label label4;
        private C2iPanel c2iPanel1;
        private ContextMenuStrip m_menuFromRequete;
        private PictureBox m_btnRefreshChamps;
        private LinkLabel m_lnkEditQuery;
        private Label label8;
        private C2iLink m_lnkTypeAgent;
        private Panel panel1;
        private Label label9;
        private C2iComboBox m_cmbModeFormulaire;
        private C2iPanel m_panelMonoFormulaire;
        private Label label10;
        private CComboBoxListeObjetsDonnees m_cmbFormulaireUnique;
        private C2iPanel c2iPanel3;
        private sc2i.win32.expression.CControlEditListeFormulesNommees m_wndListeChampsCalcules;
        private Label label11;
        private Panel panel2;
        private CWndLinkStd m_lnkDetailChamp;
        private Label label12;
        private C2iComboBox m_cmbxTypeElements;
        private PictureBox m_btnFiltreType;
        private Label label13;
        private CPanelSymboleElement m_panelSymbole;
        private CheckBox m_chkReadOnly;
        private Label label14;
        private C2iNumericUpDown c2iNumericUpDown1;
        private C2iNumericUpDown c2iNumericUpDown2;
        private Label label15;
        private Crownwood.Magic.Controls.TabPage m_pagePolling;
        private CControleEditeListeSnmpPollingFieldsSetups m_wndSetupPolling;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionTypeEntiteSnmp()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionTypeEntiteSnmp(CTypeEntiteSnmp TypeEntiteSnmp)
            : base(TypeEntiteSnmp)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionTypeEntiteSnmp(CTypeEntiteSnmp TypeEntiteSnmp, CListeObjetsDonnees liste)
            : base(TypeEntiteSnmp, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeEntiteSnmp));
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_chkReadOnly = new System.Windows.Forms.CheckBox();
            this.m_lnkTypeAgent = new sc2i.win32.common.C2iLink(this.components);
            this.m_ArbreHierarchique = new sc2i.win32.data.navigation.CArbreObjetHierarchique();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pagePolling = new Crownwood.Magic.Controls.TabPage();
            this.m_wndSetupPolling = new timos.snmp.CControleEditeListeSnmpPollingFieldsSetups();
            this.m_pageSousTypes = new Crownwood.Magic.Controls.TabPage();
            this.m_panelSousTypes = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_pageSource = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeChamps = new sc2i.win32.common.GlacialList();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkDetailChamp = new sc2i.win32.common.CWndLinkStd();
            this.c2iPanel2 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_txtFormuleIndex = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label4 = new System.Windows.Forms.Label();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lblRequeteSource = new System.Windows.Forms.Label();
            this.m_btnRefreshChamps = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lnkEditQuery = new System.Windows.Forms.LinkLabel();
            this.m_pageChamps = new Crownwood.Magic.Controls.TabPage();
            this.m_panelChamps = new sc2i.win32.common.C2iPanel(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.m_chkKey = new System.Windows.Forms.CheckBox();
            this.m_panelListeChampsCustom = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_numUpDownOrdre = new sc2i.win32.common.C2iNumericUpDown();
            this.m_lnkNewChampCustom = new System.Windows.Forms.LinkLabel();
            this.label7 = new System.Windows.Forms.Label();
            this.c2iPanel3 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_wndListeChampsCalcules = new sc2i.win32.expression.CControlEditListeFormulesNommees();
            this.label11 = new System.Windows.Forms.Label();
            this.m_panelMonoFormulaire = new sc2i.win32.common.C2iPanel(this.components);
            this.m_cmbFormulaireUnique = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
            this.label10 = new System.Windows.Forms.Label();
            this.m_panelEditChamps = new timos.win32.composants.CPanelEditDefinisseurChampsCustom();
            this.panel1 = new System.Windows.Forms.Panel();
            this.c2iNumericUpDown2 = new sc2i.win32.common.C2iNumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.c2iNumericUpDown1 = new sc2i.win32.common.C2iNumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.m_cmbModeFormulaire = new sc2i.win32.common.C2iComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_pageSetupEntitesSnmp = new Crownwood.Magic.Controls.TabPage();
            this.label13 = new System.Windows.Forms.Label();
            this.m_panelSymbole = new timos.CPanelSymboleElement();
            this.m_btnFiltreType = new System.Windows.Forms.PictureBox();
            this.m_cmbxTypeElements = new sc2i.win32.common.C2iComboBox();
            this.m_txtFormuleLibelle = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label12 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_panelConteneurGererChamps = new System.Windows.Forms.Panel();
            this.m_menuFromRequete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pagePolling.SuspendLayout();
            this.m_pageSousTypes.SuspendLayout();
            this.m_pageSource.SuspendLayout();
            this.panel2.SuspendLayout();
            this.c2iPanel2.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnRefreshChamps)).BeginInit();
            this.m_pageChamps.SuspendLayout();
            this.m_panelChamps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownOrdre)).BeginInit();
            this.c2iPanel3.SuspendLayout();
            this.m_panelMonoFormulaire.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).BeginInit();
            this.m_pageSetupEntitesSnmp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFiltreType)).BeginInit();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(738, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(630, 0);
            this.m_panelCle.Size = new System.Drawing.Size(108, 28);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Size = new System.Drawing.Size(945, 28);
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
            this.label1.Location = new System.Drawing.Point(16, 30);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 26);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(546, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_chkReadOnly);
            this.c2iPanelOmbre4.Controls.Add(this.m_lnkTypeAgent);
            this.c2iPanelOmbre4.Controls.Add(this.m_ArbreHierarchique);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.label8);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 38);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(710, 91);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_chkReadOnly
            // 
            this.m_chkReadOnly.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkReadOnly, "ReadOnly");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkReadOnly, true);
            this.m_chkReadOnly.Location = new System.Drawing.Point(132, 53);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkReadOnly, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_chkReadOnly, "");
            this.m_chkReadOnly.Name = "m_chkReadOnly";
            this.m_chkReadOnly.Size = new System.Drawing.Size(106, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkReadOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkReadOnly, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkReadOnly.TabIndex = 4010;
            this.m_chkReadOnly.Text = "Read only|20474";
            this.m_chkReadOnly.UseVisualStyleBackColor = true;
            // 
            // m_lnkTypeAgent
            // 
            this.m_lnkTypeAgent.BackColor = System.Drawing.Color.White;
            this.m_lnkTypeAgent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lnkTypeAgent.ClickEnabled = true;
            this.m_lnkTypeAgent.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkTypeAgent.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkTypeAgent.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkTypeAgent.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkTypeAgent.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkTypeAgent.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_lnkTypeAgent, "TypeAgentSnmp.Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkTypeAgent, true);
            this.m_lnkTypeAgent.Location = new System.Drawing.Point(132, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTypeAgent, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkTypeAgent, "");
            this.m_lnkTypeAgent.Name = "m_lnkTypeAgent";
            this.m_lnkTypeAgent.Size = new System.Drawing.Size(546, 17);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTypeAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTypeAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTypeAgent.TabIndex = 4009;
            this.m_lnkTypeAgent.Text = "[TypeAgentSnmp.Libelle]";
            this.m_lnkTypeAgent.LinkClicked += new System.EventHandler(this.m_lnkTypeAgent_LinkClicked);
            // 
            // m_ArbreHierarchique
            // 
            this.m_ArbreHierarchique.AutoriseReaffectation = true;
            this.m_ArbreHierarchique.BackColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_ArbreHierarchique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_ArbreHierarchique, false);
            this.m_ArbreHierarchique.Location = new System.Drawing.Point(132, 81);
            this.m_ArbreHierarchique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_ArbreHierarchique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_ArbreHierarchique, "");
            this.m_ArbreHierarchique.Name = "m_ArbreHierarchique";
            this.m_ArbreHierarchique.Size = new System.Drawing.Size(546, 13);
            this.m_extStyle.SetStyleBackColor(this.m_ArbreHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ArbreHierarchique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ArbreHierarchique.TabIndex = 4008;
            this.m_ArbreHierarchique.Visible = false;
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(16, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 13);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4002;
            this.label8.Text = "Agent type|20301";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 81);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "Hierarchy|20262";
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
            this.m_tabControl.Location = new System.Drawing.Point(12, 135);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageSousTypes;
            this.m_tabControl.Size = new System.Drawing.Size(933, 392);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageSousTypes,
            this.m_pageSource,
            this.m_pageChamps,
            this.m_pageSetupEntitesSnmp,
            this.m_pagePolling});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            this.m_tabControl.SelectionChanged += new System.EventHandler(this.m_tabControl_SelectionChanged);
            // 
            // m_pagePolling
            // 
            this.m_pagePolling.Controls.Add(this.m_wndSetupPolling);
            this.m_extLinkField.SetLinkField(this.m_pagePolling, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pagePolling, false);
            this.m_pagePolling.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pagePolling, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pagePolling, "");
            this.m_pagePolling.Name = "m_pagePolling";
            this.m_pagePolling.Selected = false;
            this.m_pagePolling.Size = new System.Drawing.Size(917, 351);
            this.m_extStyle.SetStyleBackColor(this.m_pagePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pagePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pagePolling.TabIndex = 14;
            this.m_pagePolling.Title = "Polling setup|20895";
            // 
            // m_wndSetupPolling
            // 
            this.m_wndSetupPolling.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_wndSetupPolling, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndSetupPolling, false);
            this.m_wndSetupPolling.Location = new System.Drawing.Point(0, 0);
            this.m_wndSetupPolling.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndSetupPolling, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndSetupPolling, "");
            this.m_wndSetupPolling.Name = "m_wndSetupPolling";
            this.m_wndSetupPolling.Size = new System.Drawing.Size(917, 351);
            this.m_extStyle.SetStyleBackColor(this.m_wndSetupPolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndSetupPolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndSetupPolling.TabIndex = 0;
            // 
            // m_pageSousTypes
            // 
            this.m_pageSousTypes.Controls.Add(this.m_panelSousTypes);
            this.m_extLinkField.SetLinkField(this.m_pageSousTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSousTypes, false);
            this.m_pageSousTypes.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSousTypes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSousTypes, "");
            this.m_pageSousTypes.Name = "m_pageSousTypes";
            this.m_pageSousTypes.Selected = false;
            this.m_pageSousTypes.Size = new System.Drawing.Size(917, 351);
            this.m_extStyle.SetStyleBackColor(this.m_pageSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSousTypes.TabIndex = 10;
            this.m_pageSousTypes.Title = "Sub-types|20285";
            // 
            // m_panelSousTypes
            // 
            this.m_panelSousTypes.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelSousTypes.AffectationsPourNouveauxElements")));
            this.m_panelSousTypes.AllowArbre = true;
            this.m_panelSousTypes.AllowCustomisation = true;
            this.m_panelSousTypes.AllowSerializePreferences = true;
            glColumn4.ActiveControlItems = null;
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Libelle";
            glColumn4.Propriete = "Libelle";
            glColumn4.Text = "Label|50";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 100;
            this.m_panelSousTypes.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn4});
            this.m_panelSousTypes.ContexteUtilisation = "";
            this.m_panelSousTypes.ControlFiltreStandard = null;
            this.m_panelSousTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSousTypes.ElementSelectionne = null;
            this.m_panelSousTypes.EnableCustomisation = true;
            this.m_panelSousTypes.FiltreDeBase = null;
            this.m_panelSousTypes.FiltreDeBaseEnAjout = false;
            this.m_panelSousTypes.FiltrePrefere = null;
            this.m_panelSousTypes.FiltreRapide = null;
            this.m_panelSousTypes.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelSousTypes, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSousTypes, false);
            this.m_panelSousTypes.ListeObjets = null;
            this.m_panelSousTypes.Location = new System.Drawing.Point(0, 0);
            this.m_panelSousTypes.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSousTypes, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelSousTypes.ModeQuickSearch = false;
            this.m_panelSousTypes.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelSousTypes, "");
            this.m_panelSousTypes.MultiSelect = false;
            this.m_panelSousTypes.Name = "m_panelSousTypes";
            this.m_panelSousTypes.Navigateur = null;
            this.m_panelSousTypes.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelSousTypes.ProprieteObjetAEditer = null;
            this.m_panelSousTypes.QuickSearchText = "";
            this.m_panelSousTypes.ShortIcons = false;
            this.m_panelSousTypes.Size = new System.Drawing.Size(917, 351);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousTypes, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousTypes.TabIndex = 2;
            this.m_panelSousTypes.TrierAuClicSurEnteteColonne = true;
            this.m_panelSousTypes.UseCheckBoxes = false;
            // 
            // m_pageSource
            // 
            this.m_pageSource.Controls.Add(this.m_wndListeChamps);
            this.m_pageSource.Controls.Add(this.panel2);
            this.m_pageSource.Controls.Add(this.c2iPanel2);
            this.m_pageSource.Controls.Add(this.c2iPanel1);
            this.m_extLinkField.SetLinkField(this.m_pageSource, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSource, false);
            this.m_pageSource.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSource, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSource, "");
            this.m_pageSource.Name = "m_pageSource";
            this.m_pageSource.Selected = false;
            this.m_pageSource.Size = new System.Drawing.Size(917, 351);
            this.m_extStyle.SetStyleBackColor(this.m_pageSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSource.TabIndex = 13;
            this.m_pageSource.Title = "Query source|20290";
            // 
            // m_wndListeChamps
            // 
            this.m_wndListeChamps.AllowColumnResize = true;
            this.m_wndListeChamps.AllowMultiselect = false;
            this.m_wndListeChamps.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeChamps.AlternatingColors = false;
            this.m_wndListeChamps.AutoHeight = true;
            this.m_wndListeChamps.AutoSort = true;
            this.m_wndListeChamps.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeChamps.CanChangeActivationCheckBoxes = false;
            this.m_wndListeChamps.CheckBoxes = false;
            this.m_wndListeChamps.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeChamps.CheckedItems")));
            glColumn1.ActiveControlItems = null;
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "Champ.NomChamp";
            glColumn1.Text = "Field name|20080";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 300;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Column1x";
            glColumn5.Propriete = "ChampCustom.Nom";
            glColumn5.Text = "Associated field|20343";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 250;
            this.m_wndListeChamps.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1,
            glColumn5});
            this.m_wndListeChamps.ContexteUtilisation = "";
            this.m_wndListeChamps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeChamps.EnableCustomisation = true;
            this.m_wndListeChamps.FocusedItem = null;
            this.m_wndListeChamps.FullRowSelect = true;
            this.m_wndListeChamps.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeChamps.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeChamps.HasImages = false;
            this.m_wndListeChamps.HeaderHeight = 22;
            this.m_wndListeChamps.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeChamps.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeChamps.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeChamps.HeaderVisible = true;
            this.m_wndListeChamps.HeaderWordWrap = false;
            this.m_wndListeChamps.HotColumnIndex = -1;
            this.m_wndListeChamps.HotItemIndex = -1;
            this.m_wndListeChamps.HotTracking = false;
            this.m_wndListeChamps.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeChamps.ImageList = null;
            this.m_wndListeChamps.ItemHeight = 17;
            this.m_wndListeChamps.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeChamps, false);
            this.m_wndListeChamps.ListeSource = null;
            this.m_wndListeChamps.Location = new System.Drawing.Point(0, 46);
            this.m_wndListeChamps.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeChamps, "");
            this.m_wndListeChamps.Name = "m_wndListeChamps";
            this.m_wndListeChamps.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeChamps.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeChamps.ShowBorder = true;
            this.m_wndListeChamps.ShowFocusRect = true;
            this.m_wndListeChamps.Size = new System.Drawing.Size(917, 272);
            this.m_wndListeChamps.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChamps.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeChamps.TabIndex = 2;
            this.m_wndListeChamps.Text = "glacialList1";
            this.m_wndListeChamps.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeChamps.DoubleClick += new System.EventHandler(this.m_wndListeChamps_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkDetailChamp);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel2, false);
            this.panel2.Location = new System.Drawing.Point(0, 21);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(917, 25);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 6;
            // 
            // m_lnkDetailChamp
            // 
            this.m_lnkDetailChamp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDetailChamp.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkDetailChamp.CustomImage")));
            this.m_lnkDetailChamp.CustomText = "Detail";
            this.m_lnkDetailChamp.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetailChamp.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkDetailChamp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDetailChamp, false);
            this.m_lnkDetailChamp.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetailChamp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDetailChamp, "");
            this.m_lnkDetailChamp.Name = "m_lnkDetailChamp";
            this.m_lnkDetailChamp.ShortMode = false;
            this.m_lnkDetailChamp.Size = new System.Drawing.Size(112, 25);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailChamp.TabIndex = 0;
            this.m_lnkDetailChamp.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkDetailChamp.LinkClicked += new System.EventHandler(this.m_lnkDetailChamp_LinkClicked);
            // 
            // c2iPanel2
            // 
            this.c2iPanel2.Controls.Add(this.m_txtFormuleIndex);
            this.c2iPanel2.Controls.Add(this.label4);
            this.c2iPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_extLinkField.SetLinkField(this.c2iPanel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanel2, false);
            this.c2iPanel2.Location = new System.Drawing.Point(0, 318);
            this.c2iPanel2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel2, "");
            this.c2iPanel2.Name = "c2iPanel2";
            this.c2iPanel2.Size = new System.Drawing.Size(917, 33);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel2.TabIndex = 5;
            // 
            // m_txtFormuleIndex
            // 
            this.m_txtFormuleIndex.AllowGraphic = true;
            this.m_txtFormuleIndex.AllowNullFormula = false;
            this.m_txtFormuleIndex.AllowSaisieTexte = true;
            this.m_txtFormuleIndex.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleIndex.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleIndex, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleIndex, false);
            this.m_txtFormuleIndex.Location = new System.Drawing.Point(201, 4);
            this.m_txtFormuleIndex.LockEdition = false;
            this.m_txtFormuleIndex.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleIndex, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleIndex, "");
            this.m_txtFormuleIndex.Name = "m_txtFormuleIndex";
            this.m_txtFormuleIndex.Size = new System.Drawing.Size(697, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleIndex.TabIndex = 8;
            this.m_txtFormuleIndex.Enter += new System.EventHandler(this.m_txtFormuleActions_Enter);
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 21);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 7;
            this.label4.Text = "Default index formula|20289";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_lblRequeteSource);
            this.c2iPanel1.Controls.Add(this.m_btnRefreshChamps);
            this.c2iPanel1.Controls.Add(this.label6);
            this.c2iPanel1.Controls.Add(this.m_lnkEditQuery);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.c2iPanel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanel1, false);
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel1, "");
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(917, 21);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel1.TabIndex = 4;
            // 
            // m_lblRequeteSource
            // 
            this.m_lblRequeteSource.BackColor = System.Drawing.Color.White;
            this.m_lblRequeteSource.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblRequeteSource.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lblRequeteSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_lblRequeteSource, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblRequeteSource, false);
            this.m_lblRequeteSource.Location = new System.Drawing.Point(121, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblRequeteSource, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lblRequeteSource, "");
            this.m_lblRequeteSource.Name = "m_lblRequeteSource";
            this.m_lblRequeteSource.Size = new System.Drawing.Size(616, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lblRequeteSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblRequeteSource, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblRequeteSource.TabIndex = 8;
            this.m_lblRequeteSource.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblRequeteSource.Click += new System.EventHandler(this.m_lblRequeteSource_Click);
            // 
            // m_btnRefreshChamps
            // 
            this.m_btnRefreshChamps.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnRefreshChamps.Image = global::timos.Properties.Resources.Reload;
            this.m_extLinkField.SetLinkField(this.m_btnRefreshChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnRefreshChamps, false);
            this.m_btnRefreshChamps.Location = new System.Drawing.Point(737, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnRefreshChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnRefreshChamps, "");
            this.m_btnRefreshChamps.Name = "m_btnRefreshChamps";
            this.m_btnRefreshChamps.Size = new System.Drawing.Size(24, 21);
            this.m_btnRefreshChamps.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnRefreshChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRefreshChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRefreshChamps.TabIndex = 9;
            this.m_btnRefreshChamps.TabStop = false;
            this.m_btnRefreshChamps.Click += new System.EventHandler(this.m_btnRefreshChamps_Click);
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 21);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 7;
            this.label6.Text = "Source query|20290";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkEditQuery
            // 
            this.m_lnkEditQuery.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.m_lnkEditQuery, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkEditQuery, false);
            this.m_lnkEditQuery.Location = new System.Drawing.Point(761, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkEditQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkEditQuery, "");
            this.m_lnkEditQuery.Name = "m_lnkEditQuery";
            this.m_lnkEditQuery.Size = new System.Drawing.Size(156, 21);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEditQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEditQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEditQuery.TabIndex = 10;
            this.m_lnkEditQuery.TabStop = true;
            this.m_lnkEditQuery.Text = "Edit query|20300";
            this.m_lnkEditQuery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkEditQuery.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEditQuery_LinkClicked);
            // 
            // m_pageChamps
            // 
            this.m_pageChamps.Controls.Add(this.m_panelChamps);
            this.m_pageChamps.Controls.Add(this.c2iPanel3);
            this.m_pageChamps.Controls.Add(this.m_panelMonoFormulaire);
            this.m_pageChamps.Controls.Add(this.m_panelEditChamps);
            this.m_pageChamps.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_pageChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageChamps, false);
            this.m_pageChamps.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageChamps, "");
            this.m_pageChamps.Name = "m_pageChamps";
            this.m_pageChamps.Selected = false;
            this.m_pageChamps.Size = new System.Drawing.Size(917, 351);
            this.m_extStyle.SetStyleBackColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageChamps.TabIndex = 11;
            this.m_pageChamps.Title = "Custom fields|198";
            // 
            // m_panelChamps
            // 
            this.m_panelChamps.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.m_panelChamps.Controls.Add(this.label3);
            this.m_panelChamps.Controls.Add(this.pictureBox5);
            this.m_panelChamps.Controls.Add(this.m_chkKey);
            this.m_panelChamps.Controls.Add(this.m_panelListeChampsCustom);
            this.m_panelChamps.Controls.Add(this.m_numUpDownOrdre);
            this.m_panelChamps.Controls.Add(this.m_lnkNewChampCustom);
            this.m_panelChamps.Controls.Add(this.label7);
            this.m_extLinkField.SetLinkField(this.m_panelChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelChamps, false);
            this.m_panelChamps.Location = new System.Drawing.Point(266, 21);
            this.m_panelChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelChamps, "");
            this.m_panelChamps.Name = "m_panelChamps";
            this.m_panelChamps.Size = new System.Drawing.Size(268, 327);
            this.m_extStyle.SetStyleBackColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelChamps.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(4, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 15);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fields available on mediation device|20287";
            // 
            // pictureBox5
            // 
            this.pictureBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox5.Image = global::timos.Properties.Resources.cle;
            this.m_extLinkField.SetLinkField(this.pictureBox5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.pictureBox5, false);
            this.pictureBox5.Location = new System.Drawing.Point(217, 299);
            this.m_gestionnaireModeEdition.SetModeEdition(this.pictureBox5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.pictureBox5, "");
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.pictureBox5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.pictureBox5.TabIndex = 11;
            this.pictureBox5.TabStop = false;
            // 
            // m_chkKey
            // 
            this.m_chkKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_extLinkField.SetLinkField(this.m_chkKey, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_chkKey, false);
            this.m_chkKey.Location = new System.Drawing.Point(195, 300);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkKey, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_chkKey, "");
            this.m_chkKey.Name = "m_chkKey";
            this.m_chkKey.Size = new System.Drawing.Size(19, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkKey, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkKey, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkKey.TabIndex = 10;
            this.m_chkKey.Text = "checkBox1";
            this.m_chkKey.UseVisualStyleBackColor = true;
            // 
            // m_panelListeChampsCustom
            // 
            this.m_panelListeChampsCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelListeChampsCustom.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_panelListeChampsCustom.EnableCustomisation = true;
            this.m_panelListeChampsCustom.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeChampsCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeChampsCustom, false);
            this.m_panelListeChampsCustom.Location = new System.Drawing.Point(17, 31);
            this.m_panelListeChampsCustom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeChampsCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelListeChampsCustom, "");
            this.m_panelListeChampsCustom.Name = "m_panelListeChampsCustom";
            this.m_panelListeChampsCustom.Size = new System.Drawing.Size(236, 265);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeChampsCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeChampsCustom.TabIndex = 5;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Nom";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Name|64";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 200;
            // 
            // m_numUpDownOrdre
            // 
            this.m_numUpDownOrdre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_numUpDownOrdre.DoubleValue = 0D;
            this.m_numUpDownOrdre.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numUpDownOrdre, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_numUpDownOrdre, false);
            this.m_numUpDownOrdre.Location = new System.Drawing.Point(93, 297);
            this.m_numUpDownOrdre.LockEdition = false;
            this.m_numUpDownOrdre.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numUpDownOrdre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_numUpDownOrdre, "");
            this.m_numUpDownOrdre.Name = "m_numUpDownOrdre";
            this.m_numUpDownOrdre.Size = new System.Drawing.Size(82, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numUpDownOrdre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numUpDownOrdre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numUpDownOrdre.TabIndex = 9;
            this.m_numUpDownOrdre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numUpDownOrdre.ThousandsSeparator = true;
            // 
            // m_lnkNewChampCustom
            // 
            this.m_lnkNewChampCustom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkNewChampCustom.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkNewChampCustom, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkNewChampCustom, false);
            this.m_lnkNewChampCustom.Location = new System.Drawing.Point(125, 15);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkNewChampCustom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkNewChampCustom, "");
            this.m_lnkNewChampCustom.Name = "m_lnkNewChampCustom";
            this.m_lnkNewChampCustom.Size = new System.Drawing.Size(139, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkNewChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkNewChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkNewChampCustom.TabIndex = 4;
            this.m_lnkNewChampCustom.TabStop = true;
            this.m_lnkNewChampCustom.Text = "Field management|20275";
            this.m_lnkNewChampCustom.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkNewChampCustom_LinkClicked);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(23, 299);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 16);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 8;
            this.label7.Text = "Order|20276";
            // 
            // c2iPanel3
            // 
            this.c2iPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.c2iPanel3.Controls.Add(this.m_wndListeChampsCalcules);
            this.c2iPanel3.Controls.Add(this.label11);
            this.m_extLinkField.SetLinkField(this.c2iPanel3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanel3, false);
            this.c2iPanel3.Location = new System.Drawing.Point(536, 22);
            this.c2iPanel3.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanel3, "");
            this.c2iPanel3.Name = "c2iPanel3";
            this.c2iPanel3.Size = new System.Drawing.Size(390, 260);
            this.m_extStyle.SetStyleBackColor(this.c2iPanel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iPanel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel3.TabIndex = 14;
            // 
            // m_wndListeChampsCalcules
            // 
            this.m_wndListeChampsCalcules.AutoScroll = true;
            this.m_wndListeChampsCalcules.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeChampsCalcules.HasDeleteButton = true;
            this.m_wndListeChampsCalcules.HasHadButton = true;
            this.m_wndListeChampsCalcules.HeaderTextForFormula = "";
            this.m_wndListeChampsCalcules.HeaderTextForName = "";
            this.m_wndListeChampsCalcules.HideNomFormule = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeChampsCalcules, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeChampsCalcules, false);
            this.m_wndListeChampsCalcules.Location = new System.Drawing.Point(0, 35);
            this.m_wndListeChampsCalcules.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeChampsCalcules, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_wndListeChampsCalcules, "");
            this.m_wndListeChampsCalcules.Name = "m_wndListeChampsCalcules";
            this.m_wndListeChampsCalcules.Size = new System.Drawing.Size(386, 221);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeChampsCalcules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeChampsCalcules, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeChampsCalcules.TabIndex = 13;
            this.m_wndListeChampsCalcules.TypeFormuleNomme = typeof(sc2i.expression.CFormuleNommee);
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(386, 35);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 14;
            this.label11.Text = "Other informations available on mediation device|20336";
            // 
            // m_panelMonoFormulaire
            // 
            this.m_panelMonoFormulaire.Controls.Add(this.m_cmbFormulaireUnique);
            this.m_panelMonoFormulaire.Controls.Add(this.label10);
            this.m_panelMonoFormulaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelMonoFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelMonoFormulaire, false);
            this.m_panelMonoFormulaire.Location = new System.Drawing.Point(534, 22);
            this.m_panelMonoFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelMonoFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelMonoFormulaire, "");
            this.m_panelMonoFormulaire.Name = "m_panelMonoFormulaire";
            this.m_panelMonoFormulaire.Size = new System.Drawing.Size(218, 329);
            this.m_extStyle.SetStyleBackColor(this.m_panelMonoFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMonoFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMonoFormulaire.TabIndex = 12;
            // 
            // m_cmbFormulaireUnique
            // 
            this.m_cmbFormulaireUnique.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaireUnique.ElementSelectionne = null;
            this.m_cmbFormulaireUnique.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbFormulaireUnique.FormattingEnabled = true;
            this.m_cmbFormulaireUnique.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbFormulaireUnique, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbFormulaireUnique, false);
            this.m_cmbFormulaireUnique.ListDonnees = null;
            this.m_cmbFormulaireUnique.Location = new System.Drawing.Point(4, 25);
            this.m_cmbFormulaireUnique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbFormulaireUnique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbFormulaireUnique, "");
            this.m_cmbFormulaireUnique.Name = "m_cmbFormulaireUnique";
            this.m_cmbFormulaireUnique.NullAutorise = true;
            this.m_cmbFormulaireUnique.ProprieteAffichee = null;
            this.m_cmbFormulaireUnique.ProprieteParentListeObjets = null;
            this.m_cmbFormulaireUnique.SelectionneurParent = null;
            this.m_cmbFormulaireUnique.Size = new System.Drawing.Size(211, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbFormulaireUnique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbFormulaireUnique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulaireUnique.TabIndex = 1;
            this.m_cmbFormulaireUnique.TextNull = "(empty)";
            this.m_cmbFormulaireUnique.Tri = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(7, 7);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(66, 15);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 0;
            this.label10.Text = "form|20315";
            // 
            // m_panelEditChamps
            // 
            this.m_panelEditChamps.AvecAffectationDirecteDeChamps = false;
            this.m_panelEditChamps.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelEditChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelEditChamps, false);
            this.m_panelEditChamps.Location = new System.Drawing.Point(0, 22);
            this.m_panelEditChamps.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelEditChamps, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelEditChamps, "");
            this.m_panelEditChamps.Name = "m_panelEditChamps";
            this.m_panelEditChamps.Size = new System.Drawing.Size(534, 329);
            this.m_extStyle.SetStyleBackColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEditChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEditChamps.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.c2iNumericUpDown2);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.c2iNumericUpDown1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.m_cmbModeFormulaire);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(917, 22);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 11;
            // 
            // c2iNumericUpDown2
            // 
            this.c2iNumericUpDown2.Dock = System.Windows.Forms.DockStyle.Left;
            this.c2iNumericUpDown2.DoubleValue = 0D;
            this.c2iNumericUpDown2.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.c2iNumericUpDown2, "UpdateIndex");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iNumericUpDown2, true);
            this.c2iNumericUpDown2.Location = new System.Drawing.Point(553, 0);
            this.c2iNumericUpDown2.LockEdition = false;
            this.c2iNumericUpDown2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iNumericUpDown2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iNumericUpDown2, "");
            this.c2iNumericUpDown2.Name = "c2iNumericUpDown2";
            this.c2iNumericUpDown2.Size = new System.Drawing.Size(54, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iNumericUpDown2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iNumericUpDown2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iNumericUpDown2.TabIndex = 5;
            this.c2iNumericUpDown2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c2iNumericUpDown2.ThousandsSeparator = true;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label15, false);
            this.label15.Location = new System.Drawing.Point(444, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label15, "");
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 15);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 4;
            this.label15.Text = "Update index|20850";
            // 
            // c2iNumericUpDown1
            // 
            this.c2iNumericUpDown1.Dock = System.Windows.Forms.DockStyle.Left;
            this.c2iNumericUpDown1.DoubleValue = 0D;
            this.c2iNumericUpDown1.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.c2iNumericUpDown1, "DisplayIndex");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iNumericUpDown1, true);
            this.c2iNumericUpDown1.Location = new System.Drawing.Point(390, 0);
            this.c2iNumericUpDown1.LockEdition = false;
            this.c2iNumericUpDown1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iNumericUpDown1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iNumericUpDown1, "");
            this.c2iNumericUpDown1.Name = "c2iNumericUpDown1";
            this.c2iNumericUpDown1.Size = new System.Drawing.Size(54, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iNumericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iNumericUpDown1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iNumericUpDown1.TabIndex = 3;
            this.c2iNumericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c2iNumericUpDown1.ThousandsSeparator = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label14, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label14, false);
            this.label14.Location = new System.Drawing.Point(281, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label14, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label14, "");
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(109, 15);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 2;
            this.label14.Text = "Display index|20849";
            // 
            // m_cmbModeFormulaire
            // 
            this.m_cmbModeFormulaire.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_cmbModeFormulaire.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbModeFormulaire.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbModeFormulaire.FormattingEnabled = true;
            this.m_cmbModeFormulaire.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbModeFormulaire, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbModeFormulaire, false);
            this.m_cmbModeFormulaire.Location = new System.Drawing.Point(102, 0);
            this.m_cmbModeFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbModeFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbModeFormulaire, "");
            this.m_cmbModeFormulaire.Name = "m_cmbModeFormulaire";
            this.m_cmbModeFormulaire.Size = new System.Drawing.Size(179, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbModeFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbModeFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbModeFormulaire.TabIndex = 1;
            this.m_cmbModeFormulaire.SelectedIndexChanged += new System.EventHandler(this.m_cmbModeFormulaire_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(102, 15);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 0;
            this.label9.Text = "Form mode|20314";
            // 
            // m_pageSetupEntitesSnmp
            // 
            this.m_pageSetupEntitesSnmp.Controls.Add(this.label13);
            this.m_pageSetupEntitesSnmp.Controls.Add(this.m_panelSymbole);
            this.m_pageSetupEntitesSnmp.Controls.Add(this.m_btnFiltreType);
            this.m_pageSetupEntitesSnmp.Controls.Add(this.m_cmbxTypeElements);
            this.m_pageSetupEntitesSnmp.Controls.Add(this.m_txtFormuleLibelle);
            this.m_pageSetupEntitesSnmp.Controls.Add(this.label12);
            this.m_pageSetupEntitesSnmp.Controls.Add(this.label5);
            this.m_extLinkField.SetLinkField(this.m_pageSetupEntitesSnmp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSetupEntitesSnmp, false);
            this.m_pageSetupEntitesSnmp.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSetupEntitesSnmp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSetupEntitesSnmp, "");
            this.m_pageSetupEntitesSnmp.Name = "m_pageSetupEntitesSnmp";
            this.m_pageSetupEntitesSnmp.Selected = false;
            this.m_pageSetupEntitesSnmp.Size = new System.Drawing.Size(917, 351);
            this.m_extStyle.SetStyleBackColor(this.m_pageSetupEntitesSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSetupEntitesSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSetupEntitesSnmp.TabIndex = 12;
            this.m_pageSetupEntitesSnmp.Title = "Entities setup|20286";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label13, false);
            this.label13.Location = new System.Drawing.Point(15, 64);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label13, "");
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 16);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 4013;
            this.label13.Text = "Symbol|30029";
            // 
            // m_panelSymbole
            // 
            this.m_extLinkField.SetLinkField(this.m_panelSymbole, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelSymbole, false);
            this.m_panelSymbole.Location = new System.Drawing.Point(0, 83);
            this.m_panelSymbole.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSymbole, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelSymbole, "");
            this.m_panelSymbole.Name = "m_panelSymbole";
            this.m_panelSymbole.Size = new System.Drawing.Size(917, 202);
            this.m_extStyle.SetStyleBackColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSymbole, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSymbole.TabIndex = 4012;
            // 
            // m_btnFiltreType
            // 
            this.m_btnFiltreType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnFiltreType.Image = ((System.Drawing.Image)(resources.GetObject("m_btnFiltreType.Image")));
            this.m_extLinkField.SetLinkField(this.m_btnFiltreType, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnFiltreType, false);
            this.m_btnFiltreType.Location = new System.Drawing.Point(567, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnFiltreType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnFiltreType, "");
            this.m_btnFiltreType.Name = "m_btnFiltreType";
            this.m_btnFiltreType.Size = new System.Drawing.Size(16, 15);
            this.m_btnFiltreType.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnFiltreType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnFiltreType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnFiltreType.TabIndex = 4011;
            this.m_btnFiltreType.TabStop = false;
            this.m_btnFiltreType.Click += new System.EventHandler(this.m_btnFiltreType_Click);
            // 
            // m_cmbxTypeElements
            // 
            this.m_cmbxTypeElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbxTypeElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbxTypeElements.FormattingEnabled = true;
            this.m_cmbxTypeElements.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbxTypeElements, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbxTypeElements, false);
            this.m_cmbxTypeElements.Location = new System.Drawing.Point(271, 8);
            this.m_cmbxTypeElements.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbxTypeElements, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbxTypeElements, "");
            this.m_cmbxTypeElements.Name = "m_cmbxTypeElements";
            this.m_cmbxTypeElements.Size = new System.Drawing.Size(289, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbxTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbxTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbxTypeElements.TabIndex = 4007;
            // 
            // m_txtFormuleLibelle
            // 
            this.m_txtFormuleLibelle.AllowGraphic = true;
            this.m_txtFormuleLibelle.AllowNullFormula = false;
            this.m_txtFormuleLibelle.AllowSaisieTexte = true;
            this.m_txtFormuleLibelle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleLibelle.Formule = null;
            this.m_extLinkField.SetLinkField(this.m_txtFormuleLibelle, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFormuleLibelle, false);
            this.m_txtFormuleLibelle.Location = new System.Drawing.Point(210, 33);
            this.m_txtFormuleLibelle.LockEdition = false;
            this.m_txtFormuleLibelle.LockZoneTexte = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFormuleLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFormuleLibelle, "");
            this.m_txtFormuleLibelle.Name = "m_txtFormuleLibelle";
            this.m_txtFormuleLibelle.Size = new System.Drawing.Size(615, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleLibelle.TabIndex = 5;
            // 
            // label12
            // 
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(12, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(253, 21);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 2;
            this.label12.Text = "Associated supervised Elements Type|10272";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(12, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 21);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 2;
            this.label5.Text = "Entity label|20288";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelConteneurGererChamps
            // 
            this.m_extLinkField.SetLinkField(this.m_panelConteneurGererChamps, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelConteneurGererChamps, false);
            this.m_panelConteneurGererChamps.Location = new System.Drawing.Point(322, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConteneurGererChamps, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelConteneurGererChamps, "");
            this.m_panelConteneurGererChamps.Name = "m_panelConteneurGererChamps";
            this.m_panelConteneurGererChamps.Size = new System.Drawing.Size(327, 285);
            this.m_extStyle.SetStyleBackColor(this.m_panelConteneurGererChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConteneurGererChamps, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConteneurGererChamps.TabIndex = 11;
            // 
            // m_menuFromRequete
            // 
            this.m_extLinkField.SetLinkField(this.m_menuFromRequete, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuFromRequete, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuFromRequete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuFromRequete, "");
            this.m_menuFromRequete.Name = "m_menuFromRequete";
            this.m_menuFromRequete.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuFromRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuFromRequete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // CFormEditionTypeEntiteSnmp
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(945, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeEntiteSnmp";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEntiteSnmp_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeEntiteSnmp_OnMajChampsPage);
            this.Load += new System.EventHandler(this.CFormEditionTypeEntiteSnmp_Load);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
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
            this.m_pagePolling.ResumeLayout(false);
            this.m_pageSousTypes.ResumeLayout(false);
            this.m_pageSource.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.c2iPanel2.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.c2iPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnRefreshChamps)).EndInit();
            this.m_pageChamps.ResumeLayout(false);
            this.m_panelChamps.ResumeLayout(false);
            this.m_panelChamps.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownOrdre)).EndInit();
            this.c2iPanel3.ResumeLayout(false);
            this.m_panelMonoFormulaire.ResumeLayout(false);
            this.m_panelMonoFormulaire.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.c2iNumericUpDown1)).EndInit();
            this.m_pageSetupEntitesSnmp.ResumeLayout(false);
            this.m_pageSetupEntitesSnmp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnFiltreType)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CTypeEntiteSnmp TypeEntiteSnmp
        {
            get
            {
                return (CTypeEntiteSnmp)ObjetEdite;
            }
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            m_bPageChampInit = false;
            if (ModeEdition && TypeEntiteSnmp != null &&
                TypeEntiteSnmp.TypeParent != null)
            {
                TypeEntiteSnmp.TypeAgentSnmp = TypeEntiteSnmp.TypeParent.TypeAgentSnmp;
            }
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Snmp entity type @1|20284", TypeEntiteSnmp.Libelle));

            m_ArbreHierarchique.AfficheHierarchie(TypeEntiteSnmp);

            m_menuFromRequete.Items.Clear();
            UpdateLabelSource();
            return result;
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            return base.MAJ_Champs();
        }

        private bool m_bPageChampInit = false;
        private CResultAErreur CFormEditionTypeEntiteSnmp_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageSousTypes)
            {
                m_panelSousTypes.InitFromListeObjets(
                TypeEntiteSnmp.TypesFils,
                typeof(CTypeEntiteSnmp),
                typeof(CFormEditionTypeEntiteSnmp),
                TypeEntiteSnmp,
                "TypeParent");
            }
            else if (page == m_pageSource)
            {
                FillListeChamps();
                m_txtFormuleIndex.Formule = TypeEntiteSnmp.FormuleCalculIndex;
            }
            else if (page == m_pageSetupEntitesSnmp)
            {
                m_txtFormuleLibelle.Init(new CFournisseurPropDynStd(),
                    typeof(CEntiteSnmp));
                m_txtFormuleLibelle.Formule = TypeEntiteSnmp.FormuleCalculLibelle;

                InitComboTypes();
                if (TypeEntiteSnmp.TypeElementsSupervise != null)
                    m_cmbxTypeElements.SelectedValue = TypeEntiteSnmp.TypeElementsSupervise;
                else
                    m_cmbxTypeElements.SelectedValue = typeof(DBNull);

                m_filtreElements = TypeEntiteSnmp.FiltreElementsSupervise;

                m_panelSymbole.InitChamps(TypeEntiteSnmp, null);

            }
            else if (page == m_pageChamps)
            {
                InitPanelChamps();
               
                m_bPageChampInit = true;
                m_wndListeChampsCalcules.Init(TypeEntiteSnmp.ChampsCalculesPourMediation.ToArray(),
                    typeof(CEntiteSnmp), new CFournisseurPropDynStd());

            }
            else if ( page == m_pagePolling )
            {
                m_wndSetupPolling.Init(TypeEntiteSnmp);
            }
            return result;
        }

        //-----------------------------------------------------------------------
        private void InitComboTypes()
        {
            List<CInfoClasseDynamique> lstTypes = new List<CInfoClasseDynamique>();

            foreach (CInfoClasseDynamique info in DynamicClassAttribute.GetAllDynamicClass())
            {
                if (typeof(IElementSupervise).IsAssignableFrom(info.Classe) && !info.Classe.IsAbstract)
                {
                    lstTypes.Add(info);
                }
            }
            lstTypes.Insert(0, new CInfoClasseDynamique(typeof(DBNull), I.T("Free|20400")));

            if (m_cmbxTypeElements.Items.Count == 0)
            {
                m_cmbxTypeElements.DataSource = lstTypes;
                m_cmbxTypeElements.ValueMember = "Classe";
                m_cmbxTypeElements.DisplayMember = "Nom";
            }
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeEntiteSnmp_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageChamps)
            {
                CModeFormulairePourTypeEntite modeFormulaire = m_cmbModeFormulaire.SelectedItem as CModeFormulairePourTypeEntite;
                if (modeFormulaire != null)
                    TypeEntiteSnmp.ModeFormulaire = modeFormulaire;
                TypeEntiteSnmp.FormulaireUnique = m_cmbFormulaireUnique.ElementSelectionne as CFormulaire;
                
                result = m_panelEditChamps.MAJ_Champs();

                if (result)
                    m_panelListeChampsCustom.ApplyModifs();
                TypeEntiteSnmp.ChampsCalculesPourMediationList.Clear();
                TypeEntiteSnmp.ChampsCalculesPourMediationList.AddRange(m_wndListeChampsCalcules.GetFormules());
                TypeEntiteSnmp.CommitChampsCalculesPourMediation();
            }
            else if (page == m_pageSousTypes)
            {
            }
            else if (page == m_pageSetupEntitesSnmp)
            {
                
                if (m_txtFormuleLibelle.Formule != null)
                    TypeEntiteSnmp.FormuleCalculLibelle = m_txtFormuleLibelle.Formule;

                TypeEntiteSnmp.TypeElementsSupervise = m_cmbxTypeElements.SelectedValue as Type;
                if (TypeEntiteSnmp.TypeElementsSupervise == typeof(DBNull))
                    TypeEntiteSnmp.TypeElementsSupervise = null;
                
                if (m_filtreElements != null &&
                    m_filtreElements.TypeElements == TypeEntiteSnmp.TypeElementsSupervise &&
                    m_filtreElements.ComposantPrincipal != null)
                    TypeEntiteSnmp.FiltreElementsSupervise = m_filtreElements;
                else
                    TypeEntiteSnmp.FiltreElementsSupervise = null;

                result = m_panelSymbole.MAJ_Champs();

            }
            else if (page == m_pageSource)
            {
                if (m_txtFormuleIndex.Formule != null)
                    TypeEntiteSnmp.FormuleCalculIndex = m_txtFormuleIndex.Formule;
                TypeEntiteSnmp.CommitChampsFromQuery();
            }
            else if ( page == m_pagePolling )
            {
                result = m_wndSetupPolling.MajChamps();
            }


            return result;
        }

        private void m_tabControl_SelectionChanged(object sender, EventArgs e)
        {

        }

        //-------------------------------------------------------------------------
        private void m_txtFormuleActions_Enter(object sender, EventArgs e)
        {
            if (m_bPageChampInit)
                m_panelListeChampsCustom.ApplyModifs();
            CTypeEntiteSnmpPourSupervision typeEntiteSnmp = TypeEntiteSnmp.GetTypeEntitePourSupervision(null, true);
            CEntiteSnmpPourSupervision entiteTest = typeEntiteSnmp.GetEntiteDeTest();
            m_txtFormuleIndex.Init(new CFournisseurPropDynStd(), new CObjetPourSousProprietes(entiteTest));
        }

        private void m_lnkNewChampCustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormNavigateurPopupListe.Show(new CFormListeChampsCustom(CEntiteSnmp.c_roleChampCustom));
            InitPanelChamps();
        }

        //-------------------------------------------------------------------------
        private void InitPanelChamps()
        {
            CListeObjetsDonnees listeChamps = new CListeObjetsDonnees(TypeEntiteSnmp.ContexteDonnee, typeof(CChampCustom));
            listeChamps.Filtre = CChampCustom.GetFiltreChampsForRole(CEntiteSnmp.c_roleChampCustom);

            m_cmbModeFormulaire.BeginUpdate();
            m_cmbModeFormulaire.Items.Clear();
            foreach ( CModeFormulairePourTypeEntite mode in CModeFormulairePourTypeEntite.GetValeursEnumPossibleInEnumALibelle ( typeof(CModeFormulairePourTypeEntite)))
                m_cmbModeFormulaire.Items.Add ( mode );

            m_cmbModeFormulaire.SelectedItem = TypeEntiteSnmp.ModeFormulaire;
            m_cmbModeFormulaire.EndUpdate();
            UpdateOptionsFormulaire();

             m_panelEditChamps.InitPanel(
                    TypeEntiteSnmp,
                    typeof(CFormListeChampsCustom),
                    typeof(CFormListeFormulaires));
             m_cmbFormulaireUnique.Init(
                 typeof(CFormulaire),
                 CFormulaire.GetFiltreFormulairesForRole ( CAgentSnmp.c_roleChampCustom ),
                 //new CFiltreData(CFormulaire.c_champCodeRole + "=@1", CAgentSnmp.c_roleChampCustom),
                 "Libelle",
                 false);
            m_cmbFormulaireUnique.ElementSelectionne = TypeEntiteSnmp.FormulaireUnique;

            m_panelListeChampsCustom.Init(
                listeChamps,
                TypeEntiteSnmp.RelationsChampsCustomListe,
                TypeEntiteSnmp,
                "Definisseur",
                "ChampCustom"
                );
        }

        //-------------------------------------------------------------------
        private class CMenuTableDeRequete : ToolStripMenuItem
        {
            public CODEQBase ObjetDeQuery = null;
            public CMenuTableDeRequete(CODEQBase objet)
                : base(objet.NomFinal)
            {
                ObjetDeQuery = objet;
            }
        }

        //-------------------------------------------------------------------
        private void AssureMenuFromRequete()
        {
            if (m_menuFromRequete.Items.Count != 0)
                return;
            if (TypeEntiteSnmp.TypeAgentSnmp == null)
                return;
            foreach (CEasyQuery query in TypeEntiteSnmp.TypeAgentSnmp.Queries)
            {
                ToolStripMenuItem item = new ToolStripMenuItem(query.Libelle);
                foreach (I2iObjetGraphique objet in query.Childs)
                {
                    CODEQBase objDeQuery = objet as CODEQBase;
                    if (objDeQuery != null)
                    {
                        CMenuTableDeRequete menu = new CMenuTableDeRequete(objDeQuery);
                        item.DropDownItems.Add(menu);
                        menu.Click += new EventHandler(menuDeRequete_Click);
                    }
                }
                m_menuFromRequete.Items.Add(item);
            }
        }

        //-------------------------------------------------------------------
        void menuDeRequete_Click(object sender, EventArgs e)
        {
            CMenuTableDeRequete menu = sender as CMenuTableDeRequete;
            if (menu != null)
            {
                CODEQBase objet = menu.ObjetDeQuery;
                TypeEntiteSnmp.FillFromTable(objet);
                UpdateLabelSource();
                FillListeChamps();
            }
        }

        //------------------------------------------------------------------------------
        private CODEQBase GetObjetDeQuerySource()
        {
            if (TypeEntiteSnmp.TypeAgentSnmp == null)
                return null;
            CEasyQuery query = TypeEntiteSnmp.TypeAgentSnmp.Queries.FirstOrDefault(c => c.GetObjet(TypeEntiteSnmp.IdTableSource) != null);
            if (query != null)
                return query.Childs.FirstOrDefault(o => o is IObjetDeEasyQuery && ((IObjetDeEasyQuery)o).Id == TypeEntiteSnmp.IdTableSource) as CODEQBase;
            return null;
        }

        //-------------------------------------------------------------------
        private void UpdateLabelSource()
        {
            CODEQBase objet = GetObjetDeQuerySource();
            if (objet != null && objet.Query != null)
            {
                m_lblRequeteSource.Text = objet.Query.Libelle + " (" + objet.NomFinal + ")";
            }
        }

        //-------------------------------------------------------------------
        private void m_lblRequeteSource_Click(object sender, EventArgs e)
        {
            AssureMenuFromRequete();
            m_menuFromRequete.Show(m_lblRequeteSource, new Point(0, m_lblRequeteSource.Height));
        }


        //-------------------------------------------------------------------
        private void FillListeChamps()
        {
            m_wndListeChamps.ListeSource = TypeEntiteSnmp.ChampsFromQuery.ToArray();
            m_wndListeChamps.Refresh();
        }

        //-------------------------------------------------------------------
        private void m_wndListeChamps_DoubleClick(object sender, EventArgs e)
        {
            EditeChamp();
        }

        //-------------------------------------------------------------------
        private void EditeChamp()
        {
            if (m_wndListeChamps.SelectedItems.Count == 1 && m_gestionnaireModeEdition.ModeEdition)
            {
                CChampEntiteFromQueryToChampCustom champ = m_wndListeChamps.SelectedItems[0] as CChampEntiteFromQueryToChampCustom;
                if (champ != null)
                {
                    champ.ContexteDonneePourChamp = TypeEntiteSnmp.ContexteDonnee;
                    CTypeEntiteSnmpPourSupervision typeEntiteSnmp = TypeEntiteSnmp.GetTypeEntitePourSupervision(null, true);
                    CEntiteSnmpPourSupervision entiteTest = typeEntiteSnmp.GetEntiteDeTest();
                    if (CFormEditChampEntiteFromQueryToChampCustom.EditeChamp(
                        champ,
                        typeEntiteSnmp,
                        TypeEntiteSnmp.ContexteDonnee))
                        FillListeChamps();
                }
            }

        }

        //-------------------------------------------------------------------
        private void m_btnRefreshChamps_Click(object sender, EventArgs e)
        {
            CODEQBase objet = GetObjetDeQuerySource();
            if (objet != null)
            {
                TypeEntiteSnmp.FillFromTable(objet);
                FillListeChamps();
            }
        }

        //-------------------------------------------------------------------
        private void m_lnkEditQuery_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CTypeAgentSnmp typeAgent = TypeEntiteSnmp.TypeAgentSnmp;
            CODEQBase objet = GetObjetDeQuerySource();
            if (objet != null)
            {
                CEasyQuery query = objet.Query;
                if (query != null)
                {
                    CEasyQuerySource source = new CEasyQuerySource();
                    CInterrogateurSnmp agent = new CInterrogateurSnmp();
                    agent.Connexion = CTimosApp.DefaultSnmpConnexion;
                    source.Connexion =new CSnmpConnexionForEasyQuery(agent);
                    CTableDefinitionSNMP.FromMib(source, TypeEntiteSnmp.TypeAgentSnmp.GetRootDefinitionFromMibs(), source.RootFolder);
                    query.Sources = new CEasyQuerySource[]{source};
                    if (CFormEditEasyQuery.EditeQuery(query))
                    {
                        typeAgent.CommitQueries();
                        TypeEntiteSnmp.FillFromTable(GetObjetDeQuerySource());
                        FillListeChamps();
                    }                    
                }
            }
        }

        //----------------------------------------------------------------------
        private void m_lnkTypeAgent_LinkClicked(object sender, EventArgs e)
        {
            if (TypeEntiteSnmp != null && TypeEntiteSnmp.TypeAgentSnmp != null)
            {
                CFormEditionTypeAgentSnmp form = new CFormEditionTypeAgentSnmp(TypeEntiteSnmp.TypeAgentSnmp);
                CTimosApp.Navigateur.AffichePage(form);
            }
        }



        //----------------------------------------------------------------------
        private void m_cmbModeFormulaire_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateOptionsFormulaire();
        }

        //----------------------------------------------------------------------
        private void UpdateOptionsFormulaire()
        {
            CModeFormulairePourTypeEntite mode = m_cmbModeFormulaire.SelectedItem as CModeFormulairePourTypeEntite;
            if (mode != null && mode.Code == EModeFormulairePourTypeEntite.FormulaireSurAgent)
            {
                m_panelEditChamps.Visible = false;
                m_panelMonoFormulaire.Visible = true;
            }
            else
            {
                m_panelEditChamps.Visible = true;
                m_panelMonoFormulaire.Visible = false;
            }
        }

        private void m_lnkDetailChamp_LinkClicked(object sender, EventArgs e)
        {
            EditeChamp();
        }

        CFiltreDynamique m_filtreElements = null;
        private void m_btnFiltreType_Click(object sender, EventArgs e)
        {
            Type tp = (Type)m_cmbxTypeElements.SelectedValue;
            if (tp != null)
            {
                if (m_filtreElements == null || tp != m_filtreElements.TypeElements)
                {
                    m_filtreElements = new CFiltreDynamique();
                    m_filtreElements.TypeElements = tp;
                }
                CFiltreDynamique filtreCopie = m_filtreElements.Clone() as CFiltreDynamique;
                if (CFormEditFiltreDynamique.EditeFiltre(filtreCopie,
                    true, true, null))
                    m_filtreElements = filtreCopie;
            }

        }

        private void CFormEditionTypeEntiteSnmp_Load(object sender, EventArgs e)
        {
            if (m_tabControl.TabPages.Contains(m_pageSousTypes))
                m_tabControl.TabPages.Remove(m_pageSousTypes);
        }
    }
}

