namespace timos.projet.besoin.map
{
    partial class CControleMapBesoin
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
            this.components = new System.ComponentModel.Container();
            this.m_panelDessin = new System.Windows.Forms.Panel();
            this.m_panelBasEditeur = new System.Windows.Forms.Panel();
            this.m_picZoomPage = new System.Windows.Forms.PictureBox();
            this.m_trackZoom = new System.Windows.Forms.TrackBar();
            this.m_lblZoom = new System.Windows.Forms.Label();
            this.m_menuSatisfaction = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuCentrerSur = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAfficherPhase = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.m_menuAfficherElement = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuAfficherProjet = new System.Windows.Forms.ToolStripMenuItem();
            this.m_menuMasquerProjet = new System.Windows.Forms.ToolStripMenuItem();
            this.m_panelBasEditeur.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picZoomPage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackZoom)).BeginInit();
            this.m_menuSatisfaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelDessin
            // 
            this.m_panelDessin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelDessin.Location = new System.Drawing.Point(0, 0);
            this.m_panelDessin.Name = "m_panelDessin";
            this.m_panelDessin.Size = new System.Drawing.Size(475, 154);
            this.m_panelDessin.TabIndex = 0;
            this.m_panelDessin.TabStop = true;
            this.m_panelDessin.Paint += new System.Windows.Forms.PaintEventHandler(this.m_panelDessin_Paint);
            this.m_panelDessin.MouseMove += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseMove);
            this.m_panelDessin.MouseDown += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseDown);
            this.m_panelDessin.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_panelDessin_MouseUp);
            // 
            // m_panelBasEditeur
            // 
            this.m_panelBasEditeur.Controls.Add(this.m_picZoomPage);
            this.m_panelBasEditeur.Controls.Add(this.m_trackZoom);
            this.m_panelBasEditeur.Controls.Add(this.m_lblZoom);
            this.m_panelBasEditeur.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBasEditeur.Location = new System.Drawing.Point(0, 154);
            this.m_panelBasEditeur.Name = "m_panelBasEditeur";
            this.m_panelBasEditeur.Size = new System.Drawing.Size(475, 29);
            this.m_panelBasEditeur.TabIndex = 3;
            // 
            // m_picZoomPage
            // 
            this.m_picZoomPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picZoomPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_picZoomPage.Image = global::timos.Properties.Resources.page_white_text;
            this.m_picZoomPage.Location = new System.Drawing.Point(316, 0);
            this.m_picZoomPage.Name = "m_picZoomPage";
            this.m_picZoomPage.Size = new System.Drawing.Size(26, 29);
            this.m_picZoomPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_picZoomPage.TabIndex = 2;
            this.m_picZoomPage.TabStop = false;
            this.m_picZoomPage.Click += new System.EventHandler(this.m_picZoomPage_Click);
            // 
            // m_trackZoom
            // 
            this.m_trackZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_trackZoom.Location = new System.Drawing.Point(342, 0);
            this.m_trackZoom.Maximum = 30;
            this.m_trackZoom.Minimum = 1;
            this.m_trackZoom.Name = "m_trackZoom";
            this.m_trackZoom.Size = new System.Drawing.Size(104, 29);
            this.m_trackZoom.TabIndex = 0;
            this.m_trackZoom.Value = 1;
            this.m_trackZoom.ValueChanged += new System.EventHandler(this.m_trackZoom_ValueChanged);
            // 
            // m_lblZoom
            // 
            this.m_lblZoom.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblZoom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblZoom.Location = new System.Drawing.Point(446, 0);
            this.m_lblZoom.Name = "m_lblZoom";
            this.m_lblZoom.Size = new System.Drawing.Size(29, 29);
            this.m_lblZoom.TabIndex = 1;
            this.m_lblZoom.Text = "x1";
            this.m_lblZoom.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_menuSatisfaction
            // 
            this.m_menuSatisfaction.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuCentrerSur,
            this.m_menuAfficherPhase,
            this.m_menuAfficherProjet,
            this.m_menuMasquerProjet,
            this.toolStripMenuItem1,
            this.m_menuAfficherElement});
            this.m_menuSatisfaction.Name = "m_menuBesoin";
            this.m_menuSatisfaction.Size = new System.Drawing.Size(229, 120);
            this.m_menuSatisfaction.Opening += new System.ComponentModel.CancelEventHandler(this.m_menuSatisfaction_Opening);
            // 
            // m_menuCentrerSur
            // 
            this.m_menuCentrerSur.Name = "m_menuCentrerSur";
            this.m_menuCentrerSur.Size = new System.Drawing.Size(228, 22);
            this.m_menuCentrerSur.Text = "Center on this element|20633";
            this.m_menuCentrerSur.Click += new System.EventHandler(this.examinerToolStripMenuItem_Click);
            // 
            // m_menuAfficherPhase
            // 
            this.m_menuAfficherPhase.Name = "m_menuAfficherPhase";
            this.m_menuAfficherPhase.Size = new System.Drawing.Size(228, 22);
            this.m_menuAfficherPhase.Text = "Show Specifications|20632";
            this.m_menuAfficherPhase.Click += new System.EventHandler(this.afficherLaPhaseToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(225, 6);
            // 
            // m_menuAfficherElement
            // 
            this.m_menuAfficherElement.Name = "m_menuAfficherElement";
            this.m_menuAfficherElement.Size = new System.Drawing.Size(228, 22);
            this.m_menuAfficherElement.Text = "Edit|20634";
            this.m_menuAfficherElement.Click += new System.EventHandler(this.m_menuAfficherElement_Click);
            // 
            // m_menuAfficherProjet
            // 
            this.m_menuAfficherProjet.Name = "m_menuAfficherProjet";
            this.m_menuAfficherProjet.Size = new System.Drawing.Size(228, 22);
            this.m_menuAfficherProjet.Text = "Show project|20717";
            this.m_menuAfficherProjet.Click += new System.EventHandler(this.m_menuAfficherProjet_Click);
            // 
            // m_menuMasquerProjet
            // 
            this.m_menuMasquerProjet.Name = "m_menuMasquerProjet";
            this.m_menuMasquerProjet.Size = new System.Drawing.Size(228, 22);
            this.m_menuMasquerProjet.Text = "Hide project|20718";
            // 
            // CControleMapBesoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelDessin);
            this.Controls.Add(this.m_panelBasEditeur);
            this.Name = "CControleMapBesoin";
            this.Size = new System.Drawing.Size(475, 183);
            this.Load += new System.EventHandler(this.CControleMapBesoin_Load);
            this.m_panelBasEditeur.ResumeLayout(false);
            this.m_panelBasEditeur.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picZoomPage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_trackZoom)).EndInit();
            this.m_menuSatisfaction.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelDessin;
        private System.Windows.Forms.Panel m_panelBasEditeur;
        private System.Windows.Forms.TrackBar m_trackZoom;
        private System.Windows.Forms.Label m_lblZoom;
        private System.Windows.Forms.PictureBox m_picZoomPage;
        private System.Windows.Forms.ContextMenuStrip m_menuSatisfaction;
        private System.Windows.Forms.ToolStripMenuItem m_menuCentrerSur;
        private System.Windows.Forms.ToolStripMenuItem m_menuAfficherPhase;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem m_menuAfficherElement;
        private System.Windows.Forms.ToolStripMenuItem m_menuAfficherProjet;
        private System.Windows.Forms.ToolStripMenuItem m_menuMasquerProjet;

    }
}
