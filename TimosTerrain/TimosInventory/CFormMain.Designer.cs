namespace TimosInventory
{
    partial class CFormMain
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
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_btnQuitter = new System.Windows.Forms.Button();
            this.m_btnCheckNone = new System.Windows.Forms.Button();
            this.m_btnCheckAll = new System.Windows.Forms.Button();
            this.m_panelTransmitReleves = new System.Windows.Forms.Panel();
            this.m_lnkSupprimerReleves = new System.Windows.Forms.LinkLabel();
            this.m_lnkEnvoyerReleves = new System.Windows.Forms.LinkLabel();
            this.m_btnSettings = new System.Windows.Forms.Button();
            this.m_wndListeReleves = new sc2i.win32.common.CListLink();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnDebugData = new System.Windows.Forms.Button();
            this.c2iPanelOmbre2 = new sc2i.win32.common.C2iPanelOmbre();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_wndListeSites = new sc2i.win32.common.CListLink();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lblDateData = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.c2iPanelOmbre1.SuspendLayout();
            this.m_panelTransmitReleves.SuspendLayout();
            this.c2iPanelOmbre2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(6, 35);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(227, 50);
            this.m_extStyle.SetStyleBackColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.button1.TabIndex = 0;
            this.button1.Text = "Prepare data|20000";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_btnQuitter);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnCheckNone);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnCheckAll);
            this.c2iPanelOmbre1.Controls.Add(this.m_panelTransmitReleves);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnSettings);
            this.c2iPanelOmbre1.Controls.Add(this.m_wndListeReleves);
            this.c2iPanelOmbre1.Controls.Add(this.label5);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.button1);
            this.c2iPanelOmbre1.Controls.Add(this.m_btnDebugData);
            this.c2iPanelOmbre1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(305, 0);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(299, 363);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 2;
            // 
            // m_btnQuitter
            // 
            this.m_btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQuitter.Image = global::TimosInventory.Properties.Resources.Icone_quitter_32;
            this.m_btnQuitter.Location = new System.Drawing.Point(205, 295);
            this.m_btnQuitter.Name = "m_btnQuitter";
            this.m_btnQuitter.Size = new System.Drawing.Size(72, 50);
            this.m_extStyle.SetStyleBackColor(this.m_btnQuitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnQuitter, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnQuitter.TabIndex = 12;
            this.m_btnQuitter.UseVisualStyleBackColor = true;
            this.m_btnQuitter.Click += new System.EventHandler(this.m_btnQuitter_Click);
            // 
            // m_btnCheckNone
            // 
            this.m_btnCheckNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnCheckNone.Image = global::TimosInventory.Properties.Resources.checkbox_no;
            this.m_btnCheckNone.Location = new System.Drawing.Point(31, 280);
            this.m_btnCheckNone.Name = "m_btnCheckNone";
            this.m_btnCheckNone.Size = new System.Drawing.Size(24, 21);
            this.m_extStyle.SetStyleBackColor(this.m_btnCheckNone, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCheckNone, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCheckNone.TabIndex = 10;
            this.m_btnCheckNone.UseVisualStyleBackColor = true;
            this.m_btnCheckNone.Click += new System.EventHandler(this.m_btnCheckNone_Click);
            // 
            // m_btnCheckAll
            // 
            this.m_btnCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnCheckAll.Image = global::TimosInventory.Properties.Resources.checkbox_yes;
            this.m_btnCheckAll.Location = new System.Drawing.Point(1, 280);
            this.m_btnCheckAll.Name = "m_btnCheckAll";
            this.m_btnCheckAll.Size = new System.Drawing.Size(24, 21);
            this.m_extStyle.SetStyleBackColor(this.m_btnCheckAll, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCheckAll, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCheckAll.TabIndex = 9;
            this.m_btnCheckAll.UseVisualStyleBackColor = true;
            this.m_btnCheckAll.Click += new System.EventHandler(this.m_btnCheckAll_Click);
            // 
            // m_panelTransmitReleves
            // 
            this.m_panelTransmitReleves.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelTransmitReleves.Controls.Add(this.m_lnkSupprimerReleves);
            this.m_panelTransmitReleves.Controls.Add(this.m_lnkEnvoyerReleves);
            this.m_panelTransmitReleves.Location = new System.Drawing.Point(6, 306);
            this.m_panelTransmitReleves.Name = "m_panelTransmitReleves";
            this.m_panelTransmitReleves.Size = new System.Drawing.Size(193, 17);
            this.m_extStyle.SetStyleBackColor(this.m_panelTransmitReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTransmitReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTransmitReleves.TabIndex = 7;
            this.m_panelTransmitReleves.Visible = false;
            // 
            // m_lnkSupprimerReleves
            // 
            this.m_lnkSupprimerReleves.AutoSize = true;
            this.m_lnkSupprimerReleves.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkSupprimerReleves.Location = new System.Drawing.Point(138, 0);
            this.m_lnkSupprimerReleves.Name = "m_lnkSupprimerReleves";
            this.m_lnkSupprimerReleves.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkSupprimerReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkSupprimerReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkSupprimerReleves.TabIndex = 1;
            this.m_lnkSupprimerReleves.TabStop = true;
            this.m_lnkSupprimerReleves.Text = "linkLabel1";
            this.m_lnkSupprimerReleves.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkSupprimerReleves_LinkClicked);
            // 
            // m_lnkEnvoyerReleves
            // 
            this.m_lnkEnvoyerReleves.AutoSize = true;
            this.m_lnkEnvoyerReleves.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkEnvoyerReleves.Location = new System.Drawing.Point(0, 0);
            this.m_lnkEnvoyerReleves.Name = "m_lnkEnvoyerReleves";
            this.m_lnkEnvoyerReleves.Size = new System.Drawing.Size(55, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkEnvoyerReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkEnvoyerReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkEnvoyerReleves.TabIndex = 0;
            this.m_lnkEnvoyerReleves.TabStop = true;
            this.m_lnkEnvoyerReleves.Text = "linkLabel1";
            this.m_lnkEnvoyerReleves.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkEnvoyerReleves_LinkClicked);
            // 
            // m_btnSettings
            // 
            this.m_btnSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSettings.Image = global::TimosInventory.Properties.Resources._1364325707_advancedsettings;
            this.m_btnSettings.Location = new System.Drawing.Point(239, 35);
            this.m_btnSettings.Name = "m_btnSettings";
            this.m_btnSettings.Size = new System.Drawing.Size(38, 50);
            this.m_extStyle.SetStyleBackColor(this.m_btnSettings, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSettings, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSettings.TabIndex = 11;
            this.m_btnSettings.UseVisualStyleBackColor = true;
            this.m_btnSettings.Click += new System.EventHandler(this.m_btnSettings_Click);
            // 
            // m_wndListeReleves
            // 
            this.m_wndListeReleves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndListeReleves.CheckBoxes = true;
            this.m_wndListeReleves.ColorActive = System.Drawing.Color.Red;
            this.m_wndListeReleves.ColorDesactive = System.Drawing.Color.Blue;
            this.m_wndListeReleves.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndListeReleves.ForeColor = System.Drawing.Color.Blue;
            this.m_wndListeReleves.FullRowSelect = true;
            this.m_wndListeReleves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeReleves.Location = new System.Drawing.Point(3, 110);
            this.m_wndListeReleves.MultiSelect = false;
            this.m_wndListeReleves.Name = "m_wndListeReleves";
            this.m_wndListeReleves.Size = new System.Drawing.Size(274, 170);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeReleves, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeReleves.TabIndex = 6;
            this.m_wndListeReleves.UseCompatibleStateImageBehavior = false;
            this.m_wndListeReleves.View = System.Windows.Forms.View.Details;
            this.m_wndListeReleves.ItemClick += new sc2i.win32.common.ListLinkItemClickEventHandler(this.m_wndListeReleves_ItemClick);
            this.m_wndListeReleves.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.m_wndListeReleves_ItemChecked);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 8;
            this.label5.Text = "Surveys to send|20050";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 3;
            this.label1.Text = "Connected mode|20047";
            // 
            // m_btnDebugData
            // 
            this.m_btnDebugData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnDebugData.Location = new System.Drawing.Point(6, 322);
            this.m_btnDebugData.Name = "m_btnDebugData";
            this.m_btnDebugData.Size = new System.Drawing.Size(93, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnDebugData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnDebugData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnDebugData.TabIndex = 4;
            this.m_btnDebugData.Text = "Data debug";
            this.m_btnDebugData.UseVisualStyleBackColor = true;
            this.m_btnDebugData.Click += new System.EventHandler(this.m_btnDebugData_Click);
            // 
            // c2iPanelOmbre2
            // 
            this.c2iPanelOmbre2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre2.Controls.Add(this.panel1);
            this.c2iPanelOmbre2.Dock = System.Windows.Forms.DockStyle.Left;
            this.c2iPanelOmbre2.ForeColor = System.Drawing.Color.Black;
            this.c2iPanelOmbre2.Location = new System.Drawing.Point(0, 0);
            this.c2iPanelOmbre2.LockEdition = false;
            this.c2iPanelOmbre2.Name = "c2iPanelOmbre2";
            this.c2iPanelOmbre2.Size = new System.Drawing.Size(302, 363);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre2.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.m_wndListeSites);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(284, 351);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 7;
            // 
            // m_wndListeSites
            // 
            this.m_wndListeSites.ColorActive = System.Drawing.Color.Red;
            this.m_wndListeSites.ColorDesactive = System.Drawing.Color.Blue;
            this.m_wndListeSites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeSites.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_wndListeSites.ForeColor = System.Drawing.Color.Blue;
            this.m_wndListeSites.FullRowSelect = true;
            this.m_wndListeSites.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.m_wndListeSites.Location = new System.Drawing.Point(0, 42);
            this.m_wndListeSites.MultiSelect = false;
            this.m_wndListeSites.Name = "m_wndListeSites";
            this.m_wndListeSites.Size = new System.Drawing.Size(284, 309);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSites.TabIndex = 5;
            this.m_wndListeSites.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSites.View = System.Windows.Forms.View.Details;
            this.m_wndListeSites.ItemClick += new sc2i.win32.common.ListLinkItemClickEventHandler(this.m_wndListeSites_ItemClick);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lblDateData);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(284, 19);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 6;
            // 
            // m_lblDateData
            // 
            this.m_lblDateData.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblDateData.Location = new System.Drawing.Point(168, 0);
            this.m_lblDateData.Name = "m_lblDateData";
            this.m_lblDateData.Size = new System.Drawing.Size(177, 19);
            this.m_extStyle.SetStyleBackColor(this.m_lblDateData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDateData, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDateData.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(168, 19);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "Available sites|20045";
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(284, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 6;
            this.label3.Text = "Disconnected mode|20046";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(302, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 363);
            this.m_extStyle.SetStyleBackColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.splitter1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.splitter1.TabIndex = 7;
            this.splitter1.TabStop = false;
            // 
            // CFormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 363);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.c2iPanelOmbre2);
            this.Name = "CFormMain";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Timos inventory|20005";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CFormMain_Load);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.m_panelTransmitReleves.ResumeLayout(false);
            this.m_panelTransmitReleves.PerformLayout();
            this.c2iPanelOmbre2.ResumeLayout(false);
            this.c2iPanelOmbre2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre2;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.CListLink m_wndListeSites;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnDebugData;
        private sc2i.win32.common.CListLink m_wndListeReleves;
        private System.Windows.Forms.Panel m_panelTransmitReleves;
        private System.Windows.Forms.LinkLabel m_lnkEnvoyerReleves;
        private System.Windows.Forms.LinkLabel m_lnkSupprimerReleves;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label m_lblDateData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button m_btnCheckAll;
        private System.Windows.Forms.Button m_btnCheckNone;
        private System.Windows.Forms.Button m_btnSettings;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button m_btnQuitter;
    }
}