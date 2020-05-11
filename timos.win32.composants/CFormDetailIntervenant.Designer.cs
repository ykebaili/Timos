namespace timos.win32.composants
{
	partial class CFormDetailIntervenant
	{
		/// <summary>
		/// Variable nÃ©cessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisÃ©es.
		/// </summary>
		/// <param name="disposing">true si les ressources managÃ©es doivent Ãªtre supprimÃ©esÂ ; sinon, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code gÃ©nÃ©rÃ© par le Concepteur Windows Form

		/// <summary>
		/// MÃ©thode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette mÃ©thode avec l'Ã©diteur de code.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CFormDetailIntervenant));
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.c2iPanelOmbre1 = new sc2i.win32.common.C2iPanelOmbre();
            this.m_wndListeSousProfils = new sc2i.win32.common.ListViewAutoFilled();
            this.listViewAutoFilledColumn1 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.listViewAutoFilledColumn3 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.c2iTextBox1 = new sc2i.win32.common.C2iTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listViewAutoFilledColumn2 = new sc2i.win32.common.ListViewAutoFilledColumn();
            this.m_gestionnaireModeEdition = new sc2i.win32.common.CExtModeEdition();
            this.m_linkField = new sc2i.win32.common.CExtLinkField();
            this.c2iPanelOmbre1.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnAnnuler.ForeColor = System.Drawing.Color.White;
            this.m_btnAnnuler.Image = ((System.Drawing.Image)(resources.GetObject("m_btnAnnuler.Image")));
            this.m_linkField.SetLinkField(this.m_btnAnnuler, "");
            this.m_btnAnnuler.Location = new System.Drawing.Point(219, 225);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnAnnuler, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 7;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.m_btnOk.ForeColor = System.Drawing.Color.White;
            this.m_btnOk.Image = ((System.Drawing.Image)(resources.GetObject("m_btnOk.Image")));
            this.m_linkField.SetLinkField(this.m_btnOk, "");
            this.m_btnOk.Location = new System.Drawing.Point(163, 225);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_btnOk, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(40, 40);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 6;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // c2iPanelOmbre1
            // 
            this.c2iPanelOmbre1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.c2iPanelOmbre1.Controls.Add(this.m_wndListeSousProfils);
            this.c2iPanelOmbre1.Controls.Add(this.c2iTextBox1);
            this.c2iPanelOmbre1.Controls.Add(this.label1);
            this.c2iPanelOmbre1.Controls.Add(this.label2);
            this.c2iPanelOmbre1.ForeColor = System.Drawing.Color.Black;
            this.m_linkField.SetLinkField(this.c2iPanelOmbre1, "");
            this.c2iPanelOmbre1.Location = new System.Drawing.Point(2, 0);
            this.c2iPanelOmbre1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iPanelOmbre1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.c2iPanelOmbre1.Name = "c2iPanelOmbre1";
            this.c2iPanelOmbre1.Size = new System.Drawing.Size(419, 229);
            this.m_extStyle.SetStyleBackColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.c2iPanelOmbre1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.c2iPanelOmbre1.TabIndex = 8;
            // 
            // m_wndListeSousProfils
            // 
            this.m_wndListeSousProfils.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listViewAutoFilledColumn1,
            this.listViewAutoFilledColumn3});
            this.m_wndListeSousProfils.EnableCustomisation = true;
            this.m_wndListeSousProfils.FullRowSelect = true;
            this.m_linkField.SetLinkField(this.m_wndListeSousProfils, "");
            this.m_wndListeSousProfils.Location = new System.Drawing.Point(6, 50);
            this.m_gestionnaireModeEdition.SetModeEdition(this.m_wndListeSousProfils, sc2i.win32.common.TypeModeEdition.Autonome);
            this.m_wndListeSousProfils.Name = "m_wndListeSousProfils";
            this.m_wndListeSousProfils.Size = new System.Drawing.Size(388, 156);
            this.m_extStyle.SetStyleBackColor(this.m_wndListeSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_wndListeSousProfils, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_wndListeSousProfils.TabIndex = 5;
            this.m_wndListeSousProfils.UseCompatibleStateImageBehavior = false;
            this.m_wndListeSousProfils.View = System.Windows.Forms.View.Details;
            // 
            // listViewAutoFilledColumn1
            // 
            this.listViewAutoFilledColumn1.Field = "TypeInterventionSousInterventionAssocie.TypeSousIntervention.Libelle";
            this.listViewAutoFilledColumn1.PrecisionWidth = 0;
            this.listViewAutoFilledColumn1.ProportionnalSize = false;
            this.listViewAutoFilledColumn1.Text = "Intervention type|101";
            this.listViewAutoFilledColumn1.Visible = true;
            this.listViewAutoFilledColumn1.Width = 220;
            // 
            // listViewAutoFilledColumn3
            // 
            this.listViewAutoFilledColumn3.Field = "TypeIntervention_ProfilContenu.Libelle";
            this.listViewAutoFilledColumn3.PrecisionWidth = 0;
            this.listViewAutoFilledColumn3.ProportionnalSize = false;
            this.listViewAutoFilledColumn3.Text = "Member|110";
            this.listViewAutoFilledColumn3.Visible = true;
            this.listViewAutoFilledColumn3.Width = 140;
            // 
            // c2iTextBox1
            // 
            this.m_linkField.SetLinkField(this.c2iTextBox1, "Libelle");
            this.c2iTextBox1.Location = new System.Drawing.Point(101, 6);
            this.c2iTextBox1.LockEdition = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this.c2iTextBox1, sc2i.win32.common.TypeModeEdition.EnableSurEdition);
            this.c2iTextBox1.Name = "c2iTextBox1";
            this.c2iTextBox1.Size = new System.Drawing.Size(293, 20);
            this.m_extStyle.SetStyleBackColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.c2iTextBox1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.c2iTextBox1.TabIndex = 3;
            this.c2iTextBox1.Text = "[Libelle]";
            // 
            // label1
            // 
            this.m_linkField.SetLinkField(this.label1, "");
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label1, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 15);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 4;
            this.label1.Text = "Label|50";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.m_linkField.SetLinkField(this.label2, "");
            this.label2.Location = new System.Drawing.Point(3, 34);
            this.m_gestionnaireModeEdition.SetModeEdition(this.label2, sc2i.win32.common.TypeModeEdition.Autonome);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(267, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 6;
            this.label2.Text = "This operator is used as following a actor for sub tasks|111";
            // 
            // listViewAutoFilledColumn2
            // 
            this.listViewAutoFilledColumn2.DisplayIndex = 1;
            this.listViewAutoFilledColumn2.Field = "TypeInterventionSousInterventionAssocie.TypeSousIntervention.Libelle";
            this.listViewAutoFilledColumn2.PrecisionWidth = 0;
            this.listViewAutoFilledColumn2.ProportionnalSize = false;
            this.listViewAutoFilledColumn2.Text = "Actor|110";
            this.listViewAutoFilledColumn2.Visible = true;
            this.listViewAutoFilledColumn2.Width = 140;
            // 
            // CFormDetailIntervenant
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(422, 266);
            this.ControlBox = false;
            this.Controls.Add(this.c2iPanelOmbre1);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.m_linkField.SetLinkField(this, "");
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.m_gestionnaireModeEdition.SetModeEdition(this, sc2i.win32.common.TypeModeEdition.Autonome);
            this.Name = "CFormDetailIntervenant";
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondFenetre);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "Member properties|109";
            this.Load += new System.EventHandler(this.CFormDetailIntervenant_Load);
            this.c2iPanelOmbre1.ResumeLayout(false);
            this.c2iPanelOmbre1.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private sc2i.win32.common.CExtModeEdition m_gestionnaireModeEdition;
		private sc2i.win32.common.C2iPanelOmbre c2iPanelOmbre1;
		private sc2i.win32.common.ListViewAutoFilled m_wndListeSousProfils;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn1;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn2;
		private sc2i.win32.common.C2iTextBox c2iTextBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.common.CExtLinkField m_linkField;
		private sc2i.win32.common.ListViewAutoFilledColumn listViewAutoFilledColumn3;
	}
}
