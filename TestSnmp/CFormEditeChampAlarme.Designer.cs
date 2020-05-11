namespace TestSnmp
{
    partial class CFormEditeChampAlarme
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
            this.m_txtNomChamp = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_cmbType = new System.Windows.Forms.ComboBox();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_chkCle = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nom du champ";
            // 
            // m_txtNomChamp
            // 
            this.m_txtNomChamp.Location = new System.Drawing.Point(98, 10);
            this.m_txtNomChamp.Name = "m_txtNomChamp";
            this.m_txtNomChamp.Size = new System.Drawing.Size(251, 20);
            this.m_txtNomChamp.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Type";
            // 
            // m_cmbType
            // 
            this.m_cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbType.FormattingEnabled = true;
            this.m_cmbType.Location = new System.Drawing.Point(99, 37);
            this.m_cmbType.Name = "m_cmbType";
            this.m_cmbType.Size = new System.Drawing.Size(121, 21);
            this.m_cmbType.TabIndex = 3;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(151, 86);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 4;
            this.m_btnOk.Text = "Ok";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Location = new System.Drawing.Point(251, 86);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_btnAnnuler.TabIndex = 5;
            this.m_btnAnnuler.Text = "Annuler";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.button1_Click);
            // 
            // m_chkCle
            // 
            this.m_chkCle.AutoSize = true;
            this.m_chkCle.Location = new System.Drawing.Point(99, 65);
            this.m_chkCle.Name = "m_chkCle";
            this.m_chkCle.Size = new System.Drawing.Size(41, 17);
            this.m_chkCle.TabIndex = 6;
            this.m_chkCle.Text = "Clé";
            this.m_chkCle.UseVisualStyleBackColor = true;
            // 
            // CFormEditeChampAlarme
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 127);
            this.ControlBox = false;
            this.Controls.Add(this.m_chkCle);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_cmbType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.m_txtNomChamp);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormEditeChampAlarme";
            this.Text = "Champ";
            this.Load += new System.EventHandler(this.CFormEditeChampAlarme_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtNomChamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox m_cmbType;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.CheckBox m_chkCle;
    }
}