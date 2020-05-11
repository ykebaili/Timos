namespace timos.tables
{
    partial class CFormPasteTableFromExcel
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
            this.m_grid = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnConvert = new System.Windows.Forms.Button();
            this.m_chkUseFirstRowANames = new System.Windows.Forms.CheckBox();
            this.m_btnPaste = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnSaveConfig = new System.Windows.Forms.PictureBox();
            this.m_btnOpenConfig = new System.Windows.Forms.PictureBox();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelMappage = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSaveConfig)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnOpenConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grid
            // 
            this.m_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grid.Location = new System.Drawing.Point(0, 117);
            this.m_grid.Name = "m_grid";
            this.m_grid.Size = new System.Drawing.Size(870, 459);
            this.m_extStyle.SetStyleBackColor(this.m_grid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_grid, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_grid.TabIndex = 0;
            this.m_grid.Scroll += new System.Windows.Forms.ScrollEventHandler(this.m_grid_Scroll);
            this.m_grid.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.m_grid_ColumnHeaderMouseClick);
            this.m_grid.DataSourceChanged += new System.EventHandler(this.m_grid_DataSourceChanged);
            this.m_grid.ColumnWidthChanged += new System.Windows.Forms.DataGridViewColumnEventHandler(this.m_grid_ColumnWidthChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_btnConvert);
            this.panel1.Controls.Add(this.m_chkUseFirstRowANames);
            this.panel1.Controls.Add(this.m_btnPaste);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(870, 64);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(256, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(390, 49);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Copy data from spreadsheet, then click on \'Paste button\' on the left. Map columns" +
                " by right click on column header, then click on \'Convert\' button on the right.";
            // 
            // m_btnConvert
            // 
            this.m_btnConvert.Image = global::timos.Properties.Resources.Transform_table;
            this.m_btnConvert.Location = new System.Drawing.Point(659, 4);
            this.m_btnConvert.Name = "m_btnConvert";
            this.m_btnConvert.Size = new System.Drawing.Size(57, 52);
            this.m_extStyle.SetStyleBackColor(this.m_btnConvert, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnConvert, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnConvert.TabIndex = 2;
            this.m_btnConvert.UseVisualStyleBackColor = true;
            this.m_btnConvert.Click += new System.EventHandler(this.m_btnConvert_Click_1);
            // 
            // m_chkUseFirstRowANames
            // 
            this.m_chkUseFirstRowANames.AutoSize = true;
            this.m_chkUseFirstRowANames.Checked = true;
            this.m_chkUseFirstRowANames.CheckState = System.Windows.Forms.CheckState.Checked;
            this.m_chkUseFirstRowANames.Location = new System.Drawing.Point(6, 23);
            this.m_chkUseFirstRowANames.Name = "m_chkUseFirstRowANames";
            this.m_chkUseFirstRowANames.Size = new System.Drawing.Size(174, 17);
            this.m_extStyle.SetStyleBackColor(this.m_chkUseFirstRowANames, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkUseFirstRowANames, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkUseFirstRowANames.TabIndex = 1;
            this.m_chkUseFirstRowANames.Text = "Use first row as columns names";
            this.m_chkUseFirstRowANames.UseVisualStyleBackColor = true;
            // 
            // m_btnPaste
            // 
            this.m_btnPaste.Image = global::timos.Properties.Resources.PasteIcon;
            this.m_btnPaste.Location = new System.Drawing.Point(188, 6);
            this.m_btnPaste.Name = "m_btnPaste";
            this.m_btnPaste.Size = new System.Drawing.Size(57, 52);
            this.m_extStyle.SetStyleBackColor(this.m_btnPaste, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnPaste, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnPaste.TabIndex = 0;
            this.m_btnPaste.UseVisualStyleBackColor = true;
            this.m_btnPaste.Click += new System.EventHandler(this.m_btnPaste_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.m_btnSaveConfig);
            this.panel2.Controls.Add(this.m_btnOpenConfig);
            this.panel2.Controls.Add(this.m_btnCancel);
            this.panel2.Controls.Add(this.m_btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.ForeColor = System.Drawing.Color.Black;
            this.panel2.Location = new System.Drawing.Point(0, 576);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(870, 50);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel2.TabIndex = 3;
            // 
            // m_btnSaveConfig
            // 
            this.m_btnSaveConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSaveConfig.BackColor = System.Drawing.Color.White;
            this.m_btnSaveConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnSaveConfig.Image = global::timos.Properties.Resources.SaveFile;
            this.m_btnSaveConfig.Location = new System.Drawing.Point(788, 6);
            this.m_btnSaveConfig.Name = "m_btnSaveConfig";
            this.m_btnSaveConfig.Size = new System.Drawing.Size(32, 32);
            this.m_btnSaveConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnSaveConfig, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSaveConfig, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSaveConfig.TabIndex = 3;
            this.m_btnSaveConfig.TabStop = false;
            this.m_btnSaveConfig.Click += new System.EventHandler(this.m_btnSaveConfig_Click);
            // 
            // m_btnOpenConfig
            // 
            this.m_btnOpenConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnOpenConfig.BackColor = System.Drawing.Color.White;
            this.m_btnOpenConfig.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnOpenConfig.Image = global::timos.Properties.Resources.OpenFile;
            this.m_btnOpenConfig.Location = new System.Drawing.Point(826, 6);
            this.m_btnOpenConfig.Name = "m_btnOpenConfig";
            this.m_btnOpenConfig.Size = new System.Drawing.Size(32, 32);
            this.m_btnOpenConfig.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_extStyle.SetStyleBackColor(this.m_btnOpenConfig, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOpenConfig, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOpenConfig.TabIndex = 2;
            this.m_btnOpenConfig.TabStop = false;
            this.m_btnOpenConfig.Click += new System.EventHandler(this.m_btnOpenConfig_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnCancel.Location = new System.Drawing.Point(474, 13);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCancel.TabIndex = 1;
            this.m_btnCancel.Text = "Cancel|11";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.Enabled = false;
            this.m_btnOk.Location = new System.Drawing.Point(321, 13);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "OK|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            this.m_btnOk.EnabledChanged += new System.EventHandler(this.m_btnOk_EnabledChanged);
            // 
            // m_panelMappage
            // 
            this.m_panelMappage.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelMappage.Location = new System.Drawing.Point(0, 64);
            this.m_panelMappage.Name = "m_panelMappage";
            this.m_panelMappage.Size = new System.Drawing.Size(870, 53);
            this.m_extStyle.SetStyleBackColor(this.m_panelMappage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMappage, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMappage.TabIndex = 4;
            this.m_panelMappage.Visible = false;
            // 
            // CFormPasteTableFromExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 626);
            this.Controls.Add(this.m_grid);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_panelMappage);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormPasteTableFromExcel";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Import from Spreadsheeet|20809";
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnSaveConfig)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnOpenConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_grid;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnPaste;
        private System.Windows.Forms.CheckBox m_chkUseFirstRowANames;
        private System.Windows.Forms.Button m_btnConvert;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Panel m_panelMappage;
        private System.Windows.Forms.PictureBox m_btnOpenConfig;
        private System.Windows.Forms.PictureBox m_btnSaveConfig;
    }
}

