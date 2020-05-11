namespace timos.tables
{
	partial class CCtrlEditColonneFilterSituation
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
			this.m_lblTitre = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// m_lblTitre
			// 
			this.m_lblTitre.AutoSize = true;
			this.m_lblTitre.Location = new System.Drawing.Point(2, 3);
			this.m_lblTitre.Name = "m_lblTitre";
			this.m_lblTitre.Size = new System.Drawing.Size(74, 13);
			this.m_lblTitre.TabIndex = 0;
			this.m_lblTitre.Text = "Case|1190";
			this.m_lblTitre.Click += new System.EventHandler(this.m_lblTitre_Click);
			// 
			// CCtrlEditColonneFilterSituation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Controls.Add(this.m_lblTitre);
			this.Name = "CCtrlEditColonneFilterSituation";
			this.Size = new System.Drawing.Size(68, 18);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label m_lblTitre;


	}
}
