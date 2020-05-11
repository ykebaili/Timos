namespace timos.Parametrage
{
    partial class CFormEditModulesParametrage
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
            m_instance = null;
            if (m_contexte != null)
            {
                m_contexte.Dispose();
                m_contexte = null;
            }
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditModulesParametrage));
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_panelBoutons = new System.Windows.Forms.Panel();
            this.m_panelModulesParametrage = new sc2i.win32.data.dynamic.CPanelEditModulesParametrage();
            this.m_timerSauvegarde = new System.Windows.Forms.Timer(this.components);
            this.m_imgModified = new System.Windows.Forms.PictureBox();
            this.m_panelBoutons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgModified)).BeginInit();
            this.SuspendLayout();
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatAppearance.BorderSize = 0;
            this.m_btnAnnuler.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.m_btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.Image = global::timos.Properties.Resources.cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(305, 6);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(26, 26);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOK
            // 
            this.m_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnOK.FlatAppearance.BorderSize = 0;
            this.m_btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.m_btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOK.Image = global::timos.Properties.Resources.check;
            this.m_btnOK.Location = new System.Drawing.Point(220, 6);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(26, 26);
            this.m_btnOK.TabIndex = 1;
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_panelBoutons
            // 
            this.m_panelBoutons.Controls.Add(this.m_imgModified);
            this.m_panelBoutons.Controls.Add(this.m_btnOK);
            this.m_panelBoutons.Controls.Add(this.m_btnAnnuler);
            this.m_panelBoutons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBoutons.Location = new System.Drawing.Point(0, 423);
            this.m_panelBoutons.Name = "m_panelBoutons";
            this.m_panelBoutons.Size = new System.Drawing.Size(550, 41);
            this.m_panelBoutons.TabIndex = 2;
            // 
            // m_panelModulesParametrage
            // 
            this.m_panelModulesParametrage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelModulesParametrage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelModulesParametrage.Location = new System.Drawing.Point(0, 0);
            this.m_panelModulesParametrage.Name = "m_panelModulesParametrage";
            this.m_panelModulesParametrage.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.m_panelModulesParametrage.Size = new System.Drawing.Size(550, 423);
            this.m_panelModulesParametrage.TabIndex = 0;
            this.m_panelModulesParametrage.Load += new System.EventHandler(this.m_panelModulesParametrage_Load);
            // 
            // m_timerSauvegarde
            // 
            this.m_timerSauvegarde.Interval = 300;
            this.m_timerSauvegarde.Tick += new System.EventHandler(this.m_timerSauvegarde_Tick);
            // 
            // m_imgModified
            // 
            this.m_imgModified.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_imgModified.Image = global::timos.Properties.Resources.alerte;
            this.m_imgModified.Location = new System.Drawing.Point(243, 19);
            this.m_imgModified.Name = "m_imgModified";
            this.m_imgModified.Size = new System.Drawing.Size(16, 16);
            this.m_imgModified.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.m_imgModified.TabIndex = 2;
            this.m_imgModified.TabStop = false;
            this.m_imgModified.Visible = false;
            // 
            // CFormEditModulesParametrage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(550, 464);
            this.Controls.Add(this.m_panelModulesParametrage);
            this.Controls.Add(this.m_panelBoutons);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CFormEditModulesParametrage";
            this.Text = "Setting Modules|10039";
            this.Load += new System.EventHandler(this.CFormEditModulesParametrage_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormEditModulesParametrage_FormClosing);
            this.m_panelBoutons.ResumeLayout(false);
            this.m_panelBoutons.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_imgModified)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.data.dynamic.CPanelEditModulesParametrage m_panelModulesParametrage;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Panel m_panelBoutons;
        private System.Windows.Forms.Timer m_timerSauvegarde;
        private System.Windows.Forms.PictureBox m_imgModified;
    }
}