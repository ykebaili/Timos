namespace TimosDataServeur
{
	partial class CFormLogs
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
            this.m_btnClose = new System.Windows.Forms.Button();
            this.m_btnMail = new System.Windows.Forms.Button();
            this.m_btnSauvegarder = new System.Windows.Forms.Button();
            this.m_btnImprimer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // m_btnClose
            // 
            this.m_btnClose.Location = new System.Drawing.Point(485, 143);
            this.m_btnClose.Name = "m_btnClose";
            this.m_btnClose.Size = new System.Drawing.Size(75, 23);
            this.m_btnClose.TabIndex = 0;
            this.m_btnClose.Text = "Close|30003";
            this.m_btnClose.UseVisualStyleBackColor = true;
            this.m_btnClose.Click += new System.EventHandler(this.m_btnClose_Click);
            // 
            // m_btnMail
            // 
            this.m_btnMail.Location = new System.Drawing.Point(300, 143);
            this.m_btnMail.Name = "m_btnMail";
            this.m_btnMail.Size = new System.Drawing.Size(107, 23);
            this.m_btnMail.TabIndex = 0;
            this.m_btnMail.Text = "Send by mail|30002";
            this.m_btnMail.UseVisualStyleBackColor = true;
            // 
            // m_btnSauvegarder
            // 
            this.m_btnSauvegarder.Location = new System.Drawing.Point(141, 143);
            this.m_btnSauvegarder.Name = "m_btnSauvegarder";
            this.m_btnSauvegarder.Size = new System.Drawing.Size(94, 23);
            this.m_btnSauvegarder.TabIndex = 0;
            this.m_btnSauvegarder.Text = "Save|30001";
            this.m_btnSauvegarder.UseVisualStyleBackColor = true;
            // 
            // m_btnImprimer
            // 
            this.m_btnImprimer.Location = new System.Drawing.Point(28, 143);
            this.m_btnImprimer.Name = "m_btnImprimer";
            this.m_btnImprimer.Size = new System.Drawing.Size(75, 23);
            this.m_btnImprimer.TabIndex = 0;
            this.m_btnImprimer.Text = "Print|30000";
            this.m_btnImprimer.UseVisualStyleBackColor = true;
            // 
            // CFormLogs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(572, 178);
            this.Controls.Add(this.m_btnImprimer);
            this.Controls.Add(this.m_btnSauvegarder);
            this.Controls.Add(this.m_btnMail);
            this.Controls.Add(this.m_btnClose);
            this.Name = "CFormLogs";
            this.Text = "CFormLogs";
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_btnClose;
		private System.Windows.Forms.Button m_btnMail;
		private System.Windows.Forms.Button m_btnSauvegarder;
		private System.Windows.Forms.Button m_btnImprimer;
	}
}