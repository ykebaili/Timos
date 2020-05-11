namespace timos.snmp
{
    partial class CFormControleServiceMediation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (m_listener != null)
            {
                GetConnexion().RemoveTraceListener(m_listener);
                m_listener.Dispose();
            }
            m_listener = null;
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_lblEtatService = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblIP = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_lblProxyName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkShowDataset = new System.Windows.Forms.LinkLabel();
            this.m_dataGrid = new System.Windows.Forms.DataGrid();
            this.m_menuControl = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuStart = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuStop = new System.Windows.Forms.ToolStripMenuItem();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_wndListDebug = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_btnClear = new System.Windows.Forms.Button();
            this.m_btnStopDebug = new System.Windows.Forms.Button();
            this.m_btnStartDebug = new System.Windows.Forms.Button();
            this.m_txtMessage = new sc2i.win32.common.C2iTextBox();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_timerUpdateEtatService = new System.Windows.Forms.Timer(this.components);
            this.c2iPanelOmbre1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).BeginInit();
            this.m_menuControl.SuspendLayout();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.c2iPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_lblEtatService);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblIP);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_lblProxyName);
            this.c2iPanelOmbre1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(10, 10);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(725, 97);
            this.cExtStyle1.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 0;
            // 
            // m_lblEtatService
            // 
            this.m_lblEtatService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.m_lblEtatService.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblEtatService.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lblEtatService.Location = new System.Drawing.Point(173, 48);
            this.m_lblEtatService.Name = "m_lblEtatService";
            this.m_lblEtatService.Size = new System.Drawing.Size(100, 23);
            this.cExtStyle1.SetStyleBackColor(this.m_lblEtatService, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lblEtatService, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEtatService.TabIndex = 7;
            this.m_lblEtatService.Text = "Stopped";
            this.m_lblEtatService.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblEtatService.Click += new System.EventHandler(this.m_lblEtatService_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 17);
            this.cExtStyle1.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 6;
            this.label2.Text = "Mediation state|20323";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblIP
            // 
            this.m_lblIP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_lblIP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblIP.Location = new System.Drawing.Point(515, 9);
            this.m_lblIP.Name = "m_lblIP";
            this.m_lblIP.Size = new System.Drawing.Size(172, 23);
            this.cExtStyle1.SetStyleBackColor(this.m_lblIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lblIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblIP.TabIndex = 5;
            this.m_lblIP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(150, 17);
            this.cExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 3;
            this.label1.Text = "Proxy name|20322";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblProxyName
            // 
            this.m_lblProxyName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.m_lblProxyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblProxyName.Location = new System.Drawing.Point(173, 9);
            this.m_lblProxyName.Name = "m_lblProxyName";
            this.m_lblProxyName.Size = new System.Drawing.Size(336, 23);
            this.cExtStyle1.SetStyleBackColor(this.m_lblProxyName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lblProxyName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblProxyName.TabIndex = 4;
            this.m_lblProxyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 10);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 445);
            this.cExtStyle1.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 10);
            this.cExtStyle1.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 3;
            // 
            // m_lnkShowDataset
            // 
            this.m_lnkShowDataset.AutoSize = true;
            this.m_lnkShowDataset.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lnkShowDataset.Location = new System.Drawing.Point(0, 0);
            this.m_lnkShowDataset.Name = "m_lnkShowDataset";
            this.m_lnkShowDataset.Size = new System.Drawing.Size(141, 13);
            this.cExtStyle1.SetStyleBackColor(this.m_lnkShowDataset, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lnkShowDataset, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkShowDataset.TabIndex = 8;
            this.m_lnkShowDataset.TabStop = true;
            this.m_lnkShowDataset.Text = "Show mediation data|20330";
            this.m_lnkShowDataset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkShowDataset_LinkClicked);
            // 
            // m_dataGrid
            // 
            this.m_dataGrid.DataMember = "";
            this.m_dataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_dataGrid.Location = new System.Drawing.Point(0, 13);
            this.m_dataGrid.Name = "m_dataGrid";
            this.m_dataGrid.Size = new System.Drawing.Size(709, 294);
            this.cExtStyle1.SetStyleBackColor(this.m_dataGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_dataGrid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dataGrid.TabIndex = 3;
            // 
            // m_menuControl
            // 
            this.m_menuControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuStart,
            this.m_menuStop});
            this.m_menuControl.Name = "m_menuControl";
            this.m_menuControl.Size = new System.Drawing.Size(144, 48);
            this.cExtStyle1.SetStyleBackColor(this.m_menuControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_menuControl, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_menuControl.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuControl_Opening);
            // 
            // m_menuStart
            // 
            this.m_menuStart.Name = "m_menuStart";
            this.m_menuStart.Size = new System.Drawing.Size(143, 22);
            this.m_menuStart.Text = "Start|20332";
            this.m_menuStart.Click += new System.EventHandler(this.m_menuStart_Click);
            // 
            // m_menuStop
            // 
            this.m_menuStop.Name = "m_menuStop";
            this.m_menuStop.Size = new System.Drawing.Size(143, 22);
            this.m_menuStop.Text = "Stop|20333";
            this.m_menuStop.Click += new System.EventHandler(this.m_menuStop_Click);
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iTabControl1.ForeColor = System.Drawing.Color.Black;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(10, 107);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 1;
            this.c2iTabControl1.SelectedTab = this.tabPage2;
            this.c2iTabControl1.Size = new System.Drawing.Size(725, 348);
            this.cExtStyle1.SetStyleBackColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this.c2iTabControl1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.c2iTabControl1.TabIndex = 9;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            this.c2iTabControl1.TextColor = System.Drawing.Color.Black;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_wndListDebug);
            this.tabPage2.Controls.Add(this.splitter1);
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.m_txtMessage);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(709, 307);
            this.cExtStyle1.SetStyleBackColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.tabPage2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Debug|20345";
            // 
            // m_wndListDebug
            // 
            this.m_wndListDebug.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.m_wndListDebug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListDebug.FullRowSelect = true;
            this.m_wndListDebug.Location = new System.Drawing.Point(0, 29);
            this.m_wndListDebug.Name = "m_wndListDebug";
            this.m_wndListDebug.ShowItemToolTips = true;
            this.m_wndListDebug.Size = new System.Drawing.Size(709, 203);
            this.cExtStyle1.SetStyleBackColor(this.m_wndListDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_wndListDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListDebug.TabIndex = 10;
            this.m_wndListDebug.UseCompatibleStateImageBehavior = false;
            this.m_wndListDebug.View = System.Windows.Forms.View.Details;
            this.m_wndListDebug.SelectedIndexChanged += new System.EventHandler(this.m_wndListDebug_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date|20348";
            this.columnHeader1.Width = 159;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Message|20349";
            this.columnHeader2.Width = 512;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 232);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(709, 3);
            this.cExtStyle1.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 13;
            this.splitter1.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_btnClear);
            this.panel3.Controls.Add(this.m_btnStopDebug);
            this.panel3.Controls.Add(this.m_btnStartDebug);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 29);
            this.cExtStyle1.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 11;
            // 
            // m_btnClear
            // 
            this.m_btnClear.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnClear.Enabled = true;
            this.m_btnClear.Image = global::timos.Properties.Resources.edit_clear;
            this.m_btnClear.Location = new System.Drawing.Point(68, 0);
            this.m_btnClear.Name = "m_btnClear";
            this.m_btnClear.Size = new System.Drawing.Size(34, 29);
            this.cExtStyle1.SetStyleBackColor(this.m_btnClear, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnClear, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnClear.TabIndex = 2;
            this.m_tooltip.SetToolTip(this.m_btnClear, "Stop debugging|20349");
            this.m_btnClear.UseVisualStyleBackColor = true;
            this.m_btnClear.Click += new System.EventHandler(this.m_btnClear_Click);
            // 
            // m_btnStopDebug
            // 
            this.m_btnStopDebug.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnStopDebug.Enabled = false;
            this.m_btnStopDebug.Image = global::timos.Properties.Resources.StopDebug;
            this.m_btnStopDebug.Location = new System.Drawing.Point(34, 0);
            this.m_btnStopDebug.Name = "m_btnStopDebug";
            this.m_btnStopDebug.Size = new System.Drawing.Size(34, 29);
            this.cExtStyle1.SetStyleBackColor(this.m_btnStopDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnStopDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnStopDebug.TabIndex = 1;
            this.m_tooltip.SetToolTip(this.m_btnStopDebug, "Stop debugging|20349");
            this.m_btnStopDebug.UseVisualStyleBackColor = true;
            this.m_btnStopDebug.Click += new System.EventHandler(this.m_btnStopDebug_Click);
            // 
            // m_btnStartDebug
            // 
            this.m_btnStartDebug.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_btnStartDebug.Image = global::timos.Properties.Resources.StartDebug;
            this.m_btnStartDebug.Location = new System.Drawing.Point(0, 0);
            this.m_btnStartDebug.Name = "m_btnStartDebug";
            this.m_btnStartDebug.Size = new System.Drawing.Size(34, 29);
            this.cExtStyle1.SetStyleBackColor(this.m_btnStartDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnStartDebug, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnStartDebug.TabIndex = 0;
            this.m_tooltip.SetToolTip(this.m_btnStartDebug, "Start debugging|20346");
            this.m_btnStartDebug.UseVisualStyleBackColor = true;
            this.m_btnStartDebug.Click += new System.EventHandler(this.m_btnToogleDebug_Click);
            // 
            // m_txtMessage
            // 
            this.m_txtMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_txtMessage.Location = new System.Drawing.Point(0, 235);
            this.m_txtMessage.LockEdition = true;
            this.m_txtMessage.Multiline = true;
            this.m_txtMessage.Name = "m_txtMessage";
            this.m_txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_txtMessage.Size = new System.Drawing.Size(709, 72);
            this.cExtStyle1.SetStyleBackColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtMessage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtMessage.TabIndex = 12;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.c2iPanel1);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(709, 307);
            this.cExtStyle1.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Mediation service data|20344";
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Controls.Add(this.m_dataGrid);
            this.c2iPanel1.Controls.Add(this.m_lnkShowDataset);
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = false;
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(709, 307);
            this.cExtStyle1.SetStyleBackColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.c2iPanel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iPanel1.TabIndex = 10;
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // m_timerUpdateEtatService
            // 
            this.m_timerUpdateEtatService.Enabled = true;
            this.m_timerUpdateEtatService.Interval = 20000;
            this.m_timerUpdateEtatService.Tick += new System.EventHandler(this.m_timerUpdateEtatService_Tick);
            // 
            // CFormControleServiceMediation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 455);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormControleServiceMediation";
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Mediation service control|20321";
            this.Load += new System.EventHandler(this.CFormControleServiceMediation_Load);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_dataGrid)).EndInit();
            this.m_menuControl.ResumeLayout(false);
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.c2iPanel1.ResumeLayout(false);
            this.c2iPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle cExtStyle1;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblIP;
        private System.Windows.Forms.Label m_lblProxyName;
        private System.Windows.Forms.Label m_lblEtatService;
        private System.Windows.Forms.ErrorProvider m_errorProvider;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.LinkLabel m_lnkShowDataset;
        private System.Windows.Forms.DataGrid m_dataGrid;
        private System.Windows.Forms.ContextMenuStrip m_menuControl;
        private System.Windows.Forms.ToolStripMenuItem m_menuStart;
        private System.Windows.Forms.ToolStripMenuItem m_menuStop;
        private sc2i.win32.common.C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private sc2i.win32.common.C2iPanel c2iPanel1;
        private System.Windows.Forms.ListView m_wndListDebug;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button m_btnStartDebug;
        private System.Windows.Forms.Splitter splitter1;
        private sc2i.win32.common.C2iTextBox m_txtMessage;
        private System.Windows.Forms.Button m_btnStopDebug;
        private System.Windows.Forms.ToolTip m_tooltip;
        private System.Windows.Forms.Timer m_timerUpdateEtatService;
        private System.Windows.Forms.Button m_btnClear;
    }
}