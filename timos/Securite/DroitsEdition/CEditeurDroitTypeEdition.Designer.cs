namespace timos.Securite.DroitsEdition
{
    partial class CEditeurDroitTypeEdition
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
            this.m_txtFormule = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_txtGroupe = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_lblFormule = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.AllowGraphic = true;
            this.m_txtFormule.AllowNullFormula = false;
            this.m_txtFormule.AllowSaisieTexte = true;
            this.m_txtFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormule.Formule = null;
            this.m_txtFormule.Location = new System.Drawing.Point(0, 0);
            this.m_txtFormule.LockEdition = false;
            this.m_txtFormule.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(384, 53);
            this.m_txtFormule.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_txtGroupe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(384, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(320, 53);
            this.panel1.TabIndex = 1;
            // 
            // m_txtGroupe
            // 
            this.m_txtGroupe.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_txtGroupe.ElementSelectionne = null;
            this.m_txtGroupe.FonctionTextNull = null;
            this.m_txtGroupe.ImageDisplayMode = sc2i.win32.data.dynamic.EModeAffichageImageTextBoxRapide.Always;
            this.m_txtGroupe.Location = new System.Drawing.Point(0, 0);
            this.m_txtGroupe.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtGroupe, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_txtGroupe.Name = "m_txtGroupe";
            this.m_txtGroupe.SelectedObject = null;
            this.m_txtGroupe.SelectionLength = 0;
            this.m_txtGroupe.SelectionStart = 0;
            this.m_txtGroupe.Size = new System.Drawing.Size(320, 21);
            this.m_txtGroupe.SpecificImage = null;
            this.m_txtGroupe.TabIndex = 0;
            this.m_txtGroupe.TextNull = "";
            this.m_txtGroupe.UseIntellisense = true;
            // 
            // m_lblFormule
            // 
            this.m_lblFormule.BackColor = System.Drawing.Color.White;
            this.m_lblFormule.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblFormule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblFormule.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblFormule, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblFormule.Name = "m_lblFormule";
            this.m_lblFormule.Size = new System.Drawing.Size(384, 53);
            this.m_lblFormule.TabIndex = 2;
            // 
            // CEditeurDroitTypeEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_lblFormule);
            this.Controls.Add(this.m_txtFormule);
            this.Controls.Add(this.panel1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CEditeurDroitTypeEdition";
            this.Size = new System.Drawing.Size(704, 53);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormule;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtGroupe;
        private System.Windows.Forms.Label m_lblFormule;
    }
}
