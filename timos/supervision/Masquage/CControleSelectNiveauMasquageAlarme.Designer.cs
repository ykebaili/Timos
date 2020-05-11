namespace timos.supervision
{
    partial class CControleSelectNiveauMasquageAlarme
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_trackBar = new System.Windows.Forms.TrackBar();
            this.m_panelLibelles = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // m_trackBar
            // 
            this.m_trackBar.AutoSize = false;
            this.m_trackBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_trackBar.LargeChange = 1;
            this.m_trackBar.Location = new System.Drawing.Point(0, 0);
            this.m_trackBar.Maximum = 5;
            this.m_trackBar.Name = "m_trackBar";
            this.m_trackBar.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.m_trackBar.Size = new System.Drawing.Size(28, 227);
            this.m_trackBar.TabIndex = 0;
            // 
            // m_panelLibelles
            // 
            this.m_panelLibelles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelLibelles.Location = new System.Drawing.Point(28, 0);
            this.m_panelLibelles.Name = "m_panelLibelles";
            this.m_panelLibelles.Size = new System.Drawing.Size(96, 227);
            this.m_panelLibelles.TabIndex = 1;
            // 
            // CControleSelectNiveauMasquageAlarme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelLibelles);
            this.Controls.Add(this.m_trackBar);
            this.Name = "CControleSelectNiveauMasquageAlarme";
            this.Size = new System.Drawing.Size(124, 227);
            this.Resize += new System.EventHandler(this.CControleSelectNiveauMasquageAlarme_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.m_trackBar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar m_trackBar;
        private System.Windows.Forms.Panel m_panelLibelles;
    }
}
