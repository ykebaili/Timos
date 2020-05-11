namespace timos.projet.gantt
{
    partial class CPanelEditContraintesDeProjet
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
            this.m_panelHaut = new System.Windows.Forms.Panel();
            this.m_lnkAjouter = new sc2i.win32.common.CWndLinkStd();
            this.m_panelContraintes = new System.Windows.Forms.Panel();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelGauche = new System.Windows.Forms.Panel();
            this.m_panelHaut.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelHaut
            // 
            this.m_panelHaut.Controls.Add(this.m_lnkAjouter);
            this.m_panelHaut.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHaut.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelHaut, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelHaut.Name = "m_panelHaut";
            this.m_panelHaut.Size = new System.Drawing.Size(500, 32);
            this.m_panelHaut.TabIndex = 0;
            // 
            // m_lnkAjouter
            // 
            this.m_lnkAjouter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAjouter.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAjouter.Location = new System.Drawing.Point(5, 4);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAjouter, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAjouter.Name = "m_lnkAjouter";
            this.m_lnkAjouter.Size = new System.Drawing.Size(112, 24);
            this.m_lnkAjouter.TabIndex = 0;
            this.m_lnkAjouter.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAjouter.LinkClicked += new System.EventHandler(this.m_lnkAjouter_LinkClicked);
            // 
            // m_panelContraintes
            // 
            this.m_panelContraintes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelContraintes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelContraintes.Location = new System.Drawing.Point(25, 32);
            this.m_extModeEdition.SetModeEdition(this.m_panelContraintes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelContraintes.Name = "m_panelContraintes";
            this.m_panelContraintes.Size = new System.Drawing.Size(475, 268);
            this.m_panelContraintes.TabIndex = 1;
            // 
            // m_panelGauche
            // 
            this.m_panelGauche.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelGauche.Location = new System.Drawing.Point(0, 32);
            this.m_extModeEdition.SetModeEdition(this.m_panelGauche, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelGauche.Name = "m_panelGauche";
            this.m_panelGauche.Size = new System.Drawing.Size(25, 268);
            this.m_panelGauche.TabIndex = 0;
            // 
            // CPanelEditContraintesDeProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelContraintes);
            this.Controls.Add(this.m_panelGauche);
            this.Controls.Add(this.m_panelHaut);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditContraintesDeProjet";
            this.Size = new System.Drawing.Size(500, 300);
            this.m_panelHaut.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelHaut;
        private System.Windows.Forms.Panel m_panelContraintes;
        private sc2i.win32.common.CWndLinkStd m_lnkAjouter;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Panel m_panelGauche;
    }
}
