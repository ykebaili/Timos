namespace timos.general
{
	partial class CFormOptionsGenerales
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormOptionsGenerales));
            this.m_effetFondu = new sc2i.win32.common.CEffetFonduPourForm();
            this.m_panImgOptions = new System.Windows.Forms.Panel();
            this.m_panClose = new System.Windows.Forms.Panel();
            this.m_chkFondu = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // m_effetFondu
            // 
            this.m_effetFondu.AuDessusDesAutresFenetres = true;
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
            // m_panImgOptions
            // 
            this.m_panImgOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panImgOptions.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("m_panImgOptions.BackgroundImage")));
            this.m_panImgOptions.Location = new System.Drawing.Point(235, 76);
            this.m_panImgOptions.Name = "m_panImgOptions";
            this.m_panImgOptions.Size = new System.Drawing.Size(258, 264);
            this.m_panImgOptions.TabIndex = 0;
            // 
            // m_panClose
            // 
            this.m_panClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panClose.BackColor = System.Drawing.Color.Black;
            this.m_panClose.Location = new System.Drawing.Point(445, -1);
            this.m_panClose.Name = "m_panClose";
            this.m_panClose.Size = new System.Drawing.Size(22, 22);
            this.m_panClose.TabIndex = 1;
            this.m_panClose.Click += new System.EventHandler(this.m_panClose_Click);
            // 
            // m_chkFondu
            // 
            this.m_chkFondu.AutoSize = true;
            this.m_chkFondu.Location = new System.Drawing.Point(13, 90);
            this.m_chkFondu.Name = "m_chkFondu";
            this.m_chkFondu.Size = new System.Drawing.Size(134, 17);
            this.m_chkFondu.TabIndex = 2;
            this.m_chkFondu.Text = "Windows fading|30176";
            this.m_chkFondu.UseVisualStyleBackColor = true;
            this.m_chkFondu.CheckedChanged += new System.EventHandler(this.m_chkFondu_CheckedChanged);
            // 
            // CFormOptionsGenerales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(466, 333);
            this.ControlBox = false;
            this.Controls.Add(this.m_chkFondu);
            this.Controls.Add(this.m_panClose);
            this.Controls.Add(this.m_panImgOptions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CFormOptionsGenerales";
            this.Opacity = 0;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private sc2i.win32.common.CEffetFonduPourForm m_effetFondu;
		private System.Windows.Forms.Panel m_panImgOptions;
		private System.Windows.Forms.Panel m_panClose;
		private System.Windows.Forms.CheckBox m_chkFondu;
	}
}