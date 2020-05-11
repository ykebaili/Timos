namespace timos.snmp
{
    partial class CFormEditChampEntiteFromQueryToChampCustom
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
            this.components = new System.ComponentModel.Container();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtNomChamp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtDescription = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.m_txtFormuleIndex = new sc2i.win32.expression.CTextBoxZoomFormule();
            this.m_lblDataType = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_lblAcces = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.m_txtSelectChampCustom = new sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide();
            this.m_lnkCreateField = new System.Windows.Forms.LinkLabel();
            this.m_chkNoUpdate = new System.Windows.Forms.CheckBox();
            this.m_tooltip = new sc2i.win32.common.CToolTipTraductible(this.components);
            this.m_chkNoWriteSNMP = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 243);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 31);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 0;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Location = new System.Drawing.Point(292, 5);
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
            this.m_btnOk.Location = new System.Drawing.Point(199, 4);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 17);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "Field name|20291";
            // 
            // m_txtNomChamp
            // 
            this.m_txtNomChamp.BackColor = System.Drawing.SystemColors.Control;
            this.m_txtNomChamp.Location = new System.Drawing.Point(159, 10);
            this.m_txtNomChamp.Name = "m_txtNomChamp";
            this.m_txtNomChamp.ReadOnly = true;
            this.m_txtNomChamp.Size = new System.Drawing.Size(395, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtNomChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtNomChamp, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtNomChamp.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 18);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 4;
            this.label2.Text = "Data type|20292";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 18);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 5;
            this.label3.Text = "Description|20294";
            // 
            // m_txtDescription
            // 
            this.m_txtDescription.AcceptsReturn = true;
            this.m_txtDescription.Location = new System.Drawing.Point(159, 66);
            this.m_txtDescription.Multiline = true;
            this.m_txtDescription.Name = "m_txtDescription";
            this.m_txtDescription.Size = new System.Drawing.Size(395, 70);
            this.m_extStyle.SetStyleBackColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtDescription, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtDescription.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(11, 185);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(140, 18);
            this.m_extStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 7;
            this.label5.Text = "Index formula|20295";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // m_txtFormuleIndex
            // 
            this.m_txtFormuleIndex.AllowGraphic = true;
            this.m_txtFormuleIndex.AllowNullFormula = false;
            this.m_txtFormuleIndex.AllowSaisieTexte = true;
            this.m_txtFormuleIndex.Formule = null;
            this.m_txtFormuleIndex.Location = new System.Drawing.Point(158, 183);
            this.m_txtFormuleIndex.LockEdition = false;
            this.m_txtFormuleIndex.LockZoneTexte = false;
            this.m_txtFormuleIndex.Name = "m_txtFormuleIndex";
            this.m_txtFormuleIndex.Size = new System.Drawing.Size(395, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtFormuleIndex, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtFormuleIndex.TabIndex = 9;
            this.m_tooltip.SetToolTip(this.m_txtFormuleIndex, "Leave empty to use default index|20090");
            this.m_txtFormuleIndex.Load += new System.EventHandler(this.m_txtFormuleIndex_Load);
            // 
            // m_lblDataType
            // 
            this.m_lblDataType.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblDataType.Location = new System.Drawing.Point(158, 40);
            this.m_lblDataType.Name = "m_lblDataType";
            this.m_lblDataType.Size = new System.Drawing.Size(158, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblDataType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblDataType, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblDataType.TabIndex = 10;
            this.m_lblDataType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(356, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 18);
            this.m_extStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 4;
            this.label4.Text = "Access|20293";
            // 
            // m_lblAcces
            // 
            this.m_lblAcces.BackColor = System.Drawing.SystemColors.Control;
            this.m_lblAcces.Location = new System.Drawing.Point(449, 40);
            this.m_lblAcces.Name = "m_lblAcces";
            this.m_lblAcces.Size = new System.Drawing.Size(105, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblAcces, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblAcces.TabIndex = 10;
            this.m_lblAcces.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(12, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(140, 18);
            this.m_extStyle.SetStyleBackColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label6, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label6.TabIndex = 7;
            this.label6.Text = "Map with|20299";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // m_txtSelectChampCustom
            // 
            this.m_txtSelectChampCustom.ElementSelectionne = null;
            this.m_txtSelectChampCustom.Location = new System.Drawing.Point(158, 210);
            this.m_txtSelectChampCustom.LockEdition = false;
            this.m_txtSelectChampCustom.Name = "m_txtSelectChampCustom";
            this.m_txtSelectChampCustom.SelectedObject = null;
            this.m_txtSelectChampCustom.SelectionLength = 0;
            this.m_txtSelectChampCustom.SelectionStart = 0;
            this.m_txtSelectChampCustom.Size = new System.Drawing.Size(297, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtSelectChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtSelectChampCustom, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectChampCustom.TabIndex = 11;
            this.m_txtSelectChampCustom.Load += new System.EventHandler(this.m_txtSelectChampCustom_Load);
            // 
            // m_lnkCreateField
            // 
            this.m_lnkCreateField.Location = new System.Drawing.Point(461, 212);
            this.m_lnkCreateField.Name = "m_lnkCreateField";
            this.m_lnkCreateField.Size = new System.Drawing.Size(100, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreateField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreateField, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreateField.TabIndex = 12;
            this.m_lnkCreateField.TabStop = true;
            this.m_lnkCreateField.Text = "Quick create|20313";
            this.m_lnkCreateField.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreateField_LinkClicked);
            // 
            // m_chkNoUpdate
            // 
            this.m_chkNoUpdate.Location = new System.Drawing.Point(158, 143);
            this.m_chkNoUpdate.Name = "m_chkNoUpdate";
            this.m_chkNoUpdate.Size = new System.Drawing.Size(322, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkNoUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkNoUpdate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkNoUpdate.TabIndex = 13;
            this.m_chkNoUpdate.Text = "Never update from SNMP|20476";
            this.m_chkNoUpdate.UseVisualStyleBackColor = true;
            // 
            // m_chkNoWriteSNMP
            // 
            this.m_chkNoWriteSNMP.Location = new System.Drawing.Point(158, 161);
            this.m_chkNoWriteSNMP.Name = "m_chkNoWriteSNMP";
            this.m_chkNoWriteSNMP.Size = new System.Drawing.Size(322, 16);
            this.m_extStyle.SetStyleBackColor(this.m_chkNoWriteSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkNoWriteSNMP, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkNoWriteSNMP.TabIndex = 14;
            this.m_chkNoWriteSNMP.Text = "Never write to SNMP|20549";
            this.m_chkNoWriteSNMP.UseVisualStyleBackColor = true;
            // 
            // CFormEditChampEntiteFromQueryToChampCustom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 274);
            this.ControlBox = false;
            this.Controls.Add(this.m_chkNoWriteSNMP);
            this.Controls.Add(this.m_chkNoUpdate);
            this.Controls.Add(this.m_lnkCreateField);
            this.Controls.Add(this.m_txtSelectChampCustom);
            this.Controls.Add(this.m_lblAcces);
            this.Controls.Add(this.m_lblDataType);
            this.Controls.Add(this.m_txtFormuleIndex);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.m_txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtNomChamp);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormEditChampEntiteFromQueryToChampCustom";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Field properties|20298";
            this.Load += new System.EventHandler(this.CFormEditChampEntiteSnmpToSnmp_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtNomChamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_txtDescription;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.expression.CTextBoxZoomFormule m_txtFormuleIndex;
        private sc2i.win32.common.CToolTipTraductible m_tooltip;
        private System.Windows.Forms.Label m_lblDataType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label m_lblAcces;
        private System.Windows.Forms.Label label6;
        private sc2i.win32.data.dynamic.C2iTextBoxFiltreRapide m_txtSelectChampCustom;
        private System.Windows.Forms.LinkLabel m_lnkCreateField;
        private System.Windows.Forms.CheckBox m_chkNoUpdate;
        private System.Windows.Forms.CheckBox m_chkNoWriteSNMP;
    }
}