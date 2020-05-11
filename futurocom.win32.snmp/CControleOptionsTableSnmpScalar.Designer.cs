namespace futurocom.win32.snmp
{
    partial class CControleOptionsTableSnmpScalar
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
            this.m_chkOptimiser = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // m_chkOptimiser
            // 
            this.m_chkOptimiser.AutoSize = true;
            this.m_chkOptimiser.Location = new System.Drawing.Point(6, 7);
            this.m_chkOptimiser.Name = "m_chkOptimiser";
            this.m_chkOptimiser.Size = new System.Drawing.Size(127, 17);
            this.m_chkOptimiser.TabIndex = 0;
            this.m_chkOptimiser.Text = "Optimize Read|20104";
            this.m_chkOptimiser.UseVisualStyleBackColor = true;
            // 
            // CControleOptionsTableSnmpScalar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_chkOptimiser);
            this.Name = "CControleOptionsTableSnmpScalar";
            this.Size = new System.Drawing.Size(218, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox m_chkOptimiser;
    }
}
