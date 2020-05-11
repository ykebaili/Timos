namespace timos.snmp
{
    partial class CControlEditionPlageIP
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
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtModeleIP = new sc2i.win32.common.C2iTextBox();
            this.m_lnkDelete = new sc2i.win32.common.CWndLinkStd();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.label1 = new System.Windows.Forms.Label();
            this.m_numMask = new sc2i.win32.common.C2iNumericUpDown();
            this.m_errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.m_numMask)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(5, 4);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "IP Model|10208";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtModeleIP
            // 
            this.m_txtModeleIP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtModeleIP.Location = new System.Drawing.Point(79, 4);
            this.m_txtModeleIP.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtModeleIP, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtModeleIP.Name = "m_txtModeleIP";
            this.m_txtModeleIP.Size = new System.Drawing.Size(155, 20);
            this.m_txtModeleIP.TabIndex = 25;
            this.m_txtModeleIP.TextChanged += new System.EventHandler(this.m_txtModeleIP_TextChanged);
            // 
            // m_lnkDelete
            // 
            this.m_lnkDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkDelete.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_lnkDelete.Location = new System.Drawing.Point(395, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lnkDelete, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkDelete.Name = "m_lnkDelete";
            this.m_lnkDelete.Size = new System.Drawing.Size(27, 22);
            this.m_lnkDelete.TabIndex = 26;
            this.m_lnkDelete.TypeLien = sc2i.win32.common.TypeLinkStd.Suppression;
            this.m_lnkDelete.LinkClicked += new System.EventHandler(this.m_lnkDelete_LinkClicked);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(245, 4);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "/ Mask|10209";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_numMask
            // 
            this.m_numMask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_numMask.DoubleValue = 0;
            this.m_numMask.IntValue = 0;
            this.m_numMask.Location = new System.Drawing.Point(318, 4);
            this.m_numMask.LockEdition = false;
            this.m_numMask.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.m_extModeEdition.SetModeEdition(this.m_numMask, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_numMask.Name = "m_numMask";
            this.m_numMask.Size = new System.Drawing.Size(54, 20);
            this.m_numMask.TabIndex = 4007;
            this.m_numMask.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.m_numMask.ThousandsSeparator = true;
            // 
            // m_errorProvider
            // 
            this.m_errorProvider.ContainerControl = this;
            // 
            // CControlEditionPlageIP
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Controls.Add(this.m_numMask);
            this.Controls.Add(this.m_lnkDelete);
            this.Controls.Add(this.m_txtModeleIP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionPlageIP";
            this.Size = new System.Drawing.Size(422, 28);
            ((System.ComponentModel.ISupportInitialize)(this.m_numMask)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iTextBox m_txtModeleIP;
        private sc2i.win32.common.CWndLinkStd m_lnkDelete;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iNumericUpDown m_numMask;
        private System.Windows.Forms.ErrorProvider m_errorProvider;
    }
}
