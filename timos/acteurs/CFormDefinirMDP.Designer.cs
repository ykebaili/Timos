namespace timos
{
	partial class CFormDefinirMDP
	{
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            sc2i.win32.common.CProfilEffetFondu cProfilEffetFondu1 = new sc2i.win32.common.CProfilEffetFondu();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormDefinirMDP));
            this.m_effetFondu = new sc2i.win32.common.CEffetFonduPourForm();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.m_lblPasswordConfirm = new System.Windows.Forms.Label();
            this.m_txtPasswordConfirm = new sc2i.win32.common.C2iTextBox();
            this.m_lblPassword = new System.Windows.Forms.Label();
            this.m_txtPassword = new sc2i.win32.common.C2iTextBox();
            this.m_txtOldPassword = new sc2i.win32.common.C2iTextBox();
            this.m_lblOldPassword = new System.Windows.Forms.Label();
            this.m_btnCancel = new sc2i.win32.common.CDialogResultBouton();
            this.m_btnOk = new sc2i.win32.common.CDialogResultBouton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // m_effetFondu
            // 
            this.m_effetFondu.AuDessusDesAutresFenetres = false;
            this.m_effetFondu.EffetFonduFermeture = true;
            this.m_effetFondu.EffetFonduOuverture = true;
            this.m_effetFondu.Formulaire = this;
            cProfilEffetFondu1.EffetActif = true;
            cProfilEffetFondu1.EffetFermeture = true;
            cProfilEffetFondu1.EffetOuverture = true;
            cProfilEffetFondu1.IntervalImages = 10;
            cProfilEffetFondu1.NombreImages = 10;
            this.m_effetFondu.Profil = cProfilEffetFondu1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::timos.Properties.Resources.cadenas;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(118, 74);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // m_lblPasswordConfirm
            // 
            this.m_lblPasswordConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblPasswordConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblPasswordConfirm.Location = new System.Drawing.Point(2, 123);
            this.m_lblPasswordConfirm.Name = "m_lblPasswordConfirm";
            this.m_lblPasswordConfirm.Size = new System.Drawing.Size(112, 16);
            this.m_lblPasswordConfirm.TabIndex = 15;
            this.m_lblPasswordConfirm.Text = "Confirmation|776";
            this.m_lblPasswordConfirm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPasswordConfirm
            // 
            this.m_txtPasswordConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtPasswordConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPasswordConfirm.Location = new System.Drawing.Point(120, 123);
            this.m_txtPasswordConfirm.LockEdition = false;
            this.m_txtPasswordConfirm.MaxLength = 32;
            this.m_txtPasswordConfirm.Name = "m_txtPasswordConfirm";
            this.m_txtPasswordConfirm.PasswordChar = '*';
            this.m_txtPasswordConfirm.Size = new System.Drawing.Size(132, 20);
            this.m_txtPasswordConfirm.TabIndex = 13;
            // 
            // m_lblPassword
            // 
            this.m_lblPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblPassword.Location = new System.Drawing.Point(2, 98);
            this.m_lblPassword.Name = "m_lblPassword";
            this.m_lblPassword.Size = new System.Drawing.Size(112, 16);
            this.m_lblPassword.TabIndex = 14;
            this.m_lblPassword.Text = "Password|775";
            this.m_lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_txtPassword
            // 
            this.m_txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtPassword.Location = new System.Drawing.Point(120, 98);
            this.m_txtPassword.LockEdition = false;
            this.m_txtPassword.MaxLength = 32;
            this.m_txtPassword.Name = "m_txtPassword";
            this.m_txtPassword.PasswordChar = '*';
            this.m_txtPassword.Size = new System.Drawing.Size(132, 20);
            this.m_txtPassword.TabIndex = 12;
            // 
            // m_txtOldPassword
            // 
            this.m_txtOldPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtOldPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_txtOldPassword.Location = new System.Drawing.Point(120, 73);
            this.m_txtOldPassword.LockEdition = false;
            this.m_txtOldPassword.MaxLength = 32;
            this.m_txtOldPassword.Name = "m_txtOldPassword";
            this.m_txtOldPassword.PasswordChar = '*';
            this.m_txtOldPassword.Size = new System.Drawing.Size(132, 20);
            this.m_txtOldPassword.TabIndex = 12;
            // 
            // m_lblOldPassword
            // 
            this.m_lblOldPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblOldPassword.Location = new System.Drawing.Point(-1, 76);
            this.m_lblOldPassword.Name = "m_lblOldPassword";
            this.m_lblOldPassword.Size = new System.Drawing.Size(115, 17);
            this.m_lblOldPassword.TabIndex = 14;
            this.m_lblOldPassword.Text = "Old Password|30016";
            this.m_lblOldPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnCancel.Location = new System.Drawing.Point(184, 162);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.ResultatAssocie = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnCancel.Size = new System.Drawing.Size(107, 25);
            this.m_btnCancel.TabIndex = 16;
            this.m_btnCancel.TexteAffiche = "Cancel|11";
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnOk.Location = new System.Drawing.Point(12, 162);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.ResultatAssocie = System.Windows.Forms.DialogResult.OK;
            this.m_btnOk.Size = new System.Drawing.Size(107, 25);
            this.m_btnOk.TabIndex = 16;
            this.m_btnOk.TexteAffiche = "OK|10";
            this.m_btnOk.ClicBouton += new sc2i.win32.common.ClicBoutonDialogResult(this.m_btnOk_ClicBouton);
            // 
            // CFormDefinirMDP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(303, 196);
            this.ControlBox = false;
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_lblPasswordConfirm);
            this.Controls.Add(this.m_txtPasswordConfirm);
            this.Controls.Add(this.m_lblOldPassword);
            this.Controls.Add(this.m_lblPassword);
            this.Controls.Add(this.m_txtOldPassword);
            this.Controls.Add(this.m_txtPassword);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CFormDefinirMDP";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private sc2i.win32.common.CEffetFonduPourForm m_effetFondu;
		private System.Windows.Forms.PictureBox pictureBox1;
		private sc2i.win32.common.CDialogResultBouton m_btnOk;
		private sc2i.win32.common.CDialogResultBouton m_btnCancel;
		private System.Windows.Forms.Label m_lblPasswordConfirm;
		private sc2i.win32.common.C2iTextBox m_txtPasswordConfirm;
		private System.Windows.Forms.Label m_lblOldPassword;
		private System.Windows.Forms.Label m_lblPassword;
		private sc2i.win32.common.C2iTextBox m_txtOldPassword;
		private sc2i.win32.common.C2iTextBox m_txtPassword;
	}
}