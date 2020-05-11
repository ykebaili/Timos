namespace timos.macro
{
    partial class CFormGestionDesMacros
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormGestionDesMacros));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnLoad = new System.Windows.Forms.PictureBox();
            this.m_wndListeMacros = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.m_lnkRemove = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAdd = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkEdit = new sc2i.win32.common.CWndLinkStd();
            this.m_menuAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnLoad)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lnkRemove);
            this.panel1.Controls.Add(this.m_lnkEdit);
            this.panel1.Controls.Add(this.m_btnLoad);
            this.panel1.Controls.Add(this.m_lnkAdd);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 23);
            this.panel1.TabIndex = 0;
            // 
            // m_btnLoad
            // 
            this.m_btnLoad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_btnLoad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnLoad.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnLoad.Image = ((System.Drawing.Image)(resources.GetObject("m_btnLoad.Image")));
            this.m_btnLoad.Location = new System.Drawing.Point(492, 0);
            this.m_btnLoad.Name = "m_btnLoad";
            this.m_btnLoad.Size = new System.Drawing.Size(28, 23);
            this.m_btnLoad.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_btnLoad.TabIndex = 5;
            this.m_btnLoad.TabStop = false;
            this.m_btnLoad.Click += new System.EventHandler(this.m_btnLoad_Click);
            // 
            // m_wndListeMacros
            // 
            this.m_wndListeMacros.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.m_wndListeMacros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeMacros.Location = new System.Drawing.Point(0, 23);
            this.m_wndListeMacros.MultiSelect = false;
            this.m_wndListeMacros.Name = "m_wndListeMacros";
            this.m_wndListeMacros.Size = new System.Drawing.Size(520, 332);
            this.m_wndListeMacros.TabIndex = 1;
            this.m_wndListeMacros.UseCompatibleStateImageBehavior = false;
            this.m_wndListeMacros.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 491;
            // 
            // m_lnkRemove
            // 
            this.m_lnkRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemove.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkRemove.Location = new System.Drawing.Point(224, 0);
            this.m_lnkRemove.Name = "m_lnkRemove";
            this.m_lnkRemove.Size = new System.Drawing.Size(112, 23);
            this.m_lnkRemove.TabIndex = 6;
            this.m_lnkRemove.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemove.LinkClicked += new System.EventHandler(this.m_lnkRemove_LinkClicked);
            // 
            // m_lnkAdd
            // 
            this.m_lnkAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAdd.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAdd.Location = new System.Drawing.Point(0, 0);
            this.m_lnkAdd.Name = "m_lnkAdd";
            this.m_lnkAdd.Size = new System.Drawing.Size(112, 23);
            this.m_lnkAdd.TabIndex = 7;
            this.m_lnkAdd.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAdd.LinkClicked += new System.EventHandler(this.m_lnkAdd_LinkClicked);
            // 
            // m_lnkEdit
            // 
            this.m_lnkEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkEdit.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkEdit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkEdit.Location = new System.Drawing.Point(112, 0);
            this.m_lnkEdit.Name = "m_lnkEdit";
            this.m_lnkEdit.Size = new System.Drawing.Size(112, 23);
            this.m_lnkEdit.TabIndex = 8;
            this.m_lnkEdit.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkEdit.LinkClicked += new System.EventHandler(this.m_lnkEdit_LinkClicked);
            // 
            // m_menuAdd
            // 
            this.m_menuAdd.Name = "m_menuAdd";
            this.m_menuAdd.Size = new System.Drawing.Size(61, 4);
            // 
            // CFormGestionDesMacros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 355);
            this.Controls.Add(this.m_wndListeMacros);
            this.Controls.Add(this.panel1);
            this.Name = "CFormGestionDesMacros";
            this.Text = "#Gestion des macros";
            this.Load += new System.EventHandler(this.CFormGestionDesMacros_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnLoad)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox m_btnLoad;
        private sc2i.win32.common.CWndLinkStd m_lnkRemove;
        private sc2i.win32.common.CWndLinkStd m_lnkEdit;
        private sc2i.win32.common.CWndLinkStd m_lnkAdd;
        private System.Windows.Forms.ListView m_wndListeMacros;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ContextMenuStrip m_menuAdd;
    }
}