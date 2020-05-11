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
using timos.data.snmp;
using futurocom.snmp;
using System.Collections.Generic;
using timos.data.snmp.Proxy;
using System.Text;
using futurocom.snmp.polling;
using futurocom.win32.snmp.polling;
using sc2i.common.memorydb;
using futurocom.snmp.entitesnmp;
using sc2i.common.DonneeCumulee;
using futurocom.snmp.HotelPolling;
using futurocom.win32.snmp.hotelpolling;

namespace timos.snmp
{
    [sc2i.win32.data.navigation.ObjectEditeur(typeof(CAgentSnmp))]
    public class CFormEditionAgentSnmp : CFormEditionStdTimos, IFormNavigable
    {
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageSnmp;
        private Label label2;
        private C2iTextBox m_txtAdresseIp;
        private C2iTextBox c2iTextBox1;
        private Label label3;
        private Label label4;
        private C2iTextBoxNumerique c2iTextBoxNumerique1;
        private Label label5;
        private C2iComboBox m_cmbVersion;
        private Label label6;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_cmbTypeAgent;
        private Label label7;
        private CComboBoxLinkListeObjetsDonnees m_cmbServiceMediation;
        private GroupBox m_grpUpdateSNMP;
        private Label label8;
        private Label label9;
        private LinkLabel m_lnkUpdateFromSNMP;
        private Label m_lblLastUpdateToSnmp;
        private Label m_lblLastUpdateFromSNMP;
        private LinkLabel m_lnkUpdateToSnmp;
        private CheckBox checkBox1;
        private Label label10;
        private C2iTextBoxNumerique c2iTextBoxNumerique2;
        private Label label11;
        private Panel m_panelUpdateToSNMP;
        private Label label12;
        private C2iTextBox m_txtMoreIp;
        private LinkLabel m_lnkPollingSetup;
        private ContextMenuStrip m_menuPolling;
        private LinkLabel m_lnkBigDataPolling;
        private System.ComponentModel.IContainer components = null;

        public CFormEditionAgentSnmp()
            : base()
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionAgentSnmp(CAgentSnmp AgentSnmp)
            : base(AgentSnmp)
        {
            // Cet appel est requis par le Concepteur Windows Form.
            InitializeComponent();
        }
        //-------------------------------------------------------------------------
        public CFormEditionAgentSnmp(CAgentSnmp AgentSnmp, CListeObjetsDonnees liste)
            : base(AgentSnmp, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionAgentSnmp));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_cmbTypeAgent = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.label6 = new System.Windows.Forms.Label();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageSnmp = new Crownwood.Magic.Controls.TabPage();
            this.m_txtMoreIp = new sc2i.win32.common.C2iTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.c2iTextBoxNumerique2 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label10 = new System.Windows.Forms.Label();
            this.m_grpUpdateSNMP = new System.Windows.Forms.GroupBox();
            this.m_panelUpdateToSNMP = new System.Windows.Forms.Panel();
            this.m_lblLastUpdateToSnmp = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lnkUpdateToSnmp = new System.Windows.Forms.LinkLabel();
            this.m_lnkPollingSetup = new System.Windows.Forms.LinkLabel();
            this.m_lblLastUpdateFromSNMP = new System.Windows.Forms.Label();
            this.m_lnkUpdateFromSNMP = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.m_cmbServiceMediation = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label7 = new System.Windows.Forms.Label();
            this.m_cmbVersion = new sc2i.win32.common.C2iComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.c2iTextBoxNumerique1 = new sc2i.win32.common.C2iTextBoxNumerique();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtAdresseIp = new sc2i.win32.common.C2iTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_menuPolling = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_lnkBigDataPolling = new System.Windows.Forms.LinkLabel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageSnmp.SuspendLayout();
            this.m_grpUpdateSNMP.SuspendLayout();
            this.m_panelUpdateToSNMP.SuspendLayout();
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label1, false);
            this.label1.Location = new System.Drawing.Point(16, 12);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(402, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbTypeAgent);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label6);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(8, 52);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(576, 78);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_cmbTypeAgent
            // 
            this.m_cmbTypeAgent.ElementSelectionne = null;
            this.m_cmbTypeAgent.FonctionTextNull = null;
            this.m_cmbTypeAgent.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeAgent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbTypeAgent, false);
            this.m_cmbTypeAgent.Location = new System.Drawing.Point(132, 32);
            this.m_cmbTypeAgent.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeAgent, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbTypeAgent, "");
            this.m_cmbTypeAgent.Name = "m_cmbTypeAgent";
            this.m_cmbTypeAgent.SelectedObject = null;
            this.m_cmbTypeAgent.SelectionLength = 0;
            this.m_cmbTypeAgent.SelectionStart = 0;
            this.m_cmbTypeAgent.Size = new System.Drawing.Size(402, 20);
            this.m_cmbTypeAgent.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeAgent.TabIndex = 4003;
            this.m_cmbTypeAgent.TextNull = "";
            this.m_cmbTypeAgent.UseIntellisense = true;
            this.m_cmbTypeAgent.OnSelectedObjectChanged += new System.EventHandler(this.m_cmbTypeAgent_OnSelectedObjectChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label6, false);
            this.label6.Location = new System.Drawing.Point(16, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label6, "");
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4002;
            this.label6.Text = "Agent type|20311";
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
            this.m_tabControl.Location = new System.Drawing.Point(8, 136);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageSnmp;
            this.m_tabControl.Size = new System.Drawing.Size(822, 354);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageSnmp});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageSnmp
            // 
            this.m_pageSnmp.Controls.Add(this.m_txtMoreIp);
            this.m_pageSnmp.Controls.Add(this.label12);
            this.m_pageSnmp.Controls.Add(this.label11);
            this.m_pageSnmp.Controls.Add(this.c2iTextBoxNumerique2);
            this.m_pageSnmp.Controls.Add(this.label10);
            this.m_pageSnmp.Controls.Add(this.m_grpUpdateSNMP);
            this.m_pageSnmp.Controls.Add(this.m_cmbServiceMediation);
            this.m_pageSnmp.Controls.Add(this.label7);
            this.m_pageSnmp.Controls.Add(this.m_cmbVersion);
            this.m_pageSnmp.Controls.Add(this.label5);
            this.m_pageSnmp.Controls.Add(this.c2iTextBoxNumerique1);
            this.m_pageSnmp.Controls.Add(this.c2iTextBox1);
            this.m_pageSnmp.Controls.Add(this.label3);
            this.m_pageSnmp.Controls.Add(this.m_txtAdresseIp);
            this.m_pageSnmp.Controls.Add(this.label4);
            this.m_pageSnmp.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.m_pageSnmp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageSnmp, false);
            this.m_pageSnmp.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageSnmp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageSnmp, "");
            this.m_pageSnmp.Name = "m_pageSnmp";
            this.m_pageSnmp.Size = new System.Drawing.Size(806, 313);
            this.m_extStyle.SetStyleBackColor(this.m_pageSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageSnmp.TabIndex = 10;
            this.m_pageSnmp.Title = "Snmp settings|20304";
            this.m_pageSnmp.PropertyChanged += new Crownwood.Magic.Controls.TabPage.PropChangeHandler(this.m_pageSnmp_PropertyChanged);
            // 
            // m_txtMoreIp
            // 
            this.m_txtMoreIp.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtMoreIp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtMoreIp, false);
            this.m_txtMoreIp.Location = new System.Drawing.Point(239, 97);
            this.m_txtMoreIp.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtMoreIp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtMoreIp, "");
            this.m_txtMoreIp.Name = "m_txtMoreIp";
            this.m_txtMoreIp.Size = new System.Drawing.Size(402, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtMoreIp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtMoreIp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMoreIp.TabIndex = 16;
            // 
            // label12
            // 
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label12, false);
            this.label12.Location = new System.Drawing.Point(16, 100);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label12, "");
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(252, 16);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 15;
            this.label12.Text = "Additional IP or KEY (comas seperator)|20479";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label11, false);
            this.label11.Location = new System.Drawing.Point(209, 67);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label11, "");
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 16);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 14;
            this.label11.Text = "ms|20351";
            // 
            // c2iTextBoxNumerique2
            // 
            this.c2iTextBoxNumerique2.Arrondi = 0;
            this.c2iTextBoxNumerique2.DecimalAutorise = false;
            this.c2iTextBoxNumerique2.EmptyText = "";
            this.c2iTextBoxNumerique2.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique2, "Timeout");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBoxNumerique2, true);
            this.c2iTextBoxNumerique2.Location = new System.Drawing.Point(139, 62);
            this.c2iTextBoxNumerique2.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique2, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique2, "");
            this.c2iTextBoxNumerique2.Name = "c2iTextBoxNumerique2";
            this.c2iTextBoxNumerique2.NullAutorise = false;
            this.c2iTextBoxNumerique2.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique2.SeparateurMilliers = "";
            this.c2iTextBoxNumerique2.Size = new System.Drawing.Size(68, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique2.TabIndex = 13;
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label10, false);
            this.label10.Location = new System.Drawing.Point(16, 67);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label10, "");
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(117, 16);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 12;
            this.label10.Text = "Timeout|20350";
            // 
            // m_grpUpdateSNMP
            // 
            this.m_grpUpdateSNMP.Controls.Add(this.m_lnkBigDataPolling);
            this.m_grpUpdateSNMP.Controls.Add(this.m_panelUpdateToSNMP);
            this.m_grpUpdateSNMP.Controls.Add(this.m_lnkPollingSetup);
            this.m_grpUpdateSNMP.Controls.Add(this.m_lblLastUpdateFromSNMP);
            this.m_grpUpdateSNMP.Controls.Add(this.m_lnkUpdateFromSNMP);
            this.m_grpUpdateSNMP.Controls.Add(this.label8);
            this.m_grpUpdateSNMP.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_extLinkField.SetLinkField(this.m_grpUpdateSNMP, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_grpUpdateSNMP, false);
            this.m_grpUpdateSNMP.Location = new System.Drawing.Point(19, 137);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_grpUpdateSNMP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_grpUpdateSNMP, "");
            this.m_grpUpdateSNMP.Name = "m_grpUpdateSNMP";
            this.m_grpUpdateSNMP.Size = new System.Drawing.Size(622, 145);
            this.m_extStyle.SetStyleBackColor(this.m_grpUpdateSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_grpUpdateSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_grpUpdateSNMP.TabIndex = 11;
            this.m_grpUpdateSNMP.TabStop = false;
            this.m_grpUpdateSNMP.Text = "Snmp agent|20337";
            // 
            // m_panelUpdateToSNMP
            // 
            this.m_panelUpdateToSNMP.Controls.Add(this.m_lblLastUpdateToSnmp);
            this.m_panelUpdateToSNMP.Controls.Add(this.checkBox1);
            this.m_panelUpdateToSNMP.Controls.Add(this.label9);
            this.m_panelUpdateToSNMP.Controls.Add(this.m_lnkUpdateToSnmp);
            this.m_extLinkField.SetLinkField(this.m_panelUpdateToSNMP, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelUpdateToSNMP, false);
            this.m_panelUpdateToSNMP.Location = new System.Drawing.Point(14, 58);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelUpdateToSNMP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelUpdateToSNMP, "");
            this.m_panelUpdateToSNMP.Name = "m_panelUpdateToSNMP";
            this.m_panelUpdateToSNMP.Size = new System.Drawing.Size(536, 52);
            this.m_extStyle.SetStyleBackColor(this.m_panelUpdateToSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelUpdateToSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelUpdateToSNMP.TabIndex = 15;
            // 
            // m_lblLastUpdateToSnmp
            // 
            this.m_lblLastUpdateToSnmp.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_lblLastUpdateToSnmp.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblLastUpdateToSnmp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblLastUpdateToSnmp, false);
            this.m_lblLastUpdateToSnmp.Location = new System.Drawing.Point(214, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLastUpdateToSnmp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLastUpdateToSnmp, "");
            this.m_lblLastUpdateToSnmp.Name = "m_lblLastUpdateToSnmp";
            this.m_lblLastUpdateToSnmp.Size = new System.Drawing.Size(149, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblLastUpdateToSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLastUpdateToSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLastUpdateToSnmp.TabIndex = 3;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.checkBox1, "AutoUpdate");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.checkBox1, true);
            this.checkBox1.Location = new System.Drawing.Point(214, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.checkBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.checkBox1, "");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(155, 19);
            this.m_extStyle.SetStyleBackColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.checkBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "Automatic update|20341";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(4, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(294, 20);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 1;
            this.label9.Text = "Last physical agent update|20339";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_lnkUpdateToSnmp
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkUpdateToSnmp, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkUpdateToSnmp, false);
            this.m_lnkUpdateToSnmp.Location = new System.Drawing.Point(380, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkUpdateToSnmp, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkUpdateToSnmp, "");
            this.m_lnkUpdateToSnmp.Name = "m_lnkUpdateToSnmp";
            this.m_lnkUpdateToSnmp.Size = new System.Drawing.Size(138, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkUpdateToSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkUpdateToSnmp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkUpdateToSnmp.TabIndex = 5;
            this.m_lnkUpdateToSnmp.TabStop = true;
            this.m_lnkUpdateToSnmp.Text = "Update now|20340";
            this.m_lnkUpdateToSnmp.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkUpdateToSnmp.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkUpdateToSnmp_LinkClicked);
            // 
            // m_lnkPollingSetup
            // 
            this.m_lnkPollingSetup.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkPollingSetup, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkPollingSetup, false);
            this.m_lnkPollingSetup.Location = new System.Drawing.Point(394, 111);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkPollingSetup, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkPollingSetup, "");
            this.m_lnkPollingSetup.Name = "m_lnkPollingSetup";
            this.m_lnkPollingSetup.Size = new System.Drawing.Size(109, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkPollingSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkPollingSetup, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkPollingSetup.TabIndex = 7;
            this.m_lnkPollingSetup.TabStop = true;
            this.m_lnkPollingSetup.Text = "Polling setup|20851";
            this.m_lnkPollingSetup.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkPollingSetup.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkPollingSetup_LinkClicked);
            // 
            // m_lblLastUpdateFromSNMP
            // 
            this.m_lblLastUpdateFromSNMP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_lblLastUpdateFromSNMP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_extLinkField.SetLinkField(this.m_lblLastUpdateFromSNMP, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblLastUpdateFromSNMP, false);
            this.m_lblLastUpdateFromSNMP.Location = new System.Drawing.Point(228, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblLastUpdateFromSNMP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblLastUpdateFromSNMP, "");
            this.m_lblLastUpdateFromSNMP.Name = "m_lblLastUpdateFromSNMP";
            this.m_lblLastUpdateFromSNMP.Size = new System.Drawing.Size(149, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblLastUpdateFromSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLastUpdateFromSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLastUpdateFromSNMP.TabIndex = 4;
            // 
            // m_lnkUpdateFromSNMP
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkUpdateFromSNMP, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkUpdateFromSNMP, false);
            this.m_lnkUpdateFromSNMP.Location = new System.Drawing.Point(394, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkUpdateFromSNMP, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkUpdateFromSNMP, "");
            this.m_lnkUpdateFromSNMP.Name = "m_lnkUpdateFromSNMP";
            this.m_lnkUpdateFromSNMP.Size = new System.Drawing.Size(138, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lnkUpdateFromSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkUpdateFromSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkUpdateFromSNMP.TabIndex = 2;
            this.m_lnkUpdateFromSNMP.TabStop = true;
            this.m_lnkUpdateFromSNMP.Text = "Update now|20340";
            this.m_lnkUpdateFromSNMP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkUpdateFromSNMP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkUpdateFromSNMP_LinkClicked);
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(18, 23);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(308, 20);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 0;
            this.label8.Text = "Last update from physical agent|20338";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbServiceMediation
            // 
            this.m_cmbServiceMediation.ComportementLinkStd = true;
            this.m_cmbServiceMediation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbServiceMediation.ElementSelectionne = null;
            this.m_cmbServiceMediation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbServiceMediation.FormattingEnabled = true;
            this.m_cmbServiceMediation.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbServiceMediation, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbServiceMediation, false);
            this.m_cmbServiceMediation.LinkProperty = "";
            this.m_cmbServiceMediation.ListDonnees = null;
            this.m_cmbServiceMediation.Location = new System.Drawing.Point(446, 65);
            this.m_cmbServiceMediation.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbServiceMediation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbServiceMediation, "");
            this.m_cmbServiceMediation.Name = "m_cmbServiceMediation";
            this.m_cmbServiceMediation.NullAutorise = true;
            this.m_cmbServiceMediation.ProprieteAffichee = null;
            this.m_cmbServiceMediation.ProprieteParentListeObjets = null;
            this.m_cmbServiceMediation.SelectionneurParent = null;
            this.m_cmbServiceMediation.Size = new System.Drawing.Size(195, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbServiceMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbServiceMediation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbServiceMediation.TabIndex = 10;
            this.m_cmbServiceMediation.TextNull = "(none)";
            this.m_cmbServiceMediation.Tri = true;
            this.m_cmbServiceMediation.TypeFormEdition = null;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(347, 67);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(108, 16);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 9;
            this.label7.Text = "Managed by|20329";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_cmbVersion
            // 
            this.m_cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbVersion.FormattingEnabled = true;
            this.m_cmbVersion.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbVersion, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_cmbVersion, false);
            this.m_cmbVersion.Location = new System.Drawing.Point(446, 33);
            this.m_cmbVersion.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbVersion, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_cmbVersion, "");
            this.m_cmbVersion.Name = "m_cmbVersion";
            this.m_cmbVersion.Size = new System.Drawing.Size(195, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbVersion.TabIndex = 6;
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(347, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(127, 16);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 5;
            this.label5.Text = "Snmp version|20308";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // c2iTextBoxNumerique1
            // 
            this.c2iTextBoxNumerique1.Arrondi = 0;
            this.c2iTextBoxNumerique1.DecimalAutorise = false;
            this.c2iTextBoxNumerique1.EmptyText = "";
            this.c2iTextBoxNumerique1.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.c2iTextBoxNumerique1, "SnmpPort");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBoxNumerique1, true);
            this.c2iTextBoxNumerique1.Location = new System.Drawing.Point(446, 3);
            this.c2iTextBoxNumerique1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBoxNumerique1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBoxNumerique1, "");
            this.c2iTextBoxNumerique1.Name = "c2iTextBoxNumerique1";
            this.c2iTextBoxNumerique1.NullAutorise = false;
            this.c2iTextBoxNumerique1.SelectAllOnEnter = true;
            this.c2iTextBoxNumerique1.SeparateurMilliers = "";
            this.c2iTextBoxNumerique1.Size = new System.Drawing.Size(52, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBoxNumerique1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBoxNumerique1.TabIndex = 4;
            // 
            // c2iTextBox1
            // 
            this.c2iTextBox1.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "SnmpCommunaute");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iTextBox1, true);
            this.c2iTextBox1.Location = new System.Drawing.Point(139, 32);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.c2iTextBox1, "");
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(162, 23);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 3;
            this.c2iTextBox1.Text = "[SnmpCommunaute]";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(16, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 16);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 2;
            this.label3.Text = "Comunity|20306";
            // 
            // m_txtAdresseIp
            // 
            this.m_txtAdresseIp.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtAdresseIp, "SnmpIp");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtAdresseIp, true);
            this.m_txtAdresseIp.Location = new System.Drawing.Point(139, 3);
            this.m_txtAdresseIp.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtAdresseIp, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtAdresseIp, "");
            this.m_txtAdresseIp.Name = "m_txtAdresseIp";
            this.m_txtAdresseIp.Size = new System.Drawing.Size(162, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtAdresseIp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAdresseIp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAdresseIp.TabIndex = 1;
            this.m_txtAdresseIp.Text = "[SnmpIp]";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(347, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 16);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 0;
            this.label4.Text = "Port (161)|20307";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(16, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 16);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "IP address|20305";
            // 
            // m_menuPolling
            // 
            this.m_extLinkField.SetLinkField(this.m_menuPolling, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_menuPolling, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_menuPolling, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_menuPolling, "");
            this.m_menuPolling.Name = "m_menuPolling";
            this.m_menuPolling.Size = new System.Drawing.Size(61, 4);
            this.m_extStyle.SetStyleBackColor(this.m_menuPolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_menuPolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_lnkBigDataPolling
            // 
            this.m_lnkBigDataPolling.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkBigDataPolling, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkBigDataPolling, false);
            this.m_lnkBigDataPolling.Location = new System.Drawing.Point(394, 126);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkBigDataPolling, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkBigDataPolling, "");
            this.m_lnkBigDataPolling.Name = "m_lnkBigDataPolling";
            this.m_lnkBigDataPolling.Size = new System.Drawing.Size(155, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkBigDataPolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkBigDataPolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkBigDataPolling.TabIndex = 16;
            this.m_lnkBigDataPolling.TabStop = true;
            this.m_lnkBigDataPolling.Text = "Big data polling setup|20886";
            this.m_lnkBigDataPolling.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkBigDataPolling.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkBigDataPolling_LinkClicked);
            // 
            // CFormEditionAgentSnmp
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 490);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.m_tabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionAgentSnmp";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
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
            this.m_pageSnmp.ResumeLayout(false);
            this.m_pageSnmp.PerformLayout();
            this.m_grpUpdateSNMP.ResumeLayout(false);
            this.m_grpUpdateSNMP.PerformLayout();
            this.m_panelUpdateToSNMP.ResumeLayout(false);
            this.m_panelUpdateToSNMP.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        //-------------------------------------------------------------------------
        private CAgentSnmp AgentSnmp
        {
            get
            {
                return (CAgentSnmp)ObjetEdite;
            }
        }
        //-------------------------------------------------------------------------
        protected override CResultAErreur MyInitChamps()
        {
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Agent snmp @1|20303", AgentSnmp.Libelle));

            m_grpUpdateSNMP.Visible = !AgentSnmp.IsNew();

            m_cmbVersion.BeginUpdate();
            foreach (VersionCode code in Enum.GetValues(typeof(VersionCode)))
                m_cmbVersion.Items.Add(code);
            m_cmbVersion.EndUpdate();
            m_cmbVersion.SelectedItem = AgentSnmp.SnmpVersion;

            m_cmbTypeAgent.Init(typeof(CTypeAgentSnmp), "Libelle", false);
            m_cmbTypeAgent.ElementSelectionne = AgentSnmp.TypeAgent;

            CListeObjetsDonnees lst = new CListeObjetsDonnees ( 
                AgentSnmp.ContexteDonnee, typeof(CSnmpProxyInDb));
            m_cmbServiceMediation.Init(lst, "Libelle", typeof(CFormEditionProxySnmp), false);
            m_cmbServiceMediation.ElementSelectionne = AgentSnmp.ProxyDeMediationSnmp;

            StringBuilder bl = new StringBuilder();
            foreach (string strIp in AgentSnmp.TrapsIps)
            {
                bl.Append(strIp);
                bl.Append(',');
            }
            if (bl.Length > 0)
                bl.Remove(bl.Length - 1, 1);
            m_txtMoreIp.Text = bl.ToString();


            InitEntites();

            UpdateDatesSNMP();

            return result;
        }

        //-------------------------------------------------------------------------
        private void UpdateDatesSNMP()
        {
            if (AgentSnmp.LastUpdateDateFromSNMP != null)
                m_lblLastUpdateFromSNMP.Text = AgentSnmp.LastUpdateDateFromSNMP.DateTimeValue.ToShortDateString() + " " +
                    AgentSnmp.LastUpdateDateFromSNMP.DateTimeValue.ToShortTimeString();
            else
                m_lblLastUpdateFromSNMP.Text = "-";
            if (AgentSnmp.LastUpdateDateToSNMP != null)
                m_lblLastUpdateToSnmp.Text = AgentSnmp.LastUpdateDateToSNMP.DateTimeValue.ToShortDateString() + " " +
                    AgentSnmp.LastUpdateDateToSNMP.DateTimeValue.ToShortTimeString();
            else
                m_lblLastUpdateToSnmp.Text = "-";
        }

        //-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            VersionCode? version = m_cmbVersion.SelectedItem as VersionCode?;
            if (version != null)
                AgentSnmp.SnmpVersion = version.Value;
            AgentSnmp.TypeAgent = m_cmbTypeAgent.ElementSelectionne as CTypeAgentSnmp;
            foreach (object obj in m_tabControl.TabPages)
            {
                CTabPageEntiteSnmp page = obj as CTabPageEntiteSnmp;
                if (page != null)
                {
                    result = page.MajChamps();
                    if (!result)
                        return result;
                }
            }
            string[] strIps = m_txtMoreIp.Text.Split(',');
            List<string> lstIps = new List<string>();
            foreach ( string strIp in strIps )
            {
                if (strIp.Trim().Length > 0)
                {
                    /*if (!IP.IsValidIP(strIp.Trim()))
                    {
                        result.EmpileErreur(I.T("Bad IP @1|20481", strIp.Trim()));
                    }
                    else*/
                        lstIps.Add(strIp.Trim());
                }
            }
            if ( result )
                AgentSnmp.TrapsIps = lstIps.ToArray();
        
            AgentSnmp.ProxyDeMediationSnmp = m_cmbServiceMediation.ElementSelectionne as CSnmpProxyInDb;

            return result;
        }

        //-------------------------------------------------------------
        private void m_btnTest_Click(object sender, EventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            CAgentSnmp agent = AgentSnmp;
            agent.BeginEdit();
            try
            {
                result = agent.InitEntitesFromSnmpInContexteCourant();
                if (!result)
                    MessageBox.Show(result.Erreur.ToString());
                else
                    InitChamps();
            }
            catch (Exception ex )
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                if (result)
                    result = agent.CommitEdit();
                else
                    agent.CancelEdit();
            }
        }

        //-------------------------------------------------------------
        private void InitEntites()
        {
            List<CTabPageEntiteSnmp> reserve = new List<CTabPageEntiteSnmp>();

            //Suppression des onglet
            foreach (Crownwood.Magic.Controls.TabPage page in m_tabControl.TabPages)
            {
                CTabPageEntiteSnmp tabPage = page as CTabPageEntiteSnmp;
                if (tabPage != null)
                    reserve.Add(tabPage);
            }

            if (AgentSnmp.TypeAgent != null)
            {
                foreach (CTypeEntiteSnmp typeEntite in AgentSnmp.TypeAgent.TypesEntitesRacine)
                {
                    if (typeEntite.ModeFormulaire.Code != EModeFormulairePourTypeEntite.AucunFormulaire)
                    {
                        CTabPageEntiteSnmp tab = null;
                        if (reserve.Count == 0)
                        {
                            tab = new CTabPageEntiteSnmp();
                            m_tabControl.TabPages.Add(tab);
                        }
                        else
                        {
                            tab = reserve[0];
                            reserve.RemoveAt(0);
                        }
                        tab.LockEdition = !m_gestionnaireModeEdition.ModeEdition;
                        tab.InitChamps(AgentSnmp, typeEntite);
                    }
                }
            }
            foreach (CTabPageEntiteSnmp tabPage in reserve)
            {
                m_tabControl.TabPages.Remove(tabPage);
                tabPage.Dispose();
            }
        }

        private void m_btSetSnmp_Click(object sender, EventArgs e)
        {
            CResultAErreur result = MAJ_Champs();
            if (!result)
            {
                CFormAfficheErreur.Show(result.Erreur);
                return;
            }
            foreach (CEntiteSnmp entite in AgentSnmp.EntitesSnmp)
            {
                result = entite.SendToSnmp(true);
                if (!result)
                {
                    CFormAfficheErreur.Show(result.Erreur);
                    return;
                }
            }
        }

        private void m_pageSnmp_PropertyChanged(Crownwood.Magic.Controls.TabPage page, Crownwood.Magic.Controls.TabPage.Property prop, object oldValue)
        {

        }

        private void m_lnkUpdateFromSNMP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            CAgentSnmp agent = AgentSnmp;
            if (MessageBox.Show(I.T("Warning, this operation will update all agent data from physical agent. Are you sure ?|20342"),"",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            try
            {
                using (CWaitCursor waiter = new CWaitCursor())
                {
                    result = agent.InitEntitesFromSnmpInContexteCourant();
                }
                if (!result)
                    CFormAlerte.Afficher(result.Erreur);
                else
                    InitChamps();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                
            }
        }

        private void m_lnkUpdateToSnmp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CResultAErreur result = CResultAErreur.True;
            using (CWaitCursor waiter = new CWaitCursor())
            {
                result = AgentSnmp.UpdateToSnmpInCurrentContext(false);
            }
            UpdateDatesSNMP();
            if (!result)
                CFormAlerte.Afficher(result.Erreur);
        }

        private void m_cmbTypeAgent_OnSelectedObjectChanged(object sender, EventArgs e)
        {
            CTypeAgentSnmp typeAgent = m_cmbTypeAgent.ElementSelectionne as CTypeAgentSnmp;
            m_panelUpdateToSNMP.Visible = typeAgent != null && !typeAgent.ReadOnly;
        }

        

        //--------------------------------------------------------------------------------------------------
        private void m_lnkPollingSetup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillPollingSetupMenu();
            if ( m_menuPolling.Items.Count > 0 )
                m_menuPolling.Show(m_lnkPollingSetup, new Point(0, m_lnkPollingSetup.Height));
        }

        private void m_lnkBigDataPolling_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FillHotelPollingSetupMenu();
            if (m_menuPolling.Items.Count > 0)
                m_menuPolling.Show(m_lnkBigDataPolling, new Point(0, m_lnkBigDataPolling.Height));

        }

        //--------------------------------------------------------------------------------------------------
        private void FillPollingSetupMenu()
        {
            foreach (ToolStripItem tmp in new ArrayList(m_menuPolling.Items))
                tmp.Dispose();
            m_menuPolling.Items.Clear();

            ToolStripMenuItem item = null;
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                item = new ToolStripMenuItem(I.T("<New setup>|20852"));
                item.Click += new EventHandler(NouveauPolling_Click);
                m_menuPolling.Items.Add(item);
                m_menuPolling.Items.Add(new ToolStripSeparator());
            }

            

            foreach (CSnmpPollingSetup setup in AgentSnmp.ParametresPolling)
            {
                ToolStripMenuItem itemSetup = new ToolStripMenuItem(setup.Libelle);
                m_menuPolling.Items.Add(itemSetup);
                if (m_gestionnaireModeEdition.ModeEdition)
                {
                    item = new ToolStripMenuItem(I.T("Edit|20853"));
                    item.Tag = setup;
                    itemSetup.DropDownItems.Add(item);
                    item.Click += new EventHandler(itemEditPolling_Click);

                    item = new ToolStripMenuItem(I.T("Delete|20854"));
                    item.Tag = setup;
                    itemSetup.DropDownItems.Add(item);
                    item.Click += new EventHandler(itemDeletePolling_Click);
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        private void FillHotelPollingSetupMenu()
        {
            foreach (ToolStripItem tmp in new ArrayList(m_menuPolling.Items))
                tmp.Dispose();
            m_menuPolling.Items.Clear();

            ToolStripMenuItem item = null;
            if (m_gestionnaireModeEdition.ModeEdition)
            {
                item = new ToolStripMenuItem(I.T("<New setup>|20852"));
                item.Click += new EventHandler(NouveauHotelPolling_Click);
                m_menuPolling.Items.Add(item);
                m_menuPolling.Items.Add(new ToolStripSeparator());
            }



            foreach (CSnmpHotelPollingSetup setup in AgentSnmp.ParametresHotelPolling)
            {
                ToolStripMenuItem itemSetup = new ToolStripMenuItem(setup.Libelle);
                m_menuPolling.Items.Add(itemSetup);
                if (m_gestionnaireModeEdition.ModeEdition)
                {
                    item = new ToolStripMenuItem(I.T("Edit|20853"));
                    item.Tag = setup;
                    itemSetup.DropDownItems.Add(item);
                    item.Click += new EventHandler(itemEditPolling_Click);

                    item = new ToolStripMenuItem(I.T("Delete|20854"));
                    item.Tag = setup;
                    itemSetup.DropDownItems.Add(item);
                    item.Click += new EventHandler(itemDeletePolling_Click);
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        void itemEditPolling_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CSnmpPollingSetup setup = item != null ? item.Tag as CSnmpPollingSetup : null;
            if (setup != null)
            {
                EditePollingSetup(setup);
            }
            else
            {
                CSnmpHotelPollingSetup hsetup = item != null ? item.Tag as CSnmpHotelPollingSetup : null;
                if (hsetup != null)
                    EditeHotelPollingSetup(hsetup);
            }
        }


        //--------------------------------------------------------------------------------------------------
        private bool EditePollingSetup(CSnmpPollingSetup setup)
        {
            using (CMemoryDb db = new CMemoryDb())
            {
                if (setup != null)
                {
                    CAgentSnmpPourSupervision agent = AgentSnmp.GetAgentPourSupervision(db, false);
                    CListeObjetDonneeGenerique<CTypeDonneeCumulee> lstTypes = new CListeObjetDonneeGenerique<CTypeDonneeCumulee>(AgentSnmp.ContexteDonnee);
                    if (CFormEditePollingSetup.EditeSetup(
                        setup,
                        agent,
                        lstTypes.ToArray<ITypeDonneeCumulee>()))
                    {
                        AgentSnmp.CommitParametresPolling();
                        return true;
                    }
                    else
                    {
                        AgentSnmp.RollbackParametrePolling();
                        return false;
                    }
                }
            }
            return false;
        }

        //--------------------------------------------------------------------------------------------------
        private bool EditeHotelPollingSetup(CSnmpHotelPollingSetup setup)
        {
            using (CMemoryDb db = new CMemoryDb())
            {
                if (setup != null)
                {
                    CAgentSnmpPourSupervision agent = AgentSnmp.GetAgentPourSupervision(db, false);
                    if (CFormEditeHotelPollingSetup.EditeSetup(
                        setup,
                        agent))
                    {
                        AgentSnmp.CommitParametresHotelPolling();
                        return true;
                    }
                    else
                    {
                        AgentSnmp.RollbackParametreHotelPolling();
                        return false;
                    }
                }
            }
            return false;
        }

        //--------------------------------------------------------------------------------------------------
        void itemDeletePolling_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = sender as ToolStripMenuItem;
            CSnmpPollingSetup setup = item != null ? item.Tag as CSnmpPollingSetup : null;
            if (setup != null)
            {
                if (CFormAlerte.Afficher(I.T("Delete polling '@1' ?|20855"),
                    EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                {
                    AgentSnmp.ParametresPollingList.Remove(setup);
                    AgentSnmp.CommitParametresPolling();
                }
            }
            else
            {
                CSnmpHotelPollingSetup hsetup = item != null ? item.Tag as CSnmpHotelPollingSetup : null;
                if (hsetup != null)
                {
                    if (CFormAlerte.Afficher(I.T("Delete polling '@1' ?|20855", hsetup.Libelle),
                   EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                    {
                        AgentSnmp.ParametresHotelPollingList.Remove(hsetup);
                        AgentSnmp.CommitParametresHotelPolling();
                    }
                }
            }
        }

        //--------------------------------------------------------------------------------------------------
        void NouveauPolling_Click(object sender, EventArgs e)
        {
            CMemoryDb db = new CMemoryDb();
            CSnmpPollingSetup setup = new CSnmpPollingSetup(db);
            setup.CreateNew();
            AgentSnmp.ParametresPollingList.Add(setup);
            if (!EditePollingSetup(setup))
                AgentSnmp.RollbackParametrePolling();
            
        }

        //--------------------------------------------------------------------------------------------------
        void NouveauHotelPolling_Click(object sender, EventArgs e)
        {
            CMemoryDb db = new CMemoryDb();
            CSnmpHotelPollingSetup setup = new CSnmpHotelPollingSetup(db);
            setup.CreateNew();
            AgentSnmp.ParametresHotelPollingList.Add(setup);
            if (!EditeHotelPollingSetup(setup))
                AgentSnmp.RollbackParametrePolling();

        }

       



    }
}

