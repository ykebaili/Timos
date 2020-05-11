namespace timos.win32.composants.gantt
{
    partial class CFormConfirmationAvantDeplacementElementDeGantt
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
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnValider = new System.Windows.Forms.Button();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelMilieu = new System.Windows.Forms.Panel();
            this.m_chkMemoriserLaReponse = new System.Windows.Forms.CheckBox();
            this.m_panelMessageFilsNonAuto = new System.Windows.Forms.Panel();
            this.m_chkDeplacerFilsNonAuto = new System.Windows.Forms.CheckBox();
            this.m_pictureQuestion = new System.Windows.Forms.PictureBox();
            this.m_lblMessageFilsNonAuto = new System.Windows.Forms.Label();
            this.m_panelMessageFilsTermines = new System.Windows.Forms.Panel();
            this.m_lblMessageFilsTermines = new System.Windows.Forms.Label();
            this.m_pictureWarning = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelBas.SuspendLayout();
            this.m_panelMilieu.SuspendLayout();
            this.m_panelMessageFilsNonAuto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureQuestion)).BeginInit();
            this.m_panelMessageFilsTermines.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureWarning)).BeginInit();
            this.SuspendLayout();
            // 
            // m_panelBas
            // 
            this.m_panelBas.BackColor = System.Drawing.Color.White;
            this.m_panelBas.Controls.Add(this.m_btnAnnuler);
            this.m_panelBas.Controls.Add(this.m_btnValider);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 181);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(503, 49);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBas.TabIndex = 0;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatAppearance.BorderSize = 0;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.Image = global::timos.win32.composants.Properties.Resources.cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(255, 6);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(32, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 0;
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnValider
            // 
            this.m_btnValider.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnValider.FlatAppearance.BorderSize = 0;
            this.m_btnValider.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnValider.Image = global::timos.win32.composants.Properties.Resources.check;
            this.m_btnValider.Location = new System.Drawing.Point(208, 5);
            this.m_btnValider.Name = "m_btnValider";
            this.m_btnValider.Size = new System.Drawing.Size(32, 32);
            this.m_extStyle.SetStyleBackColor(this.m_btnValider, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnValider, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnValider.TabIndex = 0;
            this.m_btnValider.UseVisualStyleBackColor = true;
            this.m_btnValider.Click += new System.EventHandler(this.m_btnValider_Click);
            // 
            // m_panelMilieu
            // 
            this.m_panelMilieu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelMilieu.Controls.Add(this.panel1);
            this.m_panelMilieu.Controls.Add(this.m_chkMemoriserLaReponse);
            this.m_panelMilieu.Controls.Add(this.m_panelMessageFilsNonAuto);
            this.m_panelMilieu.Controls.Add(this.m_panelMessageFilsTermines);
            this.m_panelMilieu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelMilieu.ForeColor = System.Drawing.Color.Black;
            this.m_panelMilieu.Location = new System.Drawing.Point(0, 0);
            this.m_panelMilieu.Name = "m_panelMilieu";
            this.m_panelMilieu.Size = new System.Drawing.Size(503, 181);
            this.m_extStyle.SetStyleBackColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelMilieu, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panelMilieu.TabIndex = 1;
            // 
            // m_chkMemoriserLaReponse
            // 
            this.m_chkMemoriserLaReponse.Location = new System.Drawing.Point(13, 150);
            this.m_chkMemoriserLaReponse.Name = "m_chkMemoriserLaReponse";
            this.m_chkMemoriserLaReponse.Size = new System.Drawing.Size(441, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkMemoriserLaReponse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkMemoriserLaReponse, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkMemoriserLaReponse.TabIndex = 2;
            this.m_chkMemoriserLaReponse.Text = "Don\'t ask me for the moment|10004";
            this.m_chkMemoriserLaReponse.UseVisualStyleBackColor = true;
            // 
            // m_panelMessageFilsNonAuto
            // 
            this.m_panelMessageFilsNonAuto.Controls.Add(this.m_chkDeplacerFilsNonAuto);
            this.m_panelMessageFilsNonAuto.Controls.Add(this.m_pictureQuestion);
            this.m_panelMessageFilsNonAuto.Controls.Add(this.m_lblMessageFilsNonAuto);
            this.m_panelMessageFilsNonAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelMessageFilsNonAuto.Location = new System.Drawing.Point(0, 68);
            this.m_panelMessageFilsNonAuto.Name = "m_panelMessageFilsNonAuto";
            this.m_panelMessageFilsNonAuto.Size = new System.Drawing.Size(503, 73);
            this.m_extStyle.SetStyleBackColor(this.m_panelMessageFilsNonAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMessageFilsNonAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMessageFilsNonAuto.TabIndex = 1;
            // 
            // m_chkDeplacerFilsNonAuto
            // 
            this.m_chkDeplacerFilsNonAuto.Location = new System.Drawing.Point(61, 46);
            this.m_chkDeplacerFilsNonAuto.Name = "m_chkDeplacerFilsNonAuto";
            this.m_chkDeplacerFilsNonAuto.Size = new System.Drawing.Size(427, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkDeplacerFilsNonAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkDeplacerFilsNonAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkDeplacerFilsNonAuto.TabIndex = 2;
            this.m_chkDeplacerFilsNonAuto.Text = "Move elements with non automatic dates|10005";
            this.m_chkDeplacerFilsNonAuto.UseVisualStyleBackColor = true;
            // 
            // m_pictureQuestion
            // 
            this.m_pictureQuestion.Image = global::timos.win32.composants.Properties.Resources.help;
            this.m_pictureQuestion.Location = new System.Drawing.Point(13, 6);
            this.m_pictureQuestion.Name = "m_pictureQuestion";
            this.m_pictureQuestion.Size = new System.Drawing.Size(37, 39);
            this.m_extStyle.SetStyleBackColor(this.m_pictureQuestion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pictureQuestion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pictureQuestion.TabIndex = 0;
            this.m_pictureQuestion.TabStop = false;
            // 
            // m_lblMessageFilsNonAuto
            // 
            this.m_lblMessageFilsNonAuto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblMessageFilsNonAuto.Location = new System.Drawing.Point(58, 6);
            this.m_lblMessageFilsNonAuto.Name = "m_lblMessageFilsNonAuto";
            this.m_lblMessageFilsNonAuto.Size = new System.Drawing.Size(430, 42);
            this.m_extStyle.SetStyleBackColor(this.m_lblMessageFilsNonAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMessageFilsNonAuto, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMessageFilsNonAuto.TabIndex = 1;
            this.m_lblMessageFilsNonAuto.Text = "label1";
            // 
            // m_panelMessageFilsTermines
            // 
            this.m_panelMessageFilsTermines.Controls.Add(this.m_lblMessageFilsTermines);
            this.m_panelMessageFilsTermines.Controls.Add(this.m_pictureWarning);
            this.m_panelMessageFilsTermines.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelMessageFilsTermines.Location = new System.Drawing.Point(0, 0);
            this.m_panelMessageFilsTermines.Name = "m_panelMessageFilsTermines";
            this.m_panelMessageFilsTermines.Size = new System.Drawing.Size(503, 68);
            this.m_extStyle.SetStyleBackColor(this.m_panelMessageFilsTermines, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMessageFilsTermines, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMessageFilsTermines.TabIndex = 0;
            // 
            // m_lblMessageFilsTermines
            // 
            this.m_lblMessageFilsTermines.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblMessageFilsTermines.Location = new System.Drawing.Point(58, 13);
            this.m_lblMessageFilsTermines.Name = "m_lblMessageFilsTermines";
            this.m_lblMessageFilsTermines.Size = new System.Drawing.Size(433, 66);
            this.m_extStyle.SetStyleBackColor(this.m_lblMessageFilsTermines, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblMessageFilsTermines, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblMessageFilsTermines.TabIndex = 1;
            this.m_lblMessageFilsTermines.Text = "label1";
            // 
            // m_pictureWarning
            // 
            this.m_pictureWarning.Image = global::timos.win32.composants.Properties.Resources.warning;
            this.m_pictureWarning.Location = new System.Drawing.Point(13, 13);
            this.m_pictureWarning.Name = "m_pictureWarning";
            this.m_pictureWarning.Size = new System.Drawing.Size(38, 42);
            this.m_extStyle.SetStyleBackColor(this.m_pictureWarning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_pictureWarning, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_pictureWarning.TabIndex = 0;
            this.m_pictureWarning.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(503, 1);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 3;
            // 
            // CFormConfirmationAvantDeplacementElementDeGantt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(503, 230);
            this.Controls.Add(this.m_panelMilieu);
            this.Controls.Add(this.m_panelBas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormConfirmationAvantDeplacementElementDeGantt";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Confirmation|10003";
            this.Load += new System.EventHandler(this.CFormConfirmationAvantDeplacementElementDeGantt_Load);
            this.m_panelBas.ResumeLayout(false);
            this.m_panelMilieu.ResumeLayout(false);
            this.m_panelMessageFilsNonAuto.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureQuestion)).EndInit();
            this.m_panelMessageFilsTermines.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.m_pictureWarning)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelBas;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel m_panelMilieu;
        private System.Windows.Forms.Button m_btnValider;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Panel m_panelMessageFilsNonAuto;
        private System.Windows.Forms.Panel m_panelMessageFilsTermines;
        private System.Windows.Forms.CheckBox m_chkMemoriserLaReponse;
        private System.Windows.Forms.PictureBox m_pictureWarning;
        private System.Windows.Forms.CheckBox m_chkDeplacerFilsNonAuto;
        private System.Windows.Forms.Label m_lblMessageFilsNonAuto;
        private System.Windows.Forms.Label m_lblMessageFilsTermines;
        private System.Windows.Forms.PictureBox m_pictureQuestion;
        private System.Windows.Forms.Panel panel1;
    }
}