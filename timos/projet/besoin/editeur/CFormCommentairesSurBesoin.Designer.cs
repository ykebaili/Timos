using sc2i.win32.common;
namespace timos.projet.besoin.editeur
{
    partial class CFormCommentairesSurBesoin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormCommentairesSurBesoin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_txtCommentaire = new sc2i.win32.common.C2iTextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.m_btnAnnuler);
            this.panel1.Controls.Add(this.m_btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 148);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(497, 46);
            this.panel1.TabIndex = 0;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.BackColor = System.Drawing.Color.Transparent;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(255, 3);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 38);
            this.m_btnAnnuler.TabIndex = 7;
            this.m_btnAnnuler.UseVisualStyleBackColor = false;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.BackColor = System.Drawing.Color.Transparent;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(199, 3);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 38);
            this.m_btnOk.TabIndex = 6;
            this.m_btnOk.UseVisualStyleBackColor = false;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.m_lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitre.ForeColor = System.Drawing.Color.White;
            this.m_lblTitre.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(497, 23);
            this.m_lblTitre.TabIndex = 1;
            // 
            // m_txtCommentaire
            // 
            this.m_txtCommentaire.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtCommentaire.EmptyText = "";
            this.m_txtCommentaire.Location = new System.Drawing.Point(0, 23);
            this.m_txtCommentaire.LockEdition = false;
            this.m_txtCommentaire.Multiline = true;
            this.m_txtCommentaire.Name = "m_txtCommentaire";
            this.m_txtCommentaire.Size = new System.Drawing.Size(497, 125);
            this.m_txtCommentaire.TabIndex = 2;
            // 
            // CFormCommentairesSurBesoin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(497, 194);
            this.Controls.Add(this.m_txtCommentaire);
            this.Controls.Add(this.m_lblTitre);
            this.Controls.Add(this.panel1);
            this.Name = "CFormCommentairesSurBesoin";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Label m_lblTitre;
        private C2iTextBox m_txtCommentaire;
    }
}