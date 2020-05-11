namespace TimosInventory
{
    partial class CFormReleveSite
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
            this.m_btnQuitter = new System.Windows.Forms.Button();
            this.m_btnSave = new System.Windows.Forms.Button();
            this.m_panelHeader = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_btnAdd = new System.Windows.Forms.Button();
            this.m_panelTitre = new System.Windows.Forms.Panel();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.m_lblStartDate = new System.Windows.Forms.Label();
            this.m_lnkReset = new System.Windows.Forms.LinkLabel();
            this.m_panelEquipements = new TimosInventory.ControleInventaire.CControleListePourInventaire();
            this.panel1.SuspendLayout();
            this.m_panelHeader.SuspendLayout();
            this.m_panelTitre.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_btnQuitter);
            this.panel1.Controls.Add(this.m_btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 367);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(888, 60);
            this.panel1.TabIndex = 12;
            // 
            // m_btnQuitter
            // 
            this.m_btnQuitter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnQuitter.Image = global::TimosInventory.Properties.Resources.Icone_quitter_32;
            this.m_btnQuitter.Location = new System.Drawing.Point(804, 6);
            this.m_btnQuitter.Name = "m_btnQuitter";
            this.m_btnQuitter.Size = new System.Drawing.Size(72, 50);
            this.m_btnQuitter.TabIndex = 1;
            this.m_btnQuitter.UseVisualStyleBackColor = true;
            this.m_btnQuitter.Click += new System.EventHandler(this.m_btnQuitter_Click);
            // 
            // m_btnSave
            // 
            this.m_btnSave.Image = global::TimosInventory.Properties.Resources.SaveFile;
            this.m_btnSave.Location = new System.Drawing.Point(13, 7);
            this.m_btnSave.Name = "m_btnSave";
            this.m_btnSave.Size = new System.Drawing.Size(72, 50);
            this.m_btnSave.TabIndex = 0;
            this.m_btnSave.UseVisualStyleBackColor = true;
            this.m_btnSave.Click += new System.EventHandler(this.m_btnSave_Click);
            // 
            // m_panelHeader
            // 
            this.m_panelHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.m_panelHeader.Controls.Add(this.label5);
            this.m_panelHeader.Controls.Add(this.label6);
            this.m_panelHeader.Controls.Add(this.label4);
            this.m_panelHeader.Controls.Add(this.label3);
            this.m_panelHeader.Controls.Add(this.label2);
            this.m_panelHeader.Controls.Add(this.label1);
            this.m_panelHeader.Controls.Add(this.m_btnAdd);
            this.m_panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelHeader.Location = new System.Drawing.Point(0, 37);
            this.m_panelHeader.Name = "m_panelHeader";
            this.m_panelHeader.Size = new System.Drawing.Size(888, 30);
            this.m_panelHeader.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(501, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(232, 30);
            this.label5.TabIndex = 4;
            this.label5.Text = "Comment|20034";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Right;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(733, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 30);
            this.label6.TabIndex = 5;
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(256, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(245, 30);
            this.label4.TabIndex = 3;
            this.label4.Text = "Type|20033";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 30);
            this.label3.TabIndex = 2;
            this.label3.Text = "Serial|20032";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 30);
            this.label2.TabIndex = 1;
            this.label2.Text = "Coord.|20031";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 30);
            this.label1.TabIndex = 0;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_btnAdd
            // 
            this.m_btnAdd.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_btnAdd.Image = global::TimosInventory.Properties.Resources.add;
            this.m_btnAdd.Location = new System.Drawing.Point(864, 0);
            this.m_btnAdd.Name = "m_btnAdd";
            this.m_btnAdd.Size = new System.Drawing.Size(24, 30);
            this.m_btnAdd.TabIndex = 6;
            this.m_btnAdd.UseVisualStyleBackColor = true;
            this.m_btnAdd.Click += new System.EventHandler(this.m_btnAdd_Click);
            // 
            // m_panelTitre
            // 
            this.m_panelTitre.BackColor = System.Drawing.Color.White;
            this.m_panelTitre.Controls.Add(this.m_lblTitre);
            this.m_panelTitre.Controls.Add(this.panel3);
            this.m_panelTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelTitre.Location = new System.Drawing.Point(0, 0);
            this.m_panelTitre.Name = "m_panelTitre";
            this.m_panelTitre.Size = new System.Drawing.Size(888, 37);
            this.m_panelTitre.TabIndex = 14;
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitre.Location = new System.Drawing.Point(0, 0);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(697, 37);
            this.m_lblTitre.TabIndex = 0;
            this.m_lblTitre.Text = "Title";
            this.m_lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.m_lblStartDate);
            this.panel3.Controls.Add(this.m_lnkReset);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(697, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(191, 37);
            this.panel3.TabIndex = 1;
            // 
            // m_lblStartDate
            // 
            this.m_lblStartDate.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_lblStartDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblStartDate.Location = new System.Drawing.Point(0, 0);
            this.m_lblStartDate.Name = "m_lblStartDate";
            this.m_lblStartDate.Size = new System.Drawing.Size(191, 13);
            this.m_lblStartDate.TabIndex = 1;
            this.m_lblStartDate.Text = "STARTED";
            // 
            // m_lnkReset
            // 
            this.m_lnkReset.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_lnkReset.Location = new System.Drawing.Point(0, 21);
            this.m_lnkReset.Name = "m_lnkReset";
            this.m_lnkReset.Size = new System.Drawing.Size(191, 16);
            this.m_lnkReset.TabIndex = 0;
            this.m_lnkReset.TabStop = true;
            this.m_lnkReset.Text = "Reset survey|20040";
            this.m_lnkReset.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.m_lnkReset.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkReset_LinkClicked);
            // 
            // m_panelEquipements
            // 
            this.m_panelEquipements.CurrentItemIndex = null;
            this.m_panelEquipements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelEquipements.Items = new sc2i.win32.common.customizableList.CCustomizableListItem[0];
            this.m_panelEquipements.Location = new System.Drawing.Point(0, 67);
            this.m_panelEquipements.LockEdition = false;
            this.m_panelEquipements.Name = "m_panelEquipements";
            this.m_panelEquipements.Size = new System.Drawing.Size(888, 300);
            this.m_panelEquipements.TabIndex = 11;
            // 
            // CFormReleveSite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(888, 427);
            this.Controls.Add(this.m_panelEquipements);
            this.Controls.Add(this.m_panelHeader);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_panelTitre);
            this.Name = "CFormReleveSite";
            this.Text = "Site survey|20020";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CFormReleveSite_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CFormReleveSite_FormClosing);
            this.panel1.ResumeLayout(false);
            this.m_panelHeader.ResumeLayout(false);
            this.m_panelTitre.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private TimosInventory.ControleInventaire.CControleListePourInventaire m_panelEquipements;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button m_btnSave;
        private System.Windows.Forms.Panel m_panelHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel m_panelTitre;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label m_lblTitre;
        private System.Windows.Forms.LinkLabel m_lnkReset;
        private System.Windows.Forms.Label m_lblStartDate;
        private System.Windows.Forms.Button m_btnAdd;
        private System.Windows.Forms.Button m_btnQuitter;
    }
}