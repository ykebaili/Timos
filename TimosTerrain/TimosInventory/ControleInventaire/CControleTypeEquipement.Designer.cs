namespace TimosInventory.ControleInventaire
{
    partial class CControleTypeEquipement
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
            this.m_cmbRefConst = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtSelectTypeEquipement = new sc2i.win32.common.MemoryDb.C2iTextBoxSelectionEntiteMemoryDb();
            this.SuspendLayout();
            // 
            // m_cmbRefConst
            // 
            this.m_cmbRefConst.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_cmbRefConst.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_cmbRefConst.FormattingEnabled = true;
            this.m_cmbRefConst.Location = new System.Drawing.Point(27, 21);
            this.m_cmbRefConst.Name = "m_cmbRefConst";
            this.m_cmbRefConst.Size = new System.Drawing.Size(430, 21);
            this.m_cmbRefConst.TabIndex = 1;
            this.m_cmbRefConst.SelectionChangeCommitted += new System.EventHandler(this.m_cmbRefConst_SelectedValueChanged);
            this.m_cmbRefConst.Enter += new System.EventHandler(this.m_cmbRefConst_Enter);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "P/N";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtSelectTypeEquipement
            // 
            this.m_txtSelectTypeEquipement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_txtSelectTypeEquipement.FonctionTextNull = null;
            this.m_txtSelectTypeEquipement.ImageDisplayMode = sc2i.win32.common.MemoryDb.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectTypeEquipement.Location = new System.Drawing.Point(0, 0);
            this.m_txtSelectTypeEquipement.LockEdition = false;
            this.m_txtSelectTypeEquipement.Name = "m_txtSelectTypeEquipement";
            this.m_txtSelectTypeEquipement.SelectedObject = null;
            this.m_txtSelectTypeEquipement.Size = new System.Drawing.Size(457, 21);
            this.m_txtSelectTypeEquipement.SpecificImage = null;
            this.m_txtSelectTypeEquipement.TabIndex = 3;
            this.m_txtSelectTypeEquipement.TextNull = "";
            this.m_txtSelectTypeEquipement.UseIntellisense = true;
            // 
            // CControleTypeEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_cmbRefConst);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_txtSelectTypeEquipement);
            this.Name = "CControleTypeEquipement";
            this.Size = new System.Drawing.Size(457, 42);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox m_cmbRefConst;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.MemoryDb.C2iTextBoxSelectionEntiteMemoryDb m_txtSelectTypeEquipement;
    }
}
