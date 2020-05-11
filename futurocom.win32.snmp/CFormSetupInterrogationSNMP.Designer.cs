namespace futurocom.win32.snmp
{
    partial class CFormSetupInterrogationSNMP
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
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtPort = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label3 = new System.Windows.Forms.Label();
            this.m_cmbVersion = new System.Windows.Forms.ComboBox();
            this.m_txtTimeout = new sc2i.win32.common.C2iTextBoxNumerique();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_txtCommunaute = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 16);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "SNMP agent IP|20032";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtIP
            // 
            this.m_txtIP.Location = new System.Drawing.Point(175, 10);
            this.m_txtIP.Name = "m_txtIP";
            this.m_txtIP.Size = new System.Drawing.Size(158, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtIP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtIP.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(156, 16);
            this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port|20033";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPort
            // 
            this.m_txtPort.Arrondi = 0;
            this.m_txtPort.DecimalAutorise = true;
            this.m_txtPort.EmptyText = "";
            this.m_txtPort.IntValue = 0;
            this.m_txtPort.Location = new System.Drawing.Point(175, 35);
            this.m_txtPort.LockEdition = false;
            this.m_txtPort.Name = "m_txtPort";
            this.m_txtPort.NullAutorise = false;
            this.m_txtPort.SelectAllOnEnter = true;
            this.m_txtPort.SeparateurMilliers = "";
            this.m_txtPort.Size = new System.Drawing.Size(100, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtPort, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtPort.TabIndex = 1;
            this.m_txtPort.Text = "0";
            this.m_txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 16);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4;
            this.label3.Text = "Version|20034";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_cmbVersion
            // 
            this.m_cmbVersion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbVersion.FormattingEnabled = true;
            this.m_cmbVersion.Location = new System.Drawing.Point(175, 87);
            this.m_cmbVersion.Name = "m_cmbVersion";
            this.m_cmbVersion.Size = new System.Drawing.Size(217, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbVersion.TabIndex = 3;
            // 
            // m_txtTimeout
            // 
            this.m_txtTimeout.Arrondi = 0;
            this.m_txtTimeout.DecimalAutorise = false;
            this.m_txtTimeout.EmptyText = "";
            this.m_txtTimeout.IntValue = 0;
            this.m_txtTimeout.Location = new System.Drawing.Point(175, 114);
            this.m_txtTimeout.LockEdition = false;
            this.m_txtTimeout.Name = "m_txtTimeout";
            this.m_txtTimeout.NullAutorise = false;
            this.m_txtTimeout.SelectAllOnEnter = true;
            this.m_txtTimeout.SeparateurMilliers = "";
            this.m_txtTimeout.Size = new System.Drawing.Size(100, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtTimeout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtTimeout, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtTimeout.TabIndex = 4;
            this.m_txtTimeout.Text = "0";
            this.m_txtTimeout.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(156, 16);
            this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 6;
            this.label4.Text = "Timeout|20035";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(281, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.m_exStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 8;
            this.label5.Text = "ms|20036";
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(124, 156);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 5;
            this.m_btnOk.Text = "Ok|1";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(215, 156);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_exStyle.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCancel.TabIndex = 6;
            this.m_btnCancel.Text = "Cancel|2";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_txtCommunaute
            // 
            this.m_txtCommunaute.Location = new System.Drawing.Point(175, 61);
            this.m_txtCommunaute.Name = "m_txtCommunaute";
            this.m_txtCommunaute.Size = new System.Drawing.Size(158, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtCommunaute, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtCommunaute, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCommunaute.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(13, 62);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(156, 16);
            this.m_exStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 11;
            this.label6.Text = "Community|20105";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CFormSetupInterrogationSNMP
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_btnCancel;
            this.ClientSize = new System.Drawing.Size(422, 203);
            this.ControlBox = false;
            this.Controls.Add(this.m_txtCommunaute);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtTimeout);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_cmbVersion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_txtPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtIP);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CFormSetupInterrogationSNMP";
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "SNMP connexion setup|20031";
            this.Load += new System.EventHandler(this.CFormSetupInterrogationSNMP_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtIP;
        private System.Windows.Forms.Label label2;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox m_cmbVersion;
        private sc2i.win32.common.C2iTextBoxNumerique m_txtTimeout;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.CExtStyle m_exStyle;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.TextBox m_txtCommunaute;
        private System.Windows.Forms.Label label6;
    }
}