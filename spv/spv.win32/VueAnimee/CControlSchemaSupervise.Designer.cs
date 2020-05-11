namespace spv.win32.VueAnimee
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
            this.m_menuRightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuShowDiagram = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuShowProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAlarmes = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuRightClick.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDessin.Location = new System.Drawing.Point(0, 0);
            this.m_panelDessin.Name = "m_panelDessin";
            this.m_panelDessin.Size = new System.Drawing.Size(150, 150);
            this.m_panelDessin.TabIndex = 0;
            this.m_panelDessin.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelDessin_Paint);
            this.m_panelDessin.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseDoubleClick);
            this.m_panelDessin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseUp);
            // 
            // m_menuRightClick
            // 
            this.m_menuRightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuShowDiagram,
            this.m_menuShowProperties,
            this.m_menuAlarmes});
            this.m_menuRightClick.Name = "m_menuRightClick";
            this.m_menuRightClick.Size = new System.Drawing.Size(187, 92);
            this.m_menuRightClick.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuRightClick_Opening);
            // 
            // m_menuShowDiagram
            // 
            this.m_menuShowDiagram.Name = "m_menuShowDiagram";
            this.m_menuShowDiagram.Size = new System.Drawing.Size(186, 22);
            this.m_menuShowDiagram.Text = "Show diagram|20017";
            this.m_menuShowDiagram.Click += new System.EventHandler(this.m_menuShowDiagram_Click);
            // 
            // m_menuShowProperties
            // 
            this.m_menuShowProperties.Name = "m_menuShowProperties";
            this.m_menuShowProperties.Size = new System.Drawing.Size(186, 22);
            this.m_menuShowProperties.Text = "Properties|20018";
            this.m_menuShowProperties.Click += new System.EventHandler(this.m_menuShowProperties_Click);
            // 
            // m_menuAlarmes
            // 
            this.m_menuAlarmes.Name = "m_menuAlarmes";
            this.m_menuAlarmes.Size = new System.Drawing.Size(186, 22);
            this.m_menuAlarmes.Text = "Alarms|20019";
            // 
            // CControlSchemaSupervise
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelDessin);
            this.DoubleBuffered = true;
            this.Name = "CControlSchemaSupervise";
            this.EnabledChanged += new System.EventHandler(this.CControlSchemaSupervise_EnabledChanged);
            this.m_menuRightClick.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        

        #endregion

        private System.Windows.Forms.Panel m_panelDessin;
        private System.Windows.Forms.ContextMenuStrip m_menuRightClick;
        private System.Windows.Forms.ToolStripMenuItem m_menuShowDiagram;
        private System.Windows.Forms.ToolStripMenuItem m_menuShowProperties;
        private System.Windows.Forms.ToolStripMenuItem m_menuAlarmes;
    }
}
