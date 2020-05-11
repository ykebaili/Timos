namespace timos.projet.gantt
{
    partial class CPanelEditParametreDessinLigneGantt
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
            this.label3 = new System.Windows.Forms.Label();
            this.m_numUpDownHauteurLignes = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownHauteurLignes)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "Lines Height|10062";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_numUpDownHauteurLignes
            // 
            this.m_numUpDownHauteurLignes.Location = new System.Drawing.Point(151, 12);
            this.m_numUpDownHauteurLignes.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.m_numUpDownHauteurLignes.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.m_extModeEdition.SetModeEdition(this.m_numUpDownHauteurLignes, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_numUpDownHauteurLignes.Name = "m_numUpDownHauteurLignes";
            this.m_numUpDownHauteurLignes.Size = new System.Drawing.Size(120, 20);
            this.m_numUpDownHauteurLignes.TabIndex = 2;
            this.m_numUpDownHauteurLignes.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(277, 16);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "min. 10 - max. 50";
            // 
            // CPanelEditParametreDessinLigneGantt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_numUpDownHauteurLignes);
            this.Controls.Add(this.label3);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditParametreDessinLigneGantt";
            this.Size = new System.Drawing.Size(492, 45);
            ((System.ComponentModel.ISupportInitialize)(this.m_numUpDownHauteurLignes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown m_numUpDownHauteurLignes;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
