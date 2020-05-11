namespace TestSnmp
{
    partial class CFormMib
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_btnLoad = new System.Windows.Forms.Button();
            this.m_btnAddModule = new System.Windows.Forms.Button();
            this.m_wndListeModules = new System.Windows.Forms.ListBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.m_mibBrowser = new futurocom.win32.snmp.CWndMibBrowser();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAddModule);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(605, 33);
            this.panel1.TabIndex = 2;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(526, 4);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(75, 23);
            this.m_btnSave.TabIndex = 3;
            this.m_btnSave.Text = "Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnLoad
            // 
            this.m_btnLoad.Location = new System.Drawing.Point(427, 4);
            this.m_btnLoad.Name = "m_btnLoad";
            this.m_btnLoad.Size = new System.Drawing.Size(75, 23);
            this.m_btnLoad.TabIndex = 2;
            this.m_btnLoad.Text = "Load";
            this.m_btnLoad.UseVisualStyleBackColor = true;
            this.m_btnLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_btnAddModule
            // 
            this.m_btnAddModule.Location = new System.Drawing.Point(12, 4);
            this.m_btnAddModule.Name = "m_btnAddModule";
            this.m_btnAddModule.Size = new System.Drawing.Size(75, 23);
            this.m_btnAddModule.TabIndex = 4;
            this.m_btnAddModule.Text = "Add Module";
            this.m_btnAddModule.UseVisualStyleBackColor = true;
            this.m_btnAddModule.Click += new System.EventHandler(this.m_btnAddModule_Click);
            // 
            // m_wndListeModules
            // 
            this.m_wndListeModules.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_wndListeModules.FormattingEnabled = true;
            this.m_wndListeModules.Location = new System.Drawing.Point(0, 33);
            this.m_wndListeModules.Name = "m_wndListeModules";
            this.m_wndListeModules.Size = new System.Drawing.Size(168, 368);
            this.m_wndListeModules.TabIndex = 3;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.Black;
            this.splitter1.Location = new System.Drawing.Point(168, 33);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 375);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // m_mibBrowser
            // 
            this.m_mibBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_mibBrowser.Location = new System.Drawing.Point(171, 33);
            this.m_mibBrowser.Name = "m_mibBrowser";
            this.m_mibBrowser.Size = new System.Drawing.Size(434, 375);
            this.m_mibBrowser.TabIndex = 0;
            // 
            // CFormMib
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 408);
            this.Controls.Add(this.m_mibBrowser);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.m_wndListeModules);
            this.Controls.Add(this.panel1);
            this.Name = "CFormMib";
            this.Text = "CFormMib";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private futurocom.win32.snmp.CWndMibBrowser m_mibBrowser;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnLoad;
        private System.Windows.Forms.Button m_btnAddModule;
        private System.Windows.Forms.ListBox m_wndListeModules;
        private System.Windows.Forms.Splitter splitter1;
    }
}