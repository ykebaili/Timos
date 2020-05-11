namespace TimosWebApp
{
    partial class CControlVariableValeur
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
            this.m_lblNomVariable = new System.Windows.Forms.Label();
            this.m_txtValeur = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_lblNomVariable
            // 
            this.m_lblNomVariable.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblNomVariable.Location = new System.Drawing.Point(0, 0);
            this.m_lblNomVariable.Name = "m_lblNomVariable";
            this.m_lblNomVariable.Size = new System.Drawing.Size(174, 22);
            this.m_lblNomVariable.TabIndex = 0;
            this.m_lblNomVariable.Text = "Nom de variable";
            this.m_lblNomVariable.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtValeur
            // 
            this.m_txtValeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtValeur.Location = new System.Drawing.Point(174, 0);
            this.m_txtValeur.Name = "m_txtValeur";
            this.m_txtValeur.Size = new System.Drawing.Size(273, 20);
            this.m_txtValeur.TabIndex = 1;
            // 
            // CControlVariableValeur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtValeur);
            this.Controls.Add(this.m_lblNomVariable);
            this.Name = "CControlVariableValeur";
            this.Size = new System.Drawing.Size(447, 22);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lblNomVariable;
        private System.Windows.Forms.TextBox m_txtValeur;
    }
}
