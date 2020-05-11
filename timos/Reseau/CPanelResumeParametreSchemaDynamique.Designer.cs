namespace timos.Reseau
{
    partial class CPanelResumeParametreSchemaDynamique
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
            this.m_lblTypeElement = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_lnkEdit = new sc2i.win32.common.CWndLinkStd();
            this.m_controleDessin = new timos.CControlDessinSymbole();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblTypeElement
            // 
            this.m_lblTypeElement.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTypeElement.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblTypeElement, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTypeElement.Name = "m_lblTypeElement";
            this.m_lblTypeElement.Size = new System.Drawing.Size(200, 23);
            this.m_lblTypeElement.TabIndex = 0;
            this.m_lblTypeElement.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_lnkEdit);
            this.panel1.Controls.Add(this.m_lblTypeElement);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 66);
            this.panel1.TabIndex = 1;
            // 
            // m_lnkEdit
            // 
            this.m_lnkEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkEdit.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lnkEdit.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkEdit.Location = new System.Drawing.Point(0, 23);
            this.m_extModeEdition.SetModeEdition(this.m_lnkEdit, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkEdit.Name = "m_lnkEdit";
            this.m_lnkEdit.Size = new System.Drawing.Size(200, 24);
            this.m_lnkEdit.TabIndex = 1;
            this.m_lnkEdit.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_lnkEdit.LinkClicked += new System.EventHandler(this.cWndLinkStd1_LinkClicked);
            // 
            // m_controleDessin
            // 
            this.m_controleDessin.AutoScroll = true;
            this.m_controleDessin.BackColor = System.Drawing.Color.White;
            this.m_controleDessin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_controleDessin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_controleDessin.Location = new System.Drawing.Point(200, 0);
            this.m_extModeEdition.SetModeEdition(this.m_controleDessin, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_controleDessin.Name = "m_controleDessin";
            this.m_controleDessin.Size = new System.Drawing.Size(322, 66);
            this.m_controleDessin.TabIndex = 4030;
            // 
            // CPanelResumeParametreSchemaDynamique
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.m_controleDessin);
            this.Controls.Add(this.panel1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelResumeParametreSchemaDynamique";
            this.Size = new System.Drawing.Size(522, 66);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label m_lblTypeElement;
        private System.Windows.Forms.Panel panel1;
        private sc2i.win32.common.CWndLinkStd m_lnkEdit;
        private CControlDessinSymbole m_controleDessin;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}
