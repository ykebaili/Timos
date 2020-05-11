namespace timos.supervision.vueanimee
{
    partial class CControlSchemaSupervise
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
            if (m_bitmapDessin != null)
                m_bitmapDessin.Dispose();
            m_bitmapDessin = null;
            if (m_imageCache != null)
                m_imageCache.Dispose();
            m_imageCache = null;
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_panelDessin = new System.Windows.Forms.Panel();
            this.m_progress = new sc2i.win32.common.C2iProgressBar();
            this.m_menuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuShowDiagram = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuShowProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAlarmes = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelSNMP = new System.Windows.Forms.Panel();
            this.m_lblLastSNMPUpdate = new System.Windows.Forms.Label();
            this.m_timerSnmp = new System.Windows.Forms.Timer(this.components);
            this.m_menuRightClick.SuspendLayout();
            this.m_panelSNMP.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDessin.Location = new System.Drawing.Point(0, 0);
            this.m_panelDessin.Name = "m_panelDessin";
            this.m_panelDessin.Size = new System.Drawing.Size(349, 216);
            this.m_panelDessin.TabIndex = 0;
            this.m_panelDessin.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelDessin_Paint);
            this.m_panelDessin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseDoubleClick);
            this.m_panelDessin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseUp);
            // 
            // m_progress
            // 
            this.m_progress.CanCancel = true;
            this.m_progress.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_progress.Location = new System.Drawing.Point(35, 0);
            this.m_progress.Name = "m_progress";
            this.m_progress.SeparateurLibelles = "/";
            this.m_progress.Size = new System.Drawing.Size(314, 22);
            this.m_progress.TabIndex = 1;
            this.m_progress.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.m_progress.Visible = false;
            // 
            // m_menuRightClick
            // 
            this.m_menuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuShowDiagram,
            this.m_menuShowProperties,
            this.m_menuAlarmes});
            this.m_menuRightClick.Name = "m_menuRightClick";
            this.m_menuRightClick.Size = new System.Drawing.Size(187, 70);
            this.m_menuRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuRightClick_Opening);
            // 
            // m_menuShowDiagram
            // 
            this.m_menuShowDiagram.Name = "m_menuShowDiagram";
            this.m_menuShowDiagram.Size = new System.Drawing.Size(186, 22);
            this.m_menuShowDiagram.Text = "Show diagram|20367";
            this.m_menuShowDiagram.Click += new System.EventHandler(this.m_menuShowDiagram_Click);
            // 
            // m_menuShowProperties
            // 
            this.m_menuShowProperties.Name = "m_menuShowProperties";
            this.m_menuShowProperties.Size = new System.Drawing.Size(186, 22);
            this.m_menuShowProperties.Text = "Properties|20368";
            this.m_menuShowProperties.Click += new System.EventHandler(this.m_menuShowProperties_Click);
            // 
            // m_menuAlarmes
            // 
            this.m_menuAlarmes.Name = "m_menuAlarmes";
            this.m_menuAlarmes.Size = new System.Drawing.Size(186, 22);
            this.m_menuAlarmes.Text = "Alarms|20369";
            // 
            // m_panelSNMP
            // 
            this.m_panelSNMP.Controls.Add(this.m_progress);
            this.m_panelSNMP.Controls.Add(this.m_lblLastSNMPUpdate);
            this.m_panelSNMP.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelSNMP.Location = new System.Drawing.Point(0, 0);
            this.m_panelSNMP.Name = "m_panelSNMP";
            this.m_panelSNMP.Size = new System.Drawing.Size(349, 22);
            this.m_panelSNMP.TabIndex = 0;
            // 
            // m_lblLastSNMPUpdate
            // 
            this.m_lblLastSNMPUpdate.AutoSize = true;
            this.m_lblLastSNMPUpdate.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblLastSNMPUpdate.Location = new System.Drawing.Point(0, 0);
            this.m_lblLastSNMPUpdate.Name = "m_lblLastSNMPUpdate";
            this.m_lblLastSNMPUpdate.Size = new System.Drawing.Size(35, 13);
            this.m_lblLastSNMPUpdate.TabIndex = 2;
            this.m_lblLastSNMPUpdate.Text = "label1";
            // 
            // m_timerSnmp
            // 
            this.m_timerSnmp.Enabled = true;
            this.m_timerSnmp.Interval = 300000;
            this.m_timerSnmp.Tick += new System.EventHandler(this.m_timerSnmp_Tick);
            // 
            // CControlSchemaSupervise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelSNMP);
            this.Controls.Add(this.m_panelDessin);
            this.DoubleBuffered = true;
            this.Name = "CControlSchemaSupervise";
            this.Size = new System.Drawing.Size(349, 216);
            this.EnabledChanged += new System.EventHandler(this.CControlSchemaSupervise_EnabledChanged);
            this.m_menuRightClick.ResumeLayout(false);
            this.m_panelSNMP.ResumeLayout(false);
            this.m_panelSNMP.PerformLayout();
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel m_panelDessin;
        private System.Windows.Forms.ContextMenuStrip m_menuRightClick;
        private System.Windows.Forms.ToolStripMenuItem m_menuShowDiagram;
        private System.Windows.Forms.ToolStripMenuItem m_menuShowProperties;
        private System.Windows.Forms.ToolStripMenuItem m_menuAlarmes;
        private sc2i.win32.common.C2iProgressBar m_progress;
        private System.Windows.Forms.Panel m_panelSNMP;
        private System.Windows.Forms.Label m_lblLastSNMPUpdate;
        private System.Windows.Forms.Timer m_timerSnmp;
    }
}
