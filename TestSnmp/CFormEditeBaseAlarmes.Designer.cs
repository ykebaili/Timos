namespace TestSnmp
{
    partial class CFormEditeBaseAlarmes
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_lnkRemoveType = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAddType = new sc2i.win32.common.CWndLinkStd();
            this.m_arbreAlarmes = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Controls.Add(this.m_btnLoad);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 35);
            this.panel1.TabIndex = 1;
            // 
            // m_btnSave
            // 
            this.m_btnSave.Location = new System.Drawing.Point(112, 4);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(75, 23);
            this.m_btnSave.TabIndex = 1;
            this.m_btnSave.Text = "Save";
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_btnLoad
            // 
            this.m_btnLoad.Location = new System.Drawing.Point(13, 4);
            this.m_btnLoad.Name = "m_btnLoad";
            this.m_btnLoad.Size = new System.Drawing.Size(75, 23);
            this.m_btnLoad.TabIndex = 0;
            this.m_btnLoad.Text = "Load";
            this.m_btnLoad.UseVisualStyleBackColor = true;
            this.m_btnLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_lnkRemoveType);
            this.panel2.Controls.Add(this.m_lnkAddType);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(550, 29);
            this.panel2.TabIndex = 2;
            // 
            // m_lnkRemoveType
            // 
            this.m_lnkRemoveType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemoveType.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemoveType.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkRemoveType.Location = new System.Drawing.Point(112, 0);
            this.m_lnkRemoveType.Name = "m_lnkRemoveType";
            this.m_lnkRemoveType.Size = new System.Drawing.Size(112, 29);
            this.m_lnkRemoveType.TabIndex = 1;
            this.m_lnkRemoveType.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemoveType.LinkClicked += new System.EventHandler(this.m_lnkRemoveType_LinkClicked);
            // 
            // m_lnkAddType
            // 
            this.m_lnkAddType.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddType.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddType.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddType.Location = new System.Drawing.Point(0, 0);
            this.m_lnkAddType.Name = "m_lnkAddType";
            this.m_lnkAddType.Size = new System.Drawing.Size(112, 29);
            this.m_lnkAddType.TabIndex = 0;
            this.m_lnkAddType.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddType.LinkClicked += new System.EventHandler(this.m_lnkAddType_LinkClicked);
            // 
            // m_arbreAlarmes
            // 
            this.m_arbreAlarmes.AllowDrop = true;
            this.m_arbreAlarmes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbreAlarmes.Location = new System.Drawing.Point(0, 64);
            this.m_arbreAlarmes.Name = "m_arbreAlarmes";
            this.m_arbreAlarmes.Size = new System.Drawing.Size(550, 350);
            this.m_arbreAlarmes.TabIndex = 3;
            this.m_arbreAlarmes.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.m_arbreAlarmes_NodeMouseDoubleClick);
            this.m_arbreAlarmes.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbreAlarmes_BeforeExpand);
            this.m_arbreAlarmes.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_arbreAlarmes_DragDrop);
            this.m_arbreAlarmes.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.m_arbreAlarmes_ItemDrag);
            this.m_arbreAlarmes.DragOver += new System.Windows.Forms.DragEventHandler(this.m_arbreAlarmes_DragOver);
            // 
            // CFormEditeBaseAlarmes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 414);
            this.Controls.Add(this.m_arbreAlarmes);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CFormEditeBaseAlarmes";
            this.Text = "CFormEditeBaseAlarmes";
            this.Load += new System.EventHandler(this.CFormEditeBaseAlarmes_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.common.CWndLinkStd m_lnkRemoveType;
        private sc2i.win32.common.CWndLinkStd m_lnkAddType;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Button m_btnLoad;
        private System.Windows.Forms.TreeView m_arbreAlarmes;
    }
}