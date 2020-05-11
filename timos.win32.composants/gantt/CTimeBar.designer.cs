namespace timos.win32.gantt
{
    partial class CTimeBar
    {
        /// <summary> 
        /// Variable nÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©cessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©es.
        /// </summary>
        /// <param name="disposing">true si les ressources managÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©es doivent ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Âªtre supprimÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©esÃƒÆ’Ã¢â‚¬Å¡Ãƒâ€šÃ‚Â ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code gÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©nÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©rÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â© par le Concepteur de composants

        /// <summary> 
        /// MÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©thode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette mÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©thode avec l'ÃƒÆ’Ã†â€™Ãƒâ€šÃ‚Â©diteur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_menuEchelle = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuHeure = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuJour = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuSemaine = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuMois = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.precisionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuPrecision12 = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuApplyAsDefaultScale = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuEchelle.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_menuEchelle
            // 
            this.m_menuEchelle.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuHeure,
            this.m_menuJour,
            this.m_menuSemaine,
            this.m_menuMois,
            this.toolStripMenuItem1,
            this.precisionToolStripMenuItem,
            this.m_menuApplyAsDefaultScale});
            this.m_menuEchelle.Name = "m_menuEchelle";
            this.m_menuEchelle.Size = new System.Drawing.Size(222, 164);
            this.m_menuEchelle.Text = "Heure";
            this.m_menuEchelle.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuEchelle_Opening);
            // 
            // m_menuHeure
            // 
            this.m_menuHeure.Name = "m_menuHeure";
            this.m_menuHeure.Size = new System.Drawing.Size(221, 22);
            this.m_menuHeure.Text = "Time|20004";
            this.m_menuHeure.Click += new System.EventHandler(this.m_menuHeure_Click);
            // 
            // m_menuJour
            // 
            this.m_menuJour.Name = "m_menuJour";
            this.m_menuJour.Size = new System.Drawing.Size(221, 22);
            this.m_menuJour.Text = "Day|20005";
            this.m_menuJour.Click += new System.EventHandler(this.m_menuJour_Click);
            // 
            // m_menuSemaine
            // 
            this.m_menuSemaine.Name = "m_menuSemaine";
            this.m_menuSemaine.Size = new System.Drawing.Size(221, 22);
            this.m_menuSemaine.Text = "Week|20006";
            this.m_menuSemaine.Click += new System.EventHandler(this.m_menuSemaine_Click);
            // 
            // m_menuMois
            // 
            this.m_menuMois.Name = "m_menuMois";
            this.m_menuMois.Size = new System.Drawing.Size(221, 22);
            this.m_menuMois.Text = "Month|20007";
            this.m_menuMois.Click += new System.EventHandler(this.m_menuMois_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(218, 6);
            // 
            // precisionToolStripMenuItem
            // 
            this.precisionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuPrecision12});
            this.precisionToolStripMenuItem.Name = "precisionToolStripMenuItem";
            this.precisionToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.precisionToolStripMenuItem.Text = "Precision|20008";
            this.precisionToolStripMenuItem.DropDownOpening += new System.EventHandler(this.precisionToolStripMenuItem_DropDownOpening);
            // 
            // m_menuPrecision12
            // 
            this.m_menuPrecision12.Name = "m_menuPrecision12";
            this.m_menuPrecision12.Size = new System.Drawing.Size(152, 22);
            this.m_menuPrecision12.Text = "12";
            // 
            // m_menuApplyAsDefaultScale
            // 
            this.m_menuApplyAsDefaultScale.Name = "m_menuApplyAsDefaultScale";
            this.m_menuApplyAsDefaultScale.Size = new System.Drawing.Size(221, 22);
            this.m_menuApplyAsDefaultScale.Text = "Apply as default scale|20030";
            this.m_menuApplyAsDefaultScale.Click += new System.EventHandler(this.m_menuApplyAsDefaultScale_Click);
            // 
            // CTimeBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.DoubleBuffered = true;
            this.Name = "CTimeBar";
            this.Size = new System.Drawing.Size(448, 82);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CTimeBar_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CTimeBar_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.CTimeBar_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CTimeBar_MouseUp);
            this.m_menuEchelle.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_menuEchelle;
        private System.Windows.Forms.ToolStripMenuItem m_menuHeure;
        private System.Windows.Forms.ToolStripMenuItem m_menuJour;
        private System.Windows.Forms.ToolStripMenuItem m_menuMois;
        private System.Windows.Forms.ToolStripMenuItem precisionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem m_menuPrecision12;
        private System.Windows.Forms.ToolStripMenuItem m_menuSemaine;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem m_menuApplyAsDefaultScale;
    }
}
