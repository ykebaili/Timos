namespace spv.win32
{
    partial class CExtenderFormTypeqMIB
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
            this.m_vidoirDevidoir = new sc2i.win32.common.CCtrlVidoirDevidoir();
            this.SuspendLayout();
            // 
            // m_vidoirDevidoir
            // 
            this.m_extLinkField.SetLinkField(this.m_vidoirDevidoir, "");
            this.m_vidoirDevidoir.Location = new System.Drawing.Point(45, 35);
            this.m_vidoirDevidoir.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_vidoirDevidoir, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_vidoirDevidoir.Name = "m_vidoirDevidoir";
            this.m_vidoirDevidoir.Size = new System.Drawing.Size(533, 451);
            this.m_extStyle.SetStyleBackColor(this.m_vidoirDevidoir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_vidoirDevidoir, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_vidoirDevidoir.TabIndex = 0;
            // 
            // CExtenderFormTypeqMIB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.Controls.Add(this.m_vidoirDevidoir);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CExtenderFormTypeqMIB";
            this.Size = new System.Drawing.Size(647, 539);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CCtrlVidoirDevidoir m_vidoirDevidoir;
    }
}
