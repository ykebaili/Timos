namespace futurocom.win32.snmp.entitesnmp
{
    partial class CPanelEditeEntiteDeAgent
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
            this.m_sliding = new sc2i.win32.common.CSlidingZone();
            this.m_panelFormulaire = new sc2i.win32.data.dynamic.CPanelFormulaireSurElement();
            this.m_sliding.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_sliding
            // 
            this.m_sliding.AllowDrop = true;
            this.m_sliding.Controls.Add(this.m_panelFormulaire);
            this.m_sliding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_sliding.ExtendedSize = 100;
            this.m_sliding.IsCollapse = false;
            this.m_sliding.Location = new System.Drawing.Point(0, 0);
            this.m_sliding.LockEdition = false;
            this.m_sliding.Name = "m_sliding";
            this.m_sliding.Size = new System.Drawing.Size(411, 285);
            this.m_sliding.TabIndex = 0;
            this.m_sliding.TitleAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_sliding.TitleBackColor = System.Drawing.SystemColors.Control;
            this.m_sliding.TitleBackColorGradient = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(210)))), ((int)(((byte)(224)))));
            this.m_sliding.TitleFont = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_sliding.TitleHeight = 18;
            this.m_sliding.TitleText = "";
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.ElementEdite = null;
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 18);
            this.m_panelFormulaire.LockEdition = false;
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(411, 267);
            this.m_panelFormulaire.TabIndex = 1;
            // 
            // CPanelEditeEntiteDeAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_sliding);
            this.Name = "CPanelEditeEntiteDeAgent";
            this.Size = new System.Drawing.Size(411, 285);
            this.m_sliding.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CSlidingZone m_sliding;
        private sc2i.win32.data.dynamic.CPanelFormulaireSurElement m_panelFormulaire;
    }
}
