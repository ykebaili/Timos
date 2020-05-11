namespace TimosInventory
{
    partial class CControlPresence
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
            this.m_chkPresent = new System.Windows.Forms.CheckBox();
            this.m_chkAbsent = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_chkPresent
            // 
            this.m_chkPresent.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkPresent.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkPresent.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkPresent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkPresent.Location = new System.Drawing.Point(0, 0);
            this.m_chkPresent.Name = "m_chkPresent";
            this.m_chkPresent.Size = new System.Drawing.Size(60, 56);
            this.m_chkPresent.TabIndex = 0;
            this.m_chkPresent.Text = "Present|20022";
            this.m_chkPresent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_chkPresent.UseVisualStyleBackColor = true;
            this.m_chkPresent.CheckedChanged += new System.EventHandler(this.m_chkPresent_CheckedChanged);
            // 
            // m_chkAbsent
            // 
            this.m_chkAbsent.Appearance = System.Windows.Forms.Appearance.Button;
            this.m_chkAbsent.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_chkAbsent.FlatAppearance.CheckedBackColor = System.Drawing.Color.Lime;
            this.m_chkAbsent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_chkAbsent.Location = new System.Drawing.Point(70, 0);
            this.m_chkAbsent.Name = "m_chkAbsent";
            this.m_chkAbsent.Size = new System.Drawing.Size(60, 56);
            this.m_chkAbsent.TabIndex = 1;
            this.m_chkAbsent.Text = "Absent|20023";
            this.m_chkAbsent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_chkAbsent.UseVisualStyleBackColor = true;
            this.m_chkAbsent.CheckedChanged += new System.EventHandler(this.m_chkAbsent_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(60, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 56);
            this.label1.TabIndex = 2;
            // 
            // CControlPresence
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_chkAbsent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_chkPresent);
            this.Name = "CControlPresence";
            this.Size = new System.Drawing.Size(199, 56);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox m_chkPresent;
        private System.Windows.Forms.CheckBox m_chkAbsent;
        private System.Windows.Forms.Label label1;
    }
}
