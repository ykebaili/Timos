namespace timos.preventives
{
	partial class CFormFloatSelectFormatDate
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
			this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
			this.m_panConteneur = new System.Windows.Forms.Panel();
			this.m_rbtAnnee = new System.Windows.Forms.RadioButton();
			this.m_rbtJour = new System.Windows.Forms.RadioButton();
			this.m_rbtMoisAnnee = new System.Windows.Forms.RadioButton();
			this.m_rbtMois = new System.Windows.Forms.RadioButton();
			this.m_rbtJourMois = new System.Windows.Forms.RadioButton();
			this.m_rbtJourMoisAnnee = new System.Windows.Forms.RadioButton();
			this.m_panDown = new System.Windows.Forms.Panel();
			this.m_btnCancel = new System.Windows.Forms.Button();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.m_extStyle = new sc2i.win32.common.CExtStyle();
			this.m_menuFiltres = new System.Windows.Forms.ContextMenu();
			this.m_rbtSemaine = new System.Windows.Forms.RadioButton();
			this.m_panOmbre.SuspendLayout();
			this.m_panConteneur.SuspendLayout();
			this.m_panDown.SuspendLayout();
			this.SuspendLayout();
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
			this.m_panOmbre.Size = new System.Drawing.Size(181, 209);
			this.m_extStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
			this.m_extStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
			this.m_panOmbre.TabIndex = 2;
			// 
			// m_panConteneur
			// 
			this.m_panConteneur.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panConteneur.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panConteneur.Controls.Add(this.m_rbtAnnee);
			this.m_panConteneur.Controls.Add(this.m_rbtJour);
			this.m_panConteneur.Controls.Add(this.m_rbtMoisAnnee);
			this.m_panConteneur.Controls.Add(this.m_rbtSemaine);
			this.m_panConteneur.Controls.Add(this.m_rbtMois);
			this.m_panConteneur.Controls.Add(this.m_rbtJourMois);
			this.m_panConteneur.Controls.Add(this.m_rbtJourMoisAnnee);
			this.m_panConteneur.Controls.Add(this.m_panDown);
			this.m_panConteneur.Location = new System.Drawing.Point(0, 0);
			this.m_panConteneur.Name = "m_panConteneur";
			this.m_panConteneur.Size = new System.Drawing.Size(165, 193);
			this.m_extStyle.SetStyleBackColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panConteneur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panConteneur.TabIndex = 3;
			// 
			// m_rbtAnnee
			// 
			this.m_rbtAnnee.AutoSize = true;
			this.m_rbtAnnee.Location = new System.Drawing.Point(11, 140);
			this.m_rbtAnnee.Name = "m_rbtAnnee";
			this.m_rbtAnnee.Size = new System.Drawing.Size(73, 17);
			this.m_extStyle.SetStyleBackColor(this.m_rbtAnnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_rbtAnnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_rbtAnnee.TabIndex = 15;
			this.m_rbtAnnee.Text = "Year|1319";
			this.m_rbtAnnee.UseVisualStyleBackColor = true;
			// 
			// m_rbtJour
			// 
			this.m_rbtJour.AutoSize = true;
			this.m_rbtJour.Location = new System.Drawing.Point(11, 118);
			this.m_rbtJour.Name = "m_rbtJour";
			this.m_rbtJour.Size = new System.Drawing.Size(70, 17);
			this.m_extStyle.SetStyleBackColor(this.m_rbtJour, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_rbtJour, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_rbtJour.TabIndex = 15;
			this.m_rbtJour.Text = "Day|1318";
			this.m_rbtJour.UseVisualStyleBackColor = true;
			// 
			// m_rbtMoisAnnee
			// 
			this.m_rbtMoisAnnee.AutoSize = true;
			this.m_rbtMoisAnnee.Location = new System.Drawing.Point(11, 49);
			this.m_rbtMoisAnnee.Name = "m_rbtMoisAnnee";
			this.m_rbtMoisAnnee.Size = new System.Drawing.Size(114, 17);
			this.m_extStyle.SetStyleBackColor(this.m_rbtMoisAnnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_rbtMoisAnnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_rbtMoisAnnee.TabIndex = 15;
			this.m_rbtMoisAnnee.Text = "Month / Year|1320";
			this.m_rbtMoisAnnee.UseVisualStyleBackColor = true;
			// 
			// m_rbtMois
			// 
			this.m_rbtMois.AutoSize = true;
			this.m_rbtMois.Location = new System.Drawing.Point(11, 95);
			this.m_rbtMois.Name = "m_rbtMois";
			this.m_rbtMois.Size = new System.Drawing.Size(81, 17);
			this.m_extStyle.SetStyleBackColor(this.m_rbtMois, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_rbtMois, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_rbtMois.TabIndex = 15;
			this.m_rbtMois.Text = "Month|1317";
			this.m_rbtMois.UseVisualStyleBackColor = true;
			// 
			// m_rbtJourMois
			// 
			this.m_rbtJourMois.AutoSize = true;
			this.m_rbtJourMois.Location = new System.Drawing.Point(11, 26);
			this.m_rbtJourMois.Name = "m_rbtJourMois";
			this.m_rbtJourMois.Size = new System.Drawing.Size(111, 17);
			this.m_extStyle.SetStyleBackColor(this.m_rbtJourMois, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_rbtJourMois, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_rbtJourMois.TabIndex = 15;
			this.m_rbtJourMois.Text = "Day / Month|1316";
			this.m_rbtJourMois.UseVisualStyleBackColor = true;
			// 
			// m_rbtJourMoisAnnee
			// 
			this.m_rbtJourMoisAnnee.AutoSize = true;
			this.m_rbtJourMoisAnnee.Checked = true;
			this.m_rbtJourMoisAnnee.Location = new System.Drawing.Point(11, 3);
			this.m_rbtJourMoisAnnee.Name = "m_rbtJourMoisAnnee";
			this.m_rbtJourMoisAnnee.Size = new System.Drawing.Size(144, 17);
			this.m_extStyle.SetStyleBackColor(this.m_rbtJourMoisAnnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_rbtJourMoisAnnee, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_rbtJourMoisAnnee.TabIndex = 15;
			this.m_rbtJourMoisAnnee.TabStop = true;
			this.m_rbtJourMoisAnnee.Text = "Day / Month / Year|1315";
			this.m_rbtJourMoisAnnee.UseVisualStyleBackColor = true;
			// 
			// m_panDown
			// 
			this.m_panDown.Controls.Add(this.m_btnCancel);
			this.m_panDown.Controls.Add(this.m_btnOk);
			this.m_panDown.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_panDown.Location = new System.Drawing.Point(0, 163);
			this.m_panDown.Name = "m_panDown";
			this.m_panDown.Size = new System.Drawing.Size(163, 28);
			this.m_extStyle.SetStyleBackColor(this.m_panDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_panDown, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panDown.TabIndex = 14;
			// 
			// m_btnCancel
			// 
			this.m_btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnCancel.Location = new System.Drawing.Point(85, 3);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
			this.m_extStyle.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnCancel.TabIndex = 1;
			this.m_btnCancel.Text = "Cancel|11";
			this.m_btnCancel.UseVisualStyleBackColor = true;
			this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
			// 
			// m_btnOk
			// 
			this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnOk.Location = new System.Drawing.Point(3, 3);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(75, 23);
			this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnOk.TabIndex = 1;
			this.m_btnOk.Text = "Ok|10";
			this.m_btnOk.UseVisualStyleBackColor = true;
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_rbtSemaine
			// 
			this.m_rbtSemaine.AutoSize = true;
			this.m_rbtSemaine.Location = new System.Drawing.Point(11, 72);
			this.m_rbtSemaine.Name = "m_rbtSemaine";
			this.m_rbtSemaine.Size = new System.Drawing.Size(80, 17);
			this.m_extStyle.SetStyleBackColor(this.m_rbtSemaine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this.m_rbtSemaine, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_rbtSemaine.TabIndex = 15;
			this.m_rbtSemaine.Text = "Week|1347";
			this.m_rbtSemaine.UseVisualStyleBackColor = true;
			// 
			// CFormFloatSelectFormatDate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackColor = System.Drawing.Color.White;
			this.CancelButton = this.m_btnCancel;
			this.ClientSize = new System.Drawing.Size(181, 209);
			this.ControlBox = false;
			this.Controls.Add(this.m_panOmbre);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CFormFloatSelectFormatDate";
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
			this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Text = "";
			this.m_panOmbre.ResumeLayout(false);
			this.m_panOmbre.PerformLayout();
			this.m_panConteneur.ResumeLayout(false);
			this.m_panConteneur.PerformLayout();
			this.m_panDown.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private System.Windows.Forms.Panel m_panConteneur;
		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Panel m_panDown;
		private System.Windows.Forms.ContextMenu m_menuFiltres;
		private System.Windows.Forms.RadioButton m_rbtAnnee;
		private System.Windows.Forms.RadioButton m_rbtJour;
		private System.Windows.Forms.RadioButton m_rbtMois;
		private System.Windows.Forms.RadioButton m_rbtJourMois;
		private System.Windows.Forms.RadioButton m_rbtJourMoisAnnee;
		private System.Windows.Forms.RadioButton m_rbtMoisAnnee;
		private System.Windows.Forms.RadioButton m_rbtSemaine;
	}
}