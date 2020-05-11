namespace timos.supervision.Masquage
{
    partial class CFormMasquageAlarmeManuel
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
            this.m_panelBoutons = new System.Windows.Forms.Panel();
            this.m_btnOK = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelOptions = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.m_dtPickerDateDebutValidite = new sc2i.win32.common.C2iDateTimePicker();
            this.m_dtPickerDateFinValidite = new sc2i.win32.common.C2iDateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.m_txtLibelle = new sc2i.win32.common.C2iTextBox();
            this.m_cmbSelecCategorieMasquage = new sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.m_panelBoutons.SuspendLayout();
            this.c2iPanelOmbre1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelBoutons
            // 
            this.m_panelBoutons.Controls.Add(this.m_btnOK);
            this.m_panelBoutons.Controls.Add(this.m_btnAnnuler);
            this.m_panelBoutons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBoutons.Location = new System.Drawing.Point(0, 330);
            this.m_panelBoutons.Name = "m_panelBoutons";
            this.m_panelBoutons.Size = new System.Drawing.Size(606, 41);
            this.m_panelBoutons.TabIndex = 3;
            // 
            // m_btnOK
            // 
            this.m_btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnOK.FlatAppearance.BorderSize = 0;
            this.m_btnOK.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.m_btnOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOK.Image = global::timos.Properties.Resources.check;
            this.m_btnOK.Location = new System.Drawing.Point(269, 6);
            this.m_btnOK.Name = "m_btnOK";
            this.m_btnOK.Size = new System.Drawing.Size(26, 26);
            this.m_btnOK.TabIndex = 1;
            this.m_btnOK.UseVisualStyleBackColor = true;
            this.m_btnOK.Click += new System.EventHandler(this.m_btnOK_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatAppearance.BorderSize = 0;
            this.m_btnAnnuler.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.m_btnAnnuler.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.Image = global::timos.Properties.Resources.cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(310, 6);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(26, 26);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_panelOptions);
            this.c2iPanelOmbre1.Controls.Add(this.m_dtPickerDateDebutValidite);
            this.c2iPanelOmbre1.Controls.Add(this.m_dtPickerDateFinValidite);
            this.c2iPanelOmbre1.Controls.Add(this.label7);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.m_txtLibelle);
            this.c2iPanelOmbre1.Controls.Add(this.m_cmbSelecCategorieMasquage);
            this.c2iPanelOmbre1.Controls.Add(this.label6);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.Controls.Add(this.label3);
            this.c2iPanelOmbre1.Controls.Add(this.label5);
            this.c2iPanelOmbre1.Controls.Add(this.label4);
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(12, 12);
            this.c2iPanelOmbre1.LockEdition = false;
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(591, 318);
            this.c2iPanelOmbre1.TabIndex = 4;
            // 
            // m_panelOptions
            // 
            this.m_panelOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelOptions.Location = new System.Drawing.Point(39, 143);
            this.m_panelOptions.Name = "m_panelOptions";
            this.m_panelOptions.Size = new System.Drawing.Size(515, 146);
            this.m_panelOptions.TabIndex = 4017;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(36, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(347, 14);
            this.label7.TabIndex = 4015;
            this.label7.Text = "Mask when the received Alarm meets all the selected conditions|10320";
            // 
            // m_dtPickerDateDebutValidite
            // 
            this.m_dtPickerDateDebutValidite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtPickerDateDebutValidite.Location = new System.Drawing.Point(188, 70);
            this.m_dtPickerDateDebutValidite.LockEdition = false;
            this.m_dtPickerDateDebutValidite.Name = "m_dtPickerDateDebutValidite";
            this.m_dtPickerDateDebutValidite.Size = new System.Drawing.Size(90, 20);
            this.m_dtPickerDateDebutValidite.TabIndex = 4012;
            this.m_dtPickerDateDebutValidite.Value = new System.DateTime(2011, 8, 26, 10, 57, 29, 736);
            // 
            // m_dtPickerDateFinValidite
            // 
            this.m_dtPickerDateFinValidite.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtPickerDateFinValidite.Location = new System.Drawing.Point(317, 70);
            this.m_dtPickerDateFinValidite.LockEdition = false;
            this.m_dtPickerDateFinValidite.Name = "m_dtPickerDateFinValidite";
            this.m_dtPickerDateFinValidite.Size = new System.Drawing.Size(90, 20);
            this.m_dtPickerDateFinValidite.TabIndex = 4011;
            this.m_dtPickerDateFinValidite.Value = new System.DateTime(2011, 8, 26, 10, 57, 29, 736);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 4015;
            this.label1.Text = "Label |50";
            // 
            // m_txtLibelle
            // 
            this.m_txtLibelle.Location = new System.Drawing.Point(90, 13);
            this.m_txtLibelle.LockEdition = false;
            this.m_txtLibelle.Name = "m_txtLibelle";
            this.m_txtLibelle.Size = new System.Drawing.Size(464, 20);
            this.m_txtLibelle.TabIndex = 4013;
            // 
            // m_cmbSelecCategorieMasquage
            // 
            this.m_cmbSelecCategorieMasquage.ComportementLinkStd = true;
            this.m_cmbSelecCategorieMasquage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbSelecCategorieMasquage.ElementSelectionne = null;
            this.m_cmbSelecCategorieMasquage.FormattingEnabled = true;
            this.m_cmbSelecCategorieMasquage.IsLink = false;
            this.m_cmbSelecCategorieMasquage.LinkProperty = "";
            this.m_cmbSelecCategorieMasquage.ListDonnees = null;
            this.m_cmbSelecCategorieMasquage.Location = new System.Drawing.Point(188, 43);
            this.m_cmbSelecCategorieMasquage.LockEdition = false;
            this.m_cmbSelecCategorieMasquage.Name = "m_cmbSelecCategorieMasquage";
            this.m_cmbSelecCategorieMasquage.NullAutorise = false;
            this.m_cmbSelecCategorieMasquage.ProprieteAffichee = null;
            this.m_cmbSelecCategorieMasquage.ProprieteParentListeObjets = null;
            this.m_cmbSelecCategorieMasquage.SelectionneurParent = null;
            this.m_cmbSelecCategorieMasquage.Size = new System.Drawing.Size(366, 21);
            this.m_cmbSelecCategorieMasquage.TabIndex = 4016;
            this.m_cmbSelecCategorieMasquage.TextNull = "(empty)";
            this.m_cmbSelecCategorieMasquage.Tri = true;
            this.m_cmbSelecCategorieMasquage.TypeFormEdition = null;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 105);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(135, 13);
            this.label6.TabIndex = 4018;
            this.label6.Text = "Filtering options|10319";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 14);
            this.label2.TabIndex = 4014;
            this.label2.Text = "Masking Category|10308";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(22, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 14);
            this.label3.TabIndex = 4010;
            this.label3.Text = "Dates of validity|10309";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(282, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 14);
            this.label5.TabIndex = 4008;
            this.label5.Text = "to|10311";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 14);
            this.label4.TabIndex = 4009;
            this.label4.Text = "from|10310";
            // 
            // CFormMasquageAlarmeManuel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(606, 371);
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.m_panelBoutons);
            this.Name = "CFormMasquageAlarmeManuel";
            this.Text = "Manual Alarm Masking setup|10318";
            this.Load += new System.EventHandler(this.CFormMasquageAlarmeManuel_Load);
            this.m_panelBoutons.ResumeLayout(false);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel m_panelBoutons;
        private System.Windows.Forms.Button m_btnOK;
        private System.Windows.Forms.Button m_btnAnnuler;
        private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private sc2i.win32.common.C2iDateTimePicker m_dtPickerDateDebutValidite;
        private System.Windows.Forms.Label label4;
        private sc2i.win32.common.C2iDateTimePicker m_dtPickerDateFinValidite;
        private System.Windows.Forms.Label label1;
        private sc2i.win32.common.C2iTextBox m_txtLibelle;
        private sc2i.win32.data.navigation.CComboBoxLinkListeObjetsDonnees m_cmbSelecCategorieMasquage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel m_panelOptions;
        private System.Windows.Forms.Label label7;
    }
}