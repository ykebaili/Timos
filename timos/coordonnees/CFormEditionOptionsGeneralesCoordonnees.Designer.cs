namespace timos.coordonnees
{
    partial class CFormEditionOptionsGeneralesCoordonnees
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
            if (m_contexteDonnee != null)
                m_contexteDonnee.Dispose();
            m_contexteDonnee = null;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormEditionOptionsGeneralesCoordonnees));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.c2iPanel3 = new sc2i.win32.common.C2iPanel(this.components);
            this.c2iPanel2 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_panelOptionsEquipement = new timos.CControleEditionOptionsControleCoordonnees();
            this.c2iPanel8 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelOptionsStock = new timos.CControleEditionOptionsControleCoordonnees();
            this.c2iPanel5 = new sc2i.win32.common.C2iPanel(this.components);
            this.m_optionsSite = new timos.CControleEditionOptionsControleCoordonnees();
            this.c2iPanel1 = new sc2i.win32.common.C2iPanel(this.components);
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel5.SuspendLayout();
            this.m_panelOptionsEquipement.SuspendLayout();
            this.m_panelOptionsStock.SuspendLayout();
            this.m_optionsSite.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(506, 27);
            this.label1.TabIndex = 2;
            this.label1.Text = "Site options|20468";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.m_optionsSite);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 141);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 27);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(45, 114);
            this.panel2.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel3.Controls.Add(this.m_panelOptionsEquipement);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 282);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(506, 141);
            this.panel3.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 27);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(45, 114);
            this.panel4.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(506, 27);
            this.label2.TabIndex = 2;
            this.label2.Text = "Equipment options|20470";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.panel5.Controls.Add(this.m_panelOptionsStock);
            this.panel5.Controls.Add(this.panel6);
            this.panel5.Controls.Add(this.label3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 141);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(506, 141);
            this.panel5.TabIndex = 3;
            // 
            // panel6
            // 
            this.panel6.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel6.Location = new System.Drawing.Point(0, 27);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(45, 114);
            this.panel6.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(506, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Stock options|20469";
            // 
            // c2iPanel3
            // 
            this.c2iPanel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanel3.Location = new System.Drawing.Point(0, 90);
            this.c2iPanel3.LockEdition = true;
            this.c2iPanel3.Name = "c2iPanel3";
            this.c2iPanel3.Size = new System.Drawing.Size(514, 50);
            this.c2iPanel3.TabIndex = 8;
            // 
            // c2iPanel2
            // 
            this.c2iPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanel2.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel2.LockEdition = true;
            this.c2iPanel2.Name = "c2iPanel2";
            this.c2iPanel2.Size = new System.Drawing.Size(514, 50);
            this.c2iPanel2.TabIndex = 8;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_btnAnnuler.Location = new System.Drawing.Point(260, 429);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_btnAnnuler.TabIndex = 5;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_btnOk.Location = new System.Drawing.Point(206, 429);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_btnOk.TabIndex = 4;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_panelOptionsEquipement
            // 
            this.m_panelOptionsEquipement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOptionsEquipement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelOptionsEquipement.Controls.Add(this.c2iPanel8);
            this.m_panelOptionsEquipement.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelOptionsEquipement.ForeColor = System.Drawing.Color.Black;
            this.m_panelOptionsEquipement.Location = new System.Drawing.Point(45, 27);
            this.m_panelOptionsEquipement.LockEdition = true;
            this.m_panelOptionsEquipement.Name = "m_panelOptionsEquipement";
            this.m_panelOptionsEquipement.Size = new System.Drawing.Size(461, 114);
            this.m_panelOptionsEquipement.TabIndex = 1;
            this.m_panelOptionsEquipement.Load += new System.EventHandler(this.m_optionsSite_Load);
            // 
            // c2iPanel8
            // 
            this.c2iPanel8.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanel8.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel8.LockEdition = true;
            this.c2iPanel8.Name = "c2iPanel8";
            this.c2iPanel8.Size = new System.Drawing.Size(459, 0);
            this.c2iPanel8.TabIndex = 8;
            // 
            // m_panelOptionsStock
            // 
            this.m_panelOptionsStock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelOptionsStock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panelOptionsStock.Controls.Add(this.c2iPanel5);
            this.m_panelOptionsStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelOptionsStock.ForeColor = System.Drawing.Color.Black;
            this.m_panelOptionsStock.Location = new System.Drawing.Point(45, 27);
            this.m_panelOptionsStock.LockEdition = true;
            this.m_panelOptionsStock.Name = "m_panelOptionsStock";
            this.m_panelOptionsStock.Size = new System.Drawing.Size(461, 114);
            this.m_panelOptionsStock.TabIndex = 1;
            this.m_panelOptionsStock.Load += new System.EventHandler(this.m_optionsSite_Load);
            // 
            // c2iPanel5
            // 
            this.c2iPanel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanel5.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel5.LockEdition = true;
            this.c2iPanel5.Name = "c2iPanel5";
            this.c2iPanel5.Size = new System.Drawing.Size(459, 0);
            this.c2iPanel5.TabIndex = 8;
            // 
            // m_optionsSite
            // 
            this.m_optionsSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_optionsSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_optionsSite.Controls.Add(this.c2iPanel1);
            this.m_optionsSite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_optionsSite.ForeColor = System.Drawing.Color.Black;
            this.m_optionsSite.Location = new System.Drawing.Point(45, 27);
            this.m_optionsSite.LockEdition = true;
            this.m_optionsSite.Name = "m_optionsSite";
            this.m_optionsSite.Size = new System.Drawing.Size(461, 114);
            this.m_optionsSite.TabIndex = 1;
            this.m_optionsSite.Load += new System.EventHandler(this.m_optionsSite_Load);
            // 
            // c2iPanel1
            // 
            this.c2iPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.c2iPanel1.Location = new System.Drawing.Point(0, 0);
            this.c2iPanel1.LockEdition = true;
            this.c2iPanel1.Name = "c2iPanel1";
            this.c2iPanel1.Size = new System.Drawing.Size(459, 0);
            this.c2iPanel1.TabIndex = 8;
            // 
            // CFormEditionOptionsGeneralesCoordonnees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(506, 476);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel1);
            this.Name = "CFormEditionOptionsGeneralesCoordonnees";
            this.Text = "General coordinate options|20464";
            this.Load += new System.EventHandler(this.CFormEditionOptionsGeneralesCoordonnees_Load);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.m_panelOptionsEquipement.ResumeLayout(false);
            this.m_panelOptionsStock.ResumeLayout(false);
            this.m_optionsSite.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private CControleEditionOptionsControleCoordonnees m_optionsSite;
        private sc2i.win32.common.C2iPanel c2iPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label3;
        private CControleEditionOptionsControleCoordonnees m_panelOptionsStock;
        private sc2i.win32.common.C2iPanel c2iPanel5;
        private CControleEditionOptionsControleCoordonnees m_panelOptionsEquipement;
        private sc2i.win32.common.C2iPanel c2iPanel8;
        private sc2i.win32.common.C2iPanel c2iPanel3;
        private sc2i.win32.common.C2iPanel c2iPanel2;
        private System.Windows.Forms.Button m_btnAnnuler;
        private System.Windows.Forms.Button m_btnOk;


    }
}