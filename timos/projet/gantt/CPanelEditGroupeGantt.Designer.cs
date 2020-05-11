namespace timos.projet.gantt
{
    partial class CPanelEditGroupeGantt
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_imageSelect = new sc2i.win32.common.C2iSelectImage();
            this.label3 = new System.Windows.Forms.Label();
            this.m_lnkDelete = new sc2i.win32.common.CWndLinkStd();
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_panelChild = new System.Windows.Forms.Panel();
            this.m_panelAddChildLevel = new System.Windows.Forms.Panel();
            this.m_lnkAddChilds = new System.Windows.Forms.LinkLabel();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).BeginInit();
            this.m_panelAddChildLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtFormule
            // 
            this.m_txtFormule.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormule.Formule = null;
            this.m_txtFormule.Location = new System.Drawing.Point(193, 0);
            this.m_txtFormule.LockEdition = false;
            this.m_txtFormule.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormule, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormule.Name = "m_txtFormule";
            this.m_txtFormule.Size = new System.Drawing.Size(388, 23);
            this.m_txtFormule.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Group formula|20164";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_imageSelect);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_lnkDelete);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.m_txtFormule);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(615, 52);
            this.panel1.TabIndex = 2;
            // 
            // m_imageSelect
            // 
            this.m_imageSelect.BackColor = System.Drawing.Color.White;
            this.m_imageSelect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_imageSelect.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageSelect.Location = new System.Drawing.Point(193, 26);
            this.m_imageSelect.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_imageSelect, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_imageSelect.Name = "m_imageSelect";
            this.m_imageSelect.Size = new System.Drawing.Size(24, 23);
            this.m_imageSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageSelect.TabIndex = 11;
            this.m_imageSelect.TabStop = false;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(6, 26);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(181, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Image|20097";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lnkDelete
            // 
            this.m_lnkDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkDelete.Location = new System.Drawing.Point(588, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDelete.Name = "m_lnkDelete";
            this.m_lnkDelete.Size = new System.Drawing.Size(27, 20);
            this.m_lnkDelete.TabIndex = 2;
            this.m_lnkDelete.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDelete.LinkClicked += new System.EventHandler(this.m_lnkDelete_LinkClicked);
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 52);
            this.m_extModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(31, 121);
            this.m_panelMarge.TabIndex = 3;
            // 
            // m_panelChild
            // 
            this.m_panelChild.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChild.Location = new System.Drawing.Point(31, 71);
            this.m_extModeEdition.SetModeEdition(this.m_panelChild, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelChild.Name = "m_panelChild";
            this.m_panelChild.Size = new System.Drawing.Size(584, 102);
            this.m_panelChild.TabIndex = 4;
            // 
            // m_panelAddChildLevel
            // 
            this.m_panelAddChildLevel.Controls.Add(this.m_lnkAddChilds);
            this.m_panelAddChildLevel.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelAddChildLevel.Location = new System.Drawing.Point(31, 52);
            this.m_extModeEdition.SetModeEdition(this.m_panelAddChildLevel, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelAddChildLevel.Name = "m_panelAddChildLevel";
            this.m_panelAddChildLevel.Size = new System.Drawing.Size(584, 19);
            this.m_panelAddChildLevel.TabIndex = 5;
            // 
            // m_lnkAddChilds
            // 
            this.m_lnkAddChilds.AutoSize = true;
            this.m_lnkAddChilds.Location = new System.Drawing.Point(6, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddChilds, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddChilds.Name = "m_lnkAddChilds";
            this.m_lnkAddChilds.Size = new System.Drawing.Size(108, 13);
            this.m_lnkAddChilds.TabIndex = 0;
            this.m_lnkAddChilds.TabStop = true;
            this.m_lnkAddChilds.Text = "Add child level|20165";
            this.m_lnkAddChilds.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAddChilds_LinkClicked);
            // 
            // CPanelEditGroupeGantt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelChild);
            this.Controls.Add(this.m_panelAddChildLevel);
            this.Controls.Add(this.m_panelMarge);
            this.Controls.Add(this.panel1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditGroupeGantt";
            this.Size = new System.Drawing.Size(615, 173);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_imageSelect)).EndInit();
            this.m_panelAddChildLevel.ResumeLayout(false);
            this.m_panelAddChildLevel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormule;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_panelMarge;
        private System.Windows.Forms.Panel m_panelChild;
        private System.Windows.Forms.Panel m_panelAddChildLevel;
        private System.Windows.Forms.LinkLabel m_lnkAddChilds;
        private sc2i.win32.common.CWndLinkStd m_lnkDelete;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iSelectImage m_imageSelect;
        private System.Windows.Forms.Label label3;
    }
}
