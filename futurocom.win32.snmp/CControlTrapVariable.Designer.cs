namespace futurocom.win32.snmp
{
    partial class CControlTrapVariable
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
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_txtValeur = new sc2i.win32.common.C2iTextBox();
            this.m_lblTypeVariable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // m_lblNomVariable
            // 
            this.m_lblNomVariable.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblNomVariable.Location = new System.Drawing.Point(0, 0);
            this.m_lblNomVariable.Name = "m_lblNomVariable";
            this.m_lblNomVariable.Size = new System.Drawing.Size(130, 19);
            this.cExtStyle1.SetStyleBackColor(this.m_lblNomVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lblNomVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblNomVariable.TabIndex = 0;
            this.m_lblNomVariable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtValeur
            // 
            this.m_txtValeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtValeur.EmptyText = "";
            this.m_txtValeur.Location = new System.Drawing.Point(130, 0);
            this.m_txtValeur.LockEdition = false;
            this.m_txtValeur.Name = "m_txtValeur";
            this.m_txtValeur.Size = new System.Drawing.Size(227, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtValeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtValeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtValeur.TabIndex = 1;
            // 
            // m_lblTypeVariable
            // 
            this.m_lblTypeVariable.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lblTypeVariable.Location = new System.Drawing.Point(357, 0);
            this.m_lblTypeVariable.Name = "m_lblTypeVariable";
            this.m_lblTypeVariable.Size = new System.Drawing.Size(130, 19);
            this.cExtStyle1.SetStyleBackColor(this.m_lblTypeVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_lblTypeVariable, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTypeVariable.TabIndex = 2;
            this.m_lblTypeVariable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CControlTrapVariable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.m_txtValeur);
            this.Controls.Add(this.m_lblTypeVariable);
            this.Controls.Add(this.m_lblNomVariable);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CControlTrapVariable";
            this.Size = new System.Drawing.Size(487, 19);
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_lblNomVariable;
        private sc2i.win32.common.CExtStyle cExtStyle1;
        private sc2i.win32.common.C2iTextBox m_txtValeur;
        private System.Windows.Forms.Label m_lblTypeVariable;
    }
}
