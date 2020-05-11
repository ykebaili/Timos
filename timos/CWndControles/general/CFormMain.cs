using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Threading;

using sc2i.multitiers.client;
using sc2i.common;
using sc2i.win32.navigation;
using sc2i.win32.common;
using sc2i.data;
using sc2i.win32.data;
using sc2i.win32.data.navigation;

using timos.acteurs;
using timos.securite;
using timos.data;
using timos.general;
using timos.client;
using timos.Parametrage;
using sc2i.workflow;
using Lys.Licence;
using System.Collections.Generic;
using System.Text;
using sc2i.expression.Debug;
using sc2i.win32.expression.debug;

namespace timos
{
	/// <summary>
	/// Description résumée de CFormMain.
	/// </summary>
	public class CFormMain : CFormNavigateur, IFormAChargement
	{


		#region Code généré par le Concepteur Windows Form

        private CheckBox m_chkDebugger = null;
		private System.Windows.Forms.Panel m_panelTop;
		private System.Windows.Forms.Button m_btnPagePrecedente;
		private System.Windows.Forms.Button m_btnPageSuivante;
		private System.Windows.Forms.Button m_btnHome;
		private System.Windows.Forms.StatusBar m_statusBar;
		private System.Windows.Forms.StatusBarPanel m_panelInfo;
		private System.Windows.Forms.StatusBarPanel m_panelMaj;
        private System.Windows.Forms.StatusBarPanel m_panelRecherche;
        private System.Windows.Forms.StatusBarPanel m_panelNum;
		private System.Windows.Forms.StatusBarPanel m_panelDates;
		private System.Windows.Forms.Timer m_timerTemoins;
		private System.Windows.Forms.Label m_lblUser;
		private timos.CPanelMenu m_panelMenu;
		private CPanelAutoHide m_panelForMenu;
		private timos.CPanelNotificationUtilisateur m_panNotification;
        private sc2i.win32.common.CExtStyle cExtStyle1;
        private Button m_btnExit;
		private CControleChat m_controleChat;
        private Splitter splitter1;
		private Label m_lblVersion;
		private System.Windows.Forms.Timer m_timerClignote;
		private Panel m_panelVersion;
		private Button m_btnInfos;
		private CWaiteurPourFormTimos m_waiteur;
        private PictureBox m_picLogoTimos;
        private Splitter m_splitterMenu;
        private Panel m_panelUser;
        private Button m_btnRefresh;
        private Button m_btnMSN;
		private System.ComponentModel.IContainer components;
        private CWndPushPine m_leftPine;
        private Panel m_panelMarge;
        private timos.Controles.MemoObjets.CMemoObjets m_memo;
        private Panel panel3;
        private Panel panel2;
        private Panel panel1;
        private System.Windows.Forms.Timer m_timerAlerteLicence;
        private bool m_bHasAlertes = false;
        private System.Windows.Forms.Timer m_timerCheckLicence;

        CToolTipTraductible m_toolTip;


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

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormMain));
            this.m_toolTip = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_btnInfos = new System.Windows.Forms.Button();
            this.m_btnRefresh = new System.Windows.Forms.Button();
            this.m_btnExit = new System.Windows.Forms.Button();
            this.m_btnHome = new System.Windows.Forms.Button();
            this.m_btnPageSuivante = new System.Windows.Forms.Button();
            this.m_btnPagePrecedente = new System.Windows.Forms.Button();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_memo = new timos.Controles.MemoObjets.CMemoObjets();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelUser = new System.Windows.Forms.Panel();
            this.m_panNotification = new timos.CPanelNotificationUtilisateur();
            this.m_lblUser = new System.Windows.Forms.Label();
            this.m_btnMSN = new System.Windows.Forms.Button();
            this.m_panelVersion = new System.Windows.Forms.Panel();
            this.m_lblVersion = new System.Windows.Forms.Label();
            this.m_statusBar = new System.Windows.Forms.StatusBar();
            this.m_panelInfo = new System.Windows.Forms.StatusBarPanel();
            this.m_panelDates = new System.Windows.Forms.StatusBarPanel();
            this.m_panelRecherche = new System.Windows.Forms.StatusBarPanel();
            this.m_panelMaj = new System.Windows.Forms.StatusBarPanel();
            this.m_panelNum = new System.Windows.Forms.StatusBarPanel();
            this.m_timerTemoins = new System.Windows.Forms.Timer(this.components);
            this.m_panelForMenu = new sc2i.win32.common.CPanelAutoHide();
            this.m_leftPine = new sc2i.win32.common.CWndPushPine();
            this.m_panelMenu = new timos.CPanelMenu();
            this.m_picLogoTimos = new System.Windows.Forms.PictureBox();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_splitterMenu = new System.Windows.Forms.Splitter();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_controleChat = new timos.CControleChat();
            this.m_timerClignote = new System.Windows.Forms.Timer(this.components);
            this.m_timerAlerteLicence = new System.Windows.Forms.Timer(this.components);
            this.m_timerCheckLicence = new System.Windows.Forms.Timer(this.components);
            this.m_waiteur = new timos.CWaiteurPourFormTimos();
            this.m_panelForMainTabs.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            this.m_panelUser.SuspendLayout();
            this.m_panelVersion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelDates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelRecherche)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelMaj)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelNum)).BeginInit();
            this.m_panelForMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_leftPine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picLogoTimos)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelForMainTabs
            // 
            this.m_panelForMainTabs.Controls.Add(this.m_panelMarge);
            this.m_panelForMainTabs.Location = new System.Drawing.Point(169, 32);
            this.m_panelForMainTabs.Size = new System.Drawing.Size(633, 417);
            this.cExtStyle1.SetStyleBackColor(this.m_panelForMainTabs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelForMainTabs, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelForMainTabs.Controls.SetChildIndex(this.m_panelMarge, 0);
            // 
            // m_btnInfos
            // 
            this.m_btnInfos.BackColor = System.Drawing.Color.Transparent;
            this.m_btnInfos.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnInfos.FlatAppearance.BorderSize = 0;
            this.m_btnInfos.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnInfos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnInfos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnInfos.Image = global::timos.Properties.Resources.aboutbox;
            this.m_btnInfos.Location = new System.Drawing.Point(196, 0);
            this.m_btnInfos.Name = "m_btnInfos";
            this.m_btnInfos.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_btnInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnInfos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnInfos.TabIndex = 2;
            this.m_toolTip.SetToolTip(this.m_btnInfos, "About Timos|10022");
            this.m_btnInfos.UseVisualStyleBackColor = false;
            this.m_btnInfos.Click += new System.EventHandler(this.m_btnInfos_Click);
            // 
            // m_btnRefresh
            // 
            this.m_btnRefresh.BackColor = System.Drawing.Color.Transparent;
            this.m_btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnRefresh.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnRefresh.FlatAppearance.BorderSize = 0;
            this.m_btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("m_btnRefresh.Image")));
            this.m_btnRefresh.Location = new System.Drawing.Point(114, 0);
            this.m_btnRefresh.Name = "m_btnRefresh";
            this.m_btnRefresh.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_btnRefresh, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnRefresh, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnRefresh.TabIndex = 2;
            this.m_toolTip.SetToolTip(this.m_btnRefresh, "Update current page|10019");
            this.m_btnRefresh.UseVisualStyleBackColor = false;
            this.m_btnRefresh.Click += new System.EventHandler(this.m_btnRefresh_Click);
            // 
            // m_btnExit
            // 
            this.m_btnExit.BackColor = System.Drawing.Color.Transparent;
            this.m_btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnExit.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnExit.FlatAppearance.BorderSize = 0;
            this.m_btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnExit.Image = ((System.Drawing.Image)(resources.GetObject("m_btnExit.Image")));
            this.m_btnExit.Location = new System.Drawing.Point(164, 0);
            this.m_btnExit.Name = "m_btnExit";
            this.m_btnExit.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_btnExit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnExit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnExit.TabIndex = 2;
            this.m_toolTip.SetToolTip(this.m_btnExit, "Exit Timos|10020");
            this.m_btnExit.UseVisualStyleBackColor = false;
            this.m_btnExit.Click += new System.EventHandler(this.m_btnExit_Click);
            // 
            // m_btnHome
            // 
            this.m_btnHome.BackColor = System.Drawing.Color.Transparent;
            this.m_btnHome.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnHome.FlatAppearance.BorderSize = 0;
            this.m_btnHome.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnHome.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnHome.Image = ((System.Drawing.Image)(resources.GetObject("m_btnHome.Image")));
            this.m_btnHome.Location = new System.Drawing.Point(64, 0);
            this.m_btnHome.Name = "m_btnHome";
            this.m_btnHome.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_btnHome, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnHome, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnHome.TabIndex = 2;
            this.m_toolTip.SetToolTip(this.m_btnHome, "Home page|10021");
            this.m_btnHome.UseVisualStyleBackColor = false;
            this.m_btnHome.Click += new System.EventHandler(this.m_btnHome_Click);
            // 
            // m_btnPageSuivante
            // 
            this.m_btnPageSuivante.BackColor = System.Drawing.Color.Transparent;
            this.m_btnPageSuivante.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnPageSuivante.FlatAppearance.BorderSize = 0;
            this.m_btnPageSuivante.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnPageSuivante.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnPageSuivante.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnPageSuivante.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPageSuivante.Image")));
            this.m_btnPageSuivante.Location = new System.Drawing.Point(32, 0);
            this.m_btnPageSuivante.Name = "m_btnPageSuivante";
            this.m_btnPageSuivante.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_btnPageSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnPageSuivante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnPageSuivante.TabIndex = 1;
            this.m_toolTip.SetToolTip(this.m_btnPageSuivante, "Next page|10018");
            this.m_btnPageSuivante.UseVisualStyleBackColor = false;
            this.m_btnPageSuivante.Click += new System.EventHandler(this.m_btnPageSuivante_Click);
            // 
            // m_btnPagePrecedente
            // 
            this.m_btnPagePrecedente.BackColor = System.Drawing.Color.Transparent;
            this.m_btnPagePrecedente.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnPagePrecedente.FlatAppearance.BorderSize = 0;
            this.m_btnPagePrecedente.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnPagePrecedente.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnPagePrecedente.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnPagePrecedente.Image = ((System.Drawing.Image)(resources.GetObject("m_btnPagePrecedente.Image")));
            this.m_btnPagePrecedente.Location = new System.Drawing.Point(0, 0);
            this.m_btnPagePrecedente.Name = "m_btnPagePrecedente";
            this.m_btnPagePrecedente.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_btnPagePrecedente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnPagePrecedente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnPagePrecedente.TabIndex = 0;
            this.m_toolTip.SetToolTip(this.m_btnPagePrecedente, "Previous page|10017");
            this.m_btnPagePrecedente.UseVisualStyleBackColor = false;
            this.m_btnPagePrecedente.Click += new System.EventHandler(this.m_btnPagePrecedente_Click);
            this.m_btnPagePrecedente.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_btnPagePrecedente_MouseUp);
            // 
            // m_panelTop
            // 
            this.m_panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(41)))), ((int)(((byte)(131)))));
            this.m_panelTop.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelTop.BackgroundImage")));
            this.m_panelTop.Controls.Add(this.m_memo);
            this.m_panelTop.Controls.Add(this.panel3);
            this.m_panelTop.Controls.Add(this.m_btnInfos);
            this.m_panelTop.Controls.Add(this.m_btnExit);
            this.m_panelTop.Controls.Add(this.panel2);
            this.m_panelTop.Controls.Add(this.m_btnRefresh);
            this.m_panelTop.Controls.Add(this.panel1);
            this.m_panelTop.Controls.Add(this.m_panelUser);
            this.m_panelTop.Controls.Add(this.m_panelVersion);
            this.m_panelTop.Controls.Add(this.m_btnHome);
            this.m_panelTop.Controls.Add(this.m_btnPageSuivante);
            this.m_panelTop.Controls.Add(this.m_btnPagePrecedente);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.ForeColor = System.Drawing.Color.Black;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(1003, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 2;
            // 
            // m_memo
            // 
            this.m_memo.AllowDrop = true;
            this.m_memo.BackColor = System.Drawing.Color.Transparent;
            this.m_memo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_memo.BackgroundImage")));
            this.m_memo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_memo.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_memo.Location = new System.Drawing.Point(246, 0);
            this.m_memo.Name = "m_memo";
            this.m_memo.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_memo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_memo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_memo.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(228, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(18, 32);
            this.cExtStyle1.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 12;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(146, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(18, 32);
            this.cExtStyle1.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 11;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(96, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(18, 32);
            this.cExtStyle1.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 10;
            // 
            // m_panelUser
            // 
            this.m_panelUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelUser.BackColor = System.Drawing.Color.Transparent;
            this.m_panelUser.Controls.Add(this.m_panNotification);
            this.m_panelUser.Controls.Add(this.m_lblUser);
            this.m_panelUser.Controls.Add(this.m_btnMSN);
            this.m_panelUser.Location = new System.Drawing.Point(767, 0);
            this.m_panelUser.Name = "m_panelUser";
            this.m_panelUser.Size = new System.Drawing.Size(236, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_panelUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelUser.TabIndex = 8;
            // 
            // m_panNotification
            // 
            this.m_panNotification.BackColor = System.Drawing.Color.Transparent;
            this.m_panNotification.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panNotification.ForeColor = System.Drawing.Color.Black;
            this.m_panNotification.Location = new System.Drawing.Point(0, 0);
            this.m_panNotification.Name = "m_panNotification";
            this.m_panNotification.Size = new System.Drawing.Size(74, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_panNotification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panNotification, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panNotification.TabIndex = 4;
            // 
            // m_lblUser
            // 
            this.m_lblUser.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblUser.ForeColor = System.Drawing.Color.White;
            this.m_lblUser.Location = new System.Drawing.Point(74, 0);
            this.m_lblUser.Name = "m_lblUser";
            this.m_lblUser.Size = new System.Drawing.Size(130, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_lblUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lblUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblUser.TabIndex = 3;
            this.m_lblUser.Text = "User EXEMPLE";
            this.m_lblUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_btnMSN
            // 
            this.m_btnMSN.BackColor = System.Drawing.Color.Transparent;
            this.m_btnMSN.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnMSN.FlatAppearance.BorderSize = 0;
            this.m_btnMSN.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(60)))), ((int)(((byte)(161)))));
            this.m_btnMSN.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(190)))));
            this.m_btnMSN.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnMSN.Image = ((System.Drawing.Image)(resources.GetObject("m_btnMSN.Image")));
            this.m_btnMSN.Location = new System.Drawing.Point(204, 0);
            this.m_btnMSN.Name = "m_btnMSN";
            this.m_btnMSN.Size = new System.Drawing.Size(32, 32);
            this.cExtStyle1.SetStyleBackColor(this.m_btnMSN, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnMSN, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnMSN.TabIndex = 2;
            this.m_btnMSN.UseVisualStyleBackColor = false;
            this.m_btnMSN.Click += new System.EventHandler(this.m_btnMSN_Click);
            // 
            // m_panelVersion
            // 
            this.m_panelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelVersion.BackColor = System.Drawing.Color.Red;
            this.m_panelVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelVersion.Controls.Add(this.m_lblVersion);
            this.m_panelVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_panelVersion.Location = new System.Drawing.Point(315, 4);
            this.m_panelVersion.Name = "m_panelVersion";
            this.m_panelVersion.Size = new System.Drawing.Size(446, 23);
            this.cExtStyle1.SetStyleBackColor(this.m_panelVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelVersion.TabIndex = 7;
            this.m_panelVersion.Visible = false;
            this.m_panelVersion.VisibleChanged += new System.EventHandler(this.m_panelVersion_VisibleChanged);
            this.m_panelVersion.Click += new System.EventHandler(this.m_lblVersion_Click);
            // 
            // m_lblVersion
            // 
            this.m_lblVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblVersion.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lblVersion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblVersion.ForeColor = System.Drawing.Color.Black;
            this.m_lblVersion.Location = new System.Drawing.Point(0, 0);
            this.m_lblVersion.Name = "m_lblVersion";
            this.m_lblVersion.Size = new System.Drawing.Size(444, 21);
            this.cExtStyle1.SetStyleBackColor(this.m_lblVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lblVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblVersion.TabIndex = 6;
            this.m_lblVersion.Text = "VERSION V1";
            this.m_lblVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblVersion.Visible = false;
            this.m_lblVersion.Click += new System.EventHandler(this.m_lblVersion_Click);
            // 
            // m_statusBar
            // 
            this.m_statusBar.Location = new System.Drawing.Point(0, 449);
            this.m_statusBar.Name = "m_statusBar";
            this.m_statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.m_panelInfo,
            this.m_panelDates,
            this.m_panelRecherche,
            this.m_panelMaj,
            this.m_panelNum});
            this.m_statusBar.ShowPanels = true;
            this.m_statusBar.Size = new System.Drawing.Size(1003, 22);
            this.cExtStyle1.SetStyleBackColor(this.m_statusBar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_statusBar, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_statusBar.TabIndex = 3;
            // 
            // m_panelInfo
            // 
            this.m_panelInfo.Alignment = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_panelInfo.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.m_panelInfo.Name = "m_panelInfo";
            this.m_panelInfo.Width = 876;
            // 
            // m_panelDates
            // 
            this.m_panelDates.Name = "m_panelDates";
            this.m_panelDates.Width = 25;
            // 
            // m_panelRecherche
            // 
            this.m_panelRecherche.Name = "m_panelRecherche";
            this.m_panelRecherche.Width = 25;
            // 
            // m_panelMaj
            // 
            this.m_panelMaj.Name = "m_panelMaj";
            this.m_panelMaj.Text = "MAJ";
            this.m_panelMaj.Width = 30;
            // 
            // m_panelNum
            // 
            this.m_panelNum.Name = "m_panelNum";
            this.m_panelNum.Text = "NUM";
            this.m_panelNum.Width = 30;
            // 
            // m_timerTemoins
            // 
            this.m_timerTemoins.Enabled = true;
            this.m_timerTemoins.Interval = 500;
            this.m_timerTemoins.Tick += new System.EventHandler(this.m_timerTemoins_Tick);
            // 
            // m_panelForMenu
            // 
            this.m_panelForMenu.AutoHide = false;
            this.m_panelForMenu.BackColor = System.Drawing.Color.White;
            this.m_panelForMenu.Controls.Add(this.m_leftPine);
            this.m_panelForMenu.Controls.Add(this.m_panelMenu);
            this.m_panelForMenu.Controls.Add(this.m_picLogoTimos);
            this.m_panelForMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelForMenu.HiddenSize = 8;
            this.m_panelForMenu.Location = new System.Drawing.Point(0, 32);
            this.m_panelForMenu.Name = "m_panelForMenu";
            this.m_panelForMenu.Size = new System.Drawing.Size(166, 417);
            this.cExtStyle1.SetStyleBackColor(this.m_panelForMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelForMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelForMenu.TabIndex = 6;
            this.m_panelForMenu.HiddenChanged += new System.EventHandler(this.m_panelForMenu_HiddenChanged);
            this.m_panelForMenu.AutoHideChanged += new System.EventHandler(this.m_panelForMenu_AutoHideChanged);
            // 
            // m_leftPine
            // 
            this.m_leftPine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_leftPine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_leftPine.Image = ((System.Drawing.Image)(resources.GetObject("m_leftPine.Image")));
            this.m_leftPine.Location = new System.Drawing.Point(137, 3);
            this.m_leftPine.Name = "m_leftPine";
            this.m_leftPine.Pined = false;
            this.m_leftPine.Size = new System.Drawing.Size(26, 24);
            this.m_leftPine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.cExtStyle1.SetStyleBackColor(this.m_leftPine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_leftPine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_leftPine.TabIndex = 11;
            this.m_leftPine.TabStop = false;
            this.m_leftPine.PineChanged += new System.EventHandler(this.m_leftPine_PineChanged);
            // 
            // m_panelMenu
            // 
            this.m_panelMenu.BackColor = System.Drawing.Color.White;
            this.m_panelMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panelMenu.BackgroundImage")));
            this.m_panelMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.m_panelMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelMenu.Location = new System.Drawing.Point(0, 83);
            this.m_panelMenu.Name = "m_panelMenu";
            this.m_panelMenu.Size = new System.Drawing.Size(166, 334);
            this.cExtStyle1.SetStyleBackColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMenu.TabIndex = 5;
            // 
            // m_picLogoTimos
            // 
            this.m_picLogoTimos.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_picLogoTimos.Image = ((System.Drawing.Image)(resources.GetObject("m_picLogoTimos.Image")));
            this.m_picLogoTimos.InitialImage = null;
            this.m_picLogoTimos.Location = new System.Drawing.Point(0, 0);
            this.m_picLogoTimos.Name = "m_picLogoTimos";
            this.m_picLogoTimos.Size = new System.Drawing.Size(166, 83);
            this.m_picLogoTimos.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cExtStyle1.SetStyleBackColor(this.m_picLogoTimos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_picLogoTimos, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_picLogoTimos.TabIndex = 10;
            this.m_picLogoTimos.TabStop = false;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(802, 32);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 417);
            this.cExtStyle1.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 8;
            this.splitter1.TabStop = false;
            // 
            // m_splitterMenu
            // 
            this.m_splitterMenu.Location = new System.Drawing.Point(166, 32);
            this.m_splitterMenu.Name = "m_splitterMenu";
            this.m_splitterMenu.Size = new System.Drawing.Size(3, 417);
            this.cExtStyle1.SetStyleBackColor(this.m_splitterMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_splitterMenu, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_splitterMenu.TabIndex = 9;
            this.m_splitterMenu.TabStop = false;
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 0);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(200, 417);
            this.cExtStyle1.SetStyleBackColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMarge.TabIndex = 12;
            this.m_panelMarge.Visible = false;
            // 
            // m_controleChat
            // 
            this.m_controleChat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_controleChat.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_controleChat.ForeColor = System.Drawing.Color.Black;
            this.m_controleChat.Location = new System.Drawing.Point(805, 32);
            this.m_controleChat.Name = "m_controleChat";
            this.m_controleChat.Size = new System.Drawing.Size(198, 417);
            this.cExtStyle1.SetStyleBackColor(this.m_controleChat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_controleChat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_controleChat.TabIndex = 7;
            this.m_controleChat.Visible = false;
            // 
            // m_timerClignote
            // 
            this.m_timerClignote.Interval = 500;
            this.m_timerClignote.Tick += new System.EventHandler(this.m_timerClignote_Tick);
            // 
            // m_timerAlerteLicence
            // 
            this.m_timerAlerteLicence.Interval = 500;
            this.m_timerAlerteLicence.Tick += new System.EventHandler(this.m_timerAlerteLicence_Tick);
            // 
            // m_timerCheckLicence
            // 
            this.m_timerCheckLicence.Enabled = true;
            this.m_timerCheckLicence.Interval = 60000;
            this.m_timerCheckLicence.Tick += new System.EventHandler(this.m_timerCheckLicence_Tick);
            // 
            // m_waiteur
            // 
            this.m_waiteur.Formulaire = this;
            // 
            // CFormMain
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1003, 471);
            this.Controls.Add(this.m_splitterMenu);
            this.Controls.Add(this.m_panelForMenu);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_controleChat);
            this.Controls.Add(this.m_statusBar);
            this.Controls.Add(this.m_panelTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CFormMain";
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Futurocom - TIMOS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CFormMain_Load);
            this.Shown += new System.EventHandler(this.CFormMain_Shown);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CFormMain_Closing);
            this.Controls.SetChildIndex(this.m_panelTop, 0);
            this.Controls.SetChildIndex(this.m_statusBar, 0);
            this.Controls.SetChildIndex(this.m_controleChat, 0);
            this.Controls.SetChildIndex(this.splitter1, 0);
            this.Controls.SetChildIndex(this.m_panelForMenu, 0);
            this.Controls.SetChildIndex(this.m_splitterMenu, 0);
            this.Controls.SetChildIndex(this.m_panelForMainTabs, 0);
            this.m_panelForMainTabs.ResumeLayout(false);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelUser.ResumeLayout(false);
            this.m_panelVersion.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_panelInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelDates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelRecherche)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelMaj)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_panelNum)).EndInit();
            this.m_panelForMenu.ResumeLayout(false);
            this.m_panelForMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_leftPine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_picLogoTimos)).EndInit();
            this.ResumeLayout(false);

		}


		#endregion


		/*[DllImport("user32")] 
		public static extern int GetKeyState(int nVirtKey);*/

		public CFormMain()
		{


			InitializeComponent();

			if (DebutChargement != null)
				DebutChargement(this, new EventArgs());

			m_instance = this;
			m_funcEditeElement = new EditeElementDelegate(EditeElementInterne);

			m_recepteurChangementPartenaire = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationModificationContexteDonnee));
			m_recepteurChangementPartenaire.OnReceiveNotification += new NotificationEventHandler(m_recepteurChangementPartenaire_OnReceiveNotification);

			m_recepteurMessage = new CRecepteurNotification(CTimosApp.SessionClient.IdSession, typeof(CDonneeNotificationMessageInstantane));
			m_recepteurMessage.OnReceiveNotification += new NotificationEventHandler(m_recepteurMessage_OnReceiveNotification);

			string strRep = AppDomain.CurrentDomain.BaseDirectory;
			if ( strRep[strRep.Length-1] != '\\' )
				strRep += "\\";
			if ( !Directory.Exists(strRep+"TimosHelp") )
				Directory.CreateDirectory ( strRep+"TimosHelp");
			HelpExtender.CHelpData.SetSourceAide ( new HelpExtender.CSourceAideFichier(strRep + "TimosHelp") );
			HelpExtender.CHelpExtender.Init(true);

			CFournisseurContexteDonnee.GetInstance().ContexteCourant.OnChangeVersionDeTravail += new EventHandler(ContexteCourant_OnChangeVersionDeTravail);

            // Bouton Modules dans la barre d'état
            Button btnModules = new Button();
            Image image = timos.Properties.Resources.Small_Folder_Blue;
            btnModules.FlatStyle = FlatStyle.Flat;
            btnModules.FlatAppearance.BorderSize = 0;
            btnModules.FlatAppearance.MouseOverBackColor = Color.Gray;
            btnModules.FlatAppearance.MouseDownBackColor = Color.DarkGray;
            btnModules.BackColor = Color.Transparent;
            btnModules.Location = new Point(10, 2);
            btnModules.Size = new Size(22, 20);
            btnModules.Image = image;
            btnModules.ImageAlign = ContentAlignment.MiddleCenter;
            m_statusBar.Controls.Add(btnModules);
            btnModules.Click += new EventHandler(btnModules_Click);

            btnModules.Visible = CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
                CDroitDeBase.c_droitBaseModulesParametrage) != null;

            // Bouton Debug dans la barre d'état
            m_chkDebugger = new CheckBox();
            m_chkDebugger.Appearance = System.Windows.Forms.Appearance.Button;
            m_chkDebugger.AutoSize = false;
            m_chkDebugger.Image = global::timos.Properties.Resources.debug;
            m_chkDebugger.Location = new Point ( btnModules.Right+1, btnModules.Top );
            m_chkDebugger.Size = new System.Drawing.Size(22, 20);
            m_chkDebugger.ImageAlign = ContentAlignment.MiddleCenter;
            m_chkDebugger.TabStop = false;
            m_chkDebugger.UseVisualStyleBackColor = true;
            m_chkDebugger.FlatStyle = FlatStyle.Popup;
            m_statusBar.Controls.Add(m_chkDebugger);
            m_chkDebugger.CheckedChanged += new EventHandler(m_chkDebugger_CheckedChanged);

            m_chkDebugger.Visible = CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
                CDroitDeBaseSC2I.c_droitAdministration) != null;

            m_controleChat.Enabled = CTimosApp.SessionClient.GetInfoUtilisateur().GetDonneeDroit(
                CDonneeNotificationMessageInstantane.c_droitEnvoiMessageInstantane) != null;

            CDebuggerFormule.OnChangeAllocateurInterface += new EventHandler(CDebuggerFormule_OnChangeAllocateurInterface);
		}

        //----------------------------------------
        void CDebuggerFormule_OnChangeAllocateurInterface(object sender, EventArgs e)
        {
            BeginInvoke(new UpdateCheckDebugDelegate(UpdateCheckDebug));
        }

        //----------------------------------------
        private delegate void UpdateCheckDebugDelegate();
        private void UpdateCheckDebug()
        {
            m_bHandleCheckDebug = false;
            m_chkDebugger.Checked = CDebuggerFormule.IsEnabled;
            m_bHandleCheckDebug = true;
        }



        //----------------------------------------
        private bool m_bHandleCheckDebug = true;
        void m_chkDebugger_CheckedChanged(object sender, EventArgs e)
        {
            if (m_bHandleCheckDebug)
            {
                try
                {
                    m_bHandleCheckDebug = false;
                    CheckBox chk = sender as CheckBox;
                    if (chk != null)
                    {
                        if (chk.Checked && !CDebuggerFormule.IsEnabled)
                            CDebuggerFormule.SetAllocateurInterfaceDebugger(new CAllocateurInterfaceDebug());
                        if (!chk.Checked && CDebuggerFormule.IsEnabled)
                            CDebuggerFormule.SetAllocateurInterfaceDebugger(null);
                    }
                }
                finally
                {
                    m_bHandleCheckDebug = true;
                }
            }
            m_chkDebugger.BackColor = CDebuggerFormule.IsEnabled ? Color.Red : m_statusBar.Controls[0].BackColor;
            
        }

        void btnModules_Click(object sender, EventArgs e)
        {
            CFormEditModulesParametrage.EditModules();
        }

		private void CFormMain_Load(object sender, System.EventArgs e)
		{
			CSc2iWin32DataNavigation.Init(this, CTimosAppRegistre.ClePrincipale);
			CWin32Traducteur.Translate(this);
            m_panelForMenu.ReadPreference();
            if ( m_leftPine.Pined == m_panelForMenu.AutoHide )
                m_leftPine.Pined = !m_panelForMenu.AutoHide;
            ArrangePanelMenu();
            if (m_panelForMenu.AutoHide)
                m_panelForMenu.SetHidden(false);
            


			AffichePage(new CFormAccueilVide());
			try
			{
				int nIdSession = CTimosApp.SessionClient.IdSession;
				m_lblUser.Text = CTimosApp.SessionClient.GetInfoUtilisateur().NomUtilisateur;

                CInfoLicenceUserProfil profil = (CInfoLicenceUserProfil)CTimosApp.SessionClient.GetPropriete(CInfoLicenceUserProfil.c_nomIdentification);
                m_toolTip.SetToolTip(m_lblUser, profil.Nom);

			}
			catch
			{ }

            CheckLicence(true);
            
		
		}


		private CRecepteurNotification m_recepteurMessage = null;

		private CRecepteurNotification m_recepteurChangementPartenaire = null;
		private int m_nIdActeur = -1;
		private static CFormMain m_instance = null;
		

		public static CFormMain GetInstance()
		{
			return m_instance;
		}

		//------------------------------------------------------
		private void m_recepteurMessage_OnReceiveNotification(IDonneeNotification donnee)
		{
			if (donnee is CDonneeNotificationMessageInstantane)
			{
				CDonneeNotificationMessageInstantane message = (CDonneeNotificationMessageInstantane)donnee;
				try
				{
					if (message.IdUtilisateurDestinataire == CTimosApp.SessionClient.GetInfoUtilisateur().IdUtilisateur)
					{
						m_controleChat.OnMessage(message.IdEnvoyeur, message.Message);
					}
				}
				catch
				{
				}
			}
		}

		//------------------------------------------------------
		public void ShowChatUser(int nIdUser)
		{
			m_controleChat.OnMessage(nIdUser, null);
		}

		private void m_recepteurChangementPartenaire_OnReceiveNotification(IDonneeNotification donnee)
		{
			try
			{
				if (donnee is CDonneeNotificationModificationContexteDonnee)
				{
					CDonneeNotificationModificationContexteDonnee donneeModif = (CDonneeNotificationModificationContexteDonnee)donnee;
					foreach (CDonneeNotificationModificationContexteDonnee.CInfoEnregistrementModifie info in donneeModif.ListeModifications)
					{
						if (info.NomTable == CActeur.c_nomTable &&
							info.ValeursCle.Length == 1 )
						{
							if ( m_nIdActeur < 0 )
							{
								CDonneesActeurUtilisateur user = new CDonneesActeurUtilisateur ( CSc2iWin32DataClient.ContexteCourant );
								if ( user.ReadIfExists ( CTimosApp.SessionClient.GetInfoUtilisateur().IdUtilisateur ) )
									m_nIdActeur = user.Acteur.Id;
								else
									m_nIdActeur = 0;
							}
						}
						if ( info.ValeursCle[0].Equals(m_nIdActeur) )
						{
							CTimosApp.SessionClient.RefreshUtilisateur();
							m_lblUser.Text = CTimosApp.SessionClient.GetInfoUtilisateur().NomUtilisateur;
						}
					}
				}
			}
			catch { }
				
		}




		private void CFormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
            if (!QueryClose())
            {
                e.Cancel = true;
                return;
            }
			if(CFormAlerte.Afficher(I.T("Are you sure you want to quit TIMOS ?|778"),
				EFormAlerteType.Question) == DialogResult.Yes)
			{
				try
				{
					CTimosApp.SessionClient.CloseSession();
				}
				catch { }
			}
			else
				e.Cancel = true;
		}

    

		public  delegate CResultAErreur EditeElementDelegate ( CObjetDonnee objet, bool bInNewOnglet, string strCodeForm);
		private EditeElementDelegate m_funcEditeElement = null;

		private CResultAErreur EditeElementInterne(CObjetDonnee objet, bool bInNewOnglet, string strCodeFormEdition)
		{
			CResultAErreur result = CResultAErreur.True;
			
            CReferenceTypeForm refTypeForm = null;
            if(strCodeFormEdition != string.Empty)
                refTypeForm = sc2i.win32.data.navigation.CFormFinder.GetRefFormToEdit(objet.GetType(), strCodeFormEdition);
            else
                refTypeForm = sc2i.win32.data.navigation.CFormFinder.GetRefFormToEdit(objet.GetType());

            if (refTypeForm == null)
			{
				result.EmpileErreur(I.T("The system is not able to edit elements of type '@1'|1076", objet.GetType().ToString()));
				return result;
			}
			try
			{
                CFormEditionStandard form = refTypeForm.GetForm((CObjetDonneeAIdNumeriqueAuto)objet) as CFormEditionStandard;
				if (bInNewOnglet)
					AffichePageDansNouvelOnglet(form);
				else
					AffichePage ( form );
			}
			catch (Exception e)
			{
				result.EmpileErreur(new CErreurException(e));
			}
			return result;
		}

		public static CResultAErreur EditeElement(CObjetDonnee objet, bool bInNewOnglet, string strCodeFormEdition)
		{
			CFormMain instance = GetInstance();
			IAsyncResult asRes = instance.BeginInvoke(instance.m_funcEditeElement, objet, bInNewOnglet, strCodeFormEdition);
            while (!asRes.IsCompleted)
                System.Threading.Thread.Sleep(100);
            return CResultAErreur.True;
		}


		//--------------------------------------------------------------------------
		public CResultAErreur TravaillerSurVersion(int? nIdVersion)
		{
			CResultAErreur result = CResultAErreur.True;
			//Ferme toutes les fenetres
			IFormNavigable[] lstForms = FormesOuvertes;
			for (int nForm = 1; nForm < lstForms.Length; nForm++)
				if (!CloseForm(lstForms[nForm]))
				{
					result.EmpileErreur(I.T("Cannot change active version, all windows should be closed|1336"));
					return result;
				}
			if (!lstForms[0].QueryClose())
			{
				result.EmpileErreur(I.T("Cannot change active version, all windows should be closed|1336"));
				return result;
			}
			try
			{
				result = CSc2iWin32DataClient.ContexteCourant.SetVersionDeTravail(nIdVersion, true);
				if (!result)
					return result;
			}
			catch (Exception e)
			{
				result.EmpileErreur(new CErreurException(e));
				return result;
			}
			AffichePage(new CFormAccueilVide());
			return result;
		}

		private void ContexteCourant_OnChangeVersionDeTravail(object sender, EventArgs e)
		{
			if (CFournisseurContexteDonnee.GetInstance().ContexteCourant.IdVersionDeTravail == null)
			{
				m_lblVersion.Text = "";
				m_panelVersion.Visible = false;
				m_timerClignote.Enabled = false;
			}
			else
			{
				CVersionDonnees version = new CVersionDonnees(CFournisseurContexteDonnee.GetInstance().ContexteCourant);
				if (version.ReadIfExists((int)CFournisseurContexteDonnee.GetInstance().ContexteCourant.IdVersionDeTravail))
				{
					m_panelVersion.Visible = true;
					m_lblVersion.Text = I.T("Vers @1|1337", version.Libelle);
					m_timerClignote.Enabled = true;
				}
			}
		}

		private void m_timerTemoins_Tick(object sender, EventArgs e)
		{

		}

		private void m_timerClignote_Tick(object sender, EventArgs e)
		{
			if (m_lblVersion.Text != "")
				m_lblVersion.Visible = !m_lblVersion.Visible;
		}
	

		private void m_panelVersion_VisibleChanged(object sender, EventArgs e)
		{
		}




		//MENU
		private void m_btnPagePrecedente_Click(object sender, System.EventArgs e)
		{
			AffichePagePrecedente();
		}
		private void m_btnPageSuivante_Click(object sender, System.EventArgs e)
		{
			AffichePageSuivante();
		}

		private void m_btnHome_Click(object sender, System.EventArgs e)
		{
			AffichePageAccueil();
		}

        private void m_btnPagePrecedente_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (EntreeEnCours != null)
                {
                    ContextMenuStrip menuHistorique = new ContextMenuStrip();
                    CEntreeHistorique pagePrecedente = EntreeEnCours.EntreePrecedente;
                    while (pagePrecedente != null)
                    {
                        CItemHistoriqueNavigation itemHisto = new CItemHistoriqueNavigation(pagePrecedente);
                        itemHisto.Click += new EventHandler(itemHisto_Click);
                        menuHistorique.Items.Add(itemHisto);
                        pagePrecedente = pagePrecedente.EntreePrecedente;
                    }
                    if (menuHistorique.Items.Count > 0)
                        menuHistorique.Show(m_btnPagePrecedente, 0, m_btnPagePrecedente.Height);
                }
            }
        }

        void itemHisto_Click(object sender, EventArgs e)
        {
            CItemHistoriqueNavigation item = sender as CItemHistoriqueNavigation;
            if (item != null)
                AffichePage(item.EntreeHistorique);
        }

        private class CItemHistoriqueNavigation : ToolStripMenuItem
        {
            public CEntreeHistorique EntreeHistorique { get; set; }
            public CItemHistoriqueNavigation(CEntreeHistorique histo)
                :base(histo.Titre)
            {
                EntreeHistorique = histo;
            }
        }

        void m_lblUser_Click(object sender, EventArgs e)
        {
            CFormListeConnectes form = new CFormListeConnectes();
            form.Show();
        }

		private void m_btnPanneauConfiguration_Click(object sender, EventArgs e)
		{
			CFormOptionsGenerales frm = new CFormOptionsGenerales();
			frm.ShowDialog();
		}
		private void m_btnExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void m_imageMSN_Click(object sender, EventArgs e)
		{
		}


		private void m_btnInfos_Click(object sender, EventArgs e)
		{
			CFormAboutBox frm = new CFormAboutBox();
			frm.ShowDialog();
            frm.Dispose();
		}

        private void m_btnRefresh_Click(object sender, EventArgs e)
        {
            using (new CWaitCursor())
            {
                if (this.PageEnCours != null)
                    this.PageEnCours.Actualiser();
            }
        }

        private void m_btnMSN_Click(object sender, EventArgs e)
        {
            m_controleChat.Visible = !m_controleChat.Visible;
        }

		//-------------------------------------------------------------
		private void m_lblVersion_Click(object sender, EventArgs e)
		{
			CContexteDonnee contexte = CFournisseurContexteDonnee.GetInstance().ContexteCourant;
			if (contexte.IdVersionDeTravail != null)
			{
				if (CFormAlerte.Afficher(I.T("Go back to reference version mode ?|1338"), EFormAlerteType.Question) == DialogResult.Yes)
				{
					CResultAErreur result = TravaillerSurVersion(null);
					if (!result)
						CFormAlerte.Afficher(result.Erreur);
				}
			}
		}

		#region IFormAChargement Membres

		public Form Formulaire
		{
			get { return this; }
		}

		public event EventHandler DebutChargement;

		public event EventHandler FinChargement;

		public int DureeAproximativeChargement
		{
			get { return 10; }
		}

		#endregion

		private void CFormMain_Shown(object sender, EventArgs e)
		{
			//Thread.CurrentThread.Join(2000);
			if (FinChargement != null)
				FinChargement(this, new EventArgs());
		}



        public E2iDialogResult ShowAlert(string strMessage, EFormAlerteBoutons boutons, EFormAlerteType typeAlerte, int nSecs)
        {
            MessageBox.Show(this, strMessage);
            return E2iDialogResult.OK;
            /*DialogResult dResult = CFormAlerte.Afficher(strMessage, boutons, typeAlerte, nSecs);
            return C2iDialogResult.Get2iDialogResultFromDialogResult(dResult);*/
        }

        private void ArrangePanelMenu()
        {
            m_leftPine.Visible = !m_panelForMenu.IsHidden;
            if (m_panelForMenu.AutoHide)
            {
                this.SuspendDrawing();
                m_panelForMenu.BringToFront();
                m_splitterMenu.Visible = false;
                m_panelForMenu.BorderStyle = BorderStyle.Fixed3D;
                m_panelMarge.Visible = true;
                m_panelMarge.Width = m_panelForMenu.HiddenSize;
                this.ResumeDrawing();
            }
            else
            {
                this.SuspendDrawing();
                m_panelMarge.Visible = false;
                m_panelForMenu.BorderStyle = BorderStyle.None;
                m_splitterMenu.Visible = true;
                m_splitterMenu.BringToFront();
                m_panelForMainTabs.BringToFront();
                this.ResumeDrawing();

            }
        }

        private void m_leftPine_PineChanged(object sender, EventArgs e)
        {
            m_panelForMenu.AutoHide = !m_leftPine.Pined;
            ArrangePanelMenu();
        }

        private void m_panelForMenu_HiddenChanged(object sender, EventArgs e)
        {
            m_leftPine.Visible = !m_panelForMenu.IsHidden;
        }

        private void m_panelForMenu_AutoHideChanged(object sender, EventArgs e)
        {
            m_leftPine.Pined = !m_panelForMenu.AutoHide;
        }

        private bool m_bIconInfoAvecAlerte = false;
        private void m_timerAlerteLicence_Tick(object sender, EventArgs e)
        {
            m_bIconInfoAvecAlerte = !m_bIconInfoAvecAlerte;
            if (m_bIconInfoAvecAlerte)
                m_btnInfos.Image = timos.Properties.Resources.aboutbox_alerte;
            else
                m_btnInfos.Image = timos.Properties.Resources.aboutbox;
        }

        private void m_timerCheckLicence_Tick(object sender, EventArgs e)
        {
            CheckLicence(false);
        }

        private void CheckLicence(bool bPopupIfCritique)
        {
            IGestionnaireSessionsTimos ges = CSessionClient.GestionnaireSessions as IGestionnaireSessionsTimos;
            if (ges != null)
            {
                IList<CAlerteLicence> lst = ges.GetAlertesLicences();

                if (lst.Count > 0)
                {

                    m_btnInfos.Image = timos.Properties.Resources.aboutbox_alerte;
                    m_bHasAlertes = true;
                    m_timerAlerteLicence.Start();
                    bool bHasCritique = false;
                    StringBuilder bl = new StringBuilder();
                    foreach (CAlerteLicence alerte in lst)
                    {
                        bl.Append(alerte.MessageAlerte);
                        bl.Append("\r\n");
                        bHasCritique |= alerte.Gravite == EGraviteAlerte.Critique;
                    }
                    m_toolTip.SetToolTip(m_btnInfos, bl.ToString());
                    if (bHasCritique && bPopupIfCritique)
                    {
                        CFormAboutBox frm = new CFormAboutBox();
                        frm.ShowDialog();
                        frm.Dispose();
                    }
                    if (bHasCritique)
                        m_timerAlerteLicence.Interval = 300;
                    else
                        m_timerAlerteLicence.Interval = 1000;
                }
                else
                {
                    m_btnInfos.Image = timos.Properties.Resources.aboutbox;
                    m_timerAlerteLicence.Stop();
                }
            }
        }
    }
}
