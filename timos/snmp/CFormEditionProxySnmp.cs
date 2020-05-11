using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;

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
using futurocom.easyquery;
using futurocom.snmp.dynamic;
using futurocom.snmp;
using futurocom.easyquery.snmp;
using futurocom.win32.snmp;
using futurocom.snmp.alarme;
using timos.data.supervision;
using futurocom.win32.snmp.alarmes;
using futurocom.snmp.Mib;
using futurocom.supervision;
using timos.data.snmp.Proxy;
using futurocom.snmp.Proxy;
using System.Text;
using sc2i.common.unites;
using sc2i.common.unites.standard;

namespace timos.snmp
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CSnmpProxyInDb))]
	public class CFormEditionProxySnmp : CFormEditionStdTimos, IFormNavigable
	{
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageLiensProxy;
        private Crownwood.Magic.Controls.TabPage m_pageConfigIP;
        private C2iTextBox m_txtAdresseIP;
        private Label label2;
        private Label label4;
        private GroupBox groupBox1;
        private Label label3;
        private C2iNumericUpDown m_numPriorite;
        private C2iNumericUpDown m_numPort;
        private ErrorProvider m_errorProvider;
        private SplitContainer splitContainer1;
        private CWndLinkStd m_lnkSupprimerLienProxy;
        private ListViewAutoFilled m_wndListeLiensProxy;
        private ListViewAutoFilledColumn m_colonneLibelle;
        private C2iTextBoxSelectionne m_txtSelectProxy;
        private Label label24;
        private CWndLinkStd m_lnkAjouterLienProxy;
        private Panel m_panelConstructeur;
        private Label m_lblProxyDest;
        private CGestionnaireEditionSousObjetDonnee m_gestionnaireEditionLiensDeProxy;
        private CControlEditionLienDeProxy m_controlEditionLienDeProxy;
        private Panel m_panelDetailsLienProxy;
        private LinkLabel m_lnkTestConfig;
        private Label label7;
        private Label label8;
        private Label label9;
        private LinkLabel m_lblControlAgent;
        private Button m_btnUpdate;
        private C2iTextBoxNumeriqueAvecUnite m_txtFrequencePolling;
        private Label label5;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionProxySnmp()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionProxySnmp(CSnmpProxyInDb proxy)
            : base(proxy)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
        public CFormEditionProxySnmp(CSnmpProxyInDb proxy, CListeObjetsDonnees liste)
            : base(proxy, liste)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionProxySnmp));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_numPriorite = new sc2i.win32.common.C2iNumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.m_btnUpdate = new System.Windows.Forms.Button();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageConfigIP = new Crownwood.Magic.Controls.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_txtFrequencePolling = new sc2i.win32.common.C2iTextBoxNumeriqueAvecUnite();
            this.m_lblControlAgent = new System.Windows.Forms.LinkLabel();
            this.m_numPort = new sc2i.win32.common.C2iNumericUpDown();
            this.m_txtAdresseIP = new sc2i.win32.common.C2iTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_pageLiensProxy = new Crownwood.Magic.Controls.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lnkSupprimerLienProxy = new sc2i.win32.common.CWndLinkStd();
            this.m_wndListeLiensProxy = new sc2i.win32.common.ListViewAutoFilled();
            this.m_colonneLibelle = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_txtSelectProxy = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label8 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.m_lnkAjouterLienProxy = new sc2i.win32.common.CWndLinkStd();
            this.m_panelConstructeur = new System.Windows.Forms.Panel();
            this.m_lnkTestConfig = new System.Windows.Forms.LinkLabel();
            this.m_panelDetailsLienProxy = new System.Windows.Forms.Panel();
            this.m_controlEditionLienDeProxy = new timos.snmp.CControlEditionLienDeProxy();
            this.label9 = new System.Windows.Forms.Label();
            this.m_lblProxyDest = new System.Windows.Forms.Label();
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.m_gestionnaireEditionLiensDeProxy = new sc2i.win32.data.navigation.CGestionnaireEditionSousObjetDonnee(this.components);
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numPriorite)).BeginInit();
            this.m_tabControl.SuspendLayout();
            this.m_pageConfigIP.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numPort)).BeginInit();
            this.m_pageLiensProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.m_panelConstructeur.SuspendLayout();
            this.m_panelDetailsLienProxy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
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
            this.m_panelNavigation.Location = new System.Drawing.Point(655, 0);
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
            this.m_panelCle.Location = new System.Drawing.Point(547, 0);
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
            this.m_txtLibelle.Location = new System.Drawing.Point(108, 8);
            this.m_txtLibelle.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtLibelle, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtLibelle, "");
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(304, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.m_numPriorite);
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.Controls.Add(this.label4);
            this.c2iPanelOmbre4.Controls.Add(this.m_btnUpdate);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 35);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(440, 106);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
            // 
            // m_numPriorite
            // 
            this.m_numPriorite.DoubleValue = 0D;
            this.m_numPriorite.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numPriorite, "Priorite");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_numPriorite, true);
            this.m_numPriorite.Location = new System.Drawing.Point(108, 37);
            this.m_numPriorite.LockEdition = false;
            this.m_numPriorite.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numPriorite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numPriorite, "");
            this.m_numPriorite.Name = "m_numPriorite";
            this.m_numPriorite.Size = new System.Drawing.Size(64, 20);
            this.m_extStyle.SetStyleBackColor(this.m_numPriorite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numPriorite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numPriorite.TabIndex = 4006;
            this.m_numPriorite.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numPriorite.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label4, false);
            this.label4.Location = new System.Drawing.Point(16, 42);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label4, "");
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4002;
            this.label4.Text = "Priority|10203";
            // 
            // m_btnUpdate
            // 
            this.m_extLinkField.SetLinkField(this.m_btnUpdate, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnUpdate, false);
            this.m_btnUpdate.Location = new System.Drawing.Point(228, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnUpdate, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_btnUpdate, "");
            this.m_btnUpdate.Name = "m_btnUpdate";
            this.m_btnUpdate.Size = new System.Drawing.Size(184, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnUpdate.TabIndex = 4007;
            this.m_btnUpdate.Text = "Update Configuration|10403";
            this.m_btnUpdate.UseVisualStyleBackColor = true;
            this.m_btnUpdate.Click += new System.EventHandler(this.m_btnUpdate_Click);
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
            this.m_tabControl.Location = new System.Drawing.Point(12, 147);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageConfigIP;
            this.m_tabControl.Size = new System.Drawing.Size(818, 385);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageConfigIP,
            this.m_pageLiensProxy});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageConfigIP
            // 
            this.m_pageConfigIP.Controls.Add(this.groupBox1);
            this.m_extLinkField.SetLinkField(this.m_pageConfigIP, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageConfigIP, false);
            this.m_pageConfigIP.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageConfigIP, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageConfigIP, "");
            this.m_pageConfigIP.Name = "m_pageConfigIP";
            this.m_pageConfigIP.Size = new System.Drawing.Size(802, 344);
            this.m_extStyle.SetStyleBackColor(this.m_pageConfigIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageConfigIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageConfigIP.TabIndex = 11;
            this.m_pageConfigIP.Title = "IP Configuration|10119";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_txtFrequencePolling);
            this.groupBox1.Controls.Add(this.m_lblControlAgent);
            this.groupBox1.Controls.Add(this.m_numPort);
            this.groupBox1.Controls.Add(this.m_txtAdresseIP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.m_extLinkField.SetLinkField(this.groupBox1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.groupBox1, false);
            this.groupBox1.Location = new System.Drawing.Point(19, 13);
            this.m_gestionnaireModeEdition.SetModeEdition(this.groupBox1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.groupBox1, "");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(637, 104);
            this.m_extStyle.SetStyleBackColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.groupBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.groupBox1.TabIndex = 4003;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Network Setting|10202";
            // 
            // m_txtFrequencePolling
            // 
            this.m_txtFrequencePolling.AllowNoUnit = false;
            this.m_txtFrequencePolling.DefaultFormat = "h min s";
            this.m_txtFrequencePolling.EmptyText = "h min s";
            this.m_extLinkField.SetLinkField(this.m_txtFrequencePolling, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtFrequencePolling, false);
            this.m_txtFrequencePolling.Location = new System.Drawing.Point(129, 71);
            this.m_txtFrequencePolling.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtFrequencePolling, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtFrequencePolling, "");
            this.m_txtFrequencePolling.Name = "m_txtFrequencePolling";
            this.m_txtFrequencePolling.Size = new System.Drawing.Size(161, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtFrequencePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFrequencePolling, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFrequencePolling.TabIndex = 4009;
            this.m_txtFrequencePolling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtFrequencePolling.UnitValue = null;
            this.m_txtFrequencePolling.UseValueFormat = true;
            // 
            // m_lblControlAgent
            // 
            this.m_lblControlAgent.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lblControlAgent, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblControlAgent, false);
            this.m_lblControlAgent.Location = new System.Drawing.Point(448, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblControlAgent, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lblControlAgent, "");
            this.m_lblControlAgent.Name = "m_lblControlAgent";
            this.m_lblControlAgent.Size = new System.Drawing.Size(176, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblControlAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblControlAgent, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblControlAgent.TabIndex = 4008;
            this.m_lblControlAgent.TabStop = true;
            this.m_lblControlAgent.Text = "Control mediation service|20329";
            this.m_lblControlAgent.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lblControlAgent_LinkClicked);
            // 
            // m_numPort
            // 
            this.m_numPort.DoubleValue = 0D;
            this.m_numPort.IntValue = 0;
            this.m_extLinkField.SetLinkField(this.m_numPort, "Port");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_numPort, true);
            this.m_numPort.Location = new System.Drawing.Point(378, 43);
            this.m_numPort.LockEdition = false;
            this.m_numPort.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_numPort, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_numPort, "");
            this.m_numPort.Name = "m_numPort";
            this.m_numPort.Size = new System.Drawing.Size(64, 23);
            this.m_extStyle.SetStyleBackColor(this.m_numPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_numPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_numPort.TabIndex = 4006;
            this.m_numPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numPort.ThousandsSeparator = true;
            // 
            // m_txtAdresseIP
            // 
            this.m_txtAdresseIP.EmptyText = "";
            this.m_extLinkField.SetLinkField(this.m_txtAdresseIP, "AdresseIp");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtAdresseIP, true);
            this.m_txtAdresseIP.Location = new System.Drawing.Point(130, 43);
            this.m_txtAdresseIP.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtAdresseIP, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtAdresseIP, "");
            this.m_txtAdresseIP.Name = "m_txtAdresseIP";
            this.m_txtAdresseIP.Size = new System.Drawing.Size(160, 23);
            this.m_extStyle.SetStyleBackColor(this.m_txtAdresseIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAdresseIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAdresseIP.TabIndex = 1;
            this.m_txtAdresseIP.Text = "[AdresseIp]";
            this.m_txtAdresseIP.TextChanged += new System.EventHandler(this.m_txtAdresseIP_TextChanged);
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label3, false);
            this.label3.Location = new System.Drawing.Point(309, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label3, "");
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4002;
            this.label3.Text = "Port|10201";
            // 
            // label7
            // 
            this.m_extLinkField.SetLinkField(this.label7, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label7, false);
            this.label7.Location = new System.Drawing.Point(15, 20);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label7, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label7, "");
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(426, 17);
            this.m_extStyle.SetStyleBackColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label7, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label7.TabIndex = 4002;
            this.label7.Text = "Indicates how this Proxy can be reached on the Network|10209";
            // 
            // label5
            // 
            this.m_extLinkField.SetLinkField(this.label5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label5, false);
            this.label5.Location = new System.Drawing.Point(15, 74);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label5, "");
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 18);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 4002;
            this.label5.Text = "Polling Frequency";
            // 
            // label2
            // 
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label2, false);
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label2, "");
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4002;
            this.label2.Text = "IP Address|10200";
            // 
            // m_pageLiensProxy
            // 
            this.m_pageLiensProxy.Controls.Add(this.splitContainer1);
            this.m_extLinkField.SetLinkField(this.m_pageLiensProxy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageLiensProxy, false);
            this.m_pageLiensProxy.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageLiensProxy, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageLiensProxy, "");
            this.m_pageLiensProxy.Name = "m_pageLiensProxy";
            this.m_pageLiensProxy.Selected = false;
            this.m_pageLiensProxy.Size = new System.Drawing.Size(802, 344);
            this.m_extStyle.SetStyleBackColor(this.m_pageLiensProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageLiensProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageLiensProxy.TabIndex = 10;
            this.m_pageLiensProxy.Title = "Proxy Links|10118";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.splitContainer1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1, false);
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1, "");
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkSupprimerLienProxy);
            this.splitContainer1.Panel1.Controls.Add(this.m_wndListeLiensProxy);
            this.splitContainer1.Panel1.Controls.Add(this.m_txtSelectProxy);
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.label24);
            this.splitContainer1.Panel1.Controls.Add(this.m_lnkAjouterLienProxy);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel1, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel1, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_panelConstructeur);
            this.m_extLinkField.SetLinkField(this.splitContainer1.Panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitContainer1.Panel2, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitContainer1.Panel2, "");
            this.m_extStyle.SetStyleBackColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1.Panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.Size = new System.Drawing.Size(802, 344);
            this.splitContainer1.SplitterDistance = 385;
            this.m_extStyle.SetStyleBackColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitContainer1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitContainer1.TabIndex = 1;
            // 
            // m_lnkSupprimerLienProxy
            // 
            this.m_lnkSupprimerLienProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lnkSupprimerLienProxy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkSupprimerLienProxy.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkSupprimerLienProxy.CustomImage")));
            this.m_lnkSupprimerLienProxy.CustomText = "Remove";
            this.m_lnkSupprimerLienProxy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkSupprimerLienProxy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkSupprimerLienProxy, false);
            this.m_lnkSupprimerLienProxy.Location = new System.Drawing.Point(19, 311);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkSupprimerLienProxy, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkSupprimerLienProxy, "");
            this.m_lnkSupprimerLienProxy.Name = "m_lnkSupprimerLienProxy";
            this.m_lnkSupprimerLienProxy.ShortMode = false;
            this.m_lnkSupprimerLienProxy.Size = new System.Drawing.Size(104, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerLienProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerLienProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerLienProxy.TabIndex = 9;
            this.m_lnkSupprimerLienProxy.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkSupprimerLienProxy.LinkClicked += new System.EventHandler(this.m_lnkSupprimerLienProxy_LinkClicked);
            // 
            // m_wndListeLiensProxy
            // 
            this.m_wndListeLiensProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeLiensProxy.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.m_colonneLibelle});
            this.m_wndListeLiensProxy.EnableCustomisation = true;
            this.m_wndListeLiensProxy.FullRowSelect = true;
            this.m_wndListeLiensProxy.HideSelection = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeLiensProxy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeLiensProxy, false);
            this.m_wndListeLiensProxy.Location = new System.Drawing.Point(10, 105);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeLiensProxy, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeLiensProxy, "");
            this.m_wndListeLiensProxy.MultiSelect = false;
            this.m_wndListeLiensProxy.Name = "m_wndListeLiensProxy";
            this.m_wndListeLiensProxy.Size = new System.Drawing.Size(363, 199);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeLiensProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeLiensProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeLiensProxy.TabIndex = 7;
            this.m_wndListeLiensProxy.UseCompatibleStateImageBehavior = false;
            this.m_wndListeLiensProxy.View = System.Windows.Forms.View.Details;
            // 
            // m_colonneLibelle
            // 
            this.m_colonneLibelle.Field = "ProxyDestination.Libelle";
            this.m_colonneLibelle.PrecisionWidth = 0D;
            this.m_colonneLibelle.ProportionnalSize = false;
            this.m_colonneLibelle.Text = "Label|50";
            this.m_colonneLibelle.Visible = true;
            this.m_colonneLibelle.Width = 200;
            // 
            // m_txtSelectProxy
            // 
            this.m_txtSelectProxy.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtSelectProxy.ElementSelectionne = null;
            this.m_txtSelectProxy.FonctionTextNull = null;
            this.m_txtSelectProxy.HasLink = true;
            this.m_txtSelectProxy.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_extLinkField.SetLinkField(this.m_txtSelectProxy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_txtSelectProxy, false);
            this.m_txtSelectProxy.Location = new System.Drawing.Point(107, 53);
            this.m_txtSelectProxy.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtSelectProxy, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_txtSelectProxy, "");
            this.m_txtSelectProxy.Name = "m_txtSelectProxy";
            this.m_txtSelectProxy.SelectedObject = null;
            this.m_txtSelectProxy.Size = new System.Drawing.Size(266, 21);
            this.m_txtSelectProxy.SpecificImage = null;
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectProxy.TabIndex = 6;
            this.m_txtSelectProxy.TextNull = "";
            // 
            // label8
            // 
            this.m_extLinkField.SetLinkField(this.label8, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label8, false);
            this.label8.Location = new System.Drawing.Point(7, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label8, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label8, "");
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(366, 32);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 5;
            this.label8.Text = "To create a link, add a Distant Proxy then configure IP Address ranges managed by" +
    " this distant Proxy|10212";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.label24, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label24, false);
            this.label24.Location = new System.Drawing.Point(7, 57);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label24, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label24, "");
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(109, 15);
            this.m_extStyle.SetStyleBackColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label24, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label24.TabIndex = 5;
            this.label24.Text = "Distant Proxy|10207";
            // 
            // m_lnkAjouterLienProxy
            // 
            this.m_lnkAjouterLienProxy.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouterLienProxy.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAjouterLienProxy.CustomImage")));
            this.m_lnkAjouterLienProxy.CustomText = "Add";
            this.m_lnkAjouterLienProxy.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAjouterLienProxy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAjouterLienProxy, false);
            this.m_lnkAjouterLienProxy.Location = new System.Drawing.Point(107, 78);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouterLienProxy, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAjouterLienProxy, "");
            this.m_lnkAjouterLienProxy.Name = "m_lnkAjouterLienProxy";
            this.m_lnkAjouterLienProxy.ShortMode = false;
            this.m_lnkAjouterLienProxy.Size = new System.Drawing.Size(104, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAjouterLienProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAjouterLienProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAjouterLienProxy.TabIndex = 8;
            this.m_lnkAjouterLienProxy.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouterLienProxy.LinkClicked += new System.EventHandler(this.m_lnkAjouterLienProxy_LinkClicked);
            // 
            // m_panelConstructeur
            // 
            this.m_panelConstructeur.Controls.Add(this.m_lnkTestConfig);
            this.m_panelConstructeur.Controls.Add(this.m_panelDetailsLienProxy);
            this.m_panelConstructeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelConstructeur, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelConstructeur, false);
            this.m_panelConstructeur.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelConstructeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelConstructeur, "");
            this.m_panelConstructeur.Name = "m_panelConstructeur";
            this.m_panelConstructeur.Size = new System.Drawing.Size(413, 344);
            this.m_extStyle.SetStyleBackColor(this.m_panelConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelConstructeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelConstructeur.TabIndex = 6;
            // 
            // m_lnkTestConfig
            // 
            this.m_lnkTestConfig.AutoSize = true;
            this.m_extLinkField.SetLinkField(this.m_lnkTestConfig, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkTestConfig, false);
            this.m_lnkTestConfig.Location = new System.Drawing.Point(9, 10);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkTestConfig, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lnkTestConfig, "");
            this.m_lnkTestConfig.Name = "m_lnkTestConfig";
            this.m_lnkTestConfig.Size = new System.Drawing.Size(125, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lnkTestConfig, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkTestConfig, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkTestConfig.TabIndex = 4005;
            this.m_lnkTestConfig.TabStop = true;
            this.m_lnkTestConfig.Text = "Configuration Preview";
            this.m_lnkTestConfig.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkTestConfig_LinkClicked);
            // 
            // m_panelDetailsLienProxy
            // 
            this.m_panelDetailsLienProxy.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelDetailsLienProxy.Controls.Add(this.m_controlEditionLienDeProxy);
            this.m_panelDetailsLienProxy.Controls.Add(this.label9);
            this.m_panelDetailsLienProxy.Controls.Add(this.m_lblProxyDest);
            this.m_extLinkField.SetLinkField(this.m_panelDetailsLienProxy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelDetailsLienProxy, false);
            this.m_panelDetailsLienProxy.Location = new System.Drawing.Point(8, 28);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDetailsLienProxy, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_panelDetailsLienProxy, "");
            this.m_panelDetailsLienProxy.Name = "m_panelDetailsLienProxy";
            this.m_panelDetailsLienProxy.Size = new System.Drawing.Size(391, 305);
            this.m_extStyle.SetStyleBackColor(this.m_panelDetailsLienProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDetailsLienProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDetailsLienProxy.TabIndex = 5;
            // 
            // m_controlEditionLienDeProxy
            // 
            this.m_controlEditionLienDeProxy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_controlEditionLienDeProxy, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_controlEditionLienDeProxy, false);
            this.m_controlEditionLienDeProxy.Location = new System.Drawing.Point(0, 61);
            this.m_controlEditionLienDeProxy.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_controlEditionLienDeProxy, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_controlEditionLienDeProxy, "");
            this.m_controlEditionLienDeProxy.Name = "m_controlEditionLienDeProxy";
            this.m_controlEditionLienDeProxy.Size = new System.Drawing.Size(391, 244);
            this.m_extStyle.SetStyleBackColor(this.m_controlEditionLienDeProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_controlEditionLienDeProxy, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controlEditionLienDeProxy.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.label9, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.label9, false);
            this.label9.Location = new System.Drawing.Point(0, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label9, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.label9, "");
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(391, 32);
            this.m_extStyle.SetStyleBackColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label9, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label9.TabIndex = 5;
            this.label9.Text = "IP Address Ranges management. Clic on Add button to create a new IP Address range" +
    " managed by the distant Proxy|10213";
            // 
            // m_lblProxyDest
            // 
            this.m_lblProxyDest.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_lblProxyDest.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblProxyDest.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblProxyDest.ForeColor = System.Drawing.Color.White;
            this.m_extLinkField.SetLinkField(this.m_lblProxyDest, "ProxyDestination.Libelle");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lblProxyDest, true);
            this.m_lblProxyDest.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblProxyDest, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_lblProxyDest, "");
            this.m_lblProxyDest.Name = "m_lblProxyDest";
            this.m_lblProxyDest.Size = new System.Drawing.Size(391, 29);
            this.m_extStyle.SetStyleBackColor(this.m_lblProxyDest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblProxyDest, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProxyDest.TabIndex = 3;
            this.m_lblProxyDest.Text = "[ProxyDestination.Libelle]";
            this.m_lblProxyDest.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // m_gestionnaireEditionLiensDeProxy
            // 
            this.m_gestionnaireEditionLiensDeProxy.ListeAssociee = this.m_wndListeLiensProxy;
            this.m_gestionnaireEditionLiensDeProxy.ObjetEdite = null;
            this.m_gestionnaireEditionLiensDeProxy.InitChamp += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionLiensDeProxy_InitChamp);
            this.m_gestionnaireEditionLiensDeProxy.MAJ_Champs += new sc2i.data.ObjetDonneeResultEventHandler(this.m_gestionnaireEditionLiensDeProxy_MAJ_Champs);
            // 
            // CFormEditionProxySnmp
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionProxySnmp";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeAgentSnmp_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeAgentSnmp_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.m_panelNavigation.ResumeLayout(false);
            this.m_panelCle.ResumeLayout(false);
            this.m_panelCle.PerformLayout();
            this.m_panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).EndInit();
            this.c2iPanelOmbre4.ResumeLayout(false);
            this.c2iPanelOmbre4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numPriorite)).EndInit();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.m_pageConfigIP.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_numPort)).EndInit();
            this.m_pageLiensProxy.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.m_panelConstructeur.ResumeLayout(false);
            this.m_panelConstructeur.PerformLayout();
            this.m_panelDetailsLienProxy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CSnmpProxyInDb Proxy
		{
			get
			{
                return (CSnmpProxyInDb)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            CResultAErreur result = base.MyInitChamps();
            if (Proxy.FrequencePollingMinutes == 0)
                m_txtFrequencePolling.UnitValue = null;
            else
                m_txtFrequencePolling.UnitValue = new CValeurUnite(Proxy.FrequencePollingMinutes, "min");
            AffecterTitre(I.T("SNMP Proxy @1|10117", Proxy.Libelle));
			
            return result;
		}

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            CResultAErreur result = base.MAJ_Champs();
            if (m_txtFrequencePolling.UnitValue!= null)
                Proxy.FrequencePollingMinutes = m_txtFrequencePolling.UnitValue.ConvertTo(CClasseUniteTemps.c_idMIN).Valeur;
            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeAgentSnmp_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_pageConfigIP)
            {

            }
            else if(page == m_pageLiensProxy)
            {
                if (Proxy.IsNew())
                    m_gestionnaireEditionLiensDeProxy.SetObjetEnCoursToNull();

                m_gestionnaireEditionLiensDeProxy.ObjetEdite = Proxy.LiensDeProxyDestination;
                InitSelectProxy();
                m_panelDetailsLienProxy.Visible = m_gestionnaireEditionLiensDeProxy.ObjetEnCours != null;
            }

            return result;
        }

        //------------------------------------------------------------------------------
        private void m_lnkAjouterLienProxy_LinkClicked(object sender, EventArgs e)
        {
            CSnmpProxyInDb proxyDistant = m_txtSelectProxy.ElementSelectionne as CSnmpProxyInDb;
            if (proxyDistant == null)
                return;

            m_txtSelectProxy.ElementSelectionne = null;
            CLienDeProxy lienProxy = new CLienDeProxy(Proxy.ContexteDonnee);
            lienProxy.CreateNewInCurrentContexte();
            lienProxy.ProxySource = Proxy;
            lienProxy.ProxyDestination = proxyDistant;

            ListViewItem item = new ListViewItem();
            m_wndListeLiensProxy.Items.Add(item);
            m_wndListeLiensProxy.UpdateItemWithObject(item, lienProxy);
            foreach (ListViewItem itemSel in m_wndListeLiensProxy.SelectedItems)
                itemSel.Selected = false;
            item.Selected = true;
            InitSelectProxy();

        }

        //------------------------------------------------------------------------------
        private void m_lnkSupprimerLienProxy_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeLiensProxy.SelectedItems.Count != 1)
                return;

            CLienDeProxy lienProxy = m_wndListeLiensProxy.SelectedItems[0].Tag as CLienDeProxy;
            if (lienProxy == null)
                return;

            m_gestionnaireEditionLiensDeProxy.SetObjetEnCoursToNull();
            CResultAErreur result = lienProxy.Delete();
            if (!result)
            {
                CFormAlerte.Afficher(result.Erreur);
                return;
            }
            if (m_wndListeLiensProxy.SelectedItems.Count == 1)
                m_wndListeLiensProxy.SelectedItems[0].Remove();

            InitSelectProxy();
        }

        //------------------------------------------------------------------------------
        private void InitSelectProxy()
        {
            CFiltreData filtre = null;

            List<string> lstIdProxyDest = new List<string>();
            lstIdProxyDest.Add(Proxy.Id.ToString());
            
            foreach (CLienDeProxy lien in Proxy.LiensDeProxyDestination)
            {
                lstIdProxyDest.Add(lien.ProxyDestination.Id.ToString());
            }

            if (lstIdProxyDest.Count > 0)
            {
                string strFiltreIn = String.Join(",", lstIdProxyDest.ToArray());
                filtre = new CFiltreData(CSnmpProxyInDb.c_champId + " NOT IN (" +
                        strFiltreIn + ")");
            }

            m_txtSelectProxy.InitAvecFiltreDeBase<CSnmpProxyInDb>(
                "Libelle",
                filtre,
                true);

        }


        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeAgentSnmp_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;

            if (page == m_pageConfigIP)
            {
                
            }
            else if (page == m_pageLiensProxy)
            {
                m_gestionnaireEditionLiensDeProxy.ValideModifs();
            }
            
            return result;
        }

        //------------------------------------------------------------------------------
        private void m_txtAdresseIP_TextChanged(object sender, EventArgs e)
        {
            C2iTextBox txtBox = sender as C2iTextBox;
            if (txtBox != null)
            {
                if (IP.IsValidIP(txtBox.Text))
                    m_errorProvider.SetError(txtBox, "");
                else
                    m_errorProvider.SetError(txtBox, I.T("Invalid IP Address format @1|10204", txtBox.Text));
            }
        }

        //------------------------------------------------------------------------------
        private void m_gestionnaireEditionLiensDeProxy_InitChamp(object sender, CObjetDonneeResultEventArgs args)
        {
            CLienDeProxy lienProxy = args.Objet as CLienDeProxy;
            if (lienProxy != null)
            {
                m_panelDetailsLienProxy.Visible = true;
                m_controlEditionLienDeProxy.Init(lienProxy);
                if (lienProxy.ProxyDestination != null)
                    m_lblProxyDest.Text = lienProxy.ProxyDestination.Libelle;
            }
            else
            {
                m_panelDetailsLienProxy.Visible = false;
            }
        }

        //------------------------------------------------------------------------------
        private void m_gestionnaireEditionLiensDeProxy_MAJ_Champs(object sender, CObjetDonneeResultEventArgs args)
        {
            CLienDeProxy lienProxy = args.Objet as CLienDeProxy;
            if (lienProxy != null)
            {
                CResultAErreur result = m_controlEditionLienDeProxy.MajChamps();
                if (!result)
                {
                    args.Result = result;
                    return;
                }

            }

        }

        private void m_lnkTestConfig_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CSnmpProxyConfiguration configTest = Proxy.GetConfiguration();

            if (configTest != null)
            {
                StringBuilder sBuilder = new StringBuilder();
                sBuilder.AppendLine(Proxy.Libelle + " Configuration is :");

                foreach (CSnmpProxy proxy in configTest.ListeProxy)
                {
                    sBuilder.Append("\t");
                    sBuilder.AppendLine(proxy.NomProxy);

                    foreach (CPlageIP plage in proxy.PlagesIP)
                    {
                        sBuilder.Append("\t\t");
                        sBuilder.AppendLine(plage.ModeleIpString + "/" + plage.Mask.ToString());
                    }
                }

                CFormAlerte.Afficher(sBuilder.ToString());

            }

        }

      
         private void m_lblControlAgent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CFormControleServiceMediation.ShowMediationInfo(Proxy);
        }

         private void m_btnUpdate_Click(object sender, EventArgs e)
         {
             Proxy.UpdateFullDistantConfiguration();
         }
	}
}

