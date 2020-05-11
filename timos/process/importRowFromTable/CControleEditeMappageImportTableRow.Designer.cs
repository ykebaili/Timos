namespace timos.process.importRowFromTable
{
    partial class CControleEditeMappageImportTableRow
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
            this.m_lblColonne = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_cmbChamp = new sc2i.win32.common.CComboboxAutoFilled();
            this.m_txtFormuleCondition = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.SuspendLayout();
            // 
            // m_lblColonne
            // 
            this.m_lblColonne.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblColonne.Location = new System.Drawing.Point(0, 0);
            this.m_lblColonne.Name = "m_lblColonne";
            this.m_lblColonne.Size = new System.Drawing.Size(130, 23);
            this.m_lblColonne.TabIndex = 0;
            this.m_lblColonne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Black;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(0, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(624, 1);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // m_cmbChamp
            // 
            this.m_cmbChamp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_cmbChamp.FormattingEnabled = true;
            this.m_cmbChamp.IsLink = false;
            this.m_cmbChamp.ListDonnees = null;
            this.m_cmbChamp.Location = new System.Drawing.Point(130, 0);
            this.m_cmbChamp.LockEdition = false;
            this.m_cmbChamp.Name = "m_cmbChamp";
            this.m_cmbChamp.NullAutorise = false;
            this.m_cmbChamp.ProprieteAffichee = null;
            this.m_cmbChamp.Size = new System.Drawing.Size(324, 21);
            this.m_cmbChamp.TabIndex = 2;
            this.m_cmbChamp.TextNull = "(empty)";
            this.m_cmbChamp.Tri = true;
            // 
            // m_txtFormuleCondition
            // 
            this.m_txtFormuleCondition.AllowGraphic = true;
            this.m_txtFormuleCondition.AllowNullFormula = true;
            this.m_txtFormuleCondition.AllowSaisieTexte = true;
            this.m_txtFormuleCondition.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_txtFormuleCondition.Formule = null;
            this.m_txtFormuleCondition.Location = new System.Drawing.Point(454, 0);
            this.m_txtFormuleCondition.LockEdition = false;
            this.m_txtFormuleCondition.LockZoneTexte = false;
            this.m_txtFormuleCondition.Name = "m_txtFormuleCondition";
            this.m_txtFormuleCondition.Size = new System.Drawing.Size(170, 23);
            this.m_txtFormuleCondition.TabIndex = 3;
            // 
            // CControleEditeMappageImportTableRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_cmbChamp);
            this.Controls.Add(this.m_txtFormuleCondition);
            this.Controls.Add(this.m_lblColonne);
            this.Controls.Add(this.label1);
            this.Name = "CControleEditeMappageImportTableRow";
            this.Size = new System.Drawing.Size(624, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblColonne;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbChamp;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleCondition;
    }
}
