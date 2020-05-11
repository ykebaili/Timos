namespace timos
{
	partial class CControlEditionColonneTableParametrable
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
            this.m_panelParametrage = new System.Windows.Forms.Panel();
            this.m_chkNull = new System.Windows.Forms.CheckBox();
            this.m_cmbTypesDonnees = new sc2i.win32.common.C2iComboBox();
            this.m_txtNom = new System.Windows.Forms.TextBox();
            this.m_lblNom = new System.Windows.Forms.Label();
            this.lbl_typecol = new System.Windows.Forms.Label();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_lblPK = new System.Windows.Forms.Label();
            this.m_panelParametrage.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelParametrage
            // 
            this.m_panelParametrage.Controls.Add(this.m_lblPK);
            this.m_panelParametrage.Controls.Add(this.m_chkNull);
            this.m_panelParametrage.Controls.Add(this.m_cmbTypesDonnees);
            this.m_panelParametrage.Controls.Add(this.m_txtNom);
            this.m_panelParametrage.Controls.Add(this.m_lblNom);
            this.m_panelParametrage.Controls.Add(this.lbl_typecol);
            this.m_panelParametrage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelParametrage.Location = new System.Drawing.Point(0, 0);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_panelParametrage, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_panelParametrage.Name = "m_panelParametrage";
            this.m_panelParametrage.Size = new System.Drawing.Size(269, 107);
            this.m_panelParametrage.TabIndex = 3;
            // 
            // m_chkNull
            // 
            this.m_chkNull.Location = new System.Drawing.Point(8, 59);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_chkNull, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_chkNull.Name = "m_chkNull";
            this.m_chkNull.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.m_chkNull.Size = new System.Drawing.Size(245, 17);
            this.m_chkNull.TabIndex = 4017;
            this.m_chkNull.Text = "NULL not allowed|1198";
            this.m_chkNull.UseVisualStyleBackColor = true;
            this.m_chkNull.CheckedChanged += new System.EventHandler(this.m_chkNull_CheckedChanged);
            // 
            // m_cmbTypesDonnees
            // 
            this.m_cmbTypesDonnees.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypesDonnees.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypesDonnees.FormattingEnabled = true;
            this.m_cmbTypesDonnees.IsLink = false;
            this.m_cmbTypesDonnees.Location = new System.Drawing.Point(66, 32);
            this.m_cmbTypesDonnees.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_cmbTypesDonnees, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_cmbTypesDonnees.Name = "m_cmbTypesDonnees";
            this.m_cmbTypesDonnees.Size = new System.Drawing.Size(196, 21);
            this.m_cmbTypesDonnees.TabIndex = 4;
            this.m_cmbTypesDonnees.SelectionChangeCommitted += new System.EventHandler(this.m_cmbTypesDonnees_SelectionChangeCommitted);
            // 
            // m_txtNom
            // 
            this.m_txtNom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_txtNom.Location = new System.Drawing.Point(66, 6);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_txtNom, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.m_txtNom.Name = "m_txtNom";
            this.m_txtNom.Size = new System.Drawing.Size(196, 20);
            this.m_txtNom.TabIndex = 2;
            this.m_txtNom.Text = "[Label]|30324";
            this.m_txtNom.TextChanged += new System.EventHandler(this.m_txtNom_TextChanged);
            // 
            // m_lblNom
            // 
            this.m_lblNom.Location = new System.Drawing.Point(3, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblNom, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblNom.Name = "m_lblNom";
            this.m_lblNom.Size = new System.Drawing.Size(57, 17);
            this.m_lblNom.TabIndex = 0;
            this.m_lblNom.Text = "Label|50";
            // 
            // lbl_typecol
            // 
            this.lbl_typecol.Location = new System.Drawing.Point(3, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.lbl_typecol, sc2i.win32.common.TypeModeEdition.Autonome);
            this.lbl_typecol.Name = "lbl_typecol";
            this.lbl_typecol.Size = new System.Drawing.Size(57, 17);
            this.lbl_typecol.TabIndex = 0;
            this.lbl_typecol.Text = "Type|54";
            // 
            // m_lblPK
            // 
            this.m_lblPK.Location = new System.Drawing.Point(5, 60);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_lblPK, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_lblPK.Name = "m_lblPK";
            this.m_lblPK.Size = new System.Drawing.Size(228, 18);
            this.m_lblPK.TabIndex = 4018;
            this.m_lblPK.Text = "Is Primary key (cannot be null)|1348";
            // 
            // CControlEditionColonneTableParametrable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.m_panelParametrage);
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CControlEditionColonneTableParametrable";
            this.Size = new System.Drawing.Size(269, 107);
            this.m_panelParametrage.ResumeLayout(false);
            this.m_panelParametrage.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel m_panelParametrage;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private System.Windows.Forms.Label lbl_typecol;
		private System.Windows.Forms.Label m_lblNom;
		private System.Windows.Forms.TextBox m_txtNom;
		private sc2i.win32.common.C2iComboBox m_cmbTypesDonnees;
        private System.Windows.Forms.CheckBox m_chkNull;
        private System.Windows.Forms.Label m_lblPK;
	}
}
