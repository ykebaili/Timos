namespace TestSnmp
{
    partial class CFormTrapReceiver
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_btnStartListener = new System.Windows.Forms.Button();
            this.m_wndListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_wndListeVariables = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.m_properties = new System.Windows.Forms.PropertyGrid();
            this.m_btnGererAlarmes = new System.Windows.Forms.Button();
            this.m_btnGererMibs = new System.Windows.Forms.Button();
            this.m_btnGererSupervision = new System.Windows.Forms.Button();
            this.c2iTabControl1 = new sc2i.win32.common.C2iTabControl(this.components);
            this.tabPage2 = new Crownwood.Magic.Controls.TabPage();
            this.m_arbreAlarmes = new System.Windows.Forms.TreeView();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.m_wndInfosAlarme = new System.Windows.Forms.ListView();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_chkAvecAlarmesRetombées = new System.Windows.Forms.CheckBox();
            this.m_btnTest = new System.Windows.Forms.Button();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_txtTestAlarmes = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.c2iTabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnStartListener
            // 
            this.m_btnStartListener.Location = new System.Drawing.Point(13, 4);
            this.m_btnStartListener.Name = "m_btnStartListener";
            this.m_btnStartListener.Size = new System.Drawing.Size(133, 23);
            this.m_btnStartListener.TabIndex = 0;
            this.m_btnStartListener.Text = "Start Listener";
            this.m_btnStartListener.UseVisualStyleBackColor = true;
            this.m_btnStartListener.Click += new System.EventHandler(this.m_btnStartListener_Click);
            // 
            // m_wndListView
            // 
            this.m_wndListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_wndListView.Location = new System.Drawing.Point(0, 0);
            this.m_wndListView.MultiSelect = false;
            this.m_wndListView.Name = "m_wndListView";
            this.m_wndListView.Size = new System.Drawing.Size(771, 212);
            this.m_wndListView.TabIndex = 1;
            this.m_wndListView.UseCompatibleStateImageBehavior = false;
            this.m_wndListView.View = System.Windows.Forms.View.Details;
            this.m_wndListView.SelectedIndexChanged += new System.EventHandler(this.m_wndListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 635;
            // 
            // m_wndListeVariables
            // 
            this.m_wndListeVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3});
            this.m_wndListeVariables.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeVariables.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeVariables.Name = "m_wndListeVariables";
            this.m_wndListeVariables.Size = new System.Drawing.Size(533, 238);
            this.m_wndListeVariables.TabIndex = 2;
            this.m_wndListeVariables.UseCompatibleStateImageBehavior = false;
            this.m_wndListeVariables.View = System.Windows.Forms.View.Details;
            this.m_wndListeVariables.SelectedIndexChanged += new System.EventHandler(this.m_wndListeVariables_SelectedIndexChanged);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 275;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 227;
            // 
            // m_properties
            // 
            this.m_properties.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_properties.Location = new System.Drawing.Point(536, 0);
            this.m_properties.Name = "m_properties";
            this.m_properties.Size = new System.Drawing.Size(235, 238);
            this.m_properties.TabIndex = 3;
            // 
            // m_btnGererAlarmes
            // 
            this.m_btnGererAlarmes.Location = new System.Drawing.Point(607, 3);
            this.m_btnGererAlarmes.Name = "m_btnGererAlarmes";
            this.m_btnGererAlarmes.Size = new System.Drawing.Size(167, 23);
            this.m_btnGererAlarmes.TabIndex = 4;
            this.m_btnGererAlarmes.Text = "Gérer les alarmes";
            this.m_btnGererAlarmes.UseVisualStyleBackColor = true;
            this.m_btnGererAlarmes.Click += new System.EventHandler(this.m_btnGererAlarmes_Click);
            // 
            // m_btnGererMibs
            // 
            this.m_btnGererMibs.Location = new System.Drawing.Point(434, 3);
            this.m_btnGererMibs.Name = "m_btnGererMibs";
            this.m_btnGererMibs.Size = new System.Drawing.Size(167, 23);
            this.m_btnGererMibs.TabIndex = 5;
            this.m_btnGererMibs.Text = "Gérer les mibs";
            this.m_btnGererMibs.UseVisualStyleBackColor = true;
            this.m_btnGererMibs.Click += new System.EventHandler(this.m_btnGererMibs_Click);
            // 
            // m_btnGererSupervision
            // 
            this.m_btnGererSupervision.Location = new System.Drawing.Point(261, 3);
            this.m_btnGererSupervision.Name = "m_btnGererSupervision";
            this.m_btnGererSupervision.Size = new System.Drawing.Size(167, 23);
            this.m_btnGererSupervision.TabIndex = 6;
            this.m_btnGererSupervision.Text = "Gérer la supervision";
            this.m_btnGererSupervision.UseVisualStyleBackColor = true;
            this.m_btnGererSupervision.Click += new System.EventHandler(this.m_btnGererSupervision_Click);
            // 
            // c2iTabControl1
            // 
            this.c2iTabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iTabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(247)))), ((int)(((byte)(184)))));
            this.c2iTabControl1.BoldSelectedPage = true;
            this.c2iTabControl1.ControlBottomOffset = 16;
            this.c2iTabControl1.ControlRightOffset = 16;
            this.c2iTabControl1.IDEPixelArea = false;
            this.c2iTabControl1.Location = new System.Drawing.Point(2, 33);
            this.c2iTabControl1.Name = "c2iTabControl1";
            this.c2iTabControl1.Ombre = true;
            this.c2iTabControl1.PositionTop = true;
            this.c2iTabControl1.SelectedIndex = 0;
            this.c2iTabControl1.SelectedTab = this.tabPage1;
            this.c2iTabControl1.Size = new System.Drawing.Size(787, 491);
            this.c2iTabControl1.TabIndex = 7;
            this.c2iTabControl1.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1,
            this.tabPage2});
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.m_arbreAlarmes);
            this.tabPage2.Controls.Add(this.splitter3);
            this.tabPage2.Controls.Add(this.m_wndInfosAlarme);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Controls.Add(this.m_btnTest);
            this.tabPage2.Controls.Add(this.splitter2);
            this.tabPage2.Location = new System.Drawing.Point(0, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Selected = false;
            this.tabPage2.Size = new System.Drawing.Size(771, 450);
            this.tabPage2.TabIndex = 11;
            this.tabPage2.Title = "Alarmes";
            // 
            // m_arbreAlarmes
            // 
            this.m_arbreAlarmes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreAlarmes.Location = new System.Drawing.Point(0, 63);
            this.m_arbreAlarmes.Name = "m_arbreAlarmes";
            this.m_arbreAlarmes.Size = new System.Drawing.Size(490, 387);
            this.m_arbreAlarmes.TabIndex = 6;
            this.m_arbreAlarmes.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreAlarmes_BeforeExpand);
            this.m_arbreAlarmes.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.m_arbreAlarmes_AfterSelect);
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter3.Location = new System.Drawing.Point(490, 63);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(3, 387);
            this.splitter3.TabIndex = 10;
            this.splitter3.TabStop = false;
            // 
            // m_wndInfosAlarme
            // 
            this.m_wndInfosAlarme.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.m_wndInfosAlarme.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_wndInfosAlarme.Location = new System.Drawing.Point(493, 63);
            this.m_wndInfosAlarme.Name = "m_wndInfosAlarme";
            this.m_wndInfosAlarme.Size = new System.Drawing.Size(275, 387);
            this.m_wndInfosAlarme.TabIndex = 9;
            this.m_wndInfosAlarme.UseCompatibleStateImageBehavior = false;
            this.m_wndInfosAlarme.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Champ";
            this.columnHeader4.Width = 111;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Valeur";
            this.columnHeader5.Width = 132;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_chkAvecAlarmesRetombées);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 23);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(768, 40);
            this.panel2.TabIndex = 8;
            // 
            // m_chkAvecAlarmesRetombées
            // 
            this.m_chkAvecAlarmesRetombées.AutoSize = true;
            this.m_chkAvecAlarmesRetombées.Location = new System.Drawing.Point(4, 7);
            this.m_chkAvecAlarmesRetombées.Name = "m_chkAvecAlarmesRetombées";
            this.m_chkAvecAlarmesRetombées.Size = new System.Drawing.Size(144, 17);
            this.m_chkAvecAlarmesRetombées.TabIndex = 0;
            this.m_chkAvecAlarmesRetombées.Text = "Avec alarmes retombées";
            this.m_chkAvecAlarmesRetombées.UseVisualStyleBackColor = true;
            this.m_chkAvecAlarmesRetombées.CheckedChanged += new System.EventHandler(this.m_chkAvecAlarmesRetombées_CheckedChanged);
            // 
            // m_btnTest
            // 
            this.m_btnTest.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_btnTest.Location = new System.Drawing.Point(0, 0);
            this.m_btnTest.Name = "m_btnTest";
            this.m_btnTest.Size = new System.Drawing.Size(768, 23);
            this.m_btnTest.TabIndex = 7;
            this.m_btnTest.Text = "test";
            this.m_btnTest.UseVisualStyleBackColor = true;
            this.m_btnTest.Click += new System.EventHandler(this.m_btnTest_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter2.Location = new System.Drawing.Point(768, 0);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(3, 450);
            this.splitter2.TabIndex = 5;
            this.splitter2.TabStop = false;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.m_wndListView);
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(771, 450);
            this.tabPage1.TabIndex = 10;
            this.tabPage1.Title = "Traps";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_wndListeVariables);
            this.panel1.Controls.Add(this.splitter1);
            this.panel1.Controls.Add(this.m_properties);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 212);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(771, 238);
            this.panel1.TabIndex = 2;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(533, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 238);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_txtTestAlarmes
            // 
            this.m_txtTestAlarmes.AllowGraphic = true;
            this.m_txtTestAlarmes.Formule = null;
            this.m_txtTestAlarmes.Location = new System.Drawing.Point(39, 530);
            this.m_txtTestAlarmes.LockEdition = false;
            this.m_txtTestAlarmes.LockZoneTexte = false;
            this.m_txtTestAlarmes.Name = "m_txtTestAlarmes";
            this.m_txtTestAlarmes.Size = new System.Drawing.Size(677, 20);
            this.m_txtTestAlarmes.TabIndex = 8;
            this.m_txtTestAlarmes.Enter += new System.EventHandler(this.m_txtTestAlarmes_Enter);
            // 
            // CFormTrapReceiver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 552);
            this.Controls.Add(this.m_txtTestAlarmes);
            this.Controls.Add(this.c2iTabControl1);
            this.Controls.Add(this.m_btnGererSupervision);
            this.Controls.Add(this.m_btnGererMibs);
            this.Controls.Add(this.m_btnGererAlarmes);
            this.Controls.Add(this.m_btnStartListener);
            this.Name = "CFormTrapReceiver";
            this.Text = "Form1";
            this.c2iTabControl1.ResumeLayout(false);
            this.c2iTabControl1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button m_btnStartListener;
        private System.Windows.Forms.ListView m_wndListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView m_wndListeVariables;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.PropertyGrid m_properties;
        private System.Windows.Forms.Button m_btnGererAlarmes;
        private System.Windows.Forms.Button m_btnGererMibs;
        private System.Windows.Forms.Button m_btnGererSupervision;
        private sc2i.win32.common.C2iTabControl c2iTabControl1;
        private Crownwood.Magic.Controls.TabPage tabPage1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Splitter splitter1;
        private Crownwood.Magic.Controls.TabPage tabPage2;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TreeView m_arbreAlarmes;
        private System.Windows.Forms.Button m_btnTest;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox m_chkAvecAlarmesRetombées;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.ListView m_wndInfosAlarme;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtTestAlarmes;
    }
}

