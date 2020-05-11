namespace timos.Equipement.consommables
{
    partial class CPanelEditConditionnement
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
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelHaut = new System.Windows.Forms.Panel();
            this.m_panelControles = new System.Windows.Forms.Panel();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_panelHaut.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_lnkAjouter);
            this.m_panelHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHaut.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelHaut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHaut.Name = "m_panelHaut";
            this.m_panelHaut.Size = new System.Drawing.Size(474, 35);
            this.m_panelHaut.TabIndex = 0;
            // 
            // m_panelControles
            // 
            this.m_panelControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelControles.Location = new System.Drawing.Point(0, 35);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelControles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelControles.Name = "m_panelControles";
            this.m_panelControles.Size = new System.Drawing.Size(474, 147);
            this.m_panelControles.TabIndex = 1;
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouter.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(112, 24);
            this.m_lnkAjouter.TabIndex = 0;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // CPanelEditConditionnement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelControles);
            this.Controls.Add(this.m_panelHaut);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditConditionnement";
            this.Size = new System.Drawing.Size(474, 182);
            this.m_panelHaut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private System.Windows.Forms.Panel m_panelHaut;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouter;
        private System.Windows.Forms.Panel m_panelControles;
    }
}
