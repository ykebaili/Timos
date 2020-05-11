namespace timos.supervision.Masquage
{
    partial class CFormSelectNiveauMasquagePopup
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
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_selectNiveauMasquage = new timos.supervision.CControleSelectNiveauMasquageAlarme();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelBas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelBas
            // 
            this.m_panelBas.Controls.Add(this.m_btnAnnuler);
            this.m_panelBas.Controls.Add(this.m_btnOK);
            this.m_panelBas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBas.Location = new System.Drawing.Point(0, 132);
            this.m_panelBas.Name = "m_panelBas";
            this.m_panelBas.Size = new System.Drawing.Size(248, 38);
            this.m_panelBas.TabIndex = 1;
            // 
            // m_btnOK
            // 
            this.m_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOK.Location = new System.Drawing.Point(31, 7);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(75, 23);
            this.m_btnOK.TabIndex = 0;
            this.m_btnOK.Text = "OK|10";
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(125, 7);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_btnAnnuler.TabIndex = 0;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTitre.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(248, 31);
            this.m_lblTitre.TabIndex = 2;
            this.m_lblTitre.Text = "Display Alarms masked with priority level lower than selected value|10314";
            // 
            // m_selectNiveauMasquage
            // 
            this.m_selectNiveauMasquage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_selectNiveauMasquage.Location = new System.Drawing.Point(0, 31);
            this.m_selectNiveauMasquage.Name = "m_selectNiveauMasquage";
            this.m_selectNiveauMasquage.Size = new System.Drawing.Size(248, 101);
            this.m_selectNiveauMasquage.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.m_selectNiveauMasquage);
            this.panel1.Controls.Add(this.m_panelBas);
            this.panel1.Controls.Add(this.m_lblTitre);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 172);
            this.panel1.TabIndex = 3;
            // 
            // CFormSelectNiveauMasquagePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(250, 172);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(250, 100);
            this.Name = "CFormSelectNiveauMasquagePopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CFormSelectNiveauMasquagePopup";
            this.Load += new System.EventHandler(this.CFormSelectNiveauMasquagePopup_Load);
            this.m_panelBas.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CControleSelectNiveauMasquageAlarme m_selectNiveauMasquage;
        private System.Windows.Forms.Panel m_panelBas;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Label m_lblTitre;
        private System.Windows.Forms.Panel panel1;
    }
}