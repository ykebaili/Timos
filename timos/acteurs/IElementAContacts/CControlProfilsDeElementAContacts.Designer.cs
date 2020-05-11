namespace timos.acteurs
{
	partial class CControlProfilsDeElementAContacts
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
            this.components = new System.ComponentModel.Container();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panIntervenants = new System.Windows.Forms.Panel();
            this.m_panTypeProfil = new System.Windows.Forms.Panel();
            this.m_chkAfficherInnActif = new System.Windows.Forms.CheckBox();
            this.m_lnkProfilIntervenant = new sc2i.win32.common.C2iLink(this.components);
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panTypeProfil.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panIntervenants
            // 
            this.m_panIntervenants.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panIntervenants.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panIntervenants.ForeColor = System.Drawing.Color.Black;
            this.m_panIntervenants.Location = new System.Drawing.Point(0, 24);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panIntervenants, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panIntervenants.Name = "m_panIntervenants";
            this.m_panIntervenants.Size = new System.Drawing.Size(559, 202);
            this.m_extStyle.SetStyleBackColor(this.m_panIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panIntervenants, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panIntervenants.TabIndex = 0;
            // 
            // m_panTypeProfil
            // 
            this.m_panTypeProfil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panTypeProfil.Controls.Add(this.m_chkAfficherInnActif);
            this.m_panTypeProfil.Controls.Add(this.m_lnkProfilIntervenant);
            this.m_panTypeProfil.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panTypeProfil.ForeColor = System.Drawing.Color.Black;
            this.m_panTypeProfil.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panTypeProfil, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panTypeProfil.Name = "m_panTypeProfil";
            this.m_panTypeProfil.Size = new System.Drawing.Size(559, 24);
            this.m_extStyle.SetStyleBackColor(this.m_panTypeProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panTypeProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panTypeProfil.TabIndex = 1;
            // 
            // m_chkAfficherInnActif
            // 
            this.m_chkAfficherInnActif.AutoSize = true;
            this.m_chkAfficherInnActif.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_chkAfficherInnActif.Location = new System.Drawing.Point(384, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkAfficherInnActif, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_chkAfficherInnActif.Name = "m_chkAfficherInnActif";
            this.m_chkAfficherInnActif.Size = new System.Drawing.Size(175, 24);
            this.m_extStyle.SetStyleBackColor(this.m_chkAfficherInnActif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_chkAfficherInnActif, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkAfficherInnActif.TabIndex = 2;
            this.m_chkAfficherInnActif.Text = "Show unavailable Contacts|785";
            this.m_chkAfficherInnActif.UseVisualStyleBackColor = true;
            this.m_chkAfficherInnActif.CheckedChanged += new System.EventHandler(this.m_chkAfficherInnActif_CheckedChanged);
            // 
            // m_lnkProfilIntervenant
            // 
            this.m_lnkProfilIntervenant.AutoSize = true;
            this.m_lnkProfilIntervenant.ClickEnabled = false;
            this.m_lnkProfilIntervenant.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkProfilIntervenant.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkProfilIntervenant.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkProfilIntervenant.Cursor = System.Windows.Forms.Cursors.Default;
            this.m_lnkProfilIntervenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.m_lnkProfilIntervenant.ForeColor = System.Drawing.SystemColors.ControlText;
            this.m_lnkProfilIntervenant.Location = new System.Drawing.Point(3, 5);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkProfilIntervenant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkProfilIntervenant.Name = "m_lnkProfilIntervenant";
            this.m_lnkProfilIntervenant.Size = new System.Drawing.Size(95, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkProfilIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkProfilIntervenant.TabIndex = 1;
            this.m_lnkProfilIntervenant.Text = "Contact profile|784";
            this.m_lnkProfilIntervenant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.m_lnkProfilIntervenant.LinkClicked += new System.EventHandler(this.m_lnkProfilIntervenant_LinkClicked);
            // 
            // CControlProfilsDeElementAContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panIntervenants);
            this.Controls.Add(this.m_panTypeProfil);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlProfilsDeElementAContacts";
            this.Size = new System.Drawing.Size(559, 226);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Load += new System.EventHandler(this.CControlProfilsDeElementAContacts_Load);
            this.m_panTypeProfil.ResumeLayout(false);
            this.m_panTypeProfil.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Panel m_panIntervenants;
		private System.Windows.Forms.Panel m_panTypeProfil;
		private sc2i.win32.common.C2iLink m_lnkProfilIntervenant;
		private System.Windows.Forms.CheckBox m_chkAfficherInnActif;
		private sc2i.win32.common.CExtStyle m_extStyle;
	}
}
