namespace timos.Equipement
{
	partial class CPanelEquipementLogiqueDeUnEquipement
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
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_panelDonnees = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkUnlink = new System.Windows.Forms.LinkLabel();
            this.m_lnkDetailLogique = new System.Windows.Forms.LinkLabel();
            this.m_panelFormulaire = new sc2i.win32.data.dynamic.CPanelChampsCustom();
            this.label3 = new System.Windows.Forms.Label();
            this.m_selectTypeEquipement = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelTop = new sc2i.win32.common.C2iPanel(this.components);
            this.m_lnkCreateNewLogique = new System.Windows.Forms.LinkLabel();
            this.m_lnkLinkToLogique = new System.Windows.Forms.LinkLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_extLinkField = new sc2i.win32.common.CExtLinkField();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_panelDonnees.SuspendLayout();
            this.m_panelTop.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // c2iTextBox1
            // 
            this.m_extLinkField.SetLinkField(this.c2iTextBox1, "Libelle");
            this.c2iTextBox1.Location = new System.Drawing.Point(158, 6);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(250, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 0;
            this.c2iTextBox1.Text = "[Libelle]";
            // 
            // label1
            // 
            this.m_extLinkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 23);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 1;
            this.label1.Text = "Logical equipment label|20069";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Beige;
            this.m_extLinkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(228, 30);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 5;
            this.label2.Text = "Logical Equipment|20068";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // m_panelDonnees
            // 
            this.m_panelDonnees.Controls.Add(this.c2iTextBox1);
            this.m_panelDonnees.Controls.Add(this.m_selectTypeEquipement);
            this.m_panelDonnees.Controls.Add(this.m_lnkUnlink);
            this.m_panelDonnees.Controls.Add(this.m_lnkDetailLogique);
            this.m_panelDonnees.Controls.Add(this.m_panelFormulaire);
            this.m_panelDonnees.Controls.Add(this.label3);
            this.m_panelDonnees.Controls.Add(this.label1);
            this.m_panelDonnees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_extLinkField.SetLinkField(this.m_panelDonnees, "");
            this.m_panelDonnees.Location = new System.Drawing.Point(0, 30);
            this.m_panelDonnees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelDonnees, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelDonnees.Name = "m_panelDonnees";
            this.m_panelDonnees.Size = new System.Drawing.Size(648, 248);
            this.m_extStyle.SetStyleBackColor(this.m_panelDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelDonnees, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelDonnees.TabIndex = 6;
            // 
            // m_lnkUnlink
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkUnlink, "");
            this.m_lnkUnlink.Location = new System.Drawing.Point(426, 33);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkUnlink, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkUnlink.Name = "m_lnkUnlink";
            this.m_lnkUnlink.Size = new System.Drawing.Size(180, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkUnlink, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkUnlink, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkUnlink.TabIndex = 4019;
            this.m_lnkUnlink.TabStop = true;
            this.m_lnkUnlink.Text = "Unlink Logical Equipment|20079";
            this.m_lnkUnlink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkUnlink_LinkClicked);
            // 
            // m_lnkDetailLogique
            // 
            this.m_extLinkField.SetLinkField(this.m_lnkDetailLogique, "");
            this.m_lnkDetailLogique.Location = new System.Drawing.Point(426, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkDetailLogique, sc2i.win32.common.TypeModeEdition.DisableSurEdition);
            this.m_lnkDetailLogique.Name = "m_lnkDetailLogique";
            this.m_lnkDetailLogique.Size = new System.Drawing.Size(180, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkDetailLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkDetailLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkDetailLogique.TabIndex = 4018;
            this.m_lnkDetailLogique.TabStop = true;
            this.m_lnkDetailLogique.Text = "Logical equipment details|20072";
            this.m_lnkDetailLogique.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkDetailLogique_LinkClicked);
            // 
            // m_panelFormulaire
            // 
            this.m_panelFormulaire.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelFormulaire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelFormulaire.BoldSelectedPage = true;
            this.m_panelFormulaire.ElementEdite = null;
            this.m_panelFormulaire.IDEPixelArea = false;
            this.m_extLinkField.SetLinkField(this.m_panelFormulaire, "");
            this.m_panelFormulaire.Location = new System.Drawing.Point(1, 56);
            this.m_panelFormulaire.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelFormulaire, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_panelFormulaire.Name = "m_panelFormulaire";
            this.m_panelFormulaire.Ombre = false;
            this.m_panelFormulaire.PositionTop = true;
            this.m_panelFormulaire.Size = new System.Drawing.Size(647, 192);
            this.m_extStyle.SetStyleBackColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelFormulaire, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelFormulaire.TabIndex = 4017;
            // 
            // label3
            // 
            this.m_extLinkField.SetLinkField(this.label3, "");
            this.label3.Location = new System.Drawing.Point(3, 31);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label3, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(158, 17);
            this.m_extStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 4015;
            this.label3.Text = "Logical equipment type|20057";
            // 
            // m_selectTypeEquipement
            // 
            this.m_selectTypeEquipement.ElementSelectionne = null;
            this.m_selectTypeEquipement.FonctionTextNull = null;
            this.m_selectTypeEquipement.HasLink = true;
            this.m_extLinkField.SetLinkField(this.m_selectTypeEquipement, "");
            this.m_selectTypeEquipement.Location = new System.Drawing.Point(158, 29);
            this.m_selectTypeEquipement.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_selectTypeEquipement, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_selectTypeEquipement.Name = "m_selectTypeEquipement";
            this.m_selectTypeEquipement.SelectedObject = null;
            this.m_selectTypeEquipement.Size = new System.Drawing.Size(250, 21);
            this.m_extStyle.SetStyleBackColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_selectTypeEquipement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectTypeEquipement.TabIndex = 4016;
            this.m_selectTypeEquipement.TextNull = "";
            // 
            // m_panelTop
            // 
            this.m_panelTop.Controls.Add(this.m_lnkCreateNewLogique);
            this.m_panelTop.Controls.Add(this.m_lnkLinkToLogique);
            this.m_panelTop.Controls.Add(this.panel1);
            this.m_panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_extLinkField.SetLinkField(this.m_panelTop, "");
            this.m_panelTop.Location = new System.Drawing.Point(0, 0);
            this.m_panelTop.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelTop, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelTop.Name = "m_panelTop";
            this.m_panelTop.Size = new System.Drawing.Size(648, 30);
            this.m_extStyle.SetStyleBackColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelTop, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTop.TabIndex = 10;
            // 
            // m_lnkCreateNewLogique
            // 
            this.m_lnkCreateNewLogique.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkCreateNewLogique.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_extLinkField.SetLinkField(this.m_lnkCreateNewLogique, "");
            this.m_lnkCreateNewLogique.Location = new System.Drawing.Point(471, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkCreateNewLogique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkCreateNewLogique.Name = "m_lnkCreateNewLogique";
            this.m_lnkCreateNewLogique.Size = new System.Drawing.Size(174, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkCreateNewLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkCreateNewLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkCreateNewLogique.TabIndex = 7;
            this.m_lnkCreateNewLogique.TabStop = true;
            this.m_lnkCreateNewLogique.Text = "Create Logical equipment|20071";
            this.m_lnkCreateNewLogique.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkCreateNewLogique_LinkClicked);
            // 
            // m_lnkLinkToLogique
            // 
            this.m_lnkLinkToLogique.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.m_lnkLinkToLogique.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.m_extLinkField.SetLinkField(this.m_lnkLinkToLogique, "");
            this.m_lnkLinkToLogique.Location = new System.Drawing.Point(234, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lnkLinkToLogique, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_lnkLinkToLogique.Name = "m_lnkLinkToLogique";
            this.m_lnkLinkToLogique.Size = new System.Drawing.Size(231, 13);
            this.m_extStyle.SetStyleBackColor(this.m_lnkLinkToLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_lnkLinkToLogique, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lnkLinkToLogique.TabIndex = 6;
            this.m_lnkLinkToLogique.TabStop = true;
            this.m_lnkLinkToLogique.Text = "Link to existing logical equipment|20070";
            this.m_lnkLinkToLogique.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.m_lnkLinkToLogique_LinkClicked);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.m_extLinkField.SetLinkField(this.panel1, "");
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.panel1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(228, 30);
            this.m_extStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 8;
            // 
            // CPanelEquipementLogiqueDeUnEquipement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelDonnees);
            this.Controls.Add(this.m_panelTop);
            this.ForeColor = System.Drawing.Color.Black;
            this.m_extLinkField.SetLinkField(this, "");
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CPanelEquipementLogiqueDeUnEquipement";
            this.Size = new System.Drawing.Size(648, 278);
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Load += new System.EventHandler(this.CPanelEquipementLogiqueDeUnEquipement_Load);
            this.m_panelDonnees.ResumeLayout(false);
            this.m_panelDonnees.PerformLayout();
            this.m_panelTop.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}


		#endregion

		private sc2i.win32.common.CExtStyle m_extStyle;
		private sc2i.win32.common.CExtLinkField m_extLinkField;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.C2iPanel m_panelDonnees;
		private System.Windows.Forms.Label label3;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectTypeEquipement;
		private sc2i.win32.data.dynamic.CPanelChampsCustom m_panelFormulaire;
		private sc2i.win32.common.C2iPanel m_panelTop;
		private System.Windows.Forms.LinkLabel m_lnkLinkToLogique;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.LinkLabel m_lnkCreateNewLogique;
		private System.Windows.Forms.LinkLabel m_lnkDetailLogique;
		private System.Windows.Forms.LinkLabel m_lnkUnlink;
	}
}
