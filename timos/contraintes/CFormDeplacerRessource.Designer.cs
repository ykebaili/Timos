namespace timos
{
	partial class CFormDeplacerRessource
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
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.m_radioSite = new System.Windows.Forms.RadioButton();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.m_txtInfo = new System.Windows.Forms.TextBox();
            this.m_selectUser = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_dtMouvement = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.m_selectActeur = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_radioActeur = new System.Windows.Forms.RadioButton();
            this.m_selectSite = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.m_panelSite = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.m_panelSite.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.m_exStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 0;
            this.label1.Text = "Move to|242";
            // 
            // m_radioSite
            // 
            this.m_radioSite.AutoSize = true;
            this.m_radioSite.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioSite.Location = new System.Drawing.Point(15, 113);
            this.m_radioSite.Name = "m_radioSite";
            this.m_radioSite.Size = new System.Drawing.Size(70, 17);
            this.m_exStyle.SetStyleBackColor(this.m_radioSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_radioSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioSite.TabIndex = 1;
            this.m_radioSite.TabStop = true;
            this.m_radioSite.Text = "A site|233";
            this.m_radioSite.UseVisualStyleBackColor = true;
            this.m_radioSite.CheckedChanged += new System.EventHandler(this.m_radioSite_CheckedChanged);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnOk.Location = new System.Drawing.Point(214, 197);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 6;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(328, 197);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
            this.m_exStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 7;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 13);
            this.m_exStyle.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 8;
            this.label3.Text = "Movement information|244";
            // 
            // m_txtInfo
            // 
            this.m_txtInfo.Location = new System.Drawing.Point(140, 6);
            this.m_txtInfo.Name = "m_txtInfo";
            this.m_txtInfo.Size = new System.Drawing.Size(479, 20);
            this.m_exStyle.SetStyleBackColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtInfo.TabIndex = 0;
            // 
            // m_selectUser
            // 
            this.m_selectUser.ElementSelectionne = null;
            this.m_selectUser.HasLink = true;
            this.m_selectUser.Location = new System.Drawing.Point(140, 32);
            this.m_selectUser.LockEdition = false;
            this.m_selectUser.Name = "m_selectUser";
            this.m_selectUser.SelectedObject = null;
            this.m_selectUser.Size = new System.Drawing.Size(476, 21);
            this.m_exStyle.SetStyleBackColor(this.m_selectUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectUser, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectUser.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.m_exStyle.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 11;
            this.label4.Text = "User|245";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.m_exStyle.SetStyleBackColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.label5, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label5.TabIndex = 12;
            this.label5.Text = "Date|246";
            // 
            // m_dtMouvement
            // 
            this.m_dtMouvement.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtMouvement.Location = new System.Drawing.Point(140, 58);
            this.m_dtMouvement.Name = "m_dtMouvement";
            this.m_dtMouvement.Size = new System.Drawing.Size(93, 20);
            this.m_exStyle.SetStyleBackColor(this.m_dtMouvement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_dtMouvement, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_dtMouvement.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.m_selectActeur);
            this.panel1.Location = new System.Drawing.Point(102, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(520, 32);
            this.m_exStyle.SetStyleBackColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.panel1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.panel1.TabIndex = 14;
            // 
            // m_selectActeur
            // 
            this.m_selectActeur.ElementSelectionne = null;
            this.m_selectActeur.HasLink = true;
            this.m_selectActeur.Location = new System.Drawing.Point(3, 3);
            this.m_selectActeur.LockEdition = false;
            this.m_selectActeur.Name = "m_selectActeur";
            this.m_selectActeur.SelectedObject = null;
            this.m_selectActeur.Size = new System.Drawing.Size(514, 21);
            this.m_exStyle.SetStyleBackColor(this.m_selectActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectActeur.TabIndex = 4;
            this.m_selectActeur.ElementSelectionneChanged += new System.EventHandler(this.m_selectActeur_ElementSelectionneChanged);
            // 
            // m_radioActeur
            // 
            this.m_radioActeur.AutoSize = true;
            this.m_radioActeur.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.m_radioActeur.Location = new System.Drawing.Point(15, 154);
            this.m_radioActeur.Name = "m_radioActeur";
            this.m_radioActeur.Size = new System.Drawing.Size(88, 17);
            this.m_exStyle.SetStyleBackColor(this.m_radioActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_radioActeur, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioActeur.TabIndex = 13;
            this.m_radioActeur.TabStop = true;
            this.m_radioActeur.Text = "A Member|317";
            this.m_radioActeur.UseVisualStyleBackColor = true;
            // 
            // m_selectSite
            // 
            this.m_selectSite.ElementSelectionne = null;
            this.m_selectSite.HasLink = true;
            this.m_selectSite.Location = new System.Drawing.Point(3, 3);
            this.m_selectSite.LockEdition = false;
            this.m_selectSite.Name = "m_selectSite";
            this.m_selectSite.SelectedObject = null;
            this.m_selectSite.Size = new System.Drawing.Size(514, 21);
            this.m_exStyle.SetStyleBackColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_selectSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_selectSite.TabIndex = 3;
            this.m_selectSite.ElementSelectionneChanged += new System.EventHandler(this.m_txtSelectSite_ElementSelectionneChanged);
            // 
            // m_panelSite
            // 
            this.m_panelSite.Controls.Add(this.m_selectSite);
            this.m_panelSite.Location = new System.Drawing.Point(102, 106);
            this.m_panelSite.Name = "m_panelSite";
            this.m_panelSite.Size = new System.Drawing.Size(520, 31);
            this.m_exStyle.SetStyleBackColor(this.m_panelSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelSite, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelSite.TabIndex = 4;
            // 
            // CFormDeplacerRessource
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(635, 232);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.m_radioActeur);
            this.Controls.Add(this.m_dtMouvement);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.m_selectUser);
            this.Controls.Add(this.m_txtInfo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.m_btnAnnuler);
            this.Controls.Add(this.m_btnOk);
            this.Controls.Add(this.m_panelSite);
            this.Controls.Add(this.m_radioSite);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormDeplacerRessource";
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Move Resource|241";
            this.Load += new System.EventHandler(this.CFormDeplacerRessource_Load);
            this.panel1.ResumeLayout(false);
            this.m_panelSite.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private sc2i.win32.common.CExtStyle m_exStyle;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton m_radioSite;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox m_txtInfo;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectUser;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.DateTimePicker m_dtMouvement;
		private System.Windows.Forms.Panel panel1;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectActeur;
		private System.Windows.Forms.RadioButton m_radioActeur;
        private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_selectSite;
        private System.Windows.Forms.Panel m_panelSite;
	}
}
