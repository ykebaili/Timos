namespace futurocom.win32.snmp
{
    partial class CFormVisuTable
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
            this.m_grid = new System.Windows.Forms.DataGridView();
            this.m_lblRequete = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grid
            // 
            this.m_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grid.Location = new System.Drawing.Point(0, 35);
            this.m_grid.Name = "m_grid";
            this.m_grid.Size = new System.Drawing.Size(432, 337);
            this.m_grid.TabIndex = 0;
            // 
            // m_lblRequete
            // 
            this.m_lblRequete.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblRequete.Location = new System.Drawing.Point(0, 0);
            this.m_lblRequete.Name = "m_lblRequete";
            this.m_lblRequete.Size = new System.Drawing.Size(432, 35);
            this.m_lblRequete.TabIndex = 1;
            // 
            // CFormVisuTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 372);
            this.Controls.Add(this.m_grid);
            this.Controls.Add(this.m_lblRequete);
            this.Name = "CFormVisuTable";
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView m_grid;
        private System.Windows.Forms.Label m_lblRequete;
    }
}