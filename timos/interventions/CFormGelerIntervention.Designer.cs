using sc2i.common;

namespace timos.interventions
{
	partial class CFormGelerIntervention
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
			this.m_lblTitre = new System.Windows.Forms.Label();
			this.m_panOmbre = new sc2i.win32.common.C2iPanelOmbre();
			this.m_panSurface = new System.Windows.Forms.Panel();
			this.m_panInfo = new System.Windows.Forms.Panel();
			this.m_txtInfo = new sc2i.win32.common.C2iTextBox();
			this.m_lblInfoFreez = new System.Windows.Forms.Label();
			this.m_panCause = new System.Windows.Forms.Panel();
			this.m_cmbCause = new sc2i.win32.data.CComboBoxListeObjetsDonnees();
			this.label2 = new System.Windows.Forms.Label();
			this.m_panelBoutons = new System.Windows.Forms.Panel();
			this.m_btnAnnuler = new System.Windows.Forms.Button();
			this.m_btnOk = new System.Windows.Forms.Button();
			this.m_panDate = new System.Windows.Forms.Panel();
			this.m_dtGel = new System.Windows.Forms.DateTimePicker();
			this.m_lblFreezeDate = new System.Windows.Forms.Label();
			this.m_exStyle = new sc2i.win32.common.CExtStyle();
			this.m_panOmbre.SuspendLayout();
			this.m_panSurface.SuspendLayout();
			this.m_panInfo.SuspendLayout();
			this.m_panCause.SuspendLayout();
			this.m_panelBoutons.SuspendLayout();
			this.m_panDate.SuspendLayout();
			this.SuspendLayout();
			// 
			// m_lblTitre
			// 
			this.m_lblTitre.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_lblTitre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.m_lblTitre.ForeColor = System.Drawing.Color.Beige;
			this.m_lblTitre.Location = new System.Drawing.Point(0, 0);
			this.m_lblTitre.Name = "m_lblTitre";
			this.m_lblTitre.Size = new System.Drawing.Size(291, 23);
			this.m_exStyle.SetStyleBackColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_lblTitre, sc2i.win32.common.CExtStyle.EnumCouleurs.ColorTitrePanel);
			this.m_lblTitre.TabIndex = 0;
			this.m_lblTitre.Text = "Freeze intervention|602";
			this.m_lblTitre.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// m_panOmbre
			// 
			this.m_panOmbre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(189)))), ((int)(((byte)(255)))));
			this.m_panOmbre.Controls.Add(this.m_panSurface);
			this.m_panOmbre.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panOmbre.ForeColor = System.Drawing.Color.Black;
			this.m_panOmbre.Location = new System.Drawing.Point(0, 0);
			this.m_panOmbre.LockEdition = false;
			this.m_panOmbre.Name = "m_panOmbre";
			this.m_panOmbre.Size = new System.Drawing.Size(309, 213);
			this.m_exStyle.SetStyleBackColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panOmbre, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panOmbre.TabIndex = 1;
			// 
			// m_panSurface
			// 
			this.m_panSurface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_panSurface.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_panSurface.Controls.Add(this.m_panInfo);
			this.m_panSurface.Controls.Add(this.m_panCause);
			this.m_panSurface.Controls.Add(this.m_panelBoutons);
			this.m_panSurface.Controls.Add(this.m_panDate);
			this.m_panSurface.Controls.Add(this.m_lblTitre);
			this.m_panSurface.Location = new System.Drawing.Point(0, 0);
			this.m_panSurface.Name = "m_panSurface";
			this.m_panSurface.Size = new System.Drawing.Size(293, 197);
			this.m_exStyle.SetStyleBackColor(this.m_panSurface, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panSurface, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panSurface.TabIndex = 12;
			// 
			// m_panInfo
			// 
			this.m_panInfo.Controls.Add(this.m_txtInfo);
			this.m_panInfo.Controls.Add(this.m_lblInfoFreez);
			this.m_panInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_panInfo.Location = new System.Drawing.Point(0, 81);
			this.m_panInfo.Name = "m_panInfo";
			this.m_panInfo.Size = new System.Drawing.Size(291, 82);
			this.m_exStyle.SetStyleBackColor(this.m_panInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panInfo.TabIndex = 11;
			// 
			// m_txtInfo
			// 
			this.m_txtInfo.AcceptsReturn = true;
			this.m_txtInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.m_txtInfo.Location = new System.Drawing.Point(3, 19);
			this.m_txtInfo.LockEdition = false;
			this.m_txtInfo.Multiline = true;
			this.m_txtInfo.Name = "m_txtInfo";
			this.m_txtInfo.Size = new System.Drawing.Size(280, 55);
			this.m_exStyle.SetStyleBackColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_txtInfo, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_txtInfo.TabIndex = 6;
			// 
			// m_lblInfoFreez
			// 
			this.m_lblInfoFreez.AutoSize = true;
			this.m_lblInfoFreez.Location = new System.Drawing.Point(3, 3);
			this.m_lblInfoFreez.Name = "m_lblInfoFreez";
			this.m_lblInfoFreez.Size = new System.Drawing.Size(121, 13);
			this.m_exStyle.SetStyleBackColor(this.m_lblInfoFreez, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_lblInfoFreez, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lblInfoFreez.TabIndex = 5;
			this.m_lblInfoFreez.Text = "Freezing information|605";
			// 
			// m_panCause
			// 
			this.m_panCause.Controls.Add(this.m_cmbCause);
			this.m_panCause.Controls.Add(this.label2);
			this.m_panCause.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panCause.Location = new System.Drawing.Point(0, 52);
			this.m_panCause.Name = "m_panCause";
			this.m_panCause.Size = new System.Drawing.Size(291, 29);
			this.m_exStyle.SetStyleBackColor(this.m_panCause, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panCause, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panCause.TabIndex = 10;
			// 
			// m_cmbCause
			// 
			this.m_cmbCause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cmbCause.ElementSelectionne = null;
			this.m_cmbCause.FormattingEnabled = true;
			this.m_cmbCause.IsLink = false;
			this.m_cmbCause.ListDonnees = null;
			this.m_cmbCause.Location = new System.Drawing.Point(103, 3);
			this.m_cmbCause.LockEdition = false;
			this.m_cmbCause.Name = "m_cmbCause";
			this.m_cmbCause.NullAutorise = false;
			this.m_cmbCause.ProprieteAffichee = null;
			this.m_cmbCause.ProprieteParentListeObjets = null;
			this.m_cmbCause.SelectionneurParent = null;
			this.m_cmbCause.Size = new System.Drawing.Size(182, 21);
			this.m_exStyle.SetStyleBackColor(this.m_cmbCause, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_cmbCause, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_cmbCause.TabIndex = 4;
            this.m_cmbCause.TextNull = I.T("(empty)|30195");
			this.m_cmbCause.Tri = true;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(3, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(109, 18);
			this.m_exStyle.SetStyleBackColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.label2, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.label2.TabIndex = 3;
			this.label2.Text = "Freezing cause|604";
			// 
			// m_panelBoutons
			// 
			this.m_panelBoutons.Controls.Add(this.m_btnAnnuler);
			this.m_panelBoutons.Controls.Add(this.m_btnOk);
			this.m_panelBoutons.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_panelBoutons.Location = new System.Drawing.Point(0, 163);
			this.m_panelBoutons.Name = "m_panelBoutons";
			this.m_panelBoutons.Size = new System.Drawing.Size(291, 32);
			this.m_exStyle.SetStyleBackColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panelBoutons, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panelBoutons.TabIndex = 7;
			// 
			// m_btnAnnuler
			// 
			this.m_btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.m_btnAnnuler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnAnnuler.Location = new System.Drawing.Point(214, 4);
			this.m_btnAnnuler.Name = "m_btnAnnuler";
			this.m_btnAnnuler.Size = new System.Drawing.Size(69, 25);
			this.m_exStyle.SetStyleBackColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_btnAnnuler, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnAnnuler.TabIndex = 1;
			this.m_btnAnnuler.Text = "Cancel|11";
			this.m_btnAnnuler.UseVisualStyleBackColor = true;
			this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
			// 
			// m_btnOk
			// 
			this.m_btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.m_btnOk.Location = new System.Drawing.Point(12, 4);
			this.m_btnOk.Name = "m_btnOk";
			this.m_btnOk.Size = new System.Drawing.Size(67, 25);
			this.m_exStyle.SetStyleBackColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_btnOk, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_btnOk.TabIndex = 0;
			this.m_btnOk.Text = "Ok|10";
			this.m_btnOk.UseVisualStyleBackColor = true;
			this.m_btnOk.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_panDate
			// 
			this.m_panDate.Controls.Add(this.m_dtGel);
			this.m_panDate.Controls.Add(this.m_lblFreezeDate);
			this.m_panDate.Dock = System.Windows.Forms.DockStyle.Top;
			this.m_panDate.Location = new System.Drawing.Point(0, 23);
			this.m_panDate.Name = "m_panDate";
			this.m_panDate.Size = new System.Drawing.Size(291, 29);
			this.m_exStyle.SetStyleBackColor(this.m_panDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_panDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_panDate.TabIndex = 10;
			// 
			// m_dtGel
			// 
			this.m_dtGel.CustomFormat = "dd/MM/yyyy HH:mm";
			this.m_dtGel.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.m_dtGel.Location = new System.Drawing.Point(103, 3);
			this.m_dtGel.Name = "m_dtGel";
			this.m_dtGel.ShowUpDown = true;
			this.m_dtGel.Size = new System.Drawing.Size(182, 20);
			this.m_exStyle.SetStyleBackColor(this.m_dtGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_dtGel, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_dtGel.TabIndex = 9;
			// 
			// m_lblFreezeDate
			// 
			this.m_lblFreezeDate.Location = new System.Drawing.Point(3, 5);
			this.m_lblFreezeDate.Name = "m_lblFreezeDate";
			this.m_lblFreezeDate.Size = new System.Drawing.Size(109, 16);
			this.m_exStyle.SetStyleBackColor(this.m_lblFreezeDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this.m_lblFreezeDate, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_lblFreezeDate.TabIndex = 8;
			this.m_lblFreezeDate.Text = "Freezing start|603";
			// 
			// CFormGelerIntervention
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(309, 213);
			this.Controls.Add(this.m_panOmbre);
			this.Name = "CFormGelerIntervention";
			this.m_exStyle.SetStyleBackColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.m_exStyle.SetStyleForeColor(this, sc2i.win32.common.CExtStyle.EnumCouleurs.None);
			this.Text = "CFormGelerIntervention";
			this.Load += new System.EventHandler(this.CFormGelerIntervention_Load);
			this.m_panOmbre.ResumeLayout(false);
			this.m_panOmbre.PerformLayout();
			this.m_panSurface.ResumeLayout(false);
			this.m_panInfo.ResumeLayout(false);
			this.m_panInfo.PerformLayout();
			this.m_panCause.ResumeLayout(false);
			this.m_panelBoutons.ResumeLayout(false);
			this.m_panDate.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label m_lblTitre;
		private sc2i.win32.common.C2iPanelOmbre m_panOmbre;
		private sc2i.win32.common.CExtStyle m_exStyle;
		private System.Windows.Forms.Label label2;
		private sc2i.win32.data.CComboBoxListeObjetsDonnees m_cmbCause;
		private sc2i.win32.common.C2iTextBox m_txtInfo;
		private System.Windows.Forms.Label m_lblInfoFreez;
		private System.Windows.Forms.Panel m_panelBoutons;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.Button m_btnOk;
		private System.Windows.Forms.DateTimePicker m_dtGel;
		private System.Windows.Forms.Label m_lblFreezeDate;
		private System.Windows.Forms.Panel m_panCause;
		private System.Windows.Forms.Panel m_panDate;
		private System.Windows.Forms.Panel m_panSurface;
		private System.Windows.Forms.Panel m_panInfo;
	}
}
