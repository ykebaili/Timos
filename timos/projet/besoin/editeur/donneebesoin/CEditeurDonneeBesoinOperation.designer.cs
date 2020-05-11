namespace timos.projet.besoin
{
    partial class CEditeurDonneeBesoinOperation
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
            this.m_txtSelectTypeOperation = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
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
            this.label1.Text = "Operation type|20685";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSelectTypeOperation
            // 
            this.m_txtSelectTypeOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSelectTypeOperation.ElementSelectionne = null;
            this.m_txtSelectTypeOperation.FonctionTextNull = null;
            this.m_txtSelectTypeOperation.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectTypeOperation.Location = new System.Drawing.Point(140, 0);
            this.m_txtSelectTypeOperation.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectTypeOperation, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectTypeOperation.Name = "m_txtSelectTypeOperation";
            this.m_txtSelectTypeOperation.SelectedObject = null;
            this.m_txtSelectTypeOperation.SelectionLength = 0;
            this.m_txtSelectTypeOperation.SelectionStart = 0;
            this.m_txtSelectTypeOperation.Size = new System.Drawing.Size(388, 21);
            this.m_txtSelectTypeOperation.SpecificImage = null;
            this.m_txtSelectTypeOperation.TabIndex = 2;
            this.m_txtSelectTypeOperation.TextNull = "";
            this.m_txtSelectTypeOperation.UseIntellisense = true;
            this.m_txtSelectTypeOperation.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectTypeOperation_ElementSelectionneChanged);
            // 
            // CEditeurDonneeBesoinOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtSelectTypeOperation);
            this.Controls.Add(this.label1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurDonneeBesoinOperation";
            this.Size = new System.Drawing.Size(528, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectTypeOperation;
    }
}
