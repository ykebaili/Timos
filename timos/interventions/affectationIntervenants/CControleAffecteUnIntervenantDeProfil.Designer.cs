namespace timos.interventions
{
    partial class CControleAffecteUnIntervenantDeProfil
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
            this.m_txtSelectIntervenant = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_lnkAffectationRapide = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // m_txtSelectIntervenant
            // 
            this.m_txtSelectIntervenant.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtSelectIntervenant.ElementSelectionne = null;
            this.m_txtSelectIntervenant.FonctionTextNull = null;
            this.m_txtSelectIntervenant.HasLink = true;
            this.m_txtSelectIntervenant.Location = new System.Drawing.Point(0, 0);
            this.m_txtSelectIntervenant.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtSelectIntervenant, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtSelectIntervenant.Name = "m_txtSelectIntervenant";
            this.m_txtSelectIntervenant.SelectedObject = null;
            this.m_txtSelectIntervenant.Size = new System.Drawing.Size(552, 20);
            this.m_txtSelectIntervenant.TabIndex = 3;
            this.m_txtSelectIntervenant.TextNull = "";
            this.m_txtSelectIntervenant.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectIntervenant_ElementSelectionneChanged);
            // 
            // m_lnkAffectationRapide
            // 
            this.m_lnkAffectationRapide.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkAffectationRapide.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.m_lnkAffectationRapide.Location = new System.Drawing.Point(552, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAffectationRapide, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAffectationRapide.Name = "m_lnkAffectationRapide";
            this.m_lnkAffectationRapide.Size = new System.Drawing.Size(55, 20);
            this.m_lnkAffectationRapide.TabIndex = 4;
            this.m_lnkAffectationRapide.TabStop = true;
            this.m_lnkAffectationRapide.Text = "Help|70";
            this.m_lnkAffectationRapide.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkAffectationRapide.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAffectationRapide_LinkClicked);
            // 
            // CControleAffecteUnIntervenantDeProfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_txtSelectIntervenant);
            this.Controls.Add(this.m_lnkAffectationRapide);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleAffecteUnIntervenantDeProfil";
            this.Size = new System.Drawing.Size(607, 20);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectIntervenant;
        private System.Windows.Forms.LinkLabel m_lnkAffectationRapide;
    }
}
