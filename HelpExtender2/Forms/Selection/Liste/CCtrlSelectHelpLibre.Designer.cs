namespace HelpExtender
{
	partial class CCtrlSelectHelpLibre
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
            this.lv_docs = new System.Windows.Forms.ListView();
            this.col_titre = new System.Windows.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lv_docs
            // 
            this.lv_docs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_titre});
            this.lv_docs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_docs.FullRowSelect = true;
            this.lv_docs.GridLines = true;
            this.lv_docs.Location = new System.Drawing.Point(0, 0);
            this.lv_docs.MultiSelect = false;
            this.lv_docs.Name = "lv_docs";
            this.lv_docs.Size = new System.Drawing.Size(318, 278);
            this.lv_docs.TabIndex = 0;
            this.lv_docs.UseCompatibleStateImageBehavior = false;
            this.lv_docs.View = System.Windows.Forms.View.Details;
            this.lv_docs.DoubleClick += new System.EventHandler(this.lv_docs_DoubleClick);
            this.lv_docs.Click += new System.EventHandler(this.lv_docs_Click);
            // 
            // col_titre
            // 
            this.col_titre.Text = "Document title|30043";
            this.col_titre.Width = 300;
            // 
            // CCtrlSelectHelpLibre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lv_docs);
            this.Name = "CCtrlSelectHelpLibre";
            this.Size = new System.Drawing.Size(318, 278);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lv_docs;
		private System.Windows.Forms.ColumnHeader col_titre;
	}
}
