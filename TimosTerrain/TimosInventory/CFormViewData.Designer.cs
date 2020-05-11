namespace TimosInventory
{
    partial class CFormViewData
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
            this.m_grid = new System.Windows.Forms.DataGrid();
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // m_grid
            // 
            this.m_grid.DataMember = "";
            this.m_grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_grid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.m_grid.Location = new System.Drawing.Point(0, 0);
            this.m_grid.Name = "m_grid";
            this.m_grid.Size = new System.Drawing.Size(598, 471);
            this.m_grid.TabIndex = 1;
            // 
            // CFormViewData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(598, 471);
            this.Controls.Add(this.m_grid);
            this.Name = "CFormViewData";
            this.Text = "CFormViewData";
            ((System.ComponentModel.ISupportInitialize)(this.m_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGrid m_grid;

    }
}