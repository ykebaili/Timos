namespace timos
{
	partial class CFormModeImport
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
			this.m_btnSuivant = new System.Windows.Forms.Button();
			this.m_btnAnnuler = new System.Windows.Forms.Button();
			this.m_rbtUpdate = new System.Windows.Forms.RadioButton();
			this.m_rbtReset = new System.Windows.Forms.RadioButton();
			this.m_rbtDelete = new System.Windows.Forms.RadioButton();
			this.SuspendLayout();
			// 
			// m_btnSuivant
			// 
			this.m_btnSuivant.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.m_btnSuivant.Location = new System.Drawing.Point(121, 90);
			this.m_btnSuivant.Name = "m_btnSuivant";
			this.m_btnSuivant.Size = new System.Drawing.Size(75, 23);
			this.m_btnSuivant.TabIndex = 4;
			this.m_btnSuivant.Text = "Next|32";
			this.m_btnSuivant.UseVisualStyleBackColor = true;
			this.m_btnSuivant.Click += new System.EventHandler(this.m_btnOk_Click);
			// 
			// m_btnAnnuler
			// 
			this.m_btnAnnuler.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.m_btnAnnuler.Location = new System.Drawing.Point(12, 90);
			this.m_btnAnnuler.Name = "m_btnAnnuler";
			this.m_btnAnnuler.Size = new System.Drawing.Size(75, 23);
			this.m_btnAnnuler.TabIndex = 5;
			this.m_btnAnnuler.Text = "Back|33";
			this.m_btnAnnuler.UseVisualStyleBackColor = true;
			this.m_btnAnnuler.Click += new System.EventHandler(this.m_btnAnnuler_Click);
			// 
			// m_rbtUpdate
			// 
			this.m_rbtUpdate.AutoSize = true;
			this.m_rbtUpdate.Checked = true;
			this.m_rbtUpdate.Location = new System.Drawing.Point(24, 12);
			this.m_rbtUpdate.Name = "m_rbtUpdate";
			this.m_rbtUpdate.Size = new System.Drawing.Size(132, 17);
			this.m_rbtUpdate.TabIndex = 7;
			this.m_rbtUpdate.TabStop = true;
			this.m_rbtUpdate.Text = "Update or Create|1289";
			this.m_rbtUpdate.UseVisualStyleBackColor = true;
			// 
			// m_rbtReset
			// 
			this.m_rbtReset.AutoSize = true;
			this.m_rbtReset.Location = new System.Drawing.Point(24, 35);
			this.m_rbtReset.Name = "m_rbtReset";
			this.m_rbtReset.Size = new System.Drawing.Size(132, 17);
			this.m_rbtReset.TabIndex = 7;
			this.m_rbtReset.Text = "Reset and Import|1290";
			this.m_rbtReset.UseVisualStyleBackColor = true;
			// 
			// m_rbtDelete
			// 
			this.m_rbtDelete.AutoSize = true;
			this.m_rbtDelete.Location = new System.Drawing.Point(24, 58);
			this.m_rbtDelete.Name = "m_rbtDelete";
			this.m_rbtDelete.Size = new System.Drawing.Size(70, 17);
			this.m_rbtDelete.TabIndex = 7;
			this.m_rbtDelete.Text = "Delete|18";
			this.m_rbtDelete.UseVisualStyleBackColor = true;
			// 
			// CFormModeImport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(205, 115);
			this.ControlBox = false;
			this.Controls.Add(this.m_rbtDelete);
			this.Controls.Add(this.m_rbtReset);
			this.Controls.Add(this.m_rbtUpdate);
			this.Controls.Add(this.m_btnAnnuler);
			this.Controls.Add(this.m_btnSuivant);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CFormModeImport";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Import Mode|1288";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button m_btnSuivant;
		private System.Windows.Forms.Button m_btnAnnuler;
		private System.Windows.Forms.RadioButton m_rbtUpdate;
		private System.Windows.Forms.RadioButton m_rbtReset;
		private System.Windows.Forms.RadioButton m_rbtDelete;
	}
}