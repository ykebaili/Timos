namespace futurocom.win32.snmp
{
    partial class CFormViewSNMPResult
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
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_lblRequete = new System.Windows.Forms.Label();
            this.m_grid = new System.Windows.Forms.DataGridView();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_panelTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_lblRequete);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(581, 35);
            this.m_panelTop.TabIndex = 0;
            // 
            // m_lblRequete
            // 
            this.m_lblRequete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblRequete.Location = new System.Drawing.Point(0, 0);
            this.m_lblRequete.Name = "m_lblRequete";
            this.m_lblRequete.Size = new System.Drawing.Size(581, 35);
            this.m_lblRequete.TabIndex = 0;
            // 
            // m_grid
            // 
            this.m_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.m_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grid.Location = new System.Drawing.Point(0, 35);
            this.m_grid.Name = "m_grid";
            this.m_grid.Size = new System.Drawing.Size(581, 347);
            this.m_grid.TabIndex = 1;
            this.m_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.m_grid_CellClick);
            // 
            // m_panelBas
            // 
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 347);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(581, 35);
            this.m_panelBas.TabIndex = 2;
            // 
            // CFormViewSNMPResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 382);
            this.Controls.Add(this.m_panelBas);
            this.Controls.Add(this.m_grid);
            this.Controls.Add(this.m_panelTop);
            this.Name = "CFormViewSNMPResult";
            this.Load += new System.EventHandler(this.CFormViewSNMPResult_Load);
            this.m_panelTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelTop;
        private System.Windows.Forms.DataGridView m_grid;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.Label m_lblRequete;
    }
}