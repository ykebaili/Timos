namespace futurocom.win32.snmp.entitesnmp
{
    partial class CPanelEditeEntitesDeAgent
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelEntites = new sc2i.win32.common.C2iPanel(this.components);
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(446, 23);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_panelEntites
            // 
            this.m_panelEntites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEntites.Location = new System.Drawing.Point(0, 23);
            this.m_panelEntites.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelEntites, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelEntites.Name = "m_panelEntites";
            this.m_panelEntites.Size = new System.Drawing.Size(446, 207);
            this.m_extStyle.SetStyleBackColor(this.m_panelEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEntites, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEntites.TabIndex = 1;
            // 
            // CPanelEditeEntitesDeAgent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelEntites);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditeEntitesDeAgent";
            this.Size = new System.Drawing.Size(446, 230);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.C2iPanel m_panelEntites;
    }
}
