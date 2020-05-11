namespace timos.Controles.MemoObjets
{
    partial class CMemoObjets
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMemoObjets));
            this.m_menu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_lblNb = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_menu
            // 
            this.m_menu.Name = "m_menu";
            this.m_menu.Size = new System.Drawing.Size(61, 4);
            // 
            // m_lblNb
            // 
            this.m_lblNb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblNb.BackColor = System.Drawing.Color.Transparent;
            this.m_lblNb.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNb.ForeColor = System.Drawing.Color.White;
            this.m_lblNb.Location = new System.Drawing.Point(0, 11);
            this.m_lblNb.Name = "m_lblNb";
            this.m_lblNb.Size = new System.Drawing.Size(32, 21);
            this.m_lblNb.TabIndex = 2;
            this.m_lblNb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lblNb.MouseUp += new System.Windows.Forms.MouseEventHandler(this.m_picBox_MouseUp);
            this.m_lblNb.MouseEnter += new System.EventHandler(this.m_lblNb_MouseEnter);
            // 
            // CMemoObjets
            // 
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.m_lblNb);
            this.DoubleBuffered = true;
            this.Name = "CMemoObjets";
            this.Size = new System.Drawing.Size(32, 32);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.CMemoObjets_DragOver);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.CMemoObjets_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.CMemoObjets_DragEnter);
            this.MouseEnter += new System.EventHandler(this.m_lblNb_MouseEnter);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip m_menu;
        private System.Windows.Forms.Label m_lblNb;
    }
}
