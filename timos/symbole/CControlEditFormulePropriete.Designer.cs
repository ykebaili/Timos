namespace timos.symbole
{
    partial class CControlEditFormulePropriete
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
            this.m_lblPropriete = new System.Windows.Forms.Label();
            this.m_txtFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.SuspendLayout();
            // 
            // m_lblPropriete
            // 
            this.m_lblPropriete.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblPropriete.Location = new System.Drawing.Point(0, 0);
            this.m_lblPropriete.Name = "m_lblPropriete";
            this.m_lblPropriete.Size = new System.Drawing.Size(84, 32);
            this.m_lblPropriete.TabIndex = 0;
            this.m_lblPropriete.Text = "Property|20157";
            this.m_lblPropriete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormule.Formule = null;
            this.m_txtFormule.Location = new System.Drawing.Point(84, 0);
            this.m_txtFormule.LockEdition = false;
            this.m_txtFormule.LockZoneTexte = false;
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(160, 32);
            this.m_txtFormule.TabIndex = 1;
            // 
            // CControlEditFormulePropriete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_txtFormule);
            this.Controls.Add(this.m_lblPropriete);
            this.Name = "CControlEditFormulePropriete";
            this.Size = new System.Drawing.Size(244, 32);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblPropriete;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormule;
    }
}
