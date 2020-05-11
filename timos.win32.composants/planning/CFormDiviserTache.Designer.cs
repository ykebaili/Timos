namespace timos.win32.composants
{
	partial class CFormDiviserIntervention
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
            this.m_extStyle = new sc2i.win32.common.CExtStyle();
            this.m_panelTotal = new System.Windows.Forms.Panel();
            this.m_datePicker = new sc2i.win32.common.C2iDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_panelBoutons = new System.Windows.Forms.Panel();
            this.m_btnAnnuler = new System.Windows.Forms.Button();
            this.m_btnOk = new System.Windows.Forms.Button();
            this.m_panelTotal.SuspendLayout();
            this.m_panelBoutons.SuspendLayout();
            this.SuspendLayout();
            // 
            // m_panelTotal
            // 
            this.m_panelTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
            this.m_panelTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.m_panelTotal.Controls.Add(this.m_datePicker);
            this.m_panelTotal.Controls.Add(this.label2);
            this.m_panelTotal.Controls.Add(this.label1);
            this.m_panelTotal.Controls.Add(this.m_panelBoutons);
            this.m_panelTotal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_panelTotal.ForeColor = System.Drawing.Color.Black;
            this.m_panelTotal.Location = new System.Drawing.Point(0, 0);
            this.m_panelTotal.Name = "m_panelTotal";
            this.m_panelTotal.Size = new System.Drawing.Size(292, 86);
            this.m_extStyle.SetStyleBackColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorFondPanel);
            this.m_extStyle.SetStyleForeColor(this.m_panelTotal, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTexteFenetre);
            this.m_panelTotal.TabIndex = 5;
            // 
            // m_datePicker
            // 
            this.m_datePicker.CustomFormat = "dd/MM/yyyy HH:mm";
            this.m_datePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.m_datePicker.Location = new System.Drawing.Point(134, 24);
            this.m_datePicker.LockEdition = false;
            this.m_datePicker.Name = "m_datePicker";
            this.m_datePicker.ShowUpDown = true;
            this.m_datePicker.Size = new System.Drawing.Size(116, 20);
            this.m_extStyle.SetStyleBackColor(this.m_datePicker, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_datePicker, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_datePicker.TabIndex = 8;
            this.m_datePicker.Value = new System.DateTime(2003, 4, 2, 9, 17, 49, 526);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.m_extStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.label2.TabIndex = 7;
            this.label2.Text = "First part end date|706";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 21);
            this.m_extStyle.SetStyleBackColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.label1, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
            this.label1.TabIndex = 6;
            this.label1.Text = "Split Intervention|705";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // m_panelBoutons
            // 
            this.m_panelBoutons.Controls.Add(this.m_btnAnnuler);
            this.m_panelBoutons.Controls.Add(this.m_btnOk);
            this.m_panelBoutons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.m_panelBoutons.Location = new System.Drawing.Point(0, 50);
            this.m_panelBoutons.Name = "m_panelBoutons";
            this.m_panelBoutons.Size = new System.Drawing.Size(288, 32);
            this.m_extStyle.SetStyleBackColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_panelBoutons.TabIndex = 5;
            // 
            // m_btnAnnuler
            // 
            this.m_btnAnnuler.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_btnAnnuler.Location = new System.Drawing.Point(152, 4);
            this.m_btnAnnuler.Name = "m_btnAnnuler";
            this.m_btnAnnuler.Size = new System.Drawing.Size(65, 25);
            this.m_extStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnAnnuler.TabIndex = 1;
            this.m_btnAnnuler.Text = "Cancel|11";
            this.m_btnAnnuler.UseVisualStyleBackColor = true;
            // 
            // m_btnOk
            // 
            this.m_btnOk.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.m_btnOk.Location = new System.Drawing.Point(70, 4);
            this.m_btnOk.Name = "m_btnOk";
            this.m_btnOk.Size = new System.Drawing.Size(67, 25);
            this.m_extStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_btnOk.TabIndex = 0;
            this.m_btnOk.Text = "Ok|10";
            this.m_btnOk.UseVisualStyleBackColor = true;
            this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
            // 
            // CFormDiviserIntervention
            // 
            this.AcceptButton = this.m_btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.m_btnAnnuler;
            this.ClientSize = new System.Drawing.Size(292, 86);
            this.Controls.Add(this.m_panelTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CFormDiviserIntervention";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.m_extStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.m_extStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
            this.Text = "CFormDiviserInterventionr";
            this.Load += new System.EventHandler(this.CFormDiviserIntervention_Load);
            this.m_panelTotal.ResumeLayout(false);
            this.m_panelTotal.PerformLayout();
            this.m_panelBoutons.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private sc2i.win32.common.CExtStyle m_extStyle;
		private System.Windows.Forms.Panel m_panelTotal;
		private System.Windows.Forms.Panel m_panelBoutons;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private sc2i.win32.common.C2iDateTimePicker m_datePicker;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}
