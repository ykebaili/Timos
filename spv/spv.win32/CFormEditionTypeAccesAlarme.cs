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
using spv.data;
using System.Collections.Generic;
using timos.data;


namespace spv.win32
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSpvTypeAccesAlarme))]
	public class CFormEditionTypeAccesAlarme: CFormEditionStandard, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
		private Label label2;
        protected CComboboxAutoFilled m_cmbTypeAcces;
        private Label label9;
        private System.ComponentModel.IContainer components = null;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private Panel panel1;
        private Panel m_panelPourPasTrap;
        private C2iTextBox m_txtNature;
        private C2iTextBoxNumerique m_txtConnectionsNB;
        private C2iTextBox m_txtNatureCxion;
        private Label label5;
        private Label label4;
        private Label label3;
        private C2iTabControl m_TabControl;
        private Crownwood.Magic.Controls.TabPage m_pageAlarmeGeree;
        private C2iPanel m_formAlarmeGeree;
        private Label label25;
        private RichTextBox m_txtComments;
        private Label label24;
        protected CComboboxAutoFilled m_cmbEventType;
        private GroupBox groupBox2;
        private CheckBox m_chkActiveSon;
        private Label label23;
        protected CComboboxAutoFilled m_cmbTypeSon;
        protected CComboboxAutoFilled m_cmbSeverity;
        private LinkLabel m_lnkGererCauses;
        private CPanelListeRelationSelection m_panelSelectCauses;
        private GroupBox groupBox1;
        private Label label21;
        private C2iTextBox m_txtOID;
        private CheckBox m_chkAutoMib;
        private Label label20;
        private C2iTextBox m_txtTopLevel;
        private Label label19;
        private C2iTextBox m_txtBottomLevel;
        private Label label18;
        private C2iTextBox m_txtSeuilNom;
        private CheckBox m_chkAcquitter;
        private CheckBox m_chkAlarmLocal;
        private CheckBox m_chkDisplay;
        private CheckBox m_chkSurveiller;
        private Label label17;
        private Label label16;
        private RichTextBox m_txtActions;
        private C2iTextBox m_txtPerSec;
        private Label label15;
        private Label label13;
        private Label label14;
        private Label label10;
        protected CComboboxAutoFilled m_cmbProtocol;
        private Label label11;
        private C2iTextBox m_AlarmNb;
        private Label label12;
        private C2iTextBox m_txtConfirmLength;
        private Panel m_panelPourTrap;
        private Label label8;
        private C2iTextBoxNumerique m_txtTrapSpecifique;
        private C2iTextBoxNumerique m_txtTrapGenerique;
        private Label label7;
        private C2iTextBoxNumerique m_txtIANA;
        private Label label6;
        private LinkLabel m_labelObjetLie;
        private ListViewAutoFilledColumn listViewAutoFilledColumn2;
        private Label label22;

        public CFormEditionTypeAccesAlarme()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeAccesAlarme(CSpvTypeAccesAlarme acces)
			:base(acces)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeAccesAlarme(CSpvTypeAccesAlarme acces, CListeObjetsDonnees liste)
			: base(acces, liste)
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbTypeAcces = new sc2i.win32.common.CComboboxAutoFilled();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelPourTrap = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.m_txtTrapSpecifique = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtTrapGenerique = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label7 = new System.Windows.Forms.Label();
            this.m_txtIANA = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label6 = new System.Windows.Forms.Label();
            this.m_panelPourPasTrap = new System.Windows.Forms.Panel();
            this.m_txtNature = new sc2i.win32.common.C2iTextBox();
            this.m_txtConnectionsNB = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_txtNatureCxion = new sc2i.win32.common.C2iTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_labelObjetLie = new System.Windows.Forms.LinkLabel();
            this.label22 = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_TabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageAlarmeGeree = new Crownwood.Magic.Controls.TabPage();
            this.m_formAlarmeGeree = new sc2i.win32.common.C2iPanel(this.components);
            this.label25 = new System.Windows.Forms.Label();
            this.m_txtComments = new System.Windows.Forms.RichTextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.m_cmbEventType = new sc2i.win32.common.CComboboxAutoFilled();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.m_chkActiveSon = new System.Windows.Forms.CheckBox();
            this.label23 = new System.Windows.Forms.Label();
            this.m_cmbTypeSon = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_cmbSeverity = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_lnkGererCauses = new System.Windows.Forms.LinkLabel();
            this.m_panelSelectCauses = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.m_txtOID = new sc2i.win32.common.C2iTextBox();
            this.m_chkAutoMib = new System.Windows.Forms.CheckBox();
            this.label20 = new System.Windows.Forms.Label();
            this.m_txtTopLevel = new sc2i.win32.common.C2iTextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.m_txtBottomLevel = new sc2i.win32.common.C2iTextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.m_txtSeuilNom = new sc2i.win32.common.C2iTextBox();
            this.m_chkAcquitter = new System.Windows.Forms.CheckBox();
            this.m_chkAlarmLocal = new System.Windows.Forms.CheckBox();
            this.m_chkDisplay = new System.Windows.Forms.CheckBox();
            this.m_chkSurveiller = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.m_txtActions = new System.Windows.Forms.RichTextBox();
            this.m_txtPerSec = new sc2i.win32.common.C2iTextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.m_cmbProtocol = new sc2i.win32.common.CComboboxAutoFilled();
            this.label11 = new System.Windows.Forms.Label();
            this.m_AlarmNb = new sc2i.win32.common.C2iTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.m_txtConfirmLength = new sc2i.win32.common.C2iTextBox();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_panelPourTrap.SuspendLayout();
            this.m_panelPourPasTrap.SuspendLayout();
            this.m_TabControl.SuspendLayout();
            this.m_pageAlarmeGeree.SuspendLayout();
            this.m_formAlarmeGeree.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnulerModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnAnnulerModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnulerModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnulerModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnValiderModifications
            // 
            this.m_extLinkField.SetLinkField(this.m_btnValiderModifications, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnValiderModifications, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValiderModifications, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnSupprimerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnSupprimerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnSupprimerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSupprimerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_btnEditerObjet
            // 
            this.m_extLinkField.SetLinkField(this.m_btnEditerObjet, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnEditerObjet, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extStyle.SetStyleBackColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnEditerObjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelNavigation
            // 
            this.m_panelNavigation.Location = new System.Drawing.Point(758, 0);
            this.m_panelNavigation.Size = new System.Drawing.Size(153, 34);
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
            this.m_panelCle.Location = new System.Drawing.Point(671, 0);
            this.m_panelCle.Size = new System.Drawing.Size(87, 34);
            this.m_extStyle.SetStyleBackColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelCle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.Dock = System.Windows.Forms.DockStyle.None;
            this.m_panelMenu.Size = new System.Drawing.Size(911, 34);
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
            this.label1.Location = new System.Drawing.Point(10, 12);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4002;
            this.label1.Text = "Label|3";
            // 
            // m_txtLibelle
            // 
            this.m_extLinkField.SetLinkField(this.m_txtLibelle, "NomAcces");
            this.m_txtLibelle.Location = new System.Drawing.Point(132, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[NomAcces]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.m_cmbTypeAcces);
            this.c2iPanelOmbre4.Controls.Add(this.label9);
            this.c2iPanelOmbre4.Controls.Add(this.panel1);
            this.c2iPanelOmbre4.Controls.Add(this.label2);
            this.c2iPanelOmbre4.Controls.Add(this.m_labelObjetLie);
            this.c2iPanelOmbre4.Controls.Add(this.label22);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 56);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(899, 188);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // label9
            // 
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.label9.Location = new System.Drawing.Point(10, 11);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 23);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 4006;
            this.label9.Text = "Label|3";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(10, 37);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4003;
            this.label2.Text = "Acces type|4";
            // 
            // m_cmbTypeAcces
            // 
            this.m_cmbTypeAcces.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeAcces.FormattingEnabled = true;
            this.m_cmbTypeAcces.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeAcces, "");
            this.m_cmbTypeAcces.ListDonnees = null;
            this.m_cmbTypeAcces.Location = new System.Drawing.Point(132, 34);
            this.m_cmbTypeAcces.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeAcces, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypeAcces.Name = "m_cmbTypeAcces";
            this.m_cmbTypeAcces.NullAutorise = false;
            this.m_cmbTypeAcces.ProprieteAffichee = null;
            this.m_cmbTypeAcces.Size = new System.Drawing.Size(280, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeAcces.TabIndex = 4004;
            this.m_cmbTypeAcces.TextNull = "(vide)";
            this.m_cmbTypeAcces.Tri = true;
            this.m_cmbTypeAcces.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypeAcces_SelectionChangeCommitted);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_panelPourTrap);
            this.panel1.Controls.Add(this.m_panelPourPasTrap);
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(5, 63);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(596, 96);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 4005;
            // 
            // m_panelPourTrap
            // 
            this.m_panelPourTrap.Controls.Add(this.label8);
            this.m_panelPourTrap.Controls.Add(this.m_txtTrapSpecifique);
            this.m_panelPourTrap.Controls.Add(this.m_txtTrapGenerique);
            this.m_panelPourTrap.Controls.Add(this.label7);
            this.m_panelPourTrap.Controls.Add(this.m_txtIANA);
            this.m_panelPourTrap.Controls.Add(this.label6);
            this.m_panelPourTrap.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelPourTrap, "");
            this.m_panelPourTrap.Location = new System.Drawing.Point(389, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPourTrap, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPourTrap.Name = "m_panelPourTrap";
            this.m_panelPourTrap.Size = new System.Drawing.Size(196, 96);
            this.m_extStyle.SetStyleBackColor(this.m_panelPourTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPourTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPourTrap.TabIndex = 1;
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 4009;
            this.label8.Text = "Specific Trap|30002";
            // 
            // m_txtTrapSpecifique
            // 
            this.m_txtTrapSpecifique.Arrondi = 0;
            this.m_txtTrapSpecifique.DecimalAutorise = false;
            this.m_txtTrapSpecifique.DoubleValue = null;
            this.m_txtTrapSpecifique.IntValue = null;
            this.m_extLinkField.SetLinkField(this.m_txtTrapSpecifique, "");
            this.m_txtTrapSpecifique.Location = new System.Drawing.Point(128, 54);
            this.m_txtTrapSpecifique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTrapSpecifique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtTrapSpecifique.Name = "m_txtTrapSpecifique";
            this.m_txtTrapSpecifique.NullAutorise = true;
            this.m_txtTrapSpecifique.SelectAllOnEnter = true;
            this.m_txtTrapSpecifique.Size = new System.Drawing.Size(52, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtTrapSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTrapSpecifique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTrapSpecifique.TabIndex = 4010;
            // 
            // m_txtTrapGenerique
            // 
            this.m_txtTrapGenerique.Arrondi = 0;
            this.m_txtTrapGenerique.DecimalAutorise = false;
            this.m_txtTrapGenerique.DoubleValue = null;
            this.m_txtTrapGenerique.IntValue = null;
            this.m_extLinkField.SetLinkField(this.m_txtTrapGenerique, "");
            this.m_txtTrapGenerique.Location = new System.Drawing.Point(128, 30);
            this.m_txtTrapGenerique.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTrapGenerique, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtTrapGenerique.Name = "m_txtTrapGenerique";
            this.m_txtTrapGenerique.NullAutorise = true;
            this.m_txtTrapGenerique.SelectAllOnEnter = true;
            this.m_txtTrapGenerique.Size = new System.Drawing.Size(52, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtTrapGenerique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTrapGenerique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTrapGenerique.TabIndex = 4008;
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.label7.Location = new System.Drawing.Point(6, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4007;
            this.label7.Text = "Generic trap|30001";
            // 
            // m_txtIANA
            // 
            this.m_txtIANA.Arrondi = 0;
            this.m_txtIANA.DecimalAutorise = false;
            this.m_txtIANA.DoubleValue = null;
            this.m_txtIANA.IntValue = null;
            this.m_extLinkField.SetLinkField(this.m_txtIANA, "");
            this.m_txtIANA.Location = new System.Drawing.Point(128, 6);
            this.m_txtIANA.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtIANA, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtIANA.Name = "m_txtIANA";
            this.m_txtIANA.NullAutorise = true;
            this.m_txtIANA.SelectAllOnEnter = true;
            this.m_txtIANA.Size = new System.Drawing.Size(52, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtIANA, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtIANA, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIANA.TabIndex = 4006;
            // 
            // label6
            // 
            this.m_extLinkField.SetLinkField(this.label6, "");
            this.label6.Location = new System.Drawing.Point(6, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label6, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 4005;
            this.label6.Text = "Iana No.|30003";
            // 
            // m_panelPourPasTrap
            // 
            this.m_panelPourPasTrap.Controls.Add(this.m_txtNature);
            this.m_panelPourPasTrap.Controls.Add(this.m_txtConnectionsNB);
            this.m_panelPourPasTrap.Controls.Add(this.m_txtNatureCxion);
            this.m_panelPourPasTrap.Controls.Add(this.label5);
            this.m_panelPourPasTrap.Controls.Add(this.label4);
            this.m_panelPourPasTrap.Controls.Add(this.label3);
            this.m_panelPourPasTrap.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_panelPourPasTrap, "");
            this.m_panelPourPasTrap.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelPourPasTrap, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelPourPasTrap.Name = "m_panelPourPasTrap";
            this.m_panelPourPasTrap.Size = new System.Drawing.Size(389, 96);
            this.m_extStyle.SetStyleBackColor(this.m_panelPourPasTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelPourPasTrap, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelPourPasTrap.TabIndex = 0;
            // 
            // m_txtNature
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNature, "Nature");
            this.m_txtNature.Location = new System.Drawing.Point(128, 54);
            this.m_txtNature.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNature, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNature.Name = "m_txtNature";
            this.m_txtNature.Size = new System.Drawing.Size(257, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNature, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNature, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNature.TabIndex = 4008;
            this.m_txtNature.Text = "[Nature]";
            // 
            // m_txtConnectionsNB
            // 
            this.m_txtConnectionsNB.Arrondi = 0;
            this.m_txtConnectionsNB.DecimalAutorise = false;
            this.m_txtConnectionsNB.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_txtConnectionsNB, "ConnectionsNumber");
            this.m_txtConnectionsNB.Location = new System.Drawing.Point(128, 30);
            this.m_txtConnectionsNB.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtConnectionsNB, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtConnectionsNB.Name = "m_txtConnectionsNB";
            this.m_txtConnectionsNB.NullAutorise = false;
            this.m_txtConnectionsNB.SelectAllOnEnter = true;
            this.m_txtConnectionsNB.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtConnectionsNB, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtConnectionsNB, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtConnectionsNB.TabIndex = 4007;
            // 
            // m_txtNatureCxion
            // 
            this.m_extLinkField.SetLinkField(this.m_txtNatureCxion, "NatureAccesConnexion");
            this.m_txtNatureCxion.Location = new System.Drawing.Point(128, 6);
            this.m_txtNatureCxion.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNatureCxion, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNatureCxion.Name = "m_txtNatureCxion";
            this.m_txtNatureCxion.Size = new System.Drawing.Size(257, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNatureCxion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNatureCxion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNatureCxion.TabIndex = 4006;
            this.m_txtNatureCxion.Text = "[NatureAccesConnexion]";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.label5.Location = new System.Drawing.Point(6, 55);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4006;
            this.label5.Text = "Connection type|7";
            // 
            // label4
            // 
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.label4.Location = new System.Drawing.Point(6, 32);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(119, 23);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4005;
            this.label4.Text = "Connections number|6";
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(6, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4004;
            this.label3.Text = "Connector|5";
            // 
            // m_labelObjetLie
            // 
            this.m_labelObjetLie.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_labelObjetLie, "");
            this.m_labelObjetLie.Location = new System.Drawing.Point(560, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_labelObjetLie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_labelObjetLie.Name = "m_labelObjetLie";
            this.m_labelObjetLie.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.m_labelObjetLie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_labelObjetLie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_labelObjetLie.TabIndex = 4007;
            this.m_labelObjetLie.TabStop = true;
            this.m_labelObjetLie.Text = "linkLabel1";
            this.m_labelObjetLie.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label22, "");
            this.label22.Location = new System.Drawing.Point(431, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label22, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(124, 13);
            this.m_extStyle.SetStyleBackColor(this.label22, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label22, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label22.TabIndex = 4008;
            this.label22.Text = "Managed element|30007";
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "AlarmCause";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Alarme cause(s)|135";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 250;
            // 
            // m_TabControl
            // 
            this.m_TabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_TabControl.BoldSelectedPage = true;
            this.m_TabControl.ControlBottomOffset = 16;
            this.m_TabControl.ControlRightOffset = 16;
            this.m_TabControl.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_TabControl, "");
            this.m_TabControl.Location = new System.Drawing.Point(12, 250);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_TabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_TabControl.Name = "m_TabControl";
            this.m_TabControl.Ombre = true;
            this.m_TabControl.PositionTop = true;
            this.m_TabControl.SelectedIndex = 0;
            this.m_TabControl.SelectedTab = this.m_pageAlarmeGeree;
            this.m_TabControl.Size = new System.Drawing.Size(899, 438);
            this.m_extStyle.SetStyleBackColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_TabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_TabControl.TabIndex = 4004;
            this.m_TabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageAlarmeGeree});
            // 
            // m_pageAlarmeGeree
            // 
            this.m_pageAlarmeGeree.Controls.Add(this.m_formAlarmeGeree);
            this.m_extLinkField.SetLinkField(this.m_pageAlarmeGeree, "");
            this.m_pageAlarmeGeree.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageAlarmeGeree, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_pageAlarmeGeree.Name = "m_pageAlarmeGeree";
            this.m_pageAlarmeGeree.Size = new System.Drawing.Size(883, 397);
            this.m_extStyle.SetStyleBackColor(this.m_pageAlarmeGeree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageAlarmeGeree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageAlarmeGeree.TabIndex = 10;
            this.m_pageAlarmeGeree.Title = "Managed alarm|30000";
            // 
            // m_formAlarmeGeree
            // 
            this.m_formAlarmeGeree.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.m_formAlarmeGeree.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_formAlarmeGeree.Controls.Add(this.label25);
            this.m_formAlarmeGeree.Controls.Add(this.m_txtComments);
            this.m_formAlarmeGeree.Controls.Add(this.label24);
            this.m_formAlarmeGeree.Controls.Add(this.m_cmbEventType);
            this.m_formAlarmeGeree.Controls.Add(this.groupBox2);
            this.m_formAlarmeGeree.Controls.Add(this.m_cmbSeverity);
            this.m_formAlarmeGeree.Controls.Add(this.m_lnkGererCauses);
            this.m_formAlarmeGeree.Controls.Add(this.m_panelSelectCauses);
            this.m_formAlarmeGeree.Controls.Add(this.groupBox1);
            this.m_formAlarmeGeree.Controls.Add(this.m_chkAcquitter);
            this.m_formAlarmeGeree.Controls.Add(this.m_chkAlarmLocal);
            this.m_formAlarmeGeree.Controls.Add(this.m_chkDisplay);
            this.m_formAlarmeGeree.Controls.Add(this.m_chkSurveiller);
            this.m_formAlarmeGeree.Controls.Add(this.label17);
            this.m_formAlarmeGeree.Controls.Add(this.label16);
            this.m_formAlarmeGeree.Controls.Add(this.m_txtActions);
            this.m_formAlarmeGeree.Controls.Add(this.m_txtPerSec);
            this.m_formAlarmeGeree.Controls.Add(this.label15);
            this.m_formAlarmeGeree.Controls.Add(this.label13);
            this.m_formAlarmeGeree.Controls.Add(this.label14);
            this.m_formAlarmeGeree.Controls.Add(this.label10);
            this.m_formAlarmeGeree.Controls.Add(this.m_cmbProtocol);
            this.m_formAlarmeGeree.Controls.Add(this.label11);
            this.m_formAlarmeGeree.Controls.Add(this.m_AlarmNb);
            this.m_formAlarmeGeree.Controls.Add(this.label12);
            this.m_formAlarmeGeree.Controls.Add(this.m_txtConfirmLength);
            this.m_formAlarmeGeree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_formAlarmeGeree.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_formAlarmeGeree, "");
            this.m_formAlarmeGeree.Location = new System.Drawing.Point(0, 0);
            this.m_formAlarmeGeree.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_formAlarmeGeree, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_formAlarmeGeree.Name = "m_formAlarmeGeree";
            this.m_formAlarmeGeree.Size = new System.Drawing.Size(883, 397);
            this.m_extStyle.SetStyleBackColor(this.m_formAlarmeGeree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_formAlarmeGeree, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_formAlarmeGeree.TabIndex = 4004;
            // 
            // label25
            // 
            this.m_extLinkField.SetLinkField(this.label25, "");
            this.label25.Location = new System.Drawing.Point(494, 278);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label25, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(130, 13);
            this.m_extStyle.SetStyleBackColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label25, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label25.TabIndex = 4030;
            this.label25.Text = "Comment|132";
            // 
            // m_txtComments
            // 
            this.m_extLinkField.SetLinkField(this.m_txtComments, "");
            this.m_txtComments.Location = new System.Drawing.Point(494, 295);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtComments, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtComments.Name = "m_txtComments";
            this.m_txtComments.Size = new System.Drawing.Size(374, 52);
            this.m_extStyle.SetStyleBackColor(this.m_txtComments, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtComments, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtComments.TabIndex = 4029;
            this.m_txtComments.Text = "";
            // 
            // label24
            // 
            this.m_extLinkField.SetLinkField(this.label24, "");
            this.label24.Location = new System.Drawing.Point(494, 204);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label24, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(130, 14);
            this.m_extStyle.SetStyleBackColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label24.TabIndex = 4028;
            this.label24.Text = "Corrective action|131";
            // 
            // m_cmbEventType
            // 
            this.m_cmbEventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbEventType.FormattingEnabled = true;
            this.m_cmbEventType.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbEventType, "");
            this.m_cmbEventType.ListDonnees = null;
            this.m_cmbEventType.Location = new System.Drawing.Point(186, 9);
            this.m_cmbEventType.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbEventType, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbEventType.Name = "m_cmbEventType";
            this.m_cmbEventType.NullAutorise = false;
            this.m_cmbEventType.ProprieteAffichee = null;
            this.m_cmbEventType.Size = new System.Drawing.Size(230, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbEventType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbEventType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbEventType.TabIndex = 4027;
            this.m_cmbEventType.TextNull = "(empty)";
            this.m_cmbEventType.Tri = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.m_chkActiveSon);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.m_cmbTypeSon);
            this.m_extLinkField.SetLinkField(this.groupBox2, "");
            this.groupBox2.Location = new System.Drawing.Point(494, 144);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 49);
            this.m_extStyle.SetStyleBackColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox2.TabIndex = 4026;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ring|130";
            // 
            // m_chkActiveSon
            // 
            this.m_chkActiveSon.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkActiveSon, "");
            this.m_chkActiveSon.Location = new System.Drawing.Point(256, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkActiveSon, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkActiveSon.Name = "m_chkActiveSon";
            this.m_chkActiveSon.Size = new System.Drawing.Size(94, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkActiveSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkActiveSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkActiveSon.TabIndex = 4024;
            this.m_chkActiveSon.Text = "Activated|115";
            this.m_chkActiveSon.UseVisualStyleBackColor = true;
            // 
            // label23
            // 
            this.m_extLinkField.SetLinkField(this.label23, "");
            this.label23.Location = new System.Drawing.Point(16, 19);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label23, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(69, 23);
            this.m_extStyle.SetStyleBackColor(this.label23, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label23, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label23.TabIndex = 4023;
            this.label23.Text = "Type|129";
            // 
            // m_cmbTypeSon
            // 
            this.m_cmbTypeSon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeSon.FormattingEnabled = true;
            this.m_cmbTypeSon.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbTypeSon, "");
            this.m_cmbTypeSon.ListDonnees = null;
            this.m_cmbTypeSon.Location = new System.Drawing.Point(105, 19);
            this.m_cmbTypeSon.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypeSon, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypeSon.Name = "m_cmbTypeSon";
            this.m_cmbTypeSon.NullAutorise = false;
            this.m_cmbTypeSon.ProprieteAffichee = null;
            this.m_cmbTypeSon.Size = new System.Drawing.Size(70, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeSon, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeSon.TabIndex = 4022;
            this.m_cmbTypeSon.TextNull = "(empty)";
            this.m_cmbTypeSon.Tri = true;
            // 
            // m_cmbSeverity
            // 
            this.m_cmbSeverity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSeverity.FormattingEnabled = true;
            this.m_cmbSeverity.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbSeverity, "");
            this.m_cmbSeverity.ListDonnees = null;
            this.m_cmbSeverity.Location = new System.Drawing.Point(186, 115);
            this.m_cmbSeverity.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbSeverity, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbSeverity.Name = "m_cmbSeverity";
            this.m_cmbSeverity.NullAutorise = false;
            this.m_cmbSeverity.ProprieteAffichee = null;
            this.m_cmbSeverity.Size = new System.Drawing.Size(230, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbSeverity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbSeverity, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbSeverity.TabIndex = 4021;
            this.m_cmbSeverity.TextNull = "(empty)";
            this.m_cmbSeverity.Tri = true;
            // 
            // m_lnkGererCauses
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkGererCauses, "");
            this.m_lnkGererCauses.Location = new System.Drawing.Point(10, 205);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkGererCauses, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkGererCauses.Name = "m_lnkGererCauses";
            this.m_lnkGererCauses.Size = new System.Drawing.Size(90, 46);
            this.m_extStyle.SetStyleBackColor(this.m_lnkGererCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkGererCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkGererCauses.TabIndex = 4032;
            this.m_lnkGererCauses.TabStop = true;
            this.m_lnkGererCauses.Text = "Alarm cause(s)|135";
            this.m_lnkGererCauses.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkGererCauses_LinkClicked_1);
            // 
            // m_panelSelectCauses
            // 
            this.m_panelSelectCauses.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn2});
            this.m_panelSelectCauses.EnableCustomisation = true;
            this.m_panelSelectCauses.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelSelectCauses, "");
            this.m_panelSelectCauses.Location = new System.Drawing.Point(92, 192);
            this.m_panelSelectCauses.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelSelectCauses, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelSelectCauses.Name = "m_panelSelectCauses";
            this.m_panelSelectCauses.Size = new System.Drawing.Size(384, 179);
            this.m_extStyle.SetStyleBackColor(this.m_panelSelectCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSelectCauses, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSelectCauses.TabIndex = 4031;
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.Field = "AlarmCause";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Label";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 120;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label21);
            this.groupBox1.Controls.Add(this.m_txtOID);
            this.groupBox1.Controls.Add(this.m_chkAutoMib);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.m_txtTopLevel);
            this.groupBox1.Controls.Add(this.label19);
            this.groupBox1.Controls.Add(this.m_txtBottomLevel);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.m_txtSeuilNom);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.groupBox1.Location = new System.Drawing.Point(494, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 129);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4022;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Threshold|133";
            // 
            // label21
            // 
            this.m_extLinkField.SetLinkField(this.label21, "");
            this.label21.Location = new System.Drawing.Point(16, 77);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label21, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(69, 23);
            this.m_extStyle.SetStyleBackColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label21, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label21.TabIndex = 4022;
            this.label21.Text = "OID|137";
            // 
            // m_txtOID
            // 
            this.m_extLinkField.SetLinkField(this.m_txtOID, "");
            this.m_txtOID.Location = new System.Drawing.Point(105, 77);
            this.m_txtOID.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtOID, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtOID.Name = "m_txtOID";
            this.m_txtOID.Size = new System.Drawing.Size(242, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtOID.TabIndex = 4021;
            // 
            // m_chkAutoMib
            // 
            this.m_chkAutoMib.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAutoMib, "");
            this.m_chkAutoMib.Location = new System.Drawing.Point(18, 110);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAutoMib, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkAutoMib.Name = "m_chkAutoMib";
            this.m_chkAutoMib.Size = new System.Drawing.Size(117, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAutoMib, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAutoMib, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAutoMib.TabIndex = 4020;
            this.m_chkAutoMib.Text = "Automatic MIB|114";
            this.m_chkAutoMib.UseVisualStyleBackColor = true;
            // 
            // label20
            // 
            this.m_extLinkField.SetLinkField(this.label20, "");
            this.label20.Location = new System.Drawing.Point(196, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label20, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label20, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label20.TabIndex = 4015;
            this.label20.Text = "Top level|124";
            // 
            // m_txtTopLevel
            // 
            this.m_extLinkField.SetLinkField(this.m_txtTopLevel, "");
            this.m_txtTopLevel.Location = new System.Drawing.Point(277, 50);
            this.m_txtTopLevel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtTopLevel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtTopLevel.Name = "m_txtTopLevel";
            this.m_txtTopLevel.Size = new System.Drawing.Size(70, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtTopLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtTopLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTopLevel.TabIndex = 4014;
            // 
            // label19
            // 
            this.m_extLinkField.SetLinkField(this.label19, "");
            this.label19.Location = new System.Drawing.Point(16, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label19, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(88, 23);
            this.m_extStyle.SetStyleBackColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label19, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label19.TabIndex = 4013;
            this.label19.Text = "Bottom level|124";
            // 
            // m_txtBottomLevel
            // 
            this.m_extLinkField.SetLinkField(this.m_txtBottomLevel, "");
            this.m_txtBottomLevel.Location = new System.Drawing.Point(105, 50);
            this.m_txtBottomLevel.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtBottomLevel, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtBottomLevel.Name = "m_txtBottomLevel";
            this.m_txtBottomLevel.Size = new System.Drawing.Size(70, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtBottomLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtBottomLevel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtBottomLevel.TabIndex = 4012;
            // 
            // label18
            // 
            this.m_extLinkField.SetLinkField(this.label18, "");
            this.label18.Location = new System.Drawing.Point(16, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label18, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(69, 23);
            this.m_extStyle.SetStyleBackColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label18, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label18.TabIndex = 4011;
            this.label18.Text = "Name|134";
            // 
            // m_txtSeuilNom
            // 
            this.m_extLinkField.SetLinkField(this.m_txtSeuilNom, "");
            this.m_txtSeuilNom.Location = new System.Drawing.Point(105, 24);
            this.m_txtSeuilNom.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSeuilNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSeuilNom.Name = "m_txtSeuilNom";
            this.m_txtSeuilNom.Size = new System.Drawing.Size(242, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtSeuilNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSeuilNom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSeuilNom.TabIndex = 4010;
            // 
            // m_chkAcquitter
            // 
            this.m_chkAcquitter.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAcquitter, "");
            this.m_chkAcquitter.Location = new System.Drawing.Point(223, 169);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAcquitter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkAcquitter.Name = "m_chkAcquitter";
            this.m_chkAcquitter.Size = new System.Drawing.Size(125, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAcquitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAcquitter.TabIndex = 4018;
            this.m_chkAcquitter.Text = "To acknowledge|113";
            this.m_chkAcquitter.UseVisualStyleBackColor = true;
            // 
            // m_chkAlarmLocal
            // 
            this.m_chkAlarmLocal.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkAlarmLocal, "");
            this.m_chkAlarmLocal.Location = new System.Drawing.Point(360, 169);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAlarmLocal, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkAlarmLocal.Name = "m_chkAlarmLocal";
            this.m_chkAlarmLocal.Size = new System.Drawing.Size(101, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkAlarmLocal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAlarmLocal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAlarmLocal.TabIndex = 4019;
            this.m_chkAlarmLocal.Text = "Local alarm|117";
            this.m_chkAlarmLocal.UseVisualStyleBackColor = true;
            // 
            // m_chkDisplay
            // 
            this.m_chkDisplay.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkDisplay, "");
            this.m_chkDisplay.Location = new System.Drawing.Point(119, 169);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkDisplay, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkDisplay.Name = "m_chkDisplay";
            this.m_chkDisplay.Size = new System.Drawing.Size(96, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDisplay, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDisplay.TabIndex = 4017;
            this.m_chkDisplay.Text = "To display|118";
            this.m_chkDisplay.UseVisualStyleBackColor = true;
            // 
            // m_chkSurveiller
            // 
            this.m_chkSurveiller.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_chkSurveiller, "");
            this.m_chkSurveiller.Location = new System.Drawing.Point(13, 169);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkSurveiller, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkSurveiller.Name = "m_chkSurveiller";
            this.m_chkSurveiller.Size = new System.Drawing.Size(99, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkSurveiller, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkSurveiller, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkSurveiller.TabIndex = 4016;
            this.m_chkSurveiller.Text = "To monitor|116";
            this.m_chkSurveiller.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.m_extLinkField.SetLinkField(this.label17, "");
            this.label17.Location = new System.Drawing.Point(10, 115);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label17, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(130, 23);
            this.m_extStyle.SetStyleBackColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label17, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label17.TabIndex = 4015;
            this.label17.Text = "Severity|123";
            // 
            // label16
            // 
            this.m_extLinkField.SetLinkField(this.label16, "");
            this.label16.Location = new System.Drawing.Point(10, 88);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label16, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(130, 23);
            this.m_extStyle.SetStyleBackColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label16, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label16.TabIndex = 4013;
            this.label16.Text = "Protocol|122";
            // 
            // m_txtActions
            // 
            this.m_extLinkField.SetLinkField(this.m_txtActions, "");
            this.m_txtActions.Location = new System.Drawing.Point(494, 221);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtActions, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtActions.Name = "m_txtActions";
            this.m_txtActions.Size = new System.Drawing.Size(374, 52);
            this.m_extStyle.SetStyleBackColor(this.m_txtActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtActions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtActions.TabIndex = 4023;
            this.m_txtActions.Text = "";
            // 
            // m_txtPerSec
            // 
            this.m_extLinkField.SetLinkField(this.m_txtPerSec, "");
            this.m_txtPerSec.Location = new System.Drawing.Point(303, 62);
            this.m_txtPerSec.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtPerSec, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtPerSec.Name = "m_txtPerSec";
            this.m_txtPerSec.Size = new System.Drawing.Size(70, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtPerSec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPerSec, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPerSec.TabIndex = 4012;
            // 
            // label15
            // 
            this.m_extLinkField.SetLinkField(this.label15, "");
            this.label15.Location = new System.Drawing.Point(260, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label15, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(37, 23);
            this.m_extStyle.SetStyleBackColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label15, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label15.TabIndex = 4011;
            this.label15.Text = "for|127";
            // 
            // label13
            // 
            this.m_extLinkField.SetLinkField(this.label13, "");
            this.label13.Location = new System.Drawing.Point(376, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label13, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 23);
            this.m_extStyle.SetStyleBackColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label13, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label13.TabIndex = 4010;
            this.label13.Text = "sec.|128";
            // 
            // label14
            // 
            this.m_extLinkField.SetLinkField(this.label14, "");
            this.label14.Location = new System.Drawing.Point(10, 62);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label14, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(155, 23);
            this.m_extStyle.SetStyleBackColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label14, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label14.TabIndex = 4009;
            this.label14.Text = "Frequent alarm number|126";
            // 
            // label10
            // 
            this.m_extLinkField.SetLinkField(this.label10, "");
            this.label10.Location = new System.Drawing.Point(10, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label10, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 23);
            this.m_extStyle.SetStyleBackColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label10, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label10.TabIndex = 4006;
            this.label10.Text = "Event type|120";
            // 
            // m_cmbProtocol
            // 
            this.m_cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbProtocol.FormattingEnabled = true;
            this.m_cmbProtocol.IsLink = false;
            this.m_extLinkField.SetLinkField(this.m_cmbProtocol, "");
            this.m_cmbProtocol.ListDonnees = null;
            this.m_cmbProtocol.Location = new System.Drawing.Point(186, 88);
            this.m_cmbProtocol.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbProtocol, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbProtocol.Name = "m_cmbProtocol";
            this.m_cmbProtocol.NullAutorise = false;
            this.m_cmbProtocol.ProprieteAffichee = null;
            this.m_cmbProtocol.Size = new System.Drawing.Size(230, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbProtocol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbProtocol, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbProtocol.TabIndex = 4004;
            this.m_cmbProtocol.TextNull = "(empty)";
            this.m_cmbProtocol.Tri = true;
            // 
            // label11
            // 
            this.m_extLinkField.SetLinkField(this.label11, "");
            this.label11.Location = new System.Drawing.Point(10, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label11, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(152, 23);
            this.m_extStyle.SetStyleBackColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label11, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label11.TabIndex = 4003;
            this.label11.Text = "Confirmation length|121";
            // 
            // m_AlarmNb
            // 
            this.m_extLinkField.SetLinkField(this.m_AlarmNb, "");
            this.m_AlarmNb.Location = new System.Drawing.Point(186, 62);
            this.m_AlarmNb.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_AlarmNb, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_AlarmNb.Name = "m_AlarmNb";
            this.m_AlarmNb.Size = new System.Drawing.Size(70, 21);
            this.m_extStyle.SetStyleBackColor(this.m_AlarmNb, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_AlarmNb, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_AlarmNb.TabIndex = 4008;
            // 
            // label12
            // 
            this.m_extLinkField.SetLinkField(this.label12, "");
            this.label12.Location = new System.Drawing.Point(260, 36);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label12, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 23);
            this.m_extStyle.SetStyleBackColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label12, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label12.TabIndex = 4007;
            this.label12.Text = "sec.|128";
            // 
            // m_txtConfirmLength
            // 
            this.m_extLinkField.SetLinkField(this.m_txtConfirmLength, "");
            this.m_txtConfirmLength.Location = new System.Drawing.Point(186, 36);
            this.m_txtConfirmLength.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtConfirmLength, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtConfirmLength.Name = "m_txtConfirmLength";
            this.m_txtConfirmLength.Size = new System.Drawing.Size(70, 21);
            this.m_extStyle.SetStyleBackColor(this.m_txtConfirmLength, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtConfirmLength, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtConfirmLength.TabIndex = 0;
            // 
            // CFormEditionTypeAccesAlarme
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(913, 743);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.Controls.Add(this.m_TabControl);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditionTypeAccesAlarme";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.AfterPassageEnEdition += new sc2i.data.ObjetDonneeEventHandler(this.CFormEditionTypeAccesAlarme_AfterPassageEnEdition);
            this.Controls.SetChildIndex(this.m_TabControl, 0);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
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
            this.panel1.ResumeLayout(false);
            this.m_panelPourTrap.ResumeLayout(false);
            this.m_panelPourTrap.PerformLayout();
            this.m_panelPourPasTrap.ResumeLayout(false);
            this.m_panelPourPasTrap.PerformLayout();
            this.m_TabControl.ResumeLayout(false);
            this.m_TabControl.PerformLayout();
            this.m_pageAlarmeGeree.ResumeLayout(false);
            this.m_formAlarmeGeree.ResumeLayout(false);
            this.m_formAlarmeGeree.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
        protected CSpvTypeAccesAlarme TypeAccesAlarme
		{
			get
			{
				return (CSpvTypeAccesAlarme)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
        //private bool m_bIsInit = false;
        protected override CResultAErreur InitChamps()
		{
			CResultAErreur result = base.InitChamps();
			if (!result)
				return result;

            AffecterTitre(I.T("Alarm acces type|10009"));

			List<IEnumALibelle> lst = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CCategorieAccesAlarme)));
			m_cmbTypeAcces.Fill(
				lst,
				"Libelle",
				false);

			m_cmbTypeAcces.SelectedValue = TypeAccesAlarme.CategorieAccesAlarme;
            if (TypeAccesAlarme.Row.RowState != System.Data.DataRowState.Added)
                m_cmbTypeAcces.Enabled = false;
            else
                m_cmbTypeAcces.Enabled = true;

            if (TypeAccesAlarme.SpvSite != null)
            {
                if (TypeAccesAlarme.SpvSite.ObjetTimosAssocie != null)
                    m_labelObjetLie.Text = TypeAccesAlarme.SpvSite.ObjetTimosAssocie.Libelle;
            }
            else if (TypeAccesAlarme.SpvTypeq != null)
            {
                if (TypeAccesAlarme.SpvTypeq.TypeEquipementSmt != null)
                    m_labelObjetLie.Text = TypeAccesAlarme.SpvTypeq.TypeEquipementSmt.Libelle;
            }
            else if (TypeAccesAlarme.SpvLiai != null)
            {
                if (TypeAccesAlarme.SpvLiai.ObjetTimosAssocie != null)
                    m_labelObjetLie.Text = TypeAccesAlarme.SpvLiai.ObjetTimosAssocie.Libelle;
            }

			UpdateAffichagePanelTrap();

			m_txtIANA.IntValue = TypeAccesAlarme.NumeroIANA;
			m_txtTrapGenerique.IntValue = TypeAccesAlarme.TrapGenerique;
			m_txtTrapSpecifique.IntValue = TypeAccesAlarme.TrapSpecifique;

			AffecterTitre(I.T( "Alarm access|100") + " " + TypeAccesAlarme.NomAcces);

        /*    m_spvAlarmGeree = TypeAccesAlarme.AlarmeGeree;
            if (m_spvAlarmGeree==null && m_gestionnaireModeEdition.ModeEdition )
            {
                m_spvAlarmGeree = new CSpvAlarmGeree(TypeAccesAlarme.ContexteDonnee);
                m_spvAlarmGeree.CreateNewInCurrentContexte();
                m_spvAlarmGeree.TypeAccesAlarme = TypeAccesAlarme;
            }*/

            List<IEnumALibelle> lstProtocol = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CProtocole)));
            m_cmbProtocol.Fill(lstProtocol, "Libelle", false);
            
            List<IEnumALibelle> lstSon = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CTypeSon)));
            m_cmbTypeSon.Fill(lstSon, "Libelle", false);
            
        //    List<IEnumALibelle> lstGrave = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CGraviteAlarme)));
            List<IEnumALibelle> lstGrave = CGraviteAlarmeAvecMasquage.GetListGrave();
            m_cmbSeverity.Fill(lstGrave, "Libelle", false);
            

            List<IEnumALibelle> lstEvent = new List<IEnumALibelle>(CUtilSurEnum.GetEnumsALibelle(typeof(CAlarmEvent)));
            m_cmbEventType.Fill(lstEvent, "Libelle", false);

            CSpvAlarmGeree spvAlarmGeree = TypeAccesAlarme.GetAlarmeGereeAvecCreationSuppression();
            if (spvAlarmGeree != null)
            {
                FillFormeAlagmeGeree(spvAlarmGeree);
                m_TabControl.Visible = true;
            }
            else
                m_TabControl.Visible = false;
            
			return result;
		}

        private void InitCauses(CSpvAlarmGeree alarmeGeree)
        {
            CListeObjetsDonnees lstCausePossible = new CListeObjetsDonnees(TypeAccesAlarme.ContexteDonnee, typeof(CSpvCauseAlarme));
            CListeObjetsDonnees lstCauseSelected = alarmeGeree.Causes;
            int cnt = lstCausePossible.Count;

            m_panelSelectCauses.Init(lstCausePossible, lstCauseSelected, alarmeGeree,
                "SpvAlarmgeree", "Cause");
            
            cnt = lstCauseSelected.Count;

            m_panelSelectCauses.RemplirGrille();
        }
		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
			if (!result)
				return result;

			TypeAccesAlarme.CategorieAccesAlarme = m_cmbTypeAcces.SelectedValue as CCategorieAccesAlarme;
			if (TypeAccesAlarme.CategorieAccesAlarme != null &&
                TypeAccesAlarme.CategorieAccesAlarme.Code == ECategorieAccesAlarme.TrapSnmp)
			{
				TypeAccesAlarme.SetInfosTrap(
					m_txtIANA.IntValue, m_txtTrapGenerique.IntValue, m_txtTrapSpecifique.IntValue);
			}
			else
				TypeAccesAlarme.SetInfosTrap(null, null, null);

            CSpvAlarmGeree spvAlarmGeree = TypeAccesAlarme.GetAlarmeGereeAvecCreationSuppression();

            if (spvAlarmGeree != null)
            {
                spvAlarmGeree.DureeMin = (m_txtConfirmLength.Text.Length >0) ? Convert.ToInt32(m_txtConfirmLength.Text):0;

                if (m_AlarmNb.Text.Length > 0)
                    spvAlarmGeree.AlarmgereeFreqNb = Convert.ToInt32(m_AlarmNb.Text);
                else
                    spvAlarmGeree.AlarmgereeFreqNb = null;
                
                if (m_txtPerSec.Text.Length > 0)
                    spvAlarmGeree.AlarmgereeFreqPeriod = Convert.ToInt32(m_txtPerSec.Text);
                else
                    spvAlarmGeree.AlarmgereeFreqPeriod = null;
                
                spvAlarmGeree.Comment = m_txtComments.Text;
                
                spvAlarmGeree.AlarmgereeSeuilNom = m_txtSeuilNom.Text;

                if (m_txtBottomLevel.Text.Length > 0)
                    spvAlarmGeree.SeuilBas = Convert.ToInt32(m_txtBottomLevel.Text);
                else
                    spvAlarmGeree.SeuilBas = null;

                if (m_txtTopLevel.Text.Length > 0)
                    spvAlarmGeree.SeuilHaut = Convert.ToInt32(m_txtTopLevel.Text);
                else
                    spvAlarmGeree.SeuilHaut = null;

                spvAlarmGeree.Threshold_OID = m_txtOID.Text;
                
                spvAlarmGeree.Corrective_Action = m_txtActions.Text;

                spvAlarmGeree.AlarmgereeLocal = m_chkAlarmLocal.Checked;
                spvAlarmGeree.Alarmgeree_Acquitter = m_chkAcquitter.Checked;
                spvAlarmGeree.AlarmgereeAfficher = m_chkDisplay.Checked;
                spvAlarmGeree.AlarmgereeSurveiller = m_chkSurveiller.Checked;
                spvAlarmGeree.Automatic_MIB = m_chkAutoMib.Checked;
                spvAlarmGeree.AlarmgereeSon = m_chkActiveSon.Checked;

                spvAlarmGeree.AlarmgereeProtocol = (CProtocole)m_cmbProtocol.SelectedValue;
                spvAlarmGeree.AlarmgereeTypeSon = (CTypeSon)m_cmbTypeSon.SelectedValue;
                spvAlarmGeree.AlarmgereeGravite = (CGraviteAlarmeAvecMasquage)m_cmbSeverity.SelectedValue;
                spvAlarmGeree.AlarmgereeEvent = (CAlarmEvent)m_cmbEventType.SelectedValue;

                m_panelSelectCauses.ApplyModifs();

                if (TypeAccesAlarme.Row.RowState != System.Data.DataRowState.Added && TypeAccesAlarme.SpvTypeq != null)
                {
                    if (MessageBox.Show(I.T("Do you want to propagate the values to the equipement of this type ?|50015"),
                                        "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        spvAlarmGeree.PropagerAuxEquipements = true;
                    else
                        spvAlarmGeree.PropagerAuxEquipements = false;
                }
            }
                
           	return result;
        }

		private void m_cmbTypeAcces_SelectionChangeCommitted(object sender, EventArgs e)
		{
			UpdateAffichagePanelTrap();
            UpdatePanelAlarmeGeree();
		}

        protected void UpdateAffichagePanelTrap()
		{
			CCategorieAccesAlarme tp = m_cmbTypeAcces.SelectedValue as CCategorieAccesAlarme;
            bool bTrap = tp != null && tp.Code == ECategorieAccesAlarme.TrapSnmp;
			m_panelPourPasTrap.Visible = !bTrap;
			m_panelPourTrap.Visible = bTrap;
            int delta = bTrap ? m_panelPourPasTrap.Width : m_panelPourTrap.Width;

    //        m_PanelPourTous.Height -= delta;
		}

        protected void UpdatePanelAlarmeGeree()
        {
            CCategorieAccesAlarme category = m_cmbTypeAcces.SelectedValue as CCategorieAccesAlarme;

            if(CSpvTypeAccesAlarme.HasAlarmeGeree(category.CodeInt))
            {
                CSpvAlarmGeree spvAlarmGeree = TypeAccesAlarme.GetAlarmeGereeAvecCreationSuppression();
                if (spvAlarmGeree == null)
                {
                    m_chkAcquitter.Checked = CSpvAlarmGeree.c_defautAlarmgeree_Acquitter;
                    m_chkSurveiller.Checked = CSpvAlarmGeree.c_defautAlarmgereeSurveiller;
                    m_chkDisplay.Checked = CSpvAlarmGeree.c_defautAlarmgereeAfficher;
                    m_chkAlarmLocal.Checked = CSpvAlarmGeree.c_defautAlarmgereeLocal;
                    m_chkActiveSon.Checked = CSpvAlarmGeree.c_defautAlarmgereeSon;

                    if (TypeAccesAlarme.SpvTypeq == null)
                        groupBox1.Visible = false;
                    else
                    {
                        m_chkAutoMib.Checked = CSpvAlarmGeree.c_defautAutomatic_MIB;
                        m_txtBottomLevel.Text = CSpvAlarmGeree.c_defautSeuilBas.ToString();
                        m_txtTopLevel.Text = CSpvAlarmGeree.c_defautSeuilHaut.ToString();
                    }
                    
                    m_AlarmNb.Text = CSpvAlarmGeree.c_defautAlarmgereeFreqNb.ToString();
                    m_txtConfirmLength.Text = CSpvAlarmGeree.c_defautDureeMin.ToString();
                    m_txtPerSec.Text = CSpvAlarmGeree.c_defautAlarmgereeFreqPeriod.ToString();

                    m_cmbProtocol.SelectedValue = new CProtocole((EProtocole)CSpvAlarmGeree.c_defautCodeAlarmgereeProtocol);
                    m_cmbEventType.SelectedValue = new CAlarmEvent((EAlarmEvent)CSpvAlarmGeree.c_defautCodeAlarmgereeEvent);
                    m_cmbSeverity.SelectedValue = new CGraviteAlarmeAvecMasquage((EGraviteAlarmeAvecMasquage)CSpvAlarmGeree.c_defautCodeAlarmgereeGravite);
                    m_cmbTypeSon.SelectedValue = new CTypeSon((ETypeSon)CSpvAlarmGeree.c_defautCodeAlarmgereeTypeSon);                  
                }
                else
                    FillFormeAlagmeGeree(spvAlarmGeree);
                
                m_TabControl.Visible = true;
            }
            else
                m_TabControl.Visible = false;
           
        }


        private void FillFormeAlagmeGeree(CSpvAlarmGeree alarmeGeree)
        {
            m_txtConfirmLength.Text = alarmeGeree.DureeMin.ToString();
            m_AlarmNb.Text = (alarmeGeree.AlarmgereeFreqNb == null) ? "" : alarmeGeree.AlarmgereeFreqNb.ToString();
            m_txtPerSec.Text = (alarmeGeree.AlarmgereeFreqPeriod == null) ? "" : alarmeGeree.AlarmgereeFreqPeriod.ToString();
            m_txtComments.Text = alarmeGeree.Comment;
            if (TypeAccesAlarme.SpvTypeq == null)
                groupBox1.Visible = false;
            else
            {
                m_txtSeuilNom.Text = alarmeGeree.AlarmgereeSeuilNom;
                m_txtBottomLevel.Text = (alarmeGeree.SeuilBas == null) ? "" : alarmeGeree.SeuilBas.ToString();
                m_txtTopLevel.Text = (alarmeGeree.SeuilHaut==null) ? "" : alarmeGeree.SeuilHaut.ToString();
                m_txtOID.Text = alarmeGeree.Threshold_OID;
            }
            m_txtActions.Text = alarmeGeree.Corrective_Action;

            m_chkAlarmLocal.Checked = alarmeGeree.AlarmgereeLocal;
            m_chkAcquitter.Checked = alarmeGeree.Alarmgeree_Acquitter;
            m_chkDisplay.Checked = alarmeGeree.AlarmgereeAfficher;
            m_chkSurveiller.Checked = alarmeGeree.AlarmgereeSurveiller;
            m_chkAutoMib.Checked = alarmeGeree.Automatic_MIB;
            m_chkActiveSon.Checked = alarmeGeree.AlarmgereeSon;

            m_cmbProtocol.SelectedValue = alarmeGeree.AlarmgereeProtocol;
            m_cmbTypeSon.SelectedValue = alarmeGeree.AlarmgereeTypeSon;
            m_cmbSeverity.SelectedValue = alarmeGeree.AlarmgereeGravite;
            m_cmbEventType.SelectedValue = alarmeGeree.AlarmgereeEvent;

            InitCauses(alarmeGeree);
        }


        private void CFormEditionTypeAccesAlarme_AfterPassageEnEdition(object sender, CObjetDonneeEventArgs args)
        {
            CSpvAlarmGeree spvAlarmGeree = TypeAccesAlarme.GetAlarmeGereeAvecCreationSuppression();
            if (spvAlarmGeree != null)
            {
                CListeObjetsDonnees lstCausePossible = new CListeObjetsDonnees(TypeAccesAlarme.ContexteDonnee, typeof(CSpvCauseAlarme));
                CListeObjetsDonnees lstCauseSelected = spvAlarmGeree.Causes;

                m_panelSelectCauses.ReloadForEdition(
                        lstCauseSelected,
                        spvAlarmGeree.ContexteDonnee);
            }
        }

      

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            CReferenceTypeForm reference;
         
            
            if (TypeAccesAlarme.SpvSite != null)
            {
                CObjetDonneeAIdNumeriqueAuto objetAEditer = (CObjetDonneeAIdNumeriqueAuto)TypeAccesAlarme.SpvSite.ObjetTimosAssocie;
                               
                
                reference = CFormFinder.GetRefFormToEdit(typeof(CSite));
                if (reference != null)
                {
                    CFormEditionStandard frm = reference.GetForm(objetAEditer) as CFormEditionStandard;

                    if (frm != null)
                        Navigateur.AffichePage(frm);
                }
            }
            else if (TypeAccesAlarme.SpvTypeq != null)
            {
                CObjetDonneeAIdNumeriqueAuto objetAEditer = (CObjetDonneeAIdNumeriqueAuto)TypeAccesAlarme.SpvTypeq.TypeEquipementSmt;
               
                             
                reference = CFormFinder.GetRefFormToEdit(typeof(CTypeEquipement));
                if (reference != null)
                {
                    CFormEditionStandard frm = reference.GetForm(objetAEditer) as CFormEditionStandard;

                    if (frm != null)
                        Navigateur.AffichePage(frm);
                }
            }
            else if (TypeAccesAlarme.SpvLiai != null)
            {
                CObjetDonneeAIdNumeriqueAuto objetAEditer = (CObjetDonneeAIdNumeriqueAuto)TypeAccesAlarme.SpvLiai.ObjetTimosAssocie;


                reference = CFormFinder.GetRefFormToEdit(typeof(CLienReseau));
                if (reference != null)
                {
                    CFormEditionStandard frm = reference.GetForm(objetAEditer) as CFormEditionStandard;

                    if (frm != null)
                        Navigateur.AffichePage(frm);
                }
            }
                
           /* CReferenceTypeForm reference;
            reference = CFormFinder.GetRefFormToEdit(typeAEditer);
            if (reference != null)
            {                  
                CFormEditionStandard frm = reference.GetForm(objetAEditer) as CFormEditionStandard;
               
                if (frm != null)
                    Navigateur.AffichePage(frm);
            }*/

        }

        private void m_lnkGererCauses_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormNavigateurPopup.Show(new CFormListeCauseAlarme());
        }
	}
}

