namespace timos.CWndControles
{
    partial class CControleDocumentsGed
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CControleDocumentsGed));
            this.m_wndListeImages16 = new System.Windows.Forms.ImageList(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_lblDocument = new System.Windows.Forms.Label();
            this.m_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_btnAttacher = new System.Windows.Forms.Button();
            this.m_picDocument = new System.Windows.Forms.PictureBox();
            this.m_visualiseurGed = new timos.CVisualiseurGed();
            ((System.ComponentModel.ISupportInitialize)(this.m_picDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // m_wndListeImages16
            // 
            this.m_wndListeImages16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("m_wndListeImages16.ImageStream")));
            this.m_wndListeImages16.TransparentColor = System.Drawing.Color.Transparent;
            this.m_wndListeImages16.Images.SetKeyName(0, "document.png");
            // 
            // m_lblDocument
            // 
            this.m_lblDocument.AllowDrop = true;
            this.m_lblDocument.BackColor = System.Drawing.Color.White;
            this.m_lblDocument.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lblDocument.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblDocument.Location = new System.Drawing.Point(137, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblDocument, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblDocument.Name = "m_lblDocument";
            this.m_lblDocument.Size = new System.Drawing.Size(286, 24);
            this.m_lblDocument.TabIndex = 4;
            this.m_lblDocument.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lblDocument.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lblDocument_MouseUp);
            // 
            // m_menu
            // 
            this.m_extModeEdition.SetModeEdition(this.m_menu, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menu.Name = "m_menu";
            this.m_menu.Size = new System.Drawing.Size(61, 4);
            // 
            // m_btnAttacher
            // 
            this.m_btnAttacher.BackgroundImage = global::timos.Properties.Resources.Paper_attach_24x24;
            this.m_btnAttacher.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_btnAttacher.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAttacher.FlatAppearance.BorderSize = 0;
            this.m_btnAttacher.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAttacher.Location = new System.Drawing.Point(423, 0);
            this.m_extModeEdition.SetModeEdition(this.m_btnAttacher, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAttacher.Name = "m_btnAttacher";
            this.m_btnAttacher.Size = new System.Drawing.Size(24, 24);
            this.m_btnAttacher.TabIndex = 0;
            this.m_btnAttacher.UseVisualStyleBackColor = true;
            this.m_btnAttacher.Click += new System.EventHandler(this.m_btnAttacher_Click);
            // 
            // m_picDocument
            // 
            this.m_picDocument.BackgroundImage = global::timos.Properties.Resources.document;
            this.m_picDocument.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.m_picDocument.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picDocument.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picDocument, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picDocument.Name = "m_picDocument";
            this.m_picDocument.Size = new System.Drawing.Size(24, 24);
            this.m_picDocument.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picDocument.TabIndex = 2;
            this.m_picDocument.TabStop = false;
            this.m_picDocument.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_lblDocument_MouseUp);
            // 
            // m_visualiseurGed
            // 
            this.m_visualiseurGed.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_visualiseurGed.Location = new System.Drawing.Point(24, 0);
            this.m_extModeEdition.SetModeEdition(this.m_visualiseurGed, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_visualiseurGed.Name = "m_visualiseurGed";
            this.m_visualiseurGed.Size = new System.Drawing.Size(113, 24);
            this.m_visualiseurGed.TabIndex = 5;
            this.m_visualiseurGed.Visible = false;
            // 
            // CControleDocumentsGed
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblDocument);
            this.Controls.Add(this.m_visualiseurGed);
            this.Controls.Add(this.m_btnAttacher);
            this.Controls.Add(this.m_picDocument);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleDocumentsGed";
            this.Size = new System.Drawing.Size(447, 24);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_lblDocument_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_lblDocument_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.m_picDocument)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList m_wndListeImages16;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.PictureBox m_picDocument;
        private System.Windows.Forms.Label m_lblDocument;
        private System.Windows.Forms.ContextMenuStrip m_menu;
        private System.Windows.Forms.Button m_btnAttacher;
        private CVisualiseurGed m_visualiseurGed;
    }
}
