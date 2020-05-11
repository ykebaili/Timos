namespace futurocom.win32.snmp
{
    partial class CFormEditTrapField
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtName = new System.Windows.Forms.TextBox();
            this.m_txtOID = new System.Windows.Forms.TextBox();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.m_panelOID = new System.Windows.Forms.Panel();
            this.m_panelOID.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 19);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field name|20063";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 19);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 0;
            this.label2.Text = "OID|20064";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_txtName
            // 
            this.m_txtName.Location = new System.Drawing.Point(136, 12);
            this.m_txtName.Name = "m_txtName";
            this.m_txtName.Size = new System.Drawing.Size(197, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtName, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtName.TabIndex = 0;
            // 
            // m_txtOID
            // 
            this.m_txtOID.Location = new System.Drawing.Point(137, 2);
            this.m_txtOID.Name = "m_txtOID";
            this.m_txtOID.Size = new System.Drawing.Size(197, 20);
            this.m_extStyle.SetStyleBackColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtOID.TabIndex = 0;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(88, 80);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 2;
            this.m_btnOk.Text = "Ok|1";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(181, 80);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.m_extStyle.SetStyleBackColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.button1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.button1.TabIndex = 3;
            this.button1.Text = "Cancel|2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_panelOID
            // 
            this.m_panelOID.Controls.Add(this.label2);
            this.m_panelOID.Controls.Add(this.m_txtOID);
            this.m_panelOID.Location = new System.Drawing.Point(0, 38);
            this.m_panelOID.Name = "m_panelOID";
            this.m_panelOID.Size = new System.Drawing.Size(346, 31);
            this.m_extStyle.SetStyleBackColor(this.m_panelOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelOID, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOID.TabIndex = 1;
            // 
            // CFormEditTrapField
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 123);
            this.ControlBox = false;
            this.Controls.Add(this.m_panelOID);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_txtName);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormEditTrapField";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Trapfield|20064";
            this.Load += new System.EventHandler(this.CFormEditTrapField_Load);
            this.m_panelOID.ResumeLayout(false);
            this.m_panelOID.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private sc2i.win32.common.CExtStyle m_extStyle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox m_txtName;
        private System.Windows.Forms.TextBox m_txtOID;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel m_panelOID;
    }
}