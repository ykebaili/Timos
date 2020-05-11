namespace timos.commandes
{
    partial class CControleEditeLignesDeCommande
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
            this.m_panelTop = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelLignes = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkAddLine = new sc2i.win32.common.CWndLinkStd();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_lnkAddLine);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(647, 23);
            this.m_panelTop.TabIndex = 0;
            // 
            // m_panelLignes
            // 
            this.m_panelLignes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelLignes.Location = new System.Drawing.Point(0, 23);
            this.m_panelLignes.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelLignes, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelLignes.Name = "m_panelLignes";
            this.m_panelLignes.Size = new System.Drawing.Size(647, 287);
            this.m_panelLignes.TabIndex = 1;
            // 
            // m_lnkAddLine
            // 
            this.m_lnkAddLine.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAddLine.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAddLine.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAddLine.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddLine, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddLine.Name = "m_lnkAddLine";
            this.m_lnkAddLine.Size = new System.Drawing.Size(112, 23);
            this.m_lnkAddLine.TabIndex = 0;
            this.m_lnkAddLine.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAddLine.LinkClicked += new System.EventHandler(this.m_lnkAddLine_LinkClicked);
            // 
            // CControleEditeLignesDeCommande
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelLignes);
            this.Controls.Add(this.m_panelTop);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControleEditeLignesDeCommande";
            this.Size = new System.Drawing.Size(647, 310);
            this.m_panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.C2iPanel m_panelTop;
        private sc2i.win32.common.CWndLinkStd m_lnkAddLine;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iPanel m_panelLignes;
    }
}
