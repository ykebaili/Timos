namespace timos.interventions
{
	partial class CFormCreateVersionPourIntervention
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
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.m_txtLibelleVersion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.m_chkFiltrerSurProjet = new System.Windows.Forms.CheckBox();
            this.m_txtSelectVersionParente = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.cExtStyle1 = new sc2i.win32.common.CExtStyle();
            this.m_panelNewVersion = new System.Windows.Forms.Panel();
            this.m_panelOption = new System.Windows.Forms.Panel();
            this.m_panelExistingVersion = new System.Windows.Forms.Panel();
            this.m_txtSelectVersionExistante = new sc2i.win32.data.navigation.C2iTextBoxSelectionne();
            this.label4 = new System.Windows.Forms.Label();
            this.m_radioLierExistant = new System.Windows.Forms.RadioButton();
            this.m_radioLierNouveau = new System.Windows.Forms.RadioButton();
            this.m_panelNewVersion.SuspendLayout();
            this.m_panelOption.SuspendLayout();
            this.m_panelExistingVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_btnOk
            // 
            this.m_btnOk.Location = new System.Drawing.Point(12, 151);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(75, 23);
            this.cExtStyle1.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // m_btnCancel
            // 
            this.m_btnCancel.Location = new System.Drawing.Point(109, 151);
            this.m_btnCancel.Name = "m_btnCancel";
            this.m_btnCancel.Size = new System.Drawing.Size(75, 23);
            this.cExtStyle1.SetStyleBackColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_btnCancel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnCancel.TabIndex = 1;
            this.m_btnCancel.Text = "Cancel|11";
            this.m_btnCancel.UseVisualStyleBackColor = true;
            this.m_btnCancel.Click += new System.EventHandler(this.m_btnCancel_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(388, 37);
            this.cExtStyle1.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label1.TabIndex = 2;
            this.label1.Text = "All modifications for that intervention will be linked to a new data version. You" +
                " have to indicate is the version is dependent on antoher version|1352";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 18);
            this.cExtStyle1.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 3;
            this.label2.Text = "Version label|1353";
            // 
            // m_txtLibelleVersion
            // 
            this.m_txtLibelleVersion.Location = new System.Drawing.Point(106, 40);
            this.m_txtLibelleVersion.Name = "m_txtLibelleVersion";
            this.m_txtLibelleVersion.Size = new System.Drawing.Size(293, 20);
            this.cExtStyle1.SetStyleBackColor(this.m_txtLibelleVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtLibelleVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtLibelleVersion.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 18);
            this.cExtStyle1.SetStyleBackColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label3, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label3.TabIndex = 5;
            this.label3.Text = "Depends on|1354";
            // 
            // m_chkFiltrerSurProjet
            // 
            this.m_chkFiltrerSurProjet.Location = new System.Drawing.Point(106, 104);
            this.m_chkFiltrerSurProjet.Name = "m_chkFiltrerSurProjet";
            this.m_chkFiltrerSurProjet.Size = new System.Drawing.Size(285, 24);
            this.cExtStyle1.SetStyleBackColor(this.m_chkFiltrerSurProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_chkFiltrerSurProjet, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_chkFiltrerSurProjet.TabIndex = 6;
            this.m_chkFiltrerSurProjet.Text = "Filter on project interventions|20022";
            this.m_chkFiltrerSurProjet.UseVisualStyleBackColor = true;
            this.m_chkFiltrerSurProjet.CheckedChanged += new System.EventHandler(this.m_chkFiltrerSurProjet_CheckedChanged);
            // 
            // m_txtSelectVersionParente
            // 
            this.m_txtSelectVersionParente.ElementSelectionne = null;
            this.m_txtSelectVersionParente.FonctionTextNull = null;
            this.m_txtSelectVersionParente.HasLink = true;
            this.m_txtSelectVersionParente.Location = new System.Drawing.Point(106, 77);
            this.m_txtSelectVersionParente.LockEdition = false;
            this.m_txtSelectVersionParente.Name = "m_txtSelectVersionParente";
            this.m_txtSelectVersionParente.SelectedObject = null;
            this.m_txtSelectVersionParente.Size = new System.Drawing.Size(293, 21);
            this.cExtStyle1.SetStyleBackColor(this.m_txtSelectVersionParente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtSelectVersionParente, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectVersionParente.TabIndex = 7;
            this.m_txtSelectVersionParente.TextNull = "";
            // 
            // m_panelNewVersion
            // 
            this.m_panelNewVersion.Controls.Add(this.label1);
            this.m_panelNewVersion.Controls.Add(this.label2);
            this.m_panelNewVersion.Controls.Add(this.m_txtSelectVersionParente);
            this.m_panelNewVersion.Controls.Add(this.m_txtLibelleVersion);
            this.m_panelNewVersion.Controls.Add(this.m_chkFiltrerSurProjet);
            this.m_panelNewVersion.Controls.Add(this.label3);
            this.m_panelNewVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelNewVersion.Location = new System.Drawing.Point(0, 0);
            this.m_panelNewVersion.Name = "m_panelNewVersion";
            this.m_panelNewVersion.Size = new System.Drawing.Size(407, 132);
            this.cExtStyle1.SetStyleBackColor(this.m_panelNewVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelNewVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelNewVersion.TabIndex = 9;
            this.m_panelNewVersion.Visible = false;
            // 
            // m_panelOption
            // 
            this.m_panelOption.Controls.Add(this.m_panelExistingVersion);
            this.m_panelOption.Controls.Add(this.m_panelNewVersion);
            this.m_panelOption.Location = new System.Drawing.Point(212, 12);
            this.m_panelOption.Name = "m_panelOption";
            this.m_panelOption.Size = new System.Drawing.Size(407, 179);
            this.cExtStyle1.SetStyleBackColor(this.m_panelOption, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelOption, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelOption.TabIndex = 10;
            // 
            // m_panelExistingVersion
            // 
            this.m_panelExistingVersion.Controls.Add(this.m_txtSelectVersionExistante);
            this.m_panelExistingVersion.Controls.Add(this.label4);
            this.m_panelExistingVersion.Dock = System.Windows.Forms.DockStyle.Top;
            this.m_panelExistingVersion.Location = new System.Drawing.Point(0, 132);
            this.m_panelExistingVersion.Name = "m_panelExistingVersion";
            this.m_panelExistingVersion.Size = new System.Drawing.Size(407, 30);
            this.cExtStyle1.SetStyleBackColor(this.m_panelExistingVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_panelExistingVersion, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelExistingVersion.TabIndex = 10;
            this.m_panelExistingVersion.Visible = false;
            // 
            // m_txtSelectVersionExistante
            // 
            this.m_txtSelectVersionExistante.ElementSelectionne = null;
            this.m_txtSelectVersionExistante.FonctionTextNull = null;
            this.m_txtSelectVersionExistante.HasLink = true;
            this.m_txtSelectVersionExistante.Location = new System.Drawing.Point(110, 3);
            this.m_txtSelectVersionExistante.LockEdition = false;
            this.m_txtSelectVersionExistante.Name = "m_txtSelectVersionExistante";
            this.m_txtSelectVersionExistante.SelectedObject = null;
            this.m_txtSelectVersionExistante.Size = new System.Drawing.Size(293, 21);
            this.cExtStyle1.SetStyleBackColor(this.m_txtSelectVersionExistante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_txtSelectVersionExistante, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_txtSelectVersionExistante.TabIndex = 9;
            this.m_txtSelectVersionExistante.TextNull = "";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(4, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 22);
            this.cExtStyle1.SetStyleBackColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.label4, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label4.TabIndex = 8;
            this.label4.Text = "Link to Version|1361";
            // 
            // m_radioLierExistant
            // 
            this.m_radioLierExistant.Location = new System.Drawing.Point(12, 12);
            this.m_radioLierExistant.Name = "m_radioLierExistant";
            this.m_radioLierExistant.Size = new System.Drawing.Size(194, 16);
            this.cExtStyle1.SetStyleBackColor(this.m_radioLierExistant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_radioLierExistant, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioLierExistant.TabIndex = 11;
            this.m_radioLierExistant.TabStop = true;
            this.m_radioLierExistant.Text = "Link to existing version|1362";
            this.m_radioLierExistant.UseVisualStyleBackColor = true;
            this.m_radioLierExistant.CheckedChanged += new System.EventHandler(this.OnChangeRadioType);
            // 
            // m_radioLierNouveau
            // 
            this.m_radioLierNouveau.Location = new System.Drawing.Point(12, 34);
            this.m_radioLierNouveau.Name = "m_radioLierNouveau";
            this.m_radioLierNouveau.Size = new System.Drawing.Size(194, 16);
            this.cExtStyle1.SetStyleBackColor(this.m_radioLierNouveau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.cExtStyle1.SetStyleForeColor(this.m_radioLierNouveau, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_radioLierNouveau.TabIndex = 12;
            this.m_radioLierNouveau.TabStop = true;
            this.m_radioLierNouveau.Text = "Link to a new version|1363";
            this.m_radioLierNouveau.UseVisualStyleBackColor = true;
            // 
            // CFormCreateVersionPourIntervention
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(619, 187);
            this.ControlBox = false;
            this.Controls.Add(this.m_radioLierNouveau);
            this.Controls.Add(this.m_radioLierExistant);
            this.Controls.Add(this.m_panelOption);
            this.Controls.Add(this.m_btnCancel);
            this.Controls.Add(this.m_btnOk);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CFormCreateVersionPourIntervention";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.cExtStyle1.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.cExtStyle1.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "Planified modifications|1351";
            this.Load += new System.EventHandler(this.CFormCreateVersionPourIntervention_Load);
            this.m_panelNewVersion.ResumeLayout(false);
            this.m_panelNewVersion.PerformLayout();
            this.m_panelOption.ResumeLayout(false);
            this.m_panelExistingVersion.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.Button m_btnCancel;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox m_txtLibelleVersion;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox m_chkFiltrerSurProjet;
		private sc2i.win32.common.CExtStyle cExtStyle1;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectVersionParente;
		private System.Windows.Forms.Panel m_panelNewVersion;
		private System.Windows.Forms.Panel m_panelOption;
		private System.Windows.Forms.Panel m_panelExistingVersion;
		private sc2i.win32.data.navigation.C2iTextBoxSelectionne m_txtSelectVersionExistante;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RadioButton m_radioLierExistant;
		private System.Windows.Forms.RadioButton m_radioLierNouveau;
	}
}
