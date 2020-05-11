namespace timos.Parametrage.sequences
{
    partial class CControleValeurSequence
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
            this.m_lblCle = new System.Windows.Forms.Label();
            this.m_txtLastVal = new sc2i.win32.common.C2iTextBoxNumerique();
            this.SuspendLayout();
            // 
            // m_lblCle
            // 
            this.m_lblCle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblCle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblCle.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblCle, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblCle.Name = "m_lblCle";
            this.m_lblCle.Size = new System.Drawing.Size(149, 20);
            this.m_lblCle.TabIndex = 0;
            this.m_lblCle.Text = "label1";
            this.m_lblCle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtLastVal
            // 
            this.m_txtLastVal.Arrondi = 0;
            this.m_txtLastVal.DecimalAutorise = false;
            this.m_txtLastVal.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtLastVal.DoubleValue = null;
            this.m_txtLastVal.EmptyText = "";
            this.m_txtLastVal.IntValue = null;
            this.m_txtLastVal.Location = new System.Drawing.Point(149, 0);
            this.m_txtLastVal.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtLastVal, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtLastVal.Name = "m_txtLastVal";
            this.m_txtLastVal.NullAutorise = true;
            this.m_txtLastVal.SelectAllOnEnter = true;
            this.m_txtLastVal.SeparateurMilliers = "";
            this.m_txtLastVal.Size = new System.Drawing.Size(100, 20);
            this.m_txtLastVal.TabIndex = 1;
            this.m_txtLastVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_txtLastVal.TextChanged += new System.EventHandler(this.m_txtLastVal_TextChanged);
            // 
            // CControleValeurSequence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblCle);
            this.Controls.Add(this.m_txtLastVal);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleValeurSequence";
            this.Size = new System.Drawing.Size(249, 20);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lblCle;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtLastVal;
    }
}
