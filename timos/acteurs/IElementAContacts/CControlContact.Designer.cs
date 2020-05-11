namespace timos.acteurs
{
	partial class CControlContact
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
            this.m_lnkNomIntervenant = new sc2i.win32.common.C2iLink(this.components);
            this.m_panIntervenant = new System.Windows.Forms.Panel();
            this.m_panIdentiteComplete = new System.Windows.Forms.Panel();
            this.m_modele = new timos.win32.composants.CRichTextViewer();
            this.m_lblGabarit = new System.Windows.Forms.Label();
            this.m_lnkActeur = new System.Windows.Forms.LinkLabel();
            this.m_panOccupation = new System.Windows.Forms.Panel();
            this.m_lblEtat = new System.Windows.Forms.Label();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panIntervenant.SuspendLayout();
            this.m_panIdentiteComplete.SuspendLayout();
            this.m_panOccupation.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lnkNomIntervenant
            // 
            this.m_lnkNomIntervenant.AutoSize = true;
            this.m_lnkNomIntervenant.ClickEnabled = true;
            this.m_lnkNomIntervenant.ColorLabel = System.Drawing.SystemColors.ControlText;
            this.m_lnkNomIntervenant.ColorLinkDisabled = System.Drawing.Color.Blue;
            this.m_lnkNomIntervenant.ColorLinkEnabled = System.Drawing.Color.Blue;
            this.m_lnkNomIntervenant.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_lnkNomIntervenant.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline);
            this.m_lnkNomIntervenant.ForeColor = System.Drawing.Color.Blue;
            this.m_extLinkField.SetLinkField(this.m_lnkNomIntervenant, "IdentiteComplete");
            this.m_lnkNomIntervenant.Location = new System.Drawing.Point(3, 3);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkNomIntervenant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkNomIntervenant.Name = "m_lnkNomIntervenant";
            this.m_lnkNomIntervenant.Size = new System.Drawing.Size(92, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkNomIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkNomIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkNomIntervenant.TabIndex = 0;
            this.m_lnkNomIntervenant.Text = "[IdentiteComplete]";
            this.m_lnkNomIntervenant.LinkClicked += new System.EventHandler(this.m_lnkNomIntervenant_LinkClicked);
            // 
            // m_panIntervenant
            // 
            this.m_panIntervenant.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panIntervenant.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panIntervenant.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panIntervenant.Controls.Add(this.m_panIdentiteComplete);
            this.m_panIntervenant.Controls.Add(this.m_lnkActeur);
            this.m_panIntervenant.Controls.Add(this.m_panOccupation);
            this.m_panIntervenant.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this.m_panIntervenant, "");
            this.m_panIntervenant.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panIntervenant, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panIntervenant.Name = "m_panIntervenant";
            this.m_panIntervenant.Size = new System.Drawing.Size(600, 64);
            this.m_extStyle.SetStyleBackColor(this.m_panIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panIntervenant, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.m_panIntervenant.TabIndex = 2;
            // 
            // m_panIdentiteComplete
            // 
            this.m_panIdentiteComplete.BackColor = System.Drawing.Color.White;
            this.m_panIdentiteComplete.Controls.Add(this.m_lnkNomIntervenant);
            this.m_panIdentiteComplete.Controls.Add(this.m_modele);
            this.m_panIdentiteComplete.Controls.Add(this.m_lblGabarit);
            this.m_panIdentiteComplete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panIdentiteComplete, "");
            this.m_panIdentiteComplete.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panIdentiteComplete, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panIdentiteComplete.Name = "m_panIdentiteComplete";
            this.m_panIdentiteComplete.Size = new System.Drawing.Size(438, 62);
            this.m_extStyle.SetStyleBackColor(this.m_panIdentiteComplete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panIdentiteComplete, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panIdentiteComplete.TabIndex = 3;
            // 
            // m_modele
            // 
            this.m_modele.BackColor = System.Drawing.Color.White;
            this.m_modele.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_modele.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_modele, "");
            this.m_modele.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_modele, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_modele.Name = "m_modele";
            this.m_modele.Size = new System.Drawing.Size(438, 62);
            this.m_extStyle.SetStyleBackColor(this.m_modele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_modele, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_modele.TabIndex = 1;
            // 
            // m_lblGabarit
            // 
            this.m_lblGabarit.BackColor = System.Drawing.Color.Yellow;
            this.m_extLinkField.SetLinkField(this.m_lblGabarit, "");
            this.m_lblGabarit.Location = new System.Drawing.Point(147, 4);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblGabarit, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblGabarit.Name = "m_lblGabarit";
            this.m_lblGabarit.Size = new System.Drawing.Size(60, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblGabarit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblGabarit, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblGabarit.TabIndex = 2;
            this.m_lblGabarit.Text = "Gabarit";
            this.m_lblGabarit.Visible = false;
            // 
            // m_lnkActeur
            // 
            this.m_lnkActeur.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.m_lnkActeur, "");
            this.m_lnkActeur.Location = new System.Drawing.Point(438, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkActeur, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lnkActeur.Name = "m_lnkActeur";
            this.m_lnkActeur.Size = new System.Drawing.Size(21, 62);
            this.m_extStyle.SetStyleBackColor(this.m_lnkActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkActeur.TabIndex = 3;
            this.m_lnkActeur.TabStop = true;
            this.m_lnkActeur.Text = "...";
            this.m_lnkActeur.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.m_lnkActeur.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkActeur_LinkClicked);
            // 
            // m_panOccupation
            // 
            this.m_panOccupation.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.m_panOccupation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_panOccupation.Controls.Add(this.m_lblEtat);
            this.m_panOccupation.Dock = System.Windows.Forms.DockStyle.Right;
            this.m_extLinkField.SetLinkField(this.m_panOccupation, "");
            this.m_panOccupation.Location = new System.Drawing.Point(459, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panOccupation, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panOccupation.Name = "m_panOccupation";
            this.m_panOccupation.Size = new System.Drawing.Size(139, 62);
            this.m_extStyle.SetStyleBackColor(this.m_panOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panOccupation, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panOccupation.TabIndex = 2;
            // 
            // m_lblEtat
            // 
            this.m_lblEtat.AutoSize = true;
            this.m_lblEtat.BackColor = System.Drawing.Color.White;
            this.m_lblEtat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.m_lblEtat.Cursor = System.Windows.Forms.Cursors.Hand;
            this.m_extLinkField.SetLinkField(this.m_lblEtat, "");
            this.m_lblEtat.Location = new System.Drawing.Point(2, 2);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblEtat, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEtat.Name = "m_lblEtat";
            this.m_lblEtat.Size = new System.Drawing.Size(48, 15);
            this.m_extStyle.SetStyleBackColor(this.m_lblEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEtat, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEtat.TabIndex = 1;
            this.m_lblEtat.Text = "State|57";
            // 
            // CControlContact
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.m_panIntervenant);
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlContact";
            this.Size = new System.Drawing.Size(601, 63);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panIntervenant.ResumeLayout(false);
            this.m_panIdentiteComplete.ResumeLayout(false);
            this.m_panIdentiteComplete.PerformLayout();
            this.m_panOccupation.ResumeLayout(false);
            this.m_panOccupation.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iLink m_lnkNomIntervenant;
		private System.Windows.Forms.Panel m_panIntervenant;
		private System.Windows.Forms.Label m_lblEtat;
		private sc2i.win32.common.CExtLinkField m_extLinkField;
		private System.Windows.Forms.Panel m_panIdentiteComplete;
		private System.Windows.Forms.Panel m_panOccupation;
		private timos.win32.composants.CRichTextViewer m_modele;
		private System.Windows.Forms.Label m_lblGabarit;
		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.LinkLabel m_lnkActeur;
	}
}
