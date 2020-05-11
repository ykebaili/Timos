namespace timos.Parametrage.ConsultationHierarchique
{
    partial class CFormTestConsultationHierarchique
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
            if (m_contexteDonnee != null)
                m_contexteDonnee.Dispose();
            m_contexteDonnee = null;
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_arbre = new timos.Parametrage.ConsultationHierarchique.CArbreConsultationHierarchique();
            this.SuspendLayout();
            // 
            // m_arbre
            // 
            this.m_arbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_arbre.Location = new System.Drawing.Point(0, 0);
            this.m_arbre.Name = "m_arbre";
            this.m_arbre.Size = new System.Drawing.Size(292, 420);
            this.m_arbre.TabIndex = 0;
            // 
            // CFormTestConsultationHierarchique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(292, 420);
            this.Controls.Add(this.m_arbre);
            this.Name = "CFormTestConsultationHierarchique";
            this.Text = "Hierarchical consultation test|20094";
            this.Load += new System.EventHandler(this.CFormTestConsultationHierarchique_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CArbreConsultationHierarchique m_arbre;
    }
}