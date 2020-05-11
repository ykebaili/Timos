namespace timos.projet.besoin
{
    partial class CEditeurDonneeBesoinConsommable
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
            this.m_lblTypeConsommable = new System.Windows.Forms.Label();
            this.m_txtSelectTypeConsommable = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.SuspendLayout();
            // 
            // m_lblTypeConsommable
            // 
            this.m_lblTypeConsommable.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lblTypeConsommable.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblTypeConsommable, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeConsommable.Name = "m_lblTypeConsommable";
            this.m_lblTypeConsommable.Size = new System.Drawing.Size(140, 21);
            this.m_lblTypeConsommable.TabIndex = 0;
            this.m_lblTypeConsommable.Text = "Consumable type|20648";
            this.m_lblTypeConsommable.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSelectTypeConsommable
            // 
            this.m_txtSelectTypeConsommable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSelectTypeConsommable.ElementSelectionne = null;
            this.m_txtSelectTypeConsommable.FonctionTextNull = null;
            this.m_txtSelectTypeConsommable.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtSelectTypeConsommable.Location = new System.Drawing.Point(140, 0);
            this.m_txtSelectTypeConsommable.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectTypeConsommable, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectTypeConsommable.Name = "m_txtSelectTypeConsommable";
            this.m_txtSelectTypeConsommable.SelectedObject = null;
            this.m_txtSelectTypeConsommable.SelectionLength = 0;
            this.m_txtSelectTypeConsommable.SelectionStart = 0;
            this.m_txtSelectTypeConsommable.Size = new System.Drawing.Size(388, 21);
            this.m_txtSelectTypeConsommable.SpecificImage = null;
            this.m_txtSelectTypeConsommable.TabIndex = 2;
            this.m_txtSelectTypeConsommable.TextNull = "";
            this.m_txtSelectTypeConsommable.UseIntellisense = true;
            this.m_txtSelectTypeConsommable.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectTypeConsommable_ElementSelectionneChanged);
            // 
            // CEditeurDonneeBesoinConsommable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtSelectTypeConsommable);
            this.Controls.Add(this.m_lblTypeConsommable);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurDonneeBesoinConsommable";
            this.Size = new System.Drawing.Size(528, 21);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        protected System.Windows.Forms.Label m_lblTypeConsommable;
        protected sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectTypeConsommable;
    }
}
