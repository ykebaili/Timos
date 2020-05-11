namespace timos.Securite
{
    partial class CFormEditRestrictionsSpecifiques
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
            this.m_panelRestrictions = new timos.Securite.CPanelRestrictionsSpecifiques();
            this.m_panelBas = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelBas.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelRestrictions
            // 
            this.m_panelRestrictions.AutoScroll = true;
            this.m_panelRestrictions.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelRestrictions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelRestrictions.ForeColor = System.Drawing.Color.Black;
            this.m_panelRestrictions.Location = new System.Drawing.Point(0, 0);
            this.m_panelRestrictions.LockEdition = true;
            this.m_extModeEdition.SetModeEdition(this.m_panelRestrictions, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelRestrictions.Name = "m_panelRestrictions";
            this.m_panelRestrictions.Size = new System.Drawing.Size(724, 405);
            this.m_extStyle.SetStyleBackColor(this.m_panelRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelRestrictions, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelRestrictions.TabIndex = 0;
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_btnAnnuler);
            this.m_panelBas.Controls.Add(this.m_btnOk);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 405);
            this.m_extModeEdition.SetModeEdition(this.m_panelBas, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(724, 46);
            this.m_extStyle.SetStyleBackColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBas, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBas.TabIndex = 1;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.Location = new System.Drawing.Point(381, 11);
            this.m_extModeEdition.SetModeEdition(this.m_btnAnnuler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.Text = "Annuler|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.Location = new System.Drawing.Point(269, 11);
            this.m_extModeEdition.SetModeEdition(this.m_btnOk, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // CFormEditRestrictionsSpecifiques
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 451);
            this.Controls.Add(this.m_panelRestrictions);
            this.Controls.Add(this.m_panelBas);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormEditRestrictionsSpecifiques";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Specific restrictions|20540";
            this.Load += new System.EventHandler(this.CFormEditRestrictionsSpecifiques_Load);
            this.m_panelBas.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CPanelRestrictionsSpecifiques m_panelRestrictions;
        private System.Windows.Forms.Panel m_panelBas;
        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
    }
}