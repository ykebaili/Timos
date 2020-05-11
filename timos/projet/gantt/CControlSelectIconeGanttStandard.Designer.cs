namespace timos.projet.gantt
{
    partial class CControlSelectIconeGanttStandard
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
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_selectIcone = new sc2i.win32.common.C2iSelectImage();
            this.m_txtFormuleToolTip = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label2 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.m_lnkDelete = new sc2i.win32.common.CWndLinkStd();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.m_selectIcone)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_selectIcone
            // 
            this.m_selectIcone.BackColor = System.Drawing.Color.White;
            this.m_selectIcone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_selectIcone.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_selectIcone.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_selectIcone.Location = new System.Drawing.Point(40, 0);
            this.m_selectIcone.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_selectIcone, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_selectIcone.Name = "m_selectIcone";
            this.m_selectIcone.Size = new System.Drawing.Size(22, 22);
            this.m_selectIcone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_selectIcone.TabIndex = 1;
            this.m_selectIcone.TabStop = false;
            // 
            // m_txtFormuleToolTip
            // 
            this.m_txtFormuleToolTip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtFormuleToolTip.Formule = null;
            this.m_txtFormuleToolTip.Location = new System.Drawing.Point(139, 0);
            this.m_txtFormuleToolTip.LockEdition = false;
            this.m_txtFormuleToolTip.LockZoneTexte = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtFormuleToolTip, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtFormuleToolTip.Name = "m_txtFormuleToolTip";
            this.m_txtFormuleToolTip.Size = new System.Drawing.Size(111, 22);
            this.m_txtFormuleToolTip.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(62, 0);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "ToolTip|10069";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.splitContainer1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.m_txtFormuleToolTip);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.m_selectIcone);
            this.splitContainer1.Panel1.Controls.Add(this.label3);
            this.m_extModeEdition.SetModeEdition(this.splitContainer1.Panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.m_lnkDelete);
            this.m_extModeEdition.SetModeEdition(this.splitContainer1.Panel2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.splitContainer1.Size = new System.Drawing.Size(450, 22);
            this.splitContainer1.SplitterDistance = 250;
            this.splitContainer1.TabIndex = 6;
            // 
            // m_lnkDelete
            // 
            this.m_lnkDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_lnkDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkDelete.Location = new System.Drawing.Point(169, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDelete.Name = "m_lnkDelete";
            this.m_lnkDelete.Size = new System.Drawing.Size(27, 22);
            this.m_lnkDelete.TabIndex = 6;
            this.m_lnkDelete.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDelete.LinkClicked += new System.EventHandler(this.m_lnkDelete_LinkClicked);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 22);
            this.label3.TabIndex = 7;
            this.label3.Text = "Image|809";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CControlSelectIconeGanttStandard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlSelectIconeGanttStandard";
            this.Size = new System.Drawing.Size(450, 22);
            ((System.ComponentModel.ISupportInitialize)(this.m_selectIcone)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private sc2i.win32.common.C2iSelectImage m_selectIcone;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleToolTip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private sc2i.win32.common.CWndLinkStd m_lnkDelete;
        private System.Windows.Forms.Label label3;
    }
}
