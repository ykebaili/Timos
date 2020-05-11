using TimosInventory.ControleInventaire;
namespace TimosInventory
{
    partial class CFormCreerEquipement
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
            this.m_txtSerial = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.m_lblSite = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_panelEqptParent = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.m_lblEqptParent = new System.Windows.Forms.Label();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_panelCoordonnee = new TimosInventory.CTxtSaisieCoordonnee();
            this.m_selectTypeEquipement = new TimosInventory.ControleInventaire.CControleTypeEquipement();
            this.panel2 = new System.Windows.Forms.Panel();
            this.m_panelChampsCustom = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.m_panelEqptParent.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(10, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Serial number|20025";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtSerial
            // 
            this.m_txtSerial.Location = new System.Drawing.Point(131, 8);
            this.m_txtSerial.Name = "m_txtSerial";
            this.m_txtSerial.Size = new System.Drawing.Size(203, 20);
            this.m_txtSerial.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(3, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Site|20026";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblSite
            // 
            this.m_lblSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblSite.Location = new System.Drawing.Point(134, 2);
            this.m_lblSite.Name = "m_lblSite";
            this.m_lblSite.Size = new System.Drawing.Size(446, 20);
            this.m_lblSite.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(10, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "Equipment type|20027";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(10, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 18);
            this.label5.TabIndex = 6;
            this.label5.Text = "Coordinate|20028";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.m_lblSite);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(635, 26);
            this.panel1.TabIndex = 8;
            // 
            // m_panelEqptParent
            // 
            this.m_panelEqptParent.Controls.Add(this.label6);
            this.m_panelEqptParent.Controls.Add(this.m_lblEqptParent);
            this.m_panelEqptParent.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEqptParent.Location = new System.Drawing.Point(0, 26);
            this.m_panelEqptParent.Name = "m_panelEqptParent";
            this.m_panelEqptParent.Size = new System.Drawing.Size(635, 26);
            this.m_panelEqptParent.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 4);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 18);
            this.label6.TabIndex = 2;
            this.label6.Text = "Parent equipment|20029";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_lblEqptParent
            // 
            this.m_lblEqptParent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_lblEqptParent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblEqptParent.Location = new System.Drawing.Point(134, 2);
            this.m_lblEqptParent.Name = "m_lblEqptParent";
            this.m_lblEqptParent.Size = new System.Drawing.Size(446, 20);
            this.m_lblEqptParent.TabIndex = 3;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOk.Location = new System.Drawing.Point(234, 11);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_btnOk.TabIndex = 10;
            this.m_btnOk.Text = "Ok|1";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.Location = new System.Drawing.Point(325, 11);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_btnAnnuler.TabIndex = 11;
            this.m_btnAnnuler.Text = "Cancel|2";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_panelCoordonnee
            // 
            this.m_panelCoordonnee.Location = new System.Drawing.Point(131, 83);
            this.m_panelCoordonnee.Name = "m_panelCoordonnee";
            this.m_panelCoordonnee.Size = new System.Drawing.Size(200, 24);
            this.m_panelCoordonnee.TabIndex = 7;
            this.m_panelCoordonnee.Enter += new System.EventHandler(this.m_panelCoordonnee_Enter);
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(131, 34);
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(443, 42);
            this.m_selectTypeEquipement.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.m_btnOk);
            this.panel2.Controls.Add(this.m_btnAnnuler);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 219);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(635, 46);
            this.panel2.TabIndex = 12;
            // 
            // m_panelChampsCustom
            // 
            this.m_panelChampsCustom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelChampsCustom.Location = new System.Drawing.Point(0, 177);
            this.m_panelChampsCustom.Name = "m_panelChampsCustom";
            this.m_panelChampsCustom.Size = new System.Drawing.Size(635, 42);
            this.m_panelChampsCustom.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_selectTypeEquipement);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.m_txtSerial);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.m_panelCoordonnee);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 52);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(635, 125);
            this.panel3.TabIndex = 14;
            // 
            // CFormCreerEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(635, 265);
            this.Controls.Add(this.m_panelChampsCustom);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.m_panelEqptParent);
            this.Controls.Add(this.panel1);
            this.Name = "CFormCreerEquipement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit equipment|20024";
            this.Load += new System.EventHandler(this.CFormCreerEquipement_Load);
            this.panel1.ResumeLayout(false);
            this.m_panelEqptParent.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_txtSerial;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label m_lblSite;
        private System.Windows.Forms.Label label4;
        private CControleTypeEquipement m_selectTypeEquipement;
        private System.Windows.Forms.Label label5;
        private CTxtSaisieCoordonnee m_panelCoordonnee;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel m_panelEqptParent;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label m_lblEqptParent;
        private System.Windows.Forms.Button m_btnOk;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel m_panelChampsCustom;
        private System.Windows.Forms.Panel panel3;
    }
}