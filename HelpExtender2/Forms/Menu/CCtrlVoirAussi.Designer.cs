namespace HelpExtender
{
	partial class CCtrlVoirAussi
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
            this.mnu = new System.Windows.Forms.MenuStrip();
            this.voirAussiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnu
            // 
            this.mnu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mnu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.voirAussiToolStripMenuItem});
            this.mnu.Location = new System.Drawing.Point(0, 0);
            this.mnu.Name = "mnu";
            this.mnu.Size = new System.Drawing.Size(150, 21);
            this.mnu.TabIndex = 0;
            this.mnu.Text = "menuStrip1";
            // 
            // voirAussiToolStripMenuItem
            // 
            this.voirAussiToolStripMenuItem.Name = "voirAussiToolStripMenuItem";
            this.voirAussiToolStripMenuItem.Size = new System.Drawing.Size(105, 17);
            this.voirAussiToolStripMenuItem.Text = "See also...|30041";
            // 
            // CCtrlVoirAussi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.mnu);
            this.Name = "CCtrlVoirAussi";
            this.Size = new System.Drawing.Size(150, 21);
            this.mnu.ResumeLayout(false);
            this.mnu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mnu;
		public System.Windows.Forms.ToolStripMenuItem voirAussiToolStripMenuItem;
	}
}
