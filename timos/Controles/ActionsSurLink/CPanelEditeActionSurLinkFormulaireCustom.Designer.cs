namespace timos.Controles.ActionsSurLink
{
    partial class CPanelEditeActionSurLinkFormulaireCustom
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
            this.m_panelFormulaireCustom = new System.Windows.Forms.Panel();
            this.m_cmbFormulaireCustom = new sc2i.win32.common.CComboboxAutoFilled();
            this.label3 = new System.Windows.Forms.Label();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_panelFormulaireCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelFormulaireCustom
            // 
            this.m_panelFormulaireCustom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFormulaireCustom.Controls.Add(this.m_cmbFormulaireCustom);
            this.m_panelFormulaireCustom.Controls.Add(this.label3);
            this.m_panelFormulaireCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaireCustom.ForeColor = System.Drawing.Color.Black;
            this.m_panelFormulaireCustom.Location = new System.Drawing.Point(0, 0);
            this.m_panelFormulaireCustom.Name = "m_panelFormulaireCustom";
            this.m_panelFormulaireCustom.Size = new System.Drawing.Size(580, 37);
            this.cExtStyle1.SetStyleBackColor(this.m_panelFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaireCustom.TabIndex = 7;
            // 
            // m_cmbFormulaireCustom
            // 
            this.m_cmbFormulaireCustom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbFormulaireCustom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_cmbFormulaireCustom.IsLink = false;
            this.m_cmbFormulaireCustom.ListDonnees = null;
            this.m_cmbFormulaireCustom.Location = new System.Drawing.Point(133, 7);
            this.m_cmbFormulaireCustom.LockEdition = false;
            this.m_cmbFormulaireCustom.Name = "m_cmbFormulaireCustom";
            this.m_cmbFormulaireCustom.NullAutorise = true;
            this.m_cmbFormulaireCustom.ProprieteAffichee = "Libelle";
            this.m_cmbFormulaireCustom.Size = new System.Drawing.Size(419, 21);
            this.cExtStyle1.SetStyleBackColor(this.m_cmbFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_cmbFormulaireCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbFormulaireCustom.TabIndex = 3;
            this.m_cmbFormulaireCustom.TextNull = "(none)";
            this.m_cmbFormulaireCustom.Tri = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 16);
            this.cExtStyle1.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 2;
            this.label3.Text = "Form|555";
            // 
            // CPanelEditeActionSurLinkFormulaireCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelFormulaireCustom);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CPanelEditeActionSurLinkFormulaireCustom";
            this.Size = new System.Drawing.Size(580, 37);
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelEditeActionSurLinkFormulaireCustom_Load);
            this.m_panelFormulaireCustom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelFormulaireCustom;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbFormulaireCustom;
        private sc2i.win32.common.CExtStyle cExtStyle1;
        private System.Windows.Forms.Label label3;
    }
}
