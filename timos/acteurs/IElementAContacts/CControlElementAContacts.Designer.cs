namespace timos.acteurs
{
	partial class CControlElementAContacts
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

		#region Code généré par le Concepteur de composants

		/// <summary> 
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent()
		{
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panControles = new System.Windows.Forms.Panel();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_panTitre = new System.Windows.Forms.Panel();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panTitre.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panControles
            // 
            this.m_panControles.AutoScroll = true;
            this.m_panControles.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panControles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panControles.ForeColor = System.Drawing.Color.Black;
            this.m_panControles.Location = new System.Drawing.Point(0, 30);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panControles, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panControles.Name = "m_panControles";
            this.m_panControles.Size = new System.Drawing.Size(644, 258);
            this.m_extStyle.SetStyleBackColor(this.m_panControles, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panControles, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panControles.TabIndex = 0;
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.AutoSize = true;
            this.m_lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblTitre.Location = new System.Drawing.Point(3, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblTitre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(145, 20);
            this.m_extStyle.SetStyleBackColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTitre.TabIndex = 1;
            this.m_lblTitre.Text = "Contacts list|783";
            // 
            // m_panTitre
            // 
            this.m_panTitre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTitre.Controls.Add(this.m_lblTitre);
            this.m_panTitre.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panTitre.ForeColor = System.Drawing.Color.Black;
            this.m_panTitre.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTitre, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panTitre.Name = "m_panTitre";
            this.m_panTitre.Size = new System.Drawing.Size(644, 30);
            this.m_extStyle.SetStyleBackColor(this.m_panTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panTitre.TabIndex = 2;
            // 
            // CControlElementAContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panControles);
            this.Controls.Add(this.m_panTitre);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlElementAContacts";
            this.Size = new System.Drawing.Size(644, 288);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CControlElementAContacts_Load);
            this.m_panTitre.ResumeLayout(false);
            this.m_panTitre.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Panel m_panControles;
		private System.Windows.Forms.Label m_lblTitre;
		private System.Windows.Forms.Panel m_panTitre;
		private sc2i.win32.common.CExtStyle m_extStyle;
	}
}
