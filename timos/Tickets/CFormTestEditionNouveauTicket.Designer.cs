namespace timos
{
    partial class CFormTestEditionNouveauTicket
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

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.m_btnValider = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_panelEditionTicket = new timos.CPanelEditionTicket();
            this.SuspendLayout();
            // 
            // m_btnValider
            // 
            this.m_btnValider.Location = new System.Drawing.Point(233, 10);
            this.m_btnValider.Name = "m_btnValider";
            this.m_btnValider.Size = new System.Drawing.Size(114, 23);
            this.m_btnValider.TabIndex = 1;
            this.m_btnValider.Text = "&Valider Modifs";
            this.m_btnValider.UseVisualStyleBackColor = true;
            this.m_btnValider.Click += new System.EventHandler(this.m_btnValider_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Location = new System.Drawing.Point(391, 10);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(110, 23);
            this.m_btnAnnuler.TabIndex = 2;
            this.m_btnAnnuler.Text = "&Annuler";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_panelEditionTicket
            // 
            this.m_panelEditionTicket.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelEditionTicket.Location = new System.Drawing.Point(0, 40);
            this.m_panelEditionTicket.LockEdition = true;
            this.m_panelEditionTicket.Name = "m_panelEditionTicket";
            this.m_panelEditionTicket.Size = new System.Drawing.Size(827, 594);
            this.m_panelEditionTicket.TabIndex = 0;
            // 
            // CFormTestEditionNouveauTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(827, 634);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnValider);
            this.Controls.Add(this.m_panelEditionTicket);
            this.Name = "CFormTestEditionNouveauTicket";
            this.Text = "CFormTestEditionNouveauTicket";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);

        }

        #endregion

        private CPanelEditionTicket m_panelEditionTicket;
        private System.Windows.Forms.Button m_btnValider;
        private System.Windows.Forms.Button m_btnAnnuler;
    }
}