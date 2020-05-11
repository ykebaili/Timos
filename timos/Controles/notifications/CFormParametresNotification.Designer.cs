namespace timos.Controles.notifications
{
    partial class CFormParametresNotification
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormParametresNotification));
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtDuree = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label2 = new System.Windows.Forms.Label();
            this.m_chkPlaySound = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtNomFichier = new System.Windows.Forms.TextBox();
            this.m_btnFichier = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnPlay = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPlay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Display duration|20609";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtDuree
            // 
            this.m_txtDuree.Arrondi = 0;
            this.m_txtDuree.DecimalAutorise = false;
            this.m_txtDuree.EmptyText = "";
            this.m_txtDuree.IntValue = 0;
            this.m_txtDuree.Location = new System.Drawing.Point(147, 10);
            this.m_txtDuree.LockEdition = false;
            this.m_txtDuree.Name = "m_txtDuree";
            this.m_txtDuree.NullAutorise = false;
            this.m_txtDuree.SelectAllOnEnter = true;
            this.m_txtDuree.SeparateurMilliers = "";
            this.m_txtDuree.Size = new System.Drawing.Size(51, 20);
            this.m_txtDuree.TabIndex = 1;
            this.m_txtDuree.Text = "0";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(198, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "seconds|20610";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_chkPlaySound
            // 
            this.m_chkPlaySound.AutoSize = true;
            this.m_chkPlaySound.Location = new System.Drawing.Point(28, 42);
            this.m_chkPlaySound.Name = "m_chkPlaySound";
            this.m_chkPlaySound.Size = new System.Drawing.Size(143, 17);
            this.m_chkPlaySound.TabIndex = 3;
            this.m_chkPlaySound.Text = "Notification sound|20611";
            this.m_chkPlaySound.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(47, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(249, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Sound file ( empty for default)|20162";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtNomFichier
            // 
            this.m_txtNomFichier.Location = new System.Drawing.Point(50, 83);
            this.m_txtNomFichier.Name = "m_txtNomFichier";
            this.m_txtNomFichier.Size = new System.Drawing.Size(263, 20);
            this.m_txtNomFichier.TabIndex = 5;
            // 
            // m_btnFichier
            // 
            this.m_btnFichier.Location = new System.Drawing.Point(310, 83);
            this.m_btnFichier.Name = "m_btnFichier";
            this.m_btnFichier.Size = new System.Drawing.Size(29, 20);
            this.m_btnFichier.TabIndex = 6;
            this.m_btnFichier.Text = "...";
            this.m_btnFichier.UseVisualStyleBackColor = true;
            this.m_btnFichier.Click += new System.EventHandler(this.m_btnFichier_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 120);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(358, 48);
            this.panel1.TabIndex = 7;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(186, 2);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_btnAnnuler.TabIndex = 3;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(132, 2);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnPlay
            // 
            this.m_btnPlay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_btnPlay.Image = global::timos.Properties.Resources._1345618093_start;
            this.m_btnPlay.Location = new System.Drawing.Point(338, 83);
            this.m_btnPlay.Name = "m_btnPlay";
            this.m_btnPlay.Size = new System.Drawing.Size(20, 20);
            this.m_btnPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.m_btnPlay.TabIndex = 8;
            this.m_btnPlay.TabStop = false;
            this.m_btnPlay.Click += new System.EventHandler(this.m_btnPlay_Click);
            // 
            // CFormParametresNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(187)))), ((int)(((byte)(187)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(358, 168);
            this.Controls.Add(this.m_btnPlay);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_btnFichier);
            this.Controls.Add(this.m_txtNomFichier);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_chkPlaySound);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtDuree);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CFormParametresNotification";
            this.Text = "Notifications setup|20608";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_btnPlay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtDuree;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox m_chkPlaySound;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txtNomFichier;
        private System.Windows.Forms.Button m_btnFichier;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.PictureBox m_btnPlay;
    }
}