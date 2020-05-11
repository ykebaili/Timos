namespace timos.Controles.ActionsSurLink
{
    partial class CControlEditLabelMenuItem
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
            this.m_wndFormuleCondition = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_numMenuItemSort = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_formuleLabel = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.SuspendLayout();
            // 
            // m_wndFormuleCondition
            // 
            this.m_wndFormuleCondition.AllowGraphic = true;
            this.m_wndFormuleCondition.AllowNullFormula = false;
            this.m_wndFormuleCondition.AllowSaisieTexte = true;
            this.m_wndFormuleCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_wndFormuleCondition.Formule = null;
            this.m_wndFormuleCondition.Location = new System.Drawing.Point(95, 89);
            this.m_wndFormuleCondition.LockEdition = false;
            this.m_wndFormuleCondition.LockZoneTexte = false;
            this.m_wndFormuleCondition.Name = "m_wndFormuleCondition";
            this.m_wndFormuleCondition.Size = new System.Drawing.Size(255, 22);
            this.m_wndFormuleCondition.TabIndex = 2;
            // 
            // m_numMenuItemSort
            // 
            this.m_numMenuItemSort.Arrondi = 0;
            this.m_numMenuItemSort.DecimalAutorise = true;
            this.m_numMenuItemSort.EmptyText = "";
            this.m_numMenuItemSort.IntValue = 0;
            this.m_numMenuItemSort.Location = new System.Drawing.Point(95, 13);
            this.m_numMenuItemSort.LockEdition = false;
            this.m_numMenuItemSort.Name = "m_numMenuItemSort";
            this.m_numMenuItemSort.NullAutorise = false;
            this.m_numMenuItemSort.SelectAllOnEnter = true;
            this.m_numMenuItemSort.SeparateurMilliers = "";
            this.m_numMenuItemSort.Size = new System.Drawing.Size(100, 20);
            this.m_numMenuItemSort.TabIndex = 0;
            this.m_numMenuItemSort.Text = "0";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(7, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 13;
            this.label4.Text = "Condition|10407";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 14;
            this.label2.Text = "Label|50";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 23);
            this.label1.TabIndex = 15;
            this.label1.Text = "Sort number|10405";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_formuleLabel
            // 
            this.m_formuleLabel.AllowGraphic = true;
            this.m_formuleLabel.AllowNullFormula = false;
            this.m_formuleLabel.AllowSaisieTexte = true;
            this.m_formuleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_formuleLabel.Formule = null;
            this.m_formuleLabel.Location = new System.Drawing.Point(95, 49);
            this.m_formuleLabel.LockEdition = false;
            this.m_formuleLabel.LockZoneTexte = false;
            this.m_formuleLabel.Name = "m_formuleLabel";
            this.m_formuleLabel.Size = new System.Drawing.Size(255, 22);
            this.m_formuleLabel.TabIndex = 1;
            // 
            // CControlEditLabelMenuItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_formuleLabel);
            this.Controls.Add(this.m_wndFormuleCondition);
            this.Controls.Add(this.m_numMenuItemSort);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "CControlEditLabelMenuItem";
            this.Size = new System.Drawing.Size(363, 174);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.expression.CTextBoxZoomFormule m_wndFormuleCondition;
        private sc2i.win32.common.C2iTextBoxNumerique m_numMenuItemSort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.expression.CTextBoxZoomFormule m_formuleLabel;
    }
}
