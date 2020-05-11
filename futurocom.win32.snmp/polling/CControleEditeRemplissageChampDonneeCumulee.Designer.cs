namespace futurocom.win32.snmp.polling
{
    partial class CControleEditeRemplissageChampDonneeCumulee
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
            this.m_lblChamp = new System.Windows.Forms.Label();
            this.m_txtFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblFormule = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_lblChamp
            // 
            this.m_lblChamp.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblChamp.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblChamp, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblChamp.Name = "m_lblChamp";
            this.m_lblChamp.Size = new System.Drawing.Size(127, 28);
            this.m_lblChamp.TabIndex = 0;
            this.m_lblChamp.Text = "FieldName";
            this.m_lblChamp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.AllowGraphic = true;
            this.m_txtFormule.AllowNullFormula = true;
            this.m_txtFormule.AllowSaisieTexte = true;
            this.m_txtFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormule.Formule = null;
            this.m_txtFormule.Location = new System.Drawing.Point(127, 0);
            this.m_txtFormule.LockEdition = false;
            this.m_txtFormule.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(357, 28);
            this.m_txtFormule.TabIndex = 1;
            // 
            // m_lblFormule
            // 
            this.m_lblFormule.BackColor = System.Drawing.Color.White;
            this.m_lblFormule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblFormule.Location = new System.Drawing.Point(186, 4);
            this.m_extModeEdition.SetModeEdition(this.m_lblFormule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFormule.Name = "m_lblFormule";
            this.m_lblFormule.Size = new System.Drawing.Size(100, 23);
            this.m_lblFormule.TabIndex = 2;
            this.m_lblFormule.Text = "label1";
            // 
            // CControleEditeRemplissageChampDonneeCumulee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblFormule);
            this.Controls.Add(this.m_txtFormule);
            this.Controls.Add(this.m_lblChamp);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeRemplissageChampDonneeCumulee";
            this.Size = new System.Drawing.Size(484, 28);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblChamp;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormule;
        private System.Windows.Forms.Label m_lblFormule;
    }
}
