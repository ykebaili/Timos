namespace timos.process.workflow
{
    partial class CPanelAffectationsEtapeWorkflow
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
            this.m_wndListeAffectations = new System.Windows.Forms.ListView();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_lnkRemove = new sc2i.win32.common.CWndLinkStd();
            this.m_lnkAdd = new sc2i.win32.common.CWndLinkStd();
            this.m_menuAdd = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_wndListeAffectations
            // 
            this.m_wndListeAffectations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeAffectations.Location = new System.Drawing.Point(0, 24);
            this.m_extModeEdition.SetModeEdition(this.m_wndListeAffectations, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeAffectations.Name = "m_wndListeAffectations";
            this.m_wndListeAffectations.Size = new System.Drawing.Size(477, 239);
            this.m_wndListeAffectations.TabIndex = 0;
            this.m_wndListeAffectations.UseCompatibleStateImageBehavior = false;
            this.m_wndListeAffectations.View = System.Windows.Forms.View.List;
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_lnkRemove);
            this.m_panelTop.Controls.Add(this.m_lnkAdd);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(477, 24);
            this.m_panelTop.TabIndex = 1;
            // 
            // m_lnkRemove
            // 
            this.m_lnkRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkRemove.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkRemove.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkRemove.Location = new System.Drawing.Point(112, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemove, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemove.Name = "m_lnkRemove";
            this.m_lnkRemove.Size = new System.Drawing.Size(112, 24);
            this.m_lnkRemove.TabIndex = 1;
            this.m_lnkRemove.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkRemove.LinkClicked += new System.EventHandler(this.m_lnkRemove_LinkClicked);
            // 
            // m_lnkAdd
            // 
            this.m_lnkAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkAdd.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkAdd.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkAdd.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAdd, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAdd.Name = "m_lnkAdd";
            this.m_lnkAdd.Size = new System.Drawing.Size(112, 24);
            this.m_lnkAdd.TabIndex = 0;
            this.m_lnkAdd.TypeLien = sc2i.win32.common.TypeLinkStd.Ajout;
            this.m_lnkAdd.LinkClicked += new System.EventHandler(this.m_lnkAdd_LinkClicked);
            // 
            // m_menuAdd
            // 
            this.m_extModeEdition.SetModeEdition(this.m_menuAdd, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_menuAdd.Name = "m_menuAdd";
            this.m_menuAdd.Size = new System.Drawing.Size(61, 4);
            // 
            // CPanelAffectationsEtapeWorkflow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_wndListeAffectations);
            this.Controls.Add(this.m_panelTop);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelAffectationsEtapeWorkflow";
            this.Size = new System.Drawing.Size(477, 263);
            this.m_panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView m_wndListeAffectations;
        private System.Windows.Forms.Panel m_panelTop;
        private sc2i.win32.common.CWndLinkStd m_lnkRemove;
        private sc2i.win32.common.CWndLinkStd m_lnkAdd;
        private System.Windows.Forms.ContextMenuStrip m_menuAdd;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
