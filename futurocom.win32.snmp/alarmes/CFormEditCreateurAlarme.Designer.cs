namespace futurocom.win32.snmp.alarmes
{
    partial class CFormEditCreateurAlarme
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_cmbTypeAlarme = new sc2i.win32.common.CComboboxAutoFilled();
            this.label8 = new System.Windows.Forms.Label();
            this.m_editeurActionConversion = new sc2i.win32.expression.CEditeurExpressionGraphique();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_txtFormuleCondition = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtCode = new System.Windows.Forms.TextBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_cmbTypeAlarme);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 56);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(739, 24);
            this.m_extStyle.SetStyleBackColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel2.TabIndex = 12;
            // 
            // m_cmbTypeAlarme
            // 
            this.m_cmbTypeAlarme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeAlarme.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeAlarme.FormattingEnabled = true;
            this.m_cmbTypeAlarme.IsLink = false;
            this.m_cmbTypeAlarme.ListDonnees = null;
            this.m_cmbTypeAlarme.Location = new System.Drawing.Point(193, 2);
            this.m_cmbTypeAlarme.LockEdition = false;
            this.m_cmbTypeAlarme.Name = "m_cmbTypeAlarme";
            this.m_cmbTypeAlarme.NullAutorise = false;
            this.m_cmbTypeAlarme.ProprieteAffichee = "Libelle";
            this.m_cmbTypeAlarme.Size = new System.Drawing.Size(543, 21);
            this.m_extStyle.SetStyleBackColor(this.m_cmbTypeAlarme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_cmbTypeAlarme, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeAlarme.TabIndex = 1;
            this.m_cmbTypeAlarme.TextNull = "(empty)";
            this.m_cmbTypeAlarme.Tri = true;
            this.m_cmbTypeAlarme.SelectedValueChanged += new System.EventHandler(this.m_cmbTypeAlarme_SelectedValueChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(4, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 17);
            this.m_extStyle.SetStyleBackColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label8, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label8.TabIndex = 0;
            this.label8.Text = "Generated alarm type|20067";
            // 
            // m_editeurActionConversion
            // 
            this.m_editeurActionConversion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_editeurActionConversion.Location = new System.Drawing.Point(0, 80);
            this.m_editeurActionConversion.Name = "m_editeurActionConversion";
            this.m_editeurActionConversion.Size = new System.Drawing.Size(739, 385);
            this.m_extStyle.SetStyleBackColor(this.m_editeurActionConversion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_editeurActionConversion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_editeurActionConversion.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnCancel);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 465);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(739, 36);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 14;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(388, 6);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCancel.TabIndex = 1;
            this.m_btnCancel.Text = "Annuler|2";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(275, 6);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|1";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_txtFormuleCondition);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 26);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(739, 30);
            this.m_extStyle.SetStyleBackColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel3.TabIndex = 15;
            // 
            // m_txtFormuleCondition
            // 
            this.m_txtFormuleCondition.AllowGraphic = true;
            this.m_txtFormuleCondition.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtFormuleCondition.Formule = null;
            this.m_txtFormuleCondition.Location = new System.Drawing.Point(193, 4);
            this.m_txtFormuleCondition.LockEdition = false;
            this.m_txtFormuleCondition.LockZoneTexte = false;
            this.m_txtFormuleCondition.Name = "m_txtFormuleCondition";
            this.m_txtFormuleCondition.Size = new System.Drawing.Size(543, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleCondition, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleCondition.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 17);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Create condition|20071";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.m_txtCode);
            this.panel4.Controls.Add(this.m_txtLibelle);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(739, 26);
            this.m_extStyle.SetStyleBackColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel4.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 17);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 1;
            this.label2.Text = "Creator label|20075";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Location = new System.Drawing.Point(193, 3);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(218, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtLibelle, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelle.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(417, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 1;
            this.label3.Text = "Code|20076";
            // 
            // m_txtCode
            // 
            this.m_txtCode.Location = new System.Drawing.Point(507, 3);
            this.m_txtCode.Name = "m_txtCode";
            this.m_txtCode.Size = new System.Drawing.Size(98, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtCode, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtCode.TabIndex = 2;
            // 
            // CFormEditCreateurAlarme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 501);
            this.Controls.Add(this.m_editeurActionConversion);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "CFormEditCreateurAlarme";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.Text = "Alarm creation|20070";
            this.Load += new System.EventHandler(this.CFormEditCreateurAlarme_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel panel2;
        private sc2i.win32.common.CComboboxAutoFilled m_cmbTypeAlarme;
        private System.Windows.Forms.Label label8;
        private sc2i.win32.expression.CEditeurExpressionGraphique m_editeurActionConversion;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleCondition;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtLibelle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txtCode;
    }
}