namespace timos
{
    partial class CPanelResumeSousDossier
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
            this.m_lnkDetail = new System.Windows.Forms.LinkLabel();
            this.m_panelTop = new System.Windows.Forms.Panel();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelFormulaire = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkDetail
            // 
            this.m_lnkDetail.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_lnkDetail.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetail, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_lnkDetail.Name = "m_lnkDetail";
            this.m_lnkDetail.Size = new System.Drawing.Size(55, 20);
            this.m_lnkDetail.TabIndex = 0;
            this.m_lnkDetail.TabStop = true;
            this.m_lnkDetail.Text = "Detail|20147";
            this.m_lnkDetail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDetail_LinkClicked);
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_lnkDetail);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(388, 20);
            this.m_panelTop.TabIndex = 1;
            // 
            // m_gestionnaireModeEdition
            // 
            this.m_gestionnaireModeEdition.ModeEdition = true;
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelFormulaire.Location = new System.Drawing.Point(0, 20);
            this.m_panelFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Size = new System.Drawing.Size(388, 149);
            this.m_panelFormulaire.TabIndex = 2;
            // 
            // CPanelResumeSousDossier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelFormulaire);
            this.Controls.Add(this.m_panelTop);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelResumeSousDossier";
            this.Size = new System.Drawing.Size(388, 169);
            this.Load += new System.EventHandler(this.CPanelResumeSousDossier_Load);
            this.m_panelTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.LinkLabel m_lnkDetail;
        private System.Windows.Forms.Panel m_panelTop;
        private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
        private sc2i.win32.common.C2iPanel m_panelFormulaire;
    }
}
