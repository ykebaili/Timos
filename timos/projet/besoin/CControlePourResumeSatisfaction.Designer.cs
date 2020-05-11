namespace timos.projet.besoin
{
    partial class CControlePourResumeSatisfaction
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
            this.m_picBox = new System.Windows.Forms.PictureBox();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_menuBesoins = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_menuDisplayMap = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            ((System.ComponentModel.ISupportInitialize)(this.m_picBox)).BeginInit();
            this.m_menuBesoins.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_picBox
            // 
            this.m_picBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_picBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_picBox.Image = global::timos.Properties.Resources.PuzzleMal32;
            this.m_picBox.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_picBox, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_picBox.Name = "m_picBox";
            this.m_picBox.Size = new System.Drawing.Size(32, 32);
            this.m_picBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picBox.TabIndex = 0;
            this.m_picBox.TabStop = false;
            this.m_picBox.Click += new System.EventHandler(this.m_picBox_Click);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.m_picBox_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.m_picBox_DragEnter);
            // 
            // m_menuBesoins
            // 
            this.m_menuBesoins.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_menuDisplayMap,
            this.toolStripMenuItem1});
            this.m_extModeEdition.SetModeEdition(this.m_menuBesoins, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuBesoins.Name = "m_menuBesoins";
            this.m_menuBesoins.Size = new System.Drawing.Size(177, 32);
            // 
            // m_menuDisplayMap
            // 
            this.m_menuDisplayMap.Name = "m_menuDisplayMap";
            this.m_menuDisplayMap.Size = new System.Drawing.Size(176, 22);
            this.m_menuDisplayMap.Text = "Display map|20635";
            this.m_menuDisplayMap.Click += new System.EventHandler(this.m_menuDisplayMap_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(173, 6);
            // 
            // CControlePourResumeSatisfaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_picBox);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlePourResumeSatisfaction";
            this.Size = new System.Drawing.Size(32, 32);
            ((System.ComponentModel.ISupportInitialize)(this.m_picBox)).EndInit();
            this.m_menuBesoins.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox m_picBox;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.ContextMenuStrip m_menuBesoins;
        private System.Windows.Forms.ToolStripMenuItem m_menuDisplayMap;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    }
}
