namespace timos
{
	partial class CPanelUtilisateur_Profil
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_lblNomProfil = new System.Windows.Forms.Label();
            this.m_panelEnteteProfil = new System.Windows.Forms.Panel();
            this.m_lnkRemoveProfile = new System.Windows.Forms.LinkLabel();
            this.m_lnkAddProfil = new System.Windows.Forms.LinkLabel();
            this.m_panelSelectEntite = new System.Windows.Forms.Panel();
            this.m_btnParDefaut = new System.Windows.Forms.Button();
            this.m_btnSelectEntite = new System.Windows.Forms.Button();
            this.m_lblEntite = new System.Windows.Forms.Label();
            this.m_lblLibelleSaisie = new System.Windows.Forms.Label();
            this.m_panelSousProfils = new sc2i.win32.common.C2iPanel(this.components);
            this.m_panelMarge = new System.Windows.Forms.Panel();
            this.m_extModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.m_panelEnteteProfil.SuspendLayout();
            this.m_panelSelectEntite.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_lblNomProfil
            // 
            this.m_lblNomProfil.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblNomProfil.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lblNomProfil.ForeColor = System.Drawing.Color.Beige;
            this.m_lblNomProfil.Location = new System.Drawing.Point(3, 0);
            this.m_extModeEdition.SetModeEdition(this.m_lblNomProfil, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblNomProfil.Name = "m_lblNomProfil";
            this.m_lblNomProfil.Size = new System.Drawing.Size(598, 22);
            this.m_extStyle.SetStyleBackColor(this.m_lblNomProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblNomProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.m_lblNomProfil.TabIndex = 0;
            this.m_lblNomProfil.Text = "Profile name|787";
            // 
            // m_panelEnteteProfil
            // 
            this.m_panelEnteteProfil.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelEnteteProfil.Controls.Add(this.m_lnkRemoveProfile);
            this.m_panelEnteteProfil.Controls.Add(this.m_lnkAddProfil);
            this.m_panelEnteteProfil.Controls.Add(this.m_lblNomProfil);
            this.m_panelEnteteProfil.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelEnteteProfil.Location = new System.Drawing.Point(0, 0);
            this.m_extModeEdition.SetModeEdition(this.m_panelEnteteProfil, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelEnteteProfil.Name = "m_panelEnteteProfil";
            this.m_panelEnteteProfil.Size = new System.Drawing.Size(608, 42);
            this.m_extStyle.SetStyleBackColor(this.m_panelEnteteProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelEnteteProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelEnteteProfil.TabIndex = 1;
            // 
            // m_lnkRemoveProfile
            // 
            this.m_lnkRemoveProfile.Location = new System.Drawing.Point(33, 24);
            this.m_extModeEdition.SetModeEdition(this.m_lnkRemoveProfile, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkRemoveProfile.Name = "m_lnkRemoveProfile";
            this.m_lnkRemoveProfile.Size = new System.Drawing.Size(140, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkRemoveProfile, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkRemoveProfile, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkRemoveProfile.TabIndex = 2;
            this.m_lnkRemoveProfile.TabStop = true;
            this.m_lnkRemoveProfile.Text = "Remove this profile|146";
            this.m_lnkRemoveProfile.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkRemoveProfile_LinkClicked);
            // 
            // m_lnkAddProfil
            // 
            this.m_lnkAddProfil.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lnkAddProfil.Location = new System.Drawing.Point(489, 24);
            this.m_extModeEdition.SetModeEdition(this.m_lnkAddProfil, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkAddProfil.Name = "m_lnkAddProfil";
            this.m_lnkAddProfil.Size = new System.Drawing.Size(113, 16);
            this.m_extStyle.SetStyleBackColor(this.m_lnkAddProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkAddProfil, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkAddProfil.TabIndex = 1;
            this.m_lnkAddProfil.TabStop = true;
            this.m_lnkAddProfil.Text = "Add child profile|145";
            this.m_lnkAddProfil.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkAddProfil_LinkClicked);
            // 
            // m_panelSelectEntite
            // 
            this.m_panelSelectEntite.Controls.Add(this.m_btnParDefaut);
            this.m_panelSelectEntite.Controls.Add(this.m_btnSelectEntite);
            this.m_panelSelectEntite.Controls.Add(this.m_lblEntite);
            this.m_panelSelectEntite.Controls.Add(this.m_lblLibelleSaisie);
            this.m_panelSelectEntite.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelSelectEntite.Location = new System.Drawing.Point(0, 42);
            this.m_extModeEdition.SetModeEdition(this.m_panelSelectEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelSelectEntite.Name = "m_panelSelectEntite";
            this.m_panelSelectEntite.Size = new System.Drawing.Size(608, 31);
            this.m_extStyle.SetStyleBackColor(this.m_panelSelectEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSelectEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSelectEntite.TabIndex = 2;
            // 
            // m_btnParDefaut
            // 
            this.m_btnParDefaut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnParDefaut.Location = new System.Drawing.Point(580, 3);
            this.m_extModeEdition.SetModeEdition(this.m_btnParDefaut, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnParDefaut.Name = "m_btnParDefaut";
            this.m_btnParDefaut.Size = new System.Drawing.Size(26, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnParDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnParDefaut, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnParDefaut.TabIndex = 3;
            this.m_btnParDefaut.Text = "X";
            this.m_btnParDefaut.UseVisualStyleBackColor = true;
            this.m_btnParDefaut.Click += new System.EventHandler(this.m_btnParDefaut_Click);
            // 
            // m_btnSelectEntite
            // 
            this.m_btnSelectEntite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.m_btnSelectEntite.Location = new System.Drawing.Point(554, 3);
            this.m_extModeEdition.SetModeEdition(this.m_btnSelectEntite, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_btnSelectEntite.Name = "m_btnSelectEntite";
            this.m_btnSelectEntite.Size = new System.Drawing.Size(25, 23);
            this.m_extStyle.SetStyleBackColor(this.m_btnSelectEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnSelectEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnSelectEntite.TabIndex = 2;
            this.m_btnSelectEntite.Text = "...";
            this.m_btnSelectEntite.UseVisualStyleBackColor = true;
            this.m_btnSelectEntite.Click += new System.EventHandler(this.m_btnSelectEntite_Click);
            // 
            // m_lblEntite
            // 
            this.m_lblEntite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblEntite.BackColor = System.Drawing.Color.White;
            this.m_lblEntite.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_lblEntite.Location = new System.Drawing.Point(155, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lblEntite, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblEntite.Name = "m_lblEntite";
            this.m_lblEntite.Size = new System.Drawing.Size(396, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblEntite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblEntite.TabIndex = 1;
            this.m_tooltip.SetToolTip(this.m_lblEntite, "###");
            // 
            // m_lblLibelleSaisie
            // 
            this.m_lblLibelleSaisie.Location = new System.Drawing.Point(4, 3);
            this.m_extModeEdition.SetModeEdition(this.m_lblLibelleSaisie, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblLibelleSaisie.Name = "m_lblLibelleSaisie";
            this.m_lblLibelleSaisie.Size = new System.Drawing.Size(146, 23);
            this.m_extStyle.SetStyleBackColor(this.m_lblLibelleSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lblLibelleSaisie, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblLibelleSaisie.TabIndex = 0;
            this.m_lblLibelleSaisie.Text = "label1";
            this.m_lblLibelleSaisie.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelSousProfils
            // 
            this.m_panelSousProfils.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelSousProfils.Location = new System.Drawing.Point(38, 73);
            this.m_panelSousProfils.LockEdition = false;
            this.m_extModeEdition.SetModeEdition(this.m_panelSousProfils, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelSousProfils.Name = "m_panelSousProfils";
            this.m_panelSousProfils.Size = new System.Drawing.Size(570, 101);
            this.m_extStyle.SetStyleBackColor(this.m_panelSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSousProfils.TabIndex = 3;
            this.m_panelSousProfils.ParentChanged += new System.EventHandler(this.m_panelSousProfils_ParentChanged);
            // 
            // m_panelMarge
            // 
            this.m_panelMarge.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_panelMarge.Location = new System.Drawing.Point(0, 73);
            this.m_extModeEdition.SetModeEdition(this.m_panelMarge, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelMarge.Name = "m_panelMarge";
            this.m_panelMarge.Size = new System.Drawing.Size(38, 101);
            this.m_extStyle.SetStyleBackColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelMarge, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelMarge.TabIndex = 4;
            // 
            // m_tooltip
            // 
            this.m_tooltip.Popup += new System.Windows.Forms.PopupEventHandler(this.m_tooltip_Popup);
            // 
            // CPanelUtilisateur_Profil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelSousProfils);
            this.Controls.Add(this.m_panelMarge);
            this.Controls.Add(this.m_panelSelectEntite);
            this.Controls.Add(this.m_panelEnteteProfil);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelUtilisateur_Profil";
            this.Size = new System.Drawing.Size(608, 174);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.BackColorChanged += new System.EventHandler(this.CPanelUtilisateur_Profil_BackColorChanged);
            this.m_panelEnteteProfil.ResumeLayout(false);
            this.m_panelSelectEntite.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.Label m_lblNomProfil;
		private System.Windows.Forms.Panel m_panelEnteteProfil;
		private sc2i.win32.common.CExtModeEdition m_extModeEdition;
		private System.Windows.Forms.Panel m_panelSelectEntite;
		private System.Windows.Forms.Button m_btnSelectEntite;
		private System.Windows.Forms.Label m_lblEntite;
		private System.Windows.Forms.Label m_lblLibelleSaisie;
		private sc2i.win32.common.C2iPanel m_panelSousProfils;
		private System.Windows.Forms.Button m_btnParDefaut;
		private System.Windows.Forms.LinkLabel m_lnkAddProfil;
		private System.Windows.Forms.LinkLabel m_lnkRemoveProfile;
		private System.Windows.Forms.Panel m_panelMarge;
		private System.Windows.Forms.ToolTip m_tooltip;
	}
}
