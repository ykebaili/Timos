namespace timos.projet.besoin
{
    partial class CEditeurDonneeBesoinEquipement
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
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtSelectTypeEquipement = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment type|20597";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSelectTypeEquipement
            // 
            this.m_txtSelectTypeEquipement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSelectTypeEquipement.ElementSelectionne = null;
            this.m_txtSelectTypeEquipement.FonctionTextNull = null;
            this.m_txtSelectTypeEquipement.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectTypeEquipement.Location = new System.Drawing.Point(140, 0);
            this.m_txtSelectTypeEquipement.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectTypeEquipement.Name = "m_txtSelectTypeEquipement";
            this.m_txtSelectTypeEquipement.SelectedObject = null;
            this.m_txtSelectTypeEquipement.SelectionLength = 0;
            this.m_txtSelectTypeEquipement.SelectionStart = 0;
            this.m_txtSelectTypeEquipement.Size = new System.Drawing.Size(388, 21);
            this.m_txtSelectTypeEquipement.SpecificImage = null;
            this.m_txtSelectTypeEquipement.TabIndex = 2;
            this.m_txtSelectTypeEquipement.TextNull = "";
            this.m_txtSelectTypeEquipement.UseIntellisense = true;
            this.m_txtSelectTypeEquipement.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectTypeEquipement_ElementSelectionneChanged);
            // 
            // CEditeurDonneeBesoinEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtSelectTypeEquipement);
            this.Controls.Add(this.label1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurDonneeBesoinEquipement";
            this.Size = new System.Drawing.Size(528, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectTypeEquipement;
    }
}
