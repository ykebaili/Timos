namespace futurocom.win32.snmp
{
    partial class CFormEditEasyQuery
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnParametres = new System.Windows.Forms.Button();
            this.m_txtLibelle = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_editeur = new futurocom.win32.easyquery.CEditeurEasyQuery();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnParametres);
            this.panel1.Controls.Add(this.m_txtLibelle);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 33);
            this.panel1.TabIndex = 1;
            // 
            // m_btnParametres
            // 
            this.m_btnParametres.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnParametres.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_btnParametres.Image = global::futurocom.win32.snmp.Properties.Resources.Settings;
            this.m_btnParametres.Location = new System.Drawing.Point(853, 0);
            this.m_btnParametres.Name = "m_btnParametres";
            this.m_btnParametres.Size = new System.Drawing.Size(35, 33);
            this.m_btnParametres.TabIndex = 4;
            this.m_btnParametres.UseVisualStyleBackColor = true;
            this.m_btnParametres.Click += new System.EventHandler(this.m_btnParametres_Click);
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Location = new System.Drawing.Point(153, 7);
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(397, 20);
            this.m_txtLibelle.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Query label|20069";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnCancel);
            this.panel2.Controls.Add(this.m_btnOk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 419);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(888, 39);
            this.panel2.TabIndex = 2;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Location = new System.Drawing.Point(410, 6);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.m_btnCancel.TabIndex = 8;
            this.m_btnCancel.Text = "Cancel|2";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(319, 6);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 7;
            this.m_btnOk.Text = "Ok|1";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_editeur
            // 
            this.m_editeur.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_editeur.Location = new System.Drawing.Point(0, 33);
            this.m_editeur.Name = "m_editeur";
            this.m_editeur.Size = new System.Drawing.Size(888, 386);
            this.m_editeur.TabIndex = 0;
            // 
            // CFormEditEasyQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 458);
            this.Controls.Add(this.m_editeur);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "CFormEditEasyQuery";
            this.Text = "CFormEditEasyQuery";
            this.Load += new System.EventHandler(this.CFormEditEasyQuery_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private futurocom.win32.easyquery.CEditeurEasyQuery m_editeur;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button m_btnCancel;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtLibelle;
        private System.Windows.Forms.Button m_btnParametres;
    }
}