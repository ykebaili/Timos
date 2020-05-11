namespace spv.win32
{
    partial class CFormTestSpvGraph
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
            this.m_arbre = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // m_arbre
            // 
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbre.Location = new System.Drawing.Point(0, 0);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(519, 535);
            this.m_arbre.TabIndex = 0;
            this.m_arbre.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.m_arbre_BeforeExpand);
            // 
            // CFormTestSpvGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 535);
            this.Controls.Add(this.m_arbre);
            this.Name = "CFormTestSpvGraph";
            this.Text = "CFormTestSpvGraph";
            this.Load += new System.EventHandler(this.CFormTestSpvGraph_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView m_arbre;
    }
}