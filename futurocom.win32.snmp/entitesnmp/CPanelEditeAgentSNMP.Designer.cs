namespace futurocom.win32.snmp.entitesnmp
{
    partial class CPanelEditeAgentSNMP
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtAgentIP = new sc2i.win32.common.C2iTextBox();
            this.m_tabControl = new sc2i.win32.common.C2iTabControl(this.components);
            this.m_txtCommunaute = new sc2i.win32.common.C2iTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_txtPort = new sc2i.win32.common.C2iTextBoxNumerique();
            this.m_cmbVersion = new sc2i.win32.common.C2iComboBox();
            this.tabPage1 = new Crownwood.Magic.Controls.TabPage();
            this.panel1.SuspendLayout();
            this.m_tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_cmbVersion);
            this.panel1.Controls.Add(this.m_txtPort);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.m_txtCommunaute);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_txtAgentIP);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(574, 55);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 1);
            this.m_extModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agent IP|20095";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtAgentIP
            // 
            this.m_txtAgentIP.Location = new System.Drawing.Point(138, 3);
            this.m_txtAgentIP.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtAgentIP, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtAgentIP.Name = "m_txtAgentIP";
            this.m_txtAgentIP.Size = new System.Drawing.Size(167, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtAgentIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtAgentIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtAgentIP.TabIndex = 1;
            // 
            // m_tabControl
            // 
            this.m_tabControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_tabControl.BoldSelectedPage = true;
            this.m_tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_tabControl.ForeColor = System.Drawing.Color.Black;
            this.m_tabControl.IDEPixelArea = false;
            this.m_tabControl.Location = new System.Drawing.Point(0, 55);
            this.m_extModeEdition.SetModeEdition(this.m_tabControl, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_tabControl.Name = "m_tabControl";
            this.m_tabControl.Ombre = false;
            this.m_tabControl.PositionTop = true;
            this.m_tabControl.SelectedIndex = 0;
            this.m_tabControl.SelectedTab = this.tabPage1;
            this.m_tabControl.Size = new System.Drawing.Size(574, 281);
            this.m_extStyle.SetStyleBackColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_tabControl, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.m_tabControl.TabIndex = 1;
            this.m_tabControl.TabPages.AddRange(new Crownwood.Magic.Controls.TabPage[] {
            this.tabPage1});
            this.m_tabControl.TextColor = System.Drawing.Color.Black;
            // 
            // m_txtCommunaute
            // 
            this.m_txtCommunaute.Location = new System.Drawing.Point(138, 26);
            this.m_txtCommunaute.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtCommunaute, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtCommunaute.Name = "m_txtCommunaute";
            this.m_txtCommunaute.Size = new System.Drawing.Size(167, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCommunaute, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCommunaute, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommunaute.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 24);
            this.m_extModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 23);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Community|20056";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(311, 1);
            this.m_extModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Port|20033";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(311, 23);
            this.m_extModeEdition.SetModeEdition(this.label4, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 5;
            this.label4.Text = "Version|20034";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtPort
            // 
            this.m_txtPort.Arrondi = 0;
            this.m_txtPort.DecimalAutorise = false;
            this.m_txtPort.IntValue = 0;
            this.m_txtPort.Location = new System.Drawing.Point(402, 3);
            this.m_txtPort.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_txtPort, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtPort.Name = "m_txtPort";
            this.m_txtPort.NullAutorise = false;
            this.m_txtPort.SelectAllOnEnter = true;
            this.m_txtPort.Size = new System.Drawing.Size(100, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPort.TabIndex = 6;
            this.m_txtPort.TextChanged += new System.EventHandler(this.m_txtPort_TextChanged);
            // 
            // m_cmbVersion
            // 
            this.m_cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbVersion.FormattingEnabled = true;
            this.m_cmbVersion.IsLink = false;
            this.m_cmbVersion.Location = new System.Drawing.Point(402, 25);
            this.m_cmbVersion.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_cmbVersion, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbVersion.Name = "m_cmbVersion";
            this.m_cmbVersion.Size = new System.Drawing.Size(169, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbVersion.TabIndex = 7;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(0, 25);
            this.m_extModeEdition.SetModeEdition(this.tabPage1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(574, 256);
            this.m_extStyle.SetStyleBackColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.tabPage1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.tabPage1.TabIndex = 10;
            // 
            // CPanelEditeAgentSNMP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.m_tabControl);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEditeAgentSNMP";
            this.Size = new System.Drawing.Size(574, 336);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.m_tabControl.ResumeLayout(false);
            this.m_tabControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private sc2i.win32.common.CExtModeEdition m_extModeEdition;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtAgentIP;
        private sc2i.win32.common.C2iTabControl m_tabControl;
        private sc2i.win32.common.C2iTextBox m_txtCommunaute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private sc2i.win32.common.C2iComboBox m_cmbVersion;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtPort;
        private System.Windows.Forms.Label label4;
        private Crownwood.Magic.Controls.TabPage tabPage1;
    }
}
