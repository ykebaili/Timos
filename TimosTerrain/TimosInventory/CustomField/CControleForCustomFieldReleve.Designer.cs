namespace TimosInventory.CustomField
{
    partial class CControleForCustomFieldReleve
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
            this.m_lblNomChamp = new System.Windows.Forms.Label();
            this.m_panelForChamp = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // m_lblNomChamp
            // 
            this.m_lblNomChamp.AutoSize = true;
            this.m_lblNomChamp.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblNomChamp.Location = new System.Drawing.Point(0, 0);
            this.m_lblNomChamp.Name = "m_lblNomChamp";
            this.m_lblNomChamp.Size = new System.Drawing.Size(58, 13);
            this.m_lblNomChamp.TabIndex = 0;
            this.m_lblNomChamp.Text = "Field name";
            // 
            // m_panelForChamp
            // 
            this.m_panelForChamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelForChamp.Location = new System.Drawing.Point(58, 0);
            this.m_panelForChamp.Name = "m_panelForChamp";
            this.m_panelForChamp.Size = new System.Drawing.Size(222, 24);
            this.m_panelForChamp.TabIndex = 1;
            // 
            // CControleForCustomFieldReleve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelForChamp);
            this.Controls.Add(this.m_lblNomChamp);
            this.Name = "CControleForCustomFieldReleve";
            this.Size = new System.Drawing.Size(280, 24);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lblNomChamp;
        private System.Windows.Forms.Panel m_panelForChamp;
    }
}
