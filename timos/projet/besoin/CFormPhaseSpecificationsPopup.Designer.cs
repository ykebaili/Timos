namespace timos.projet.besoin
{
    partial class CFormPhaseSpecificationsPopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.m_wndListeBesoins = new timos.projet.besoin.CControleListeBesoins();
            this.m_lblPhase = new System.Windows.Forms.Label();
            this.m_picPhase = new System.Windows.Forms.PictureBox();
            this.m_btnEditPhase = new sc2i.win32.common.CWndLinkStd();
            this.m_imageRefresh = new System.Windows.Forms.PictureBox();
            this.m_panelTop.SuspendLayout();
            this.m_zonePourControlesFils.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_picPhase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_imageRefresh);
            this.m_panelTop.Controls.Add(this.m_picPhase);
            this.m_panelTop.Controls.SetChildIndex(this.m_picPhase, 0);
            this.m_panelTop.Controls.SetChildIndex(this.m_imageRefresh, 0);
            // 
            // m_zonePourControlesFils
            // 
            this.m_zonePourControlesFils.Controls.Add(this.m_btnEditPhase);
            this.m_zonePourControlesFils.Controls.Add(this.m_lblPhase);
            this.m_zonePourControlesFils.Controls.Add(this.m_wndListeBesoins);
            // 
            // m_wndListeBesoins
            // 
            this.m_wndListeBesoins.BackColor = System.Drawing.Color.White;
            this.m_wndListeBesoins.CurrentItemIndex = null;
            this.m_wndListeBesoins.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_wndListeBesoins.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_wndListeBesoins.Location = new System.Drawing.Point(0, 0);
            this.m_wndListeBesoins.LockEdition = true;
            this.m_wndListeBesoins.Name = "m_wndListeBesoins";
            this.m_wndListeBesoins.Size = new System.Drawing.Size(325, 474);
            this.m_wndListeBesoins.TabIndex = 1;
            // 
            // m_lblPhase
            // 
            this.m_lblPhase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblPhase.Location = new System.Drawing.Point(25, 0);
            this.m_lblPhase.Name = "m_lblPhase";
            this.m_lblPhase.Size = new System.Drawing.Size(241, 22);
            this.m_lblPhase.TabIndex = 3;
            this.m_lblPhase.Text = "La phase de spécifications";
            this.m_lblPhase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_picPhase
            // 
            this.m_picPhase.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_picPhase.Location = new System.Drawing.Point(0, 0);
            this.m_picPhase.Name = "m_picPhase";
            this.m_picPhase.Size = new System.Drawing.Size(20, 20);
            this.m_picPhase.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_picPhase.TabIndex = 4;
            this.m_picPhase.TabStop = false;
            // 
            // m_btnEditPhase
            // 
            this.m_btnEditPhase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnEditPhase.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.m_btnEditPhase.Location = new System.Drawing.Point(0, 0);
            this.m_btnEditPhase.Name = "m_btnEditPhase";
            this.m_btnEditPhase.ShortMode = true;
            this.m_btnEditPhase.Size = new System.Drawing.Size(24, 22);
            this.m_btnEditPhase.TabIndex = 4;
            this.m_btnEditPhase.TypeLien = sc2i.win32.common.TypeLinkStd.Modification;
            this.m_btnEditPhase.LinkClicked += new System.EventHandler(this.m_btnEditPhase_LinkClicked);
            // 
            // m_imageRefresh
            // 
            this.m_imageRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_imageRefresh.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_imageRefresh.Image = global::timos.Properties.Resources.Refresh;
            this.m_imageRefresh.Location = new System.Drawing.Point(261, 0);
            this.m_imageRefresh.Name = "m_imageRefresh";
            this.m_imageRefresh.Size = new System.Drawing.Size(20, 20);
            this.m_imageRefresh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.m_imageRefresh.TabIndex = 5;
            this.m_imageRefresh.TabStop = false;
            this.m_imageRefresh.Click += new System.EventHandler(this.m_imageRefresh_Click);
            // 
            // CFormPhaseSpecificationsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 494);
            this.Name = "CFormPhaseSpecificationsPopup";
            this.Text = "CFormListeBesoinsPopup";
            this.Load += new System.EventHandler(this.CFormPhaseSpecificationsPopup_Load);
            this.m_panelTop.ResumeLayout(false);
            this.m_panelTop.PerformLayout();
            this.m_zonePourControlesFils.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_picPhase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.m_imageRefresh)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CControleListeBesoins m_wndListeBesoins;
        private System.Windows.Forms.PictureBox m_picPhase;
        private System.Windows.Forms.Label m_lblPhase;
        private sc2i.win32.common.CWndLinkStd m_btnEditPhase;
        private System.Windows.Forms.PictureBox m_imageRefresh;
    }
}