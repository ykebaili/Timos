﻿namespace timos.snmp
{
    partial class CPanelEditeEntitesSnmp
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
            this.m_panelEntites = new sc2i.win32.common.C2iPanel(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.SuspendLayout();
            // 
            // m_panelEntites
            // 
            this.m_panelEntites.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEntites.Location = new System.Drawing.Point(0, 0);
            this.m_panelEntites.LockEdition = false;
            this.m_panelEntites.AutoScroll = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelEntites, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEntites.Name = "m_panelEntites";
            this.m_panelEntites.Size = new System.Drawing.Size(530, 316);
            this.m_panelEntites.TabIndex = 0;
            // 
            // CPanelEditeEntitesSnmp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_panelEntites);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditeEntitesSnmp";
            this.Size = new System.Drawing.Size(530, 316);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelEntites;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
