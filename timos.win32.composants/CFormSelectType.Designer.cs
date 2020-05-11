namespace timos.win32.composants
{
	partial class CFormSelectType
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
            this.m_cmbTypeElements = new sc2i.win32.common.C2iComboBox();
            this.m_lblTitre = new System.Windows.Forms.Label();
            this.m_exStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelTotal = new sc2i.win32.common.C2iPanelOmbre();
            this.m_panelBoutons = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_panelTotal.SuspendLayout();
            this.m_panelBoutons.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_cmbTypeElements
            // 
            this.m_cmbTypeElements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_cmbTypeElements.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.m_cmbTypeElements.IsLink = false;
            this.m_cmbTypeElements.Location = new System.Drawing.Point(3, 51);
            this.m_cmbTypeElements.LockEdition = false;
            this.m_cmbTypeElements.Name = "m_cmbTypeElements";
            this.m_cmbTypeElements.Size = new System.Drawing.Size(283, 21);
            this.m_exStyle.SetStyleBackColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_cmbTypeElements, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_cmbTypeElements.TabIndex = 4002;
            // 
            // m_lblTitre
            // 
            this.m_lblTitre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_lblTitre.Location = new System.Drawing.Point(3, 5);
            this.m_lblTitre.Name = "m_lblTitre";
            this.m_lblTitre.Size = new System.Drawing.Size(283, 43);
            this.m_exStyle.SetStyleBackColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_lblTitre.TabIndex = 4003;
            this.m_lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelTotal
            // 
            this.m_panelTotal.Controls.Add(this.m_panelBoutons);
            this.m_panelTotal.Controls.Add(this.m_cmbTypeElements);
            this.m_panelTotal.Controls.Add(this.m_lblTitre);
            this.m_panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTotal.Location = new System.Drawing.Point(0, 0);
            this.m_panelTotal.LockEdition = false;
            this.m_panelTotal.Name = "m_panelTotal";
            this.m_panelTotal.Size = new System.Drawing.Size(311, 123);
            this.m_exStyle.SetStyleBackColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelTotal.TabIndex = 4005;
            // 
            // m_panelBoutons
            // 
            this.m_panelBoutons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_panelBoutons.Controls.Add(this.m_btnAnnuler);
            this.m_panelBoutons.Controls.Add(this.m_btnOk);
            this.m_panelBoutons.Location = new System.Drawing.Point(0, 75);
            this.m_panelBoutons.Name = "m_panelBoutons";
            this.m_panelBoutons.Size = new System.Drawing.Size(295, 32);
            this.m_exStyle.SetStyleBackColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBoutons.TabIndex = 4005;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(155, 4);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(61, 25);
            this.m_exStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.Location = new System.Drawing.Point(79, 4);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(61, 25);
            this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // CFormSelectType
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(311, 123);
            this.Controls.Add(this.m_panelTotal);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormSelectType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTextePanel);
            this.Text = "CFormSelectType";
            this.m_panelTotal.ResumeLayout(false);
            this.m_panelTotal.PerformLayout();
            this.m_panelBoutons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.C2iComboBox m_cmbTypeElements;
		private System.Windows.Forms.Label m_lblTitre;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private sc2i.win32.common.C2iPanelOmbre m_panelTotal;
		private System.Windows.Forms.Panel m_panelBoutons;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;

	}
}