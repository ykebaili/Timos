namespace timos.acteurs
{
	partial class CFormFloatContacts
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
            this.m_txtErr = new System.Windows.Forms.TextBox();
            this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panConteneur = new System.Windows.Forms.Panel();
            this.m_ctrlContacts = new timos.acteurs.CControlElementAContacts();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panOmbre.SuspendLayout();
            this.m_panConteneur.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_txtErr
            // 
            this.m_txtErr.BackColor = System.Drawing.SystemColors.ControlLight;
            this.m_txtErr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_txtErr.Location = new System.Drawing.Point(0, 0);
            this.m_txtErr.Multiline = true;
            this.m_txtErr.Name = "m_txtErr";
            this.m_txtErr.Size = new System.Drawing.Size(275, 342);
            this.m_extStyle.SetStyleBackColor(this.m_txtErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_txtErr, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtErr.TabIndex = 1;
            this.m_txtErr.Visible = false;
            // 
            // m_panOmbre
            // 
            this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panOmbre.Controls.Add(this.m_panConteneur);
            this.m_panOmbre.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
            this.m_panOmbre.Location = new System.Drawing.Point(0, 0);
            this.m_panOmbre.LockEdition = false;
            this.m_panOmbre.Name = "m_panOmbre";
            this.m_panOmbre.Size = new System.Drawing.Size(293, 360);
            this.m_extStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panOmbre.TabIndex = 2;
            // 
            // m_panConteneur
            // 
            this.m_panConteneur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panConteneur.Controls.Add(this.m_ctrlContacts);
            this.m_panConteneur.Controls.Add(this.m_txtErr);
            this.m_panConteneur.Location = new System.Drawing.Point(0, 0);
            this.m_panConteneur.Name = "m_panConteneur";
            this.m_panConteneur.Size = new System.Drawing.Size(277, 344);
            this.m_extStyle.SetStyleBackColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panConteneur.TabIndex = 3;
            // 
            // m_ctrlContacts
            // 
            this.m_ctrlContacts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_ctrlContacts.Location = new System.Drawing.Point(0, 0);
            this.m_ctrlContacts.LockEdition = true;
            this.m_ctrlContacts.Name = "m_ctrlContacts";
            this.m_ctrlContacts.Size = new System.Drawing.Size(275, 342);
            this.m_extStyle.SetStyleBackColor(this.m_ctrlContacts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_ctrlContacts, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_ctrlContacts.TabIndex = 0;
            // 
            // CFormFloatContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(293, 360);
            this.ControlBox = false;
            this.Controls.Add(this.m_panOmbre);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormFloatContacts";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "";
            this.Load += new System.EventHandler(this.CFormFloatContactsPhase_Load);
            this.m_panOmbre.ResumeLayout(false);
            this.m_panOmbre.PerformLayout();
            this.m_panConteneur.ResumeLayout(false);
            this.m_panConteneur.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private CControlElementAContacts m_ctrlContacts;
		private System.Windows.Forms.TextBox m_txtErr;
		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private System.Windows.Forms.Panel m_panConteneur;
		private sc2i.win32.common.CExtStyle m_extStyle;
	}
}