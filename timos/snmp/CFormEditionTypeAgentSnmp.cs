using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
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
using sc2i.common.memorydb;
using futurocom.snmp.entitesnmp;
using sc2i.expression.FonctionsDynamiques;
using sc2i.win32.expression;
using sc2i.expression;

namespace timos.snmp
{
	[sc2i.win32.data.navigation.ObjectEditeur(typeof(CTypeAgentSnmp))]
	public class CFormEditionTypeAgentSnmp : CFormEditionStdTimos, IFormNavigable
	{
        CMemoryDb m_memoryDb = null;
        private IBaseTypesAlarmes m_baseTypesAlarmes = null;
		private System.Windows.Forms.Label label1;
		private sc2i.win32.common.C2iTextBox m_txtLibelle;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre4;
        private C2iTabControl m_tabControl;
        private Crownwood.Magic.Controls.TabPage m_pageMIB;
        private Crownwood.Magic.Controls.TabPage m_pageQueries;
        private Crownwood.Magic.Controls.TabPage m_pageHandlers;
        private Crownwood.Magic.Controls.TabPage m_pageEntites;
        private CPanelListeRelationSelection m_panelListeMibs;
        private ListViewAutoFilledColumn listViewAutoFilledColumn1;
        private GlacialList m_wndListeQueries;
        private Panel panel3;
        private CWndLinkStd m_lnkRemoveQuery;
        private CWndLinkStd m_lnkAddQuery;
        private GlacialList m_wndListeHandlers;
        private Panel panel1;
        private CWndLinkStd m_lnkRemoveHandler;
        private CWndLinkStd m_lnkAddHandler;
        private CWndMibBrowser m_browser;
        private Panel panel2;
        private LinkLabel m_lnkCreateHandler;
        private Splitter splitter1;
        private Timer m_timerReloadMib;
        private CPanelListeSpeedStandard m_panelTypesEntites;
        private Button button1;
        private CWndLinkStd m_lnkDetailQuery;
        private CWndLinkStd m_lnkDetailHandler;
        private Crownwood.Magic.Controls.TabPage m_pageFonctions;
        private GlacialList m_wndListeFonctions;
        private Panel panel4;
        private CWndLinkStd m_btnRemoveFonction;
        private CWndLinkStd m_btnDetailFonction;
        private CWndLinkStd m_btnAddFonction;
        private Crownwood.Magic.Controls.TabPage m_pageAgentFinders;
        private GlacialList m_wndListAgentFinders;
        private Panel panel5;
        private CWndLinkStd m_lnkRemoveFinder;
        private CWndLinkStd m_lnkDetailFinder;
        private CWndLinkStd m_lnkAddFinder;
        private LinkLabel m_lnkCreateFinder;
		private System.ComponentModel.IContainer components = null;

		public CFormEditionTypeAgentSnmp()
			:base()
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeAgentSnmp(CTypeAgentSnmp TypeAgentSnmp)
			:base(TypeAgentSnmp)
		{
			// Cet appel est requis par le Concepteur Windows Form.
			InitializeComponent();
		}
		//-------------------------------------------------------------------------
		public CFormEditionTypeAgentSnmp(CTypeAgentSnmp TypeAgentSnmp, CListeObjetsDonnees liste)
			:base(TypeAgentSnmp, liste)
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
            sc2i.win32.common.GLColumn glColumn6 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn7 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn8 = new sc2i.win32.common.GLColumn();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionTypeAgentSnmp));
            sc2i.win32.common.GLColumn glColumn1 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn2 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn3 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn4 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn5 = new sc2i.win32.common.GLColumn();
            sc2i.win32.common.GLColumn glColumn9 = new sc2i.win32.common.GLColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.c2iPanelOmbre4 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_pageAgentFinders = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListAgentFinders = new sc2i.win32.common.GlacialList();
            this.panel5 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveFinder = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkDetailFinder = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddFinder = new sc2i.win32.common.CWndLinkStd();
            this.m_pageMIB = new Crownwood.Magic.Controls.TabPage();
            this.m_browser = new futurocom.win32.snmp.CWndMibBrowser();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkCreateHandler = new System.Windows.Forms.LinkLabel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_panelListeMibs = new sc2i.win32.data.navigation.CPanelListeRelationSelection();
            this.listViewAutoFilledColumn1 = ((sc2i.win32.common.ListViewAutoFilledColumn)(new sc2i.win32.common.ListViewAutoFilledColumn()));
            this.m_pageQueries = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeQueries = new sc2i.win32.common.GlacialList();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveQuery = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkDetailQuery = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddQuery = new sc2i.win32.common.CWndLinkStd();
            this.m_pageFonctions = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeFonctions = new sc2i.win32.common.GlacialList();
            this.panel4 = new System.Windows.Forms.Panel();
            this.m_btnRemoveFonction = new sc2i.win32.common.CWndLinkStd();
            this.m_btnDetailFonction = new sc2i.win32.common.CWndLinkStd();
            this.m_btnAddFonction = new sc2i.win32.common.CWndLinkStd();
            this.m_pageHandlers = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListeHandlers = new sc2i.win32.common.GlacialList();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveHandler = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkDetailHandler = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddHandler = new sc2i.win32.common.CWndLinkStd();
            this.m_pageEntites = new Crownwood.Magic.Controls.TabPage();
            this.m_panelTypesEntites = new sc2i.win32.data.navigation.CPanelListeSpeedStandard();
            this.m_timerReloadMib = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.m_lnkCreateFinder = new System.Windows.Forms.LinkLabel();
            this.m_panelNavigation.SuspendLayout();
            this.m_panelCle.SuspendLayout();
            this.m_panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnHistorique)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageCle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnChercherObjet)).BeginInit();
            this.c2iPanelOmbre4.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.m_pageAgentFinders.SuspendLayout();
            this.panel5.SuspendLayout();
            this.m_pageMIB.SuspendLayout();
            this.panel2.SuspendLayout();
            this.m_pageQueries.SuspendLayout();
            this.panel3.SuspendLayout();
            this.m_pageFonctions.SuspendLayout();
            this.panel4.SuspendLayout();
            this.m_pageHandlers.SuspendLayout();
            this.panel1.SuspendLayout();
            this.m_pageEntites.SuspendLayout();
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
            this.m_txtLibelle.Size = new System.Drawing.Size(280, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 0;
            this.m_txtLibelle.Text = "[Libelle]";
            // 
            // c2iPanelOmbre4
            // 
            this.c2iPanelOmbre4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre4.Controls.Add(this.label1);
            this.c2iPanelOmbre4.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre4.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.c2iPanelOmbre4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.c2iPanelOmbre4, false);
            this.c2iPanelOmbre4.Location = new System.Drawing.Point(12, 35);
            this.c2iPanelOmbre4.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.c2iPanelOmbre4, "");
            this.c2iPanelOmbre4.Name = "c2iPanelOmbre4";
            this.c2iPanelOmbre4.Size = new System.Drawing.Size(440, 56);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre4, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre4.TabIndex = 0;
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
            this.m_tabControl.Location = new System.Drawing.Point(12, 98);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_tabControl, "");
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = true;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.m_pageMIB;
            this.m_tabControl.Size = new System.Drawing.Size(818, 434);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_tabControl.TabIndex = 4004;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.m_pageMIB,
            this.m_pageQueries,
            this.m_pageFonctions,
            this.m_pageHandlers,
            this.m_pageAgentFinders,
            this.m_pageEntites});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_pageAgentFinders
            // 
            this.m_pageAgentFinders.Controls.Add(this.m_wndListAgentFinders);
            this.m_pageAgentFinders.Controls.Add(this.panel5);
            this.m_extLinkField.SetLinkField(this.m_pageAgentFinders, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageAgentFinders, false);
            this.m_pageAgentFinders.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageAgentFinders, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageAgentFinders, "");
            this.m_pageAgentFinders.Name = "m_pageAgentFinders";
            this.m_pageAgentFinders.Selected = false;
            this.m_pageAgentFinders.Size = new System.Drawing.Size(802, 393);
            this.m_extStyle.SetStyleBackColor(this.m_pageAgentFinders, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageAgentFinders, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageAgentFinders.TabIndex = 15;
            this.m_pageAgentFinders.Title = "Agent Finders|10419";
            // 
            // m_wndListAgentFinders
            // 
            this.m_wndListAgentFinders.AllowColumnResize = true;
            this.m_wndListAgentFinders.AllowMultiselect = false;
            this.m_wndListAgentFinders.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListAgentFinders.AlternatingColors = false;
            this.m_wndListAgentFinders.AutoHeight = true;
            this.m_wndListAgentFinders.AutoSort = true;
            this.m_wndListAgentFinders.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListAgentFinders.CanChangeActivationCheckBoxes = false;
            this.m_wndListAgentFinders.CheckBoxes = false;
            this.m_wndListAgentFinders.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListAgentFinders.CheckedItems")));
            glColumn6.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn6.ActiveControlItems")));
            glColumn6.BackColor = System.Drawing.Color.Transparent;
            glColumn6.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn6.ForColor = System.Drawing.Color.Black;
            glColumn6.ImageIndex = -1;
            glColumn6.IsCheckColumn = false;
            glColumn6.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn6.Name = "Column1";
            glColumn6.Propriete = "Libelle";
            glColumn6.Text = "Finder name|10420";
            glColumn6.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn6.Width = 150;
            glColumn7.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn7.ActiveControlItems")));
            glColumn7.BackColor = System.Drawing.Color.Transparent;
            glColumn7.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn7.ForColor = System.Drawing.Color.Black;
            glColumn7.ImageIndex = -1;
            glColumn7.IsCheckColumn = false;
            glColumn7.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn7.Name = "Column2";
            glColumn7.Propriete = "EntrepriseRequestedValue";
            glColumn7.Text = "Entreprise|20280";
            glColumn7.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn7.Width = 150;
            glColumn8.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn8.ActiveControlItems")));
            glColumn8.BackColor = System.Drawing.Color.Transparent;
            glColumn8.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn8.ForColor = System.Drawing.Color.Black;
            glColumn8.ImageIndex = -1;
            glColumn8.IsCheckColumn = false;
            glColumn8.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn8.Name = "Column3";
            glColumn8.Propriete = "SpecificRequestedValue";
            glColumn8.Text = "Specific|20281";
            glColumn8.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn8.Width = 100;
            this.m_wndListAgentFinders.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn6,
            glColumn7,
            glColumn8});
            this.m_wndListAgentFinders.ContexteUtilisation = "";
            this.m_wndListAgentFinders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListAgentFinders.EnableCustomisation = true;
            this.m_wndListAgentFinders.FocusedItem = null;
            this.m_wndListAgentFinders.FullRowSelect = true;
            this.m_wndListAgentFinders.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListAgentFinders.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListAgentFinders.HasImages = false;
            this.m_wndListAgentFinders.HeaderHeight = 22;
            this.m_wndListAgentFinders.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListAgentFinders.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListAgentFinders.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListAgentFinders.HeaderVisible = true;
            this.m_wndListAgentFinders.HeaderWordWrap = false;
            this.m_wndListAgentFinders.HotColumnIndex = -1;
            this.m_wndListAgentFinders.HotItemIndex = -1;
            this.m_wndListAgentFinders.HotTracking = false;
            this.m_wndListAgentFinders.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListAgentFinders.ImageList = null;
            this.m_wndListAgentFinders.ItemHeight = 17;
            this.m_wndListAgentFinders.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_wndListAgentFinders, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListAgentFinders, false);
            this.m_wndListAgentFinders.ListeSource = null;
            this.m_wndListAgentFinders.Location = new System.Drawing.Point(0, 24);
            this.m_wndListAgentFinders.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListAgentFinders, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListAgentFinders, "");
            this.m_wndListAgentFinders.Name = "m_wndListAgentFinders";
            this.m_wndListAgentFinders.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListAgentFinders.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListAgentFinders.ShowBorder = true;
            this.m_wndListAgentFinders.ShowFocusRect = true;
            this.m_wndListAgentFinders.Size = new System.Drawing.Size(802, 369);
            this.m_wndListAgentFinders.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListAgentFinders, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListAgentFinders, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListAgentFinders.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListAgentFinders.TabIndex = 4;
            this.m_wndListAgentFinders.Text = "glacialList1";
            this.m_wndListAgentFinders.TrierAuClicSurEnteteColonne = true;
            this.m_wndListAgentFinders.DoubleClick += new System.EventHandler(this.m_wndListAgentFinders_DoubleClick);
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.m_lnkRemoveFinder);
            this.panel5.Controls.Add(this.m_lnkDetailFinder);
            this.panel5.Controls.Add(this.m_lnkAddFinder);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel5, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel5, false);
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel5, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel5, "");
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(802, 24);
            this.m_extStyle.SetStyleBackColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel5.TabIndex = 5;
            // 
            // m_lnkRemoveFinder
            // 
            this.m_lnkRemoveFinder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveFinder.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveFinder.CustomImage")));
            this.m_lnkRemoveFinder.CustomText = "Remove";
            this.m_lnkRemoveFinder.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveFinder.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkRemoveFinder, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkRemoveFinder, false);
            this.m_lnkRemoveFinder.Location = new System.Drawing.Point(224, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemoveFinder, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkRemoveFinder, "");
            this.m_lnkRemoveFinder.Name = "m_lnkRemoveFinder";
            this.m_lnkRemoveFinder.ShortMode = false;
            this.m_lnkRemoveFinder.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveFinder.TabIndex = 1;
            this.m_lnkRemoveFinder.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveFinder.LinkClicked += new System.EventHandler(this.m_lnkRemoveFinder_LinkClicked);
            // 
            // m_lnkDetailFinder
            // 
            this.m_lnkDetailFinder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDetailFinder.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkDetailFinder.CustomImage")));
            this.m_lnkDetailFinder.CustomText = "Detail";
            this.m_lnkDetailFinder.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetailFinder.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkDetailFinder, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDetailFinder, false);
            this.m_lnkDetailFinder.Location = new System.Drawing.Point(112, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetailFinder, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDetailFinder, "");
            this.m_lnkDetailFinder.Name = "m_lnkDetailFinder";
            this.m_lnkDetailFinder.ShortMode = false;
            this.m_lnkDetailFinder.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailFinder.TabIndex = 3;
            this.m_lnkDetailFinder.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkDetailFinder.LinkClicked += new System.EventHandler(this.m_lnkDetailFinder_LinkClicked);
            // 
            // m_lnkAddFinder
            // 
            this.m_lnkAddFinder.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddFinder.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddFinder.CustomImage")));
            this.m_lnkAddFinder.CustomText = "Add";
            this.m_lnkAddFinder.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddFinder.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddFinder, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAddFinder, false);
            this.m_lnkAddFinder.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddFinder, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddFinder, "");
            this.m_lnkAddFinder.Name = "m_lnkAddFinder";
            this.m_lnkAddFinder.ShortMode = false;
            this.m_lnkAddFinder.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddFinder.TabIndex = 0;
            this.m_lnkAddFinder.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddFinder.LinkClicked += new System.EventHandler(this.m_lnkAddFinder_LinkClicked);
            // 
            // m_pageMIB
            // 
            this.m_pageMIB.Controls.Add(this.m_browser);
            this.m_pageMIB.Controls.Add(this.panel2);
            this.m_pageMIB.Controls.Add(this.splitter1);
            this.m_pageMIB.Controls.Add(this.m_panelListeMibs);
            this.m_extLinkField.SetLinkField(this.m_pageMIB, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageMIB, false);
            this.m_pageMIB.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageMIB, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageMIB, "");
            this.m_pageMIB.Name = "m_pageMIB";
            this.m_pageMIB.Size = new System.Drawing.Size(802, 393);
            this.m_extStyle.SetStyleBackColor(this.m_pageMIB, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageMIB, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageMIB.TabIndex = 10;
            this.m_pageMIB.Title = "Managed mibs modules|20271";
            // 
            // m_browser
            // 
            this.m_browser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_browser, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_browser, false);
            this.m_browser.Location = new System.Drawing.Point(248, 29);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_browser, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_browser, "");
            this.m_browser.Name = "m_browser";
            this.m_browser.Size = new System.Drawing.Size(554, 364);
            this.m_extStyle.SetStyleBackColor(this.m_browser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_browser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_browser.TabIndex = 7;
            this.m_browser.SelectedDefinitionChanged += new System.EventHandler(this.m_browser_SelectedDefinitionChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkCreateFinder);
            this.panel2.Controls.Add(this.m_lnkCreateHandler);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel2, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel2, false);
            this.panel2.Location = new System.Drawing.Point(248, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel2, "");
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(554, 29);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 8;
            // 
            // m_lnkCreateHandler
            // 
            this.m_lnkCreateHandler.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lnkCreateHandler, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkCreateHandler, false);
            this.m_lnkCreateHandler.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCreateHandler, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkCreateHandler, "");
            this.m_lnkCreateHandler.Name = "m_lnkCreateHandler";
            this.m_lnkCreateHandler.Size = new System.Drawing.Size(144, 29);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreateHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreateHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreateHandler.TabIndex = 0;
            this.m_lnkCreateHandler.TabStop = true;
            this.m_lnkCreateHandler.Text = "Create handler|20283";
            this.m_lnkCreateHandler.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkCreateHandler.Visible = false;
            this.m_lnkCreateHandler.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreateHandler_LinkClicked);
            // 
            // splitter1
            // 
            this.m_extLinkField.SetLinkField(this.splitter1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.splitter1, false);
            this.splitter1.Location = new System.Drawing.Point(245, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.splitter1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.splitter1, "");
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 393);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 9;
            this.splitter1.TabStop = false;
            // 
            // m_panelListeMibs
            // 
            this.m_panelListeMibs.Columns.AddRange(new sc2i.win32.common.ListViewAutoFilledColumn[] {
            this.listViewAutoFilledColumn1});
            this.m_panelListeMibs.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelListeMibs.EnableCustomisation = true;
            this.m_panelListeMibs.ExclusionParException = false;
            this.m_extLinkField.SetLinkField(this.m_panelListeMibs, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelListeMibs, false);
            this.m_panelListeMibs.Location = new System.Drawing.Point(0, 0);
            this.m_panelListeMibs.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelListeMibs, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_panelListeMibs, "");
            this.m_panelListeMibs.Name = "m_panelListeMibs";
            this.m_panelListeMibs.Size = new System.Drawing.Size(245, 393);
            this.m_extStyle.SetStyleBackColor(this.m_panelListeMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelListeMibs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelListeMibs.TabIndex = 6;
            this.m_panelListeMibs.OnItemCheck += new System.EventHandler(this.m_panelListeMibs_OnItemCheck);
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0D;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Label|50";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 200;
            // 
            // m_pageQueries
            // 
            this.m_pageQueries.Controls.Add(this.m_wndListeQueries);
            this.m_pageQueries.Controls.Add(this.panel3);
            this.m_extLinkField.SetLinkField(this.m_pageQueries, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageQueries, false);
            this.m_pageQueries.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageQueries, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageQueries, "");
            this.m_pageQueries.Name = "m_pageQueries";
            this.m_pageQueries.Selected = false;
            this.m_pageQueries.Size = new System.Drawing.Size(802, 393);
            this.m_extStyle.SetStyleBackColor(this.m_pageQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageQueries.TabIndex = 11;
            this.m_pageQueries.Title = "Queries|20272";
            // 
            // m_wndListeQueries
            // 
            this.m_wndListeQueries.AllowColumnResize = true;
            this.m_wndListeQueries.AllowMultiselect = false;
            this.m_wndListeQueries.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeQueries.AlternatingColors = false;
            this.m_wndListeQueries.AutoHeight = true;
            this.m_wndListeQueries.AutoSort = true;
            this.m_wndListeQueries.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeQueries.CanChangeActivationCheckBoxes = false;
            this.m_wndListeQueries.CheckBoxes = false;
            this.m_wndListeQueries.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeQueries.CheckedItems")));
            glColumn1.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn1.ActiveControlItems")));
            glColumn1.BackColor = System.Drawing.Color.Transparent;
            glColumn1.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn1.ForColor = System.Drawing.Color.Black;
            glColumn1.ImageIndex = -1;
            glColumn1.IsCheckColumn = false;
            glColumn1.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn1.Name = "Column1";
            glColumn1.Propriete = "Libelle";
            glColumn1.Text = "Handler name|20277";
            glColumn1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn1.Width = 250;
            this.m_wndListeQueries.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn1});
            this.m_wndListeQueries.ContexteUtilisation = "";
            this.m_wndListeQueries.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeQueries.EnableCustomisation = true;
            this.m_wndListeQueries.FocusedItem = null;
            this.m_wndListeQueries.FullRowSelect = true;
            this.m_wndListeQueries.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeQueries.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeQueries.HasImages = false;
            this.m_wndListeQueries.HeaderHeight = 22;
            this.m_wndListeQueries.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeQueries.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeQueries.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeQueries.HeaderVisible = true;
            this.m_wndListeQueries.HeaderWordWrap = false;
            this.m_wndListeQueries.HotColumnIndex = -1;
            this.m_wndListeQueries.HotItemIndex = -1;
            this.m_wndListeQueries.HotTracking = false;
            this.m_wndListeQueries.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeQueries.ImageList = null;
            this.m_wndListeQueries.ItemHeight = 17;
            this.m_wndListeQueries.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeQueries, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeQueries, false);
            this.m_wndListeQueries.ListeSource = null;
            this.m_wndListeQueries.Location = new System.Drawing.Point(0, 24);
            this.m_wndListeQueries.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeQueries, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeQueries, "");
            this.m_wndListeQueries.Name = "m_wndListeQueries";
            this.m_wndListeQueries.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeQueries.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeQueries.ShowBorder = true;
            this.m_wndListeQueries.ShowFocusRect = true;
            this.m_wndListeQueries.Size = new System.Drawing.Size(802, 369);
            this.m_wndListeQueries.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeQueries, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeQueries.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeQueries.TabIndex = 4;
            this.m_wndListeQueries.Text = "glacialList1";
            this.m_wndListeQueries.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeQueries.DoubleClick += new System.EventHandler(this.m_wndListeQueries_DoubleClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lnkRemoveQuery);
            this.panel3.Controls.Add(this.m_lnkDetailQuery);
            this.panel3.Controls.Add(this.m_lnkAddQuery);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel3, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel3, false);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel3, "");
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(802, 24);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 5;
            // 
            // m_lnkRemoveQuery
            // 
            this.m_lnkRemoveQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveQuery.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveQuery.CustomImage")));
            this.m_lnkRemoveQuery.CustomText = "Remove";
            this.m_lnkRemoveQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveQuery.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkRemoveQuery, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkRemoveQuery, false);
            this.m_lnkRemoveQuery.Location = new System.Drawing.Point(224, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemoveQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkRemoveQuery, "");
            this.m_lnkRemoveQuery.Name = "m_lnkRemoveQuery";
            this.m_lnkRemoveQuery.ShortMode = false;
            this.m_lnkRemoveQuery.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveQuery.TabIndex = 1;
            this.m_lnkRemoveQuery.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveQuery.LinkClicked += new System.EventHandler(this.m_lnkRemoveQuery_LinkClicked);
            // 
            // m_lnkDetailQuery
            // 
            this.m_lnkDetailQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDetailQuery.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkDetailQuery.CustomImage")));
            this.m_lnkDetailQuery.CustomText = "Detail";
            this.m_lnkDetailQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetailQuery.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkDetailQuery, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDetailQuery, false);
            this.m_lnkDetailQuery.Location = new System.Drawing.Point(112, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetailQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDetailQuery, "");
            this.m_lnkDetailQuery.Name = "m_lnkDetailQuery";
            this.m_lnkDetailQuery.ShortMode = false;
            this.m_lnkDetailQuery.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailQuery.TabIndex = 2;
            this.m_lnkDetailQuery.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkDetailQuery.LinkClicked += new System.EventHandler(this.m_lnkDetailQuery_LinkClicked);
            // 
            // m_lnkAddQuery
            // 
            this.m_lnkAddQuery.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddQuery.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddQuery.CustomImage")));
            this.m_lnkAddQuery.CustomText = "Add";
            this.m_lnkAddQuery.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddQuery.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddQuery, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAddQuery, false);
            this.m_lnkAddQuery.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddQuery, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddQuery, "");
            this.m_lnkAddQuery.Name = "m_lnkAddQuery";
            this.m_lnkAddQuery.ShortMode = false;
            this.m_lnkAddQuery.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddQuery, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddQuery.TabIndex = 0;
            this.m_lnkAddQuery.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddQuery.LinkClicked += new System.EventHandler(this.m_lnkAddQuery_LinkClicked);
            // 
            // m_pageFonctions
            // 
            this.m_pageFonctions.Controls.Add(this.m_wndListeFonctions);
            this.m_pageFonctions.Controls.Add(this.panel4);
            this.m_extLinkField.SetLinkField(this.m_pageFonctions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageFonctions, false);
            this.m_pageFonctions.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageFonctions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageFonctions, "");
            this.m_pageFonctions.Name = "m_pageFonctions";
            this.m_pageFonctions.Selected = false;
            this.m_pageFonctions.Size = new System.Drawing.Size(802, 393);
            this.m_extStyle.SetStyleBackColor(this.m_pageFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageFonctions.TabIndex = 14;
            this.m_pageFonctions.Title = "Specific functions|20844";
            // 
            // m_wndListeFonctions
            // 
            this.m_wndListeFonctions.AllowColumnResize = true;
            this.m_wndListeFonctions.AllowMultiselect = false;
            this.m_wndListeFonctions.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeFonctions.AlternatingColors = false;
            this.m_wndListeFonctions.AutoHeight = true;
            this.m_wndListeFonctions.AutoSort = true;
            this.m_wndListeFonctions.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeFonctions.CanChangeActivationCheckBoxes = false;
            this.m_wndListeFonctions.CheckBoxes = false;
            this.m_wndListeFonctions.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeFonctions.CheckedItems")));
            glColumn2.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn2.ActiveControlItems")));
            glColumn2.BackColor = System.Drawing.Color.Transparent;
            glColumn2.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn2.ForColor = System.Drawing.Color.Black;
            glColumn2.ImageIndex = -1;
            glColumn2.IsCheckColumn = false;
            glColumn2.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn2.Name = "Column1";
            glColumn2.Propriete = "Nom";
            glColumn2.Text = "Function ame|20845";
            glColumn2.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn2.Width = 250;
            this.m_wndListeFonctions.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn2});
            this.m_wndListeFonctions.ContexteUtilisation = "";
            this.m_wndListeFonctions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeFonctions.EnableCustomisation = true;
            this.m_wndListeFonctions.FocusedItem = null;
            this.m_wndListeFonctions.FullRowSelect = true;
            this.m_wndListeFonctions.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeFonctions.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeFonctions.HasImages = false;
            this.m_wndListeFonctions.HeaderHeight = 22;
            this.m_wndListeFonctions.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeFonctions.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeFonctions.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeFonctions.HeaderVisible = true;
            this.m_wndListeFonctions.HeaderWordWrap = false;
            this.m_wndListeFonctions.HotColumnIndex = -1;
            this.m_wndListeFonctions.HotItemIndex = -1;
            this.m_wndListeFonctions.HotTracking = false;
            this.m_wndListeFonctions.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeFonctions.ImageList = null;
            this.m_wndListeFonctions.ItemHeight = 17;
            this.m_wndListeFonctions.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeFonctions, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeFonctions, false);
            this.m_wndListeFonctions.ListeSource = null;
            this.m_wndListeFonctions.Location = new System.Drawing.Point(0, 24);
            this.m_wndListeFonctions.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeFonctions, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeFonctions, "");
            this.m_wndListeFonctions.Name = "m_wndListeFonctions";
            this.m_wndListeFonctions.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeFonctions.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeFonctions.ShowBorder = true;
            this.m_wndListeFonctions.ShowFocusRect = true;
            this.m_wndListeFonctions.Size = new System.Drawing.Size(802, 369);
            this.m_wndListeFonctions.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeFonctions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeFonctions.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeFonctions.TabIndex = 6;
            this.m_wndListeFonctions.Text = "glacialList1";
            this.m_wndListeFonctions.TrierAuClicSurEnteteColonne = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_btnRemoveFonction);
            this.panel4.Controls.Add(this.m_btnDetailFonction);
            this.panel4.Controls.Add(this.m_btnAddFonction);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel4, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel4, false);
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel4, "");
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(802, 24);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 7;
            // 
            // m_btnRemoveFonction
            // 
            this.m_btnRemoveFonction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnRemoveFonction.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnRemoveFonction.CustomImage")));
            this.m_btnRemoveFonction.CustomText = "Remove";
            this.m_btnRemoveFonction.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnRemoveFonction.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_btnRemoveFonction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnRemoveFonction, false);
            this.m_btnRemoveFonction.Location = new System.Drawing.Point(224, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnRemoveFonction, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnRemoveFonction, "");
            this.m_btnRemoveFonction.Name = "m_btnRemoveFonction";
            this.m_btnRemoveFonction.ShortMode = false;
            this.m_btnRemoveFonction.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnRemoveFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnRemoveFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRemoveFonction.TabIndex = 1;
            this.m_btnRemoveFonction.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_btnRemoveFonction.LinkClicked += new System.EventHandler(this.m_btnRemoveFonction_LinkClicked);
            // 
            // m_btnDetailFonction
            // 
            this.m_btnDetailFonction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnDetailFonction.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnDetailFonction.CustomImage")));
            this.m_btnDetailFonction.CustomText = "Detail";
            this.m_btnDetailFonction.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnDetailFonction.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_btnDetailFonction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnDetailFonction, false);
            this.m_btnDetailFonction.Location = new System.Drawing.Point(112, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnDetailFonction, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnDetailFonction, "");
            this.m_btnDetailFonction.Name = "m_btnDetailFonction";
            this.m_btnDetailFonction.ShortMode = false;
            this.m_btnDetailFonction.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnDetailFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDetailFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDetailFonction.TabIndex = 2;
            this.m_btnDetailFonction.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnDetailFonction.LinkClicked += new System.EventHandler(this.m_btnDetailFonction_LinkClicked);
            // 
            // m_btnAddFonction
            // 
            this.m_btnAddFonction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnAddFonction.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_btnAddFonction.CustomImage")));
            this.m_btnAddFonction.CustomText = "Add";
            this.m_btnAddFonction.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnAddFonction.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_btnAddFonction, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_btnAddFonction, false);
            this.m_btnAddFonction.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAddFonction, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_btnAddFonction, "");
            this.m_btnAddFonction.Name = "m_btnAddFonction";
            this.m_btnAddFonction.ShortMode = false;
            this.m_btnAddFonction.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_btnAddFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAddFonction, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAddFonction.TabIndex = 0;
            this.m_btnAddFonction.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_btnAddFonction.LinkClicked += new System.EventHandler(this.m_btnAddFonction_LinkClicked);
            // 
            // m_pageHandlers
            // 
            this.m_pageHandlers.Controls.Add(this.m_wndListeHandlers);
            this.m_pageHandlers.Controls.Add(this.panel1);
            this.m_extLinkField.SetLinkField(this.m_pageHandlers, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageHandlers, false);
            this.m_pageHandlers.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageHandlers, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageHandlers, "");
            this.m_pageHandlers.Name = "m_pageHandlers";
            this.m_pageHandlers.Selected = false;
            this.m_pageHandlers.Size = new System.Drawing.Size(802, 393);
            this.m_extStyle.SetStyleBackColor(this.m_pageHandlers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageHandlers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageHandlers.TabIndex = 12;
            this.m_pageHandlers.Title = "Traps handlers|20273";
            // 
            // m_wndListeHandlers
            // 
            this.m_wndListeHandlers.AllowColumnResize = true;
            this.m_wndListeHandlers.AllowMultiselect = false;
            this.m_wndListeHandlers.AlternateBackground = System.Drawing.Color.DarkGreen;
            this.m_wndListeHandlers.AlternatingColors = false;
            this.m_wndListeHandlers.AutoHeight = true;
            this.m_wndListeHandlers.AutoSort = true;
            this.m_wndListeHandlers.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.m_wndListeHandlers.CanChangeActivationCheckBoxes = false;
            this.m_wndListeHandlers.CheckBoxes = false;
            this.m_wndListeHandlers.CheckedItems = ((System.Collections.ArrayList)(resources.GetObject("m_wndListeHandlers.CheckedItems")));
            glColumn3.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn3.ActiveControlItems")));
            glColumn3.BackColor = System.Drawing.Color.Transparent;
            glColumn3.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn3.ForColor = System.Drawing.Color.Black;
            glColumn3.ImageIndex = -1;
            glColumn3.IsCheckColumn = false;
            glColumn3.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn3.Name = "Column1";
            glColumn3.Propriete = "Libelle";
            glColumn3.Text = "Handler name|20279";
            glColumn3.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn3.Width = 150;
            glColumn4.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn4.ActiveControlItems")));
            glColumn4.BackColor = System.Drawing.Color.Transparent;
            glColumn4.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn4.ForColor = System.Drawing.Color.Black;
            glColumn4.ImageIndex = -1;
            glColumn4.IsCheckColumn = false;
            glColumn4.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn4.Name = "Column2";
            glColumn4.Propriete = "EntrepriseRequestedValue";
            glColumn4.Text = "Entreprise|20280";
            glColumn4.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn4.Width = 150;
            glColumn5.ActiveControlItems = ((System.Collections.ArrayList)(resources.GetObject("glColumn5.ActiveControlItems")));
            glColumn5.BackColor = System.Drawing.Color.Transparent;
            glColumn5.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn5.ForColor = System.Drawing.Color.Black;
            glColumn5.ImageIndex = -1;
            glColumn5.IsCheckColumn = false;
            glColumn5.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn5.Name = "Column3";
            glColumn5.Propriete = "SpecificRequestedValue";
            glColumn5.Text = "Specific|20281";
            glColumn5.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn5.Width = 100;
            this.m_wndListeHandlers.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn3,
            glColumn4,
            glColumn5});
            this.m_wndListeHandlers.ContexteUtilisation = "";
            this.m_wndListeHandlers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeHandlers.EnableCustomisation = true;
            this.m_wndListeHandlers.FocusedItem = null;
            this.m_wndListeHandlers.FullRowSelect = true;
            this.m_wndListeHandlers.GLGridLines = sc2i.win32.common.GLGridStyles.gridSolid;
            this.m_wndListeHandlers.GridColor = System.Drawing.SystemColors.ControlLight;
            this.m_wndListeHandlers.HasImages = false;
            this.m_wndListeHandlers.HeaderHeight = 22;
            this.m_wndListeHandlers.HeaderStyle = sc2i.win32.common.GLHeaderStyles.Normal;
            this.m_wndListeHandlers.HeaderTextColor = System.Drawing.Color.Black;
            this.m_wndListeHandlers.HeaderTextFont = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.m_wndListeHandlers.HeaderVisible = true;
            this.m_wndListeHandlers.HeaderWordWrap = false;
            this.m_wndListeHandlers.HotColumnIndex = -1;
            this.m_wndListeHandlers.HotItemIndex = -1;
            this.m_wndListeHandlers.HotTracking = false;
            this.m_wndListeHandlers.HotTrackingColor = System.Drawing.Color.LightGray;
            this.m_wndListeHandlers.ImageList = null;
            this.m_wndListeHandlers.ItemHeight = 17;
            this.m_wndListeHandlers.ItemWordWrap = false;
            this.m_extLinkField.SetLinkField(this.m_wndListeHandlers, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_wndListeHandlers, false);
            this.m_wndListeHandlers.ListeSource = null;
            this.m_wndListeHandlers.Location = new System.Drawing.Point(0, 24);
            this.m_wndListeHandlers.MaxHeight = 17;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeHandlers, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_wndListeHandlers, "");
            this.m_wndListeHandlers.Name = "m_wndListeHandlers";
            this.m_wndListeHandlers.SelectedTextColor = System.Drawing.Color.White;
            this.m_wndListeHandlers.SelectionColor = System.Drawing.Color.DarkBlue;
            this.m_wndListeHandlers.ShowBorder = true;
            this.m_wndListeHandlers.ShowFocusRect = true;
            this.m_wndListeHandlers.Size = new System.Drawing.Size(802, 369);
            this.m_wndListeHandlers.SortIndex = 0;
            this.m_extStyle.SetStyleBackColor(this.m_wndListeHandlers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeHandlers, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeHandlers.SuperFlatHeaderColor = System.Drawing.Color.White;
            this.m_wndListeHandlers.TabIndex = 2;
            this.m_wndListeHandlers.Text = "glacialList1";
            this.m_wndListeHandlers.TrierAuClicSurEnteteColonne = true;
            this.m_wndListeHandlers.DoubleClick += new System.EventHandler(this.m_wndListeHandlers_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lnkRemoveHandler);
            this.panel1.Controls.Add(this.m_lnkDetailHandler);
            this.panel1.Controls.Add(this.m_lnkAddHandler);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.panel1, false);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.panel1, "");
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(802, 24);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 3;
            // 
            // m_lnkRemoveHandler
            // 
            this.m_lnkRemoveHandler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveHandler.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkRemoveHandler.CustomImage")));
            this.m_lnkRemoveHandler.CustomText = "Remove";
            this.m_lnkRemoveHandler.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveHandler.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkRemoveHandler, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkRemoveHandler, false);
            this.m_lnkRemoveHandler.Location = new System.Drawing.Point(224, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkRemoveHandler, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkRemoveHandler, "");
            this.m_lnkRemoveHandler.Name = "m_lnkRemoveHandler";
            this.m_lnkRemoveHandler.ShortMode = false;
            this.m_lnkRemoveHandler.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveHandler.TabIndex = 1;
            this.m_lnkRemoveHandler.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveHandler.LinkClicked += new System.EventHandler(this.m_lnkRemoveHandler_LinkClicked);
            // 
            // m_lnkDetailHandler
            // 
            this.m_lnkDetailHandler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDetailHandler.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkDetailHandler.CustomImage")));
            this.m_lnkDetailHandler.CustomText = "Detail";
            this.m_lnkDetailHandler.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetailHandler.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkDetailHandler, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkDetailHandler, false);
            this.m_lnkDetailHandler.Location = new System.Drawing.Point(112, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetailHandler, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkDetailHandler, "");
            this.m_lnkDetailHandler.Name = "m_lnkDetailHandler";
            this.m_lnkDetailHandler.ShortMode = false;
            this.m_lnkDetailHandler.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailHandler.TabIndex = 3;
            this.m_lnkDetailHandler.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkDetailHandler.LinkClicked += new System.EventHandler(this.m_lnkDetailHandler_LinkClicked);
            // 
            // m_lnkAddHandler
            // 
            this.m_lnkAddHandler.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddHandler.CustomImage = ((System.Drawing.Image)(resources.GetObject("m_lnkAddHandler.CustomImage")));
            this.m_lnkAddHandler.CustomText = "Add";
            this.m_lnkAddHandler.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddHandler.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_extLinkField.SetLinkField(this.m_lnkAddHandler, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkAddHandler, false);
            this.m_lnkAddHandler.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAddHandler, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkAddHandler, "");
            this.m_lnkAddHandler.Name = "m_lnkAddHandler";
            this.m_lnkAddHandler.ShortMode = false;
            this.m_lnkAddHandler.Size = new System.Drawing.Size(112, 24);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddHandler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddHandler.TabIndex = 0;
            this.m_lnkAddHandler.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddHandler.LinkClicked += new System.EventHandler(this.m_lnkAddHandler_LinkClicked);
            // 
            // m_pageEntites
            // 
            this.m_pageEntites.Controls.Add(this.m_panelTypesEntites);
            this.m_extLinkField.SetLinkField(this.m_pageEntites, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_pageEntites, false);
            this.m_pageEntites.Location = new System.Drawing.Point(0, 25);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_pageEntites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.m_pageEntites, "");
            this.m_pageEntites.Name = "m_pageEntites";
            this.m_pageEntites.Selected = false;
            this.m_pageEntites.Size = new System.Drawing.Size(802, 393);
            this.m_extStyle.SetStyleBackColor(this.m_pageEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pageEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pageEntites.TabIndex = 13;
            this.m_pageEntites.Title = "Managed entities|20274";
            // 
            // m_panelTypesEntites
            // 
            this.m_panelTypesEntites.AffectationsPourNouveauxElements = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("m_panelTypesEntites.AffectationsPourNouveauxElements")));
            this.m_panelTypesEntites.AllowArbre = true;
            this.m_panelTypesEntites.AllowCustomisation = true;
            this.m_panelTypesEntites.AllowSerializePreferences = true;
            glColumn9.ActiveControlItems = null;
            glColumn9.BackColor = System.Drawing.Color.Transparent;
            glColumn9.ControlType = sc2i.win32.common.ColumnControlTypes.None;
            glColumn9.ForColor = System.Drawing.Color.Black;
            glColumn9.ImageIndex = -1;
            glColumn9.IsCheckColumn = false;
            glColumn9.LastSortState = sc2i.win32.common.ColumnSortState.SortedUp;
            glColumn9.Name = "Libelle";
            glColumn9.Propriete = "Libelle";
            glColumn9.Text = "Label|50";
            glColumn9.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            glColumn9.Width = 250;
            this.m_panelTypesEntites.Columns.AddRange(new sc2i.win32.common.GLColumn[] {
            glColumn9});
            this.m_panelTypesEntites.ContexteUtilisation = "";
            this.m_panelTypesEntites.ControlFiltreStandard = null;
            this.m_panelTypesEntites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTypesEntites.ElementSelectionne = null;
            this.m_panelTypesEntites.EnableCustomisation = true;
            this.m_panelTypesEntites.FiltreDeBase = null;
            this.m_panelTypesEntites.FiltreDeBaseEnAjout = false;
            this.m_panelTypesEntites.FiltrePrefere = null;
            this.m_panelTypesEntites.FiltreRapide = null;
            this.m_panelTypesEntites.HasImages = false;
            this.m_extLinkField.SetLinkField(this.m_panelTypesEntites, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_panelTypesEntites, false);
            this.m_panelTypesEntites.ListeObjets = null;
            this.m_panelTypesEntites.Location = new System.Drawing.Point(0, 0);
            this.m_panelTypesEntites.LockEdition = true;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTypesEntites, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_panelTypesEntites.ModeQuickSearch = false;
            this.m_panelTypesEntites.ModeSelection = false;
            this.m_extModulesAssociator.SetModules(this.m_panelTypesEntites, "");
            this.m_panelTypesEntites.MultiSelect = false;
            this.m_panelTypesEntites.Name = "m_panelTypesEntites";
            this.m_panelTypesEntites.Navigateur = null;
            this.m_panelTypesEntites.ObjetReferencePourAffectationsInitiales = null;
            this.m_panelTypesEntites.ProprieteObjetAEditer = null;
            this.m_panelTypesEntites.QuickSearchText = "";
            this.m_panelTypesEntites.ShortIcons = false;
            this.m_panelTypesEntites.Size = new System.Drawing.Size(802, 393);
            this.m_extStyle.SetStyleBackColor(this.m_panelTypesEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTypesEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTypesEntites.TabIndex = 2;
            this.m_panelTypesEntites.TrierAuClicSurEnteteColonne = true;
            this.m_panelTypesEntites.UseCheckBoxes = false;
            // 
            // m_timerReloadMib
            // 
            this.m_timerReloadMib.Interval = 1000;
            this.m_timerReloadMib.Tick += new System.EventHandler(this.m_timerReloadMib_Tick);
            // 
            // button1
            // 
            this.m_extLinkField.SetLinkField(this.button1, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.button1, false);
            this.button1.Location = new System.Drawing.Point(458, 39);
            this.m_gestionnaireModeEdition.SetModeEdition(this.button1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this.button1, "");
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.button1.TabIndex = 4005;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_lnkCreateFinder
            // 
            this.m_lnkCreateFinder.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.m_lnkCreateFinder, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this.m_lnkCreateFinder, false);
            this.m_lnkCreateFinder.Location = new System.Drawing.Point(144, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCreateFinder, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_extModulesAssociator.SetModules(this.m_lnkCreateFinder, "");
            this.m_lnkCreateFinder.Name = "m_lnkCreateFinder";
            this.m_lnkCreateFinder.Size = new System.Drawing.Size(144, 29);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreateFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreateFinder, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreateFinder.TabIndex = 1;
            this.m_lnkCreateFinder.TabStop = true;
            this.m_lnkCreateFinder.Text = "Create finder|20883";
            this.m_lnkCreateFinder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkCreateFinder.Visible = false;
            this.m_lnkCreateFinder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreateFinder_LinkClicked);
            // 
            // CFormEditionTypeAgentSnmp
            // 
            this.AffectationsPourNouvelElement = ((System.Collections.Generic.IEnumerable<sc2i.formulaire.CAffectationsProprietes>)(resources.GetObject("$this.AffectationsPourNouvelElement")));
            this.ClientSize = new System.Drawing.Size(830, 530);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.c2iPanelOmbre4);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extLinkField.SetLinkFieldAutoUpdate(this, false);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_extModulesAssociator.SetModules(this, "");
            this.Name = "CFormEditionTypeAgentSnmp";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.TabControl = this.m_tabControl;
            this.OnInitPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeAgentSnmp_OnInitPage);
            this.OnMajChampsPage += new sc2i.win32.data.navigation.EventOnPageHandler(this.CFormEditionTypeAgentSnmp_OnMajChampsPage);
            this.Controls.SetChildIndex(this.m_panelMenu, 0);
            this.Controls.SetChildIndex(this.c2iPanelOmbre4, 0);
            this.Controls.SetChildIndex(this.m_tabControl, 0);
            this.Controls.SetChildIndex(this.button1, 0);
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
            this.m_pageAgentFinders.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.m_pageMIB.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.m_pageQueries.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.m_pageFonctions.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.m_pageHandlers.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.m_pageEntites.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion
		//-------------------------------------------------------------------------
		private CTypeAgentSnmp TypeAgentSnmp
		{
			get
			{
				return (CTypeAgentSnmp)ObjetEdite;
			}
		}
		//-------------------------------------------------------------------------
		protected override CResultAErreur MyInitChamps()
		{
            m_bPageMibInit = false;
            m_memoryDb = CMemoryDbPourSupervision.GetMemoryDb(TypeAgentSnmp.ContexteDonnee);
            CResultAErreur result = base.MyInitChamps();
            AffecterTitre(I.T("Snmp agent type @1|20270", TypeAgentSnmp.Libelle));
            DelayReloadMib();
			return result;
		}

		//-------------------------------------------------------------------------
        protected override CResultAErreur MAJ_Champs()
        {
            return base.MAJ_Champs();
        }

        //-------------------------------------------------------------------------
        private bool m_bPageMibInit = false;
        private CResultAErreur CFormEditionTypeAgentSnmp_OnInitPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if ( page == m_pageMIB )
            {
                m_panelListeMibs.Init (
                    new CListeObjetsDonnees ( TypeAgentSnmp.ContexteDonnee, typeof(CSnmpMibModule) ),
                    TypeAgentSnmp.RelationsModulesMib,
                    TypeAgentSnmp,
                    "TypeAgent",
                    "MibModule");
                m_bPageMibInit = true;
            }
            if (page == m_pageQueries)
            {
                FillListeQueries();
            }
            if (page == m_pageHandlers)
            {
                FillListeHandlers();
            }
            if(page == m_pageAgentFinders)
            {
                FillListeAgentFinders();
            }
            if (page == m_pageFonctions)
            {
                FillListeFonctions();
            }
            if (page == m_pageEntites)
            {
                CListeObjetsDonnees lst = TypeAgentSnmp.TypesEntites;
                lst.Filtre = new CFiltreData(CTypeEntiteSnmp.c_champIdTypeParent + " is null");
                m_panelTypesEntites.InitFromListeObjets(
                    lst,
                    typeof(CTypeEntiteSnmp),                    
                    TypeAgentSnmp,
                    "TypeAgentSnmp");
            }

            return result;
        }

        //-------------------------------------------------------------------------
        private CResultAErreur CFormEditionTypeAgentSnmp_OnMajChampsPage(object page)
        {
            CResultAErreur result = CResultAErreur.True;
            if (page == m_pageMIB)
            {
                m_panelListeMibs.ApplyModifs();
            }
            if (page == m_pageQueries)
            {
                TypeAgentSnmp.CommitQueries();
            }
            if (page == m_pageHandlers)
            {
                TypeAgentSnmp.CommitHandlers();
            }
            if(page == m_pageAgentFinders)
            {
                TypeAgentSnmp.CommitFinders();
            }
            return result;
        }

        //-------------------------------------------------------------------------
        private void FillListeQueries()
        {
            m_wndListeQueries.ListeSource = TypeAgentSnmp.Queries.ToArray();
            m_wndListeQueries.Refresh();
        }

        //---------------------------------------------------------------
        private void m_lnkAddQuery_LinkClicked(object sender, EventArgs e)
        {
            CEasyQuery query = new CEasyQuery();
            if (EditeQuery(query))
            {
                TypeAgentSnmp.AddQuery(query);
                FillListeQueries();
            }

        }

        //---------------------------------------------------------------
        private IDefinition GetMibRootDefinition()
        {
            return m_browser.RootDefinition;
        }

        //---------------------------------------------------------------
        private bool EditeQuery(CEasyQuery query)
        {
            CEasyQuerySource source = new CEasyQuerySource();
            CInterrogateurSnmp agent = new CInterrogateurSnmp();
            agent.Connexion = CTimosApp.DefaultSnmpConnexion;
            source.Connexion =new CSnmpConnexionForEasyQuery(agent);
            CTableDefinitionSNMP.FromMib(source, GetMibRootDefinition(), source.RootFolder);
            query.Sources = new CEasyQuerySource[] { source };
            return CFormEditEasyQuery.EditeQuery(query);
        }

        //---------------------------------------------------------------
        private void m_wndListeQueries_DoubleClick(object sender, EventArgs e)
        {
            EditeQuery();
        }

        //---------------------------------------------------------------
        private void EditeQuery()
        {
            if (m_wndListeQueries.SelectedItems.Count == 1 && m_gestionnaireModeEdition.ModeEdition)
            {
                CEasyQuery query = m_wndListeQueries.SelectedItems[0] as CEasyQuery;
                if (query != null)
                {
                    if (EditeQuery(query))
                        FillListeQueries();
                }
            }
        }

        //---------------------------------------------------------------
        private void m_lnkRemoveQuery_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeQueries.SelectedItems.Count == 1)
            {
                CEasyQuery query = m_wndListeQueries.SelectedItems[0] as CEasyQuery;
                if (query != null && CFormAlerte.Afficher (
                    I.T("Delete query @1 ?|20847", query.Libelle),
                    EFormAlerteBoutons.OuiNon, EFormAlerteType.Question ) == DialogResult.Yes )
                    TypeAgentSnmp.RemoveQuery(query);
            }
        }

        //---------------------------------------------------------------
        public IBaseTypesAlarmes BaseTypesAlarmes
        {
            get
            {
                if (m_baseTypesAlarmes == null)
                    m_baseTypesAlarmes = CTypeAlarme.GetBaseTypesAlarmes(CSc2iWin32DataClient.ContexteCourant);
                CCurentBaseTypesAlarmes.SetCurrentBase(m_baseTypesAlarmes);
                return m_baseTypesAlarmes;
            }
        }


        //---------------------------------------------------------------
        private void FillListeHandlers()
        {
            IEnumerable<CTrapHandler> handlers = TypeAgentSnmp.TrapHandlers;
            if (handlers.Count() > 0)
                m_memoryDb = handlers.ElementAt(0).Database;
            m_wndListeHandlers.ListeSource = handlers.ToArray();
            m_wndListeHandlers.Refresh();
        }

        //---------------------------------------------------------------
        private void EditeHandler()
        {
            if (m_wndListeHandlers.SelectedItems.Count == 1 && m_gestionnaireModeEdition.ModeEdition)
            {
                CTrapHandler handler = m_wndListeHandlers.SelectedItems[0] as CTrapHandler;
                if (handler != null)
                {
                    if (EditeTrapHandler(handler))
                    {
                        FillListeHandlers();
                    }
                }
            }
        }

       //---------------------------------------------------------------
        private bool EditeTrapHandler(CTrapHandler handler)
        {
            handler.TypeAgent = TypeAgentSnmp.GetTypeAgentPourSupervision(m_memoryDb);
            handler.TypeAgent.InterrogateurSNMP = new CInterrogateurSnmp(GetMibRootDefinition());
            handler.TypeAgent.InterrogateurSNMP.Connexion = CTimosApp.DefaultSnmpConnexion;
            return CFormEditeTrapHandler.EditeTrapHandler(handler,
                        BaseTypesAlarmes,
                        GetMibRootDefinition());
        }


        //---------------------------------------------------------------
        private void m_wndListeHandlers_DoubleClick(object sender, EventArgs e)
        {
            EditeHandler();
        }

        //---------------------------------------------------------------
        private void m_lnkAddHandler_LinkClicked(object sender, EventArgs e)
        {
            CTrapHandler handler = new CTrapHandler(m_memoryDb);
            handler.CreateNew();
            if (EditeTrapHandler(handler))
            {
                TypeAgentSnmp.AddTrapHandler(handler);
                FillListeHandlers();
            }
            else
                handler.Delete();
        }

        //---------------------------------------------------------------
        private void m_lnkDetailHandler_LinkClicked(object sender, EventArgs e)
        {
            EditeHandler();
        }

        //---------------------------------------------------------------
        private void m_lnkRemoveHandler_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeHandlers.SelectedItems.Count == 1)
            {
                CTrapHandler handler = m_wndListeHandlers.SelectedItems[0] as CTrapHandler;
                if (handler != null && CFormAlerte.Afficher (
                    I.T("Delete handler @1 ?|20846", handler.Libelle),
                    EFormAlerteBoutons.OuiNon, EFormAlerteType.Question ) == DialogResult.Yes )
                {
                    TypeAgentSnmp.RemoveTrapHandler(handler);
                    FillListeHandlers();

                }
            }
        }

        //---------------------------------------------------------------
        private void m_panelListeMibs_OnItemCheck(object sender, EventArgs e)
        {
            DelayReloadMib();
        }

        //---------------------------------------------------------------
        private void DelayReloadMib()
        {
            m_timerReloadMib.Stop();
            m_timerReloadMib.Start();
        }

        //---------------------------------------------------------------
        private void m_timerReloadMib_Tick(object sender, EventArgs e)
        {
            try
            {
                m_timerReloadMib.Stop();
                if (m_bPageMibInit)
                    m_panelListeMibs.ApplyModifs();
                m_browser.Init(TypeAgentSnmp.GetRootDefinitionFromMibs(), CTimosApp.DefaultSnmpConnexion);
            }
            catch
            {
            }
        }

        //---------------------------------------------------------------
        private void m_lnkCreateHandler_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IDefinition def = m_browser.SelectedDefinition;
            if (def != null)
            {
                if (def.Entity is NotificationType || def.Entity is TrapType)
                {
                    CTrapHandler handler = CTrapHandler.CreateFromMib(def.Tree, def, m_memoryDb);
                    if (handler != null)
                    {
                        if (EditeTrapHandler(handler))
                        {
                            TypeAgentSnmp.AddTrapHandler(handler);
                            FillListeHandlers();
                        }
                    }
                }
            }
        }

        //---------------------------------------------------------------
        private void m_browser_SelectedDefinitionChanged(object sender, EventArgs e)
        {
            m_lnkCreateFinder.Visible = m_lnkCreateHandler.Visible = m_browser.SelectedDefinition != null &&
            (m_browser.SelectedDefinition.Entity is NotificationType ||
            m_browser.SelectedDefinition.Entity is TrapType);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CTypeAgentPourSupervision ta =  TypeAgentSnmp.GetTypeAgentPourSupervision(null);
            CResultAErreur result = CSerializerObjetInFile.SaveToFile(ta, "TEST", "c:\\TEST.AGENT");
            ta = new CTypeAgentPourSupervision(new CMemoryDb());
            result = CSerializerObjetInFile.ReadFromFile(ta, "TEST", "c:\\TEST.AGENT");

        }

        private void m_lnkDetailQuery_LinkClicked(object sender, EventArgs e)
        {
            EditeQuery();
        }



        //-------------------------------------------------------------------------
        private void FillListeFonctions()
        {
            m_wndListeFonctions.ListeSource = TypeAgentSnmp.FonctionsDynamiques.ToArray();
            m_wndListeFonctions.Refresh();
        }

        //-------------------------------------------------------------------------
        private void m_btnAddFonction_LinkClicked(object sender, EventArgs e)
        {
            MAJ_Champs();
            CFonctionDynamique fonction = new CFonctionDynamique();
            if ( EditeFonction ( ref fonction ) )
            {
                TypeAgentSnmp.AddFonctionDynamique ( fonction );
                FillListeFonctions();
            }
        }

        //------------------------------------------------------------------------
        private bool EditeFonction ( ref CFonctionDynamique fonction )
        {
            CListeFonctionsDynamiques lstFonctions = new CListeFonctionsDynamiques();
            foreach ( CFonctionDynamique f in m_wndListeFonctions.ListeSource )
            {
                lstFonctions.Add ( f );
            }
            
            if ( CFormEditionFonctionDynamique.EditeFonction ( ref fonction,
                new CObjetPourSousProprietes(lstFonctions),
                new KeyValuePair<string, Type>("Trap",typeof(CTrapInstance) ),
                new KeyValuePair<string, Type>("Alarm", typeof(CLocalAlarme))))
            {
                return true;
            }
            return false;
        }

        
        //------------------------------------------------------------------------
        private void m_btnDetailFonction_LinkClicked(object sender, EventArgs e)
        {
            CFonctionDynamique fonction = null;
            if (m_wndListeFonctions.SelectedItems.Count == 1)
            {
                fonction = m_wndListeFonctions.SelectedItems[0] as CFonctionDynamique;
                if (fonction != null)
                {
                    if (EditeFonction(ref fonction))
                    {
                        TypeAgentSnmp.AddFonctionDynamique(fonction);
                        FillListeFonctions();
                    }
                }
            }                
        }

        //------------------------------------------------------------------------
        private void m_btnRemoveFonction_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListeFonctions.SelectedItems.Count == 1)
            {
                CFonctionDynamique fonction = m_wndListeFonctions.SelectedItems[0] as CFonctionDynamique;
                if (fonction != null && CFormAlerte.Afficher (
                    I.T("Delete function @1 ?|20848", fonction.Nom),
                    EFormAlerteBoutons.OuiNon, EFormAlerteType.Question ) == DialogResult.Yes )
                {
                    TypeAgentSnmp.RemoveFonctionDynamique ( fonction );
                    FillListeFonctions();

                }
            }
        }

        //-------------------------------------------------------------------------
        private void m_lnkAddFinder_LinkClicked(object sender, EventArgs e)
        {
            CAgentFinderFromKey agentFinder = new CAgentFinderFromKey(m_memoryDb);
            agentFinder.CreateNew();
            if (EditeAgentFinder(agentFinder))
            {
                TypeAgentSnmp.AddAgentFinder(agentFinder);
                FillListeAgentFinders();
            }
            else
                agentFinder.Delete();
        }

        //-------------------------------------------------------------------------
        private void m_lnkDetailFinder_LinkClicked(object sender, EventArgs e)
        {
            EditeAgentFinder();
        }

        //-------------------------------------------------------------------------
        private void m_lnkRemoveFinder_LinkClicked(object sender, EventArgs e)
        {
            if (m_wndListAgentFinders.SelectedItems.Count == 1)
            {
                CAgentFinderFromKey agentFinder = m_wndListAgentFinders.SelectedItems[0] as CAgentFinderFromKey;
                if (agentFinder != null && CFormAlerte.Afficher(
                    I.T("Delete Agent Finder @1 ?|10422", agentFinder.Libelle),
                    EFormAlerteBoutons.OuiNon, EFormAlerteType.Question) == DialogResult.Yes)
                {
                    TypeAgentSnmp.RemoveAgentFinder(agentFinder);
                    FillListeAgentFinders();

                }
            }
        }

        //---------------------------------------------------------------
        private void FillListeAgentFinders()
        {
            IEnumerable<CAgentFinderFromKey> finders = TypeAgentSnmp.AgentFinders;
            if (finders.Count() > 0)
                m_memoryDb = finders.ElementAt(0).Database;
            m_wndListAgentFinders.ListeSource = finders.ToArray();
            m_wndListAgentFinders.Refresh();
        }

        //------------------------------------------------------------------------
        private void EditeAgentFinder()
        {
            if (m_wndListAgentFinders.SelectedItems.Count == 1 && m_gestionnaireModeEdition.ModeEdition)
            {
                CAgentFinderFromKey agentFinder = m_wndListAgentFinders.SelectedItems[0] as CAgentFinderFromKey;
                if (agentFinder!= null)
                {
                    if(EditeAgentFinder(agentFinder))
                    {
                        FillListeAgentFinders();
                    }
                }
            }
        }

        //------------------------------------------------------------------------
        private bool EditeAgentFinder(CAgentFinderFromKey agentFinder)
        {
            agentFinder.TypeAgent = TypeAgentSnmp.GetTypeAgentPourSupervision(m_memoryDb);
            agentFinder.TypeAgent.InterrogateurSNMP = new CInterrogateurSnmp(GetMibRootDefinition());
            agentFinder.TypeAgent.InterrogateurSNMP.Connexion = CTimosApp.DefaultSnmpConnexion;
            bool bResult = CFormEditAgentFinder.EditeAgentFinder(
                                   agentFinder,
                                   BaseTypesAlarmes,
                                   GetMibRootDefinition());

            return bResult;
        }

        //------------------------------------------------------------------------
        private void m_wndListAgentFinders_DoubleClick(object sender, EventArgs e)
        {
            EditeAgentFinder();
        }

        //------------------------------------------------------------------------
        private void m_lnkCreateFinder_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            IDefinition def = m_browser.SelectedDefinition;
            if (def != null)
            {
                if (def.Entity is NotificationType || def.Entity is TrapType)
                {
                    CAgentFinderFromKey finder = CAgentFinderFromKey.CreateFromMib(def.Tree, def, m_memoryDb);
                    if (finder != null)
                    {
                        if (EditeAgentFinder(finder))
                        {
                            TypeAgentSnmp.AddAgentFinder(finder);
                            FillListeAgentFinders();
                        }
                    }
                }
            }
        }        


	}
}

