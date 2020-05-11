namespace timos
{
    partial class CControlNotification
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
            this.m_link = new System.Windows.Forms.LinkLabel();
            this.m_panelImage = new System.Windows.Forms.Panel();
            this.m_panelSep = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_imageNotif = new System.Windows.Forms.PictureBox();
            this.m_panelImage.SuspendLayout();
            this.m_panelSep.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageNotif)).BeginInit();
            this.SuspendLayout();
            // 
            // m_link
            // 
            this.m_link.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_link.Location = new System.Drawing.Point(34, 0);
            this.m_extModeEdition.SetModeEdition(this.m_link, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_link.Name = "m_link";
            this.m_link.Size = new System.Drawing.Size(158, 35);
            this.m_link.TabIndex = 0;
            this.m_link.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_link.Click += new System.EventHandler(this.m_link_Click);
            // 
            // m_panelImage
            // 
            this.m_panelImage.Controls.Add(this.m_imageNotif);
            this.m_panelImage.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelImage.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelImage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelImage.Name = "m_panelImage";
            this.m_panelImage.Size = new System.Drawing.Size(34, 35);
            this.m_panelImage.TabIndex = 1;
            // 
            // m_panelSep
            // 
            this.m_panelSep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(108)))), ((int)(((byte)(0)))));
            this.m_panelSep.Controls.Add(this.label2);
            this.m_panelSep.Controls.Add(this.label1);
            this.m_panelSep.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelSep.Location = new System.Drawing.Point(0, 35);
            this.m_extModeEdition.SetModeEdition(this.m_panelSep, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelSep.Name = "m_panelSep";
            this.m_panelSep.Size = new System.Drawing.Size(192, 1);
            this.m_panelSep.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(152)))), ((int)(((byte)(5)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(5, 1);
            this.label1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(152)))), ((int)(((byte)(5)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Right;
            this.label2.Location = new System.Drawing.Point(187, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(5, 1);
            this.label2.TabIndex = 1;
            // 
            // m_imageNotif
            // 
            this.m_imageNotif.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.m_imageNotif.Location = new System.Drawing.Point(5, 5);
            this.m_extModeEdition.SetModeEdition(this.m_imageNotif, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_imageNotif.Name = "m_imageNotif";
            this.m_imageNotif.Size = new System.Drawing.Size(24, 24);
            this.m_imageNotif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_imageNotif.TabIndex = 0;
            this.m_imageNotif.TabStop = false;
            // 
            // CControlNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.ColorInactive = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(229)))), ((int)(((byte)(229)))));
            this.Controls.Add(this.m_link);
            this.Controls.Add(this.m_panelImage);
            this.Controls.Add(this.m_panelSep);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlNotification";
            this.Size = new System.Drawing.Size(192, 36);
            this.m_panelImage.ResumeLayout(false);
            this.m_panelSep.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageNotif)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel m_link;
        private System.Windows.Forms.Panel m_panelImage;
        private System.Windows.Forms.PictureBox m_imageNotif;
        private System.Windows.Forms.Panel m_panelSep;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}
