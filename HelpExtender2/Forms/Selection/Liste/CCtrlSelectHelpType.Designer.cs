namespace HelpExtender
{
	partial class CCtrlSelectHelpType
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
            this.tv_projet = new System.Windows.Forms.TreeView();
            this.lv_controles = new System.Windows.Forms.ListView();
            this.col_controlesLies = new System.Windows.Forms.ColumnHeader();
            this.pan_projet = new System.Windows.Forms.Panel();
            this.pan_elements = new System.Windows.Forms.Panel();
            this.pan_controles = new System.Windows.Forms.Panel();
            this.pan_doc = new System.Windows.Forms.Panel();
            this.chk_docexistant = new System.Windows.Forms.CheckBox();
            this.pan_projet.SuspendLayout();
            this.pan_elements.SuspendLayout();
            this.pan_controles.SuspendLayout();
            this.pan_doc.SuspendLayout();
            this.SuspendLayout();
            // 
            // tv_projet
            // 
            this.tv_projet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tv_projet.Location = new System.Drawing.Point(3, 3);
            this.tv_projet.Name = "tv_projet";
            this.tv_projet.Size = new System.Drawing.Size(254, 301);
            this.tv_projet.TabIndex = 0;
            // 
            // lv_controles
            // 
            this.lv_controles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_controles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.col_controlesLies});
            this.lv_controles.FullRowSelect = true;
            this.lv_controles.GridLines = true;
            this.lv_controles.Location = new System.Drawing.Point(0, 3);
            this.lv_controles.MultiSelect = false;
            this.lv_controles.Name = "lv_controles";
            this.lv_controles.Size = new System.Drawing.Size(205, 270);
            this.lv_controles.TabIndex = 1;
            this.lv_controles.UseCompatibleStateImageBehavior = false;
            this.lv_controles.View = System.Windows.Forms.View.Details;
            // 
            // col_controlesLies
            // 
            this.col_controlesLies.Text = "Documented controls of this type|30045";
            this.col_controlesLies.Width = 175;
            // 
            // pan_projet
            // 
            this.pan_projet.Controls.Add(this.tv_projet);
            this.pan_projet.Dock = System.Windows.Forms.DockStyle.Left;
            this.pan_projet.Location = new System.Drawing.Point(0, 0);
            this.pan_projet.Name = "pan_projet";
            this.pan_projet.Size = new System.Drawing.Size(260, 307);
            this.pan_projet.TabIndex = 2;
            // 
            // pan_elements
            // 
            this.pan_elements.Controls.Add(this.pan_controles);
            this.pan_elements.Controls.Add(this.pan_doc);
            this.pan_elements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_elements.Location = new System.Drawing.Point(260, 0);
            this.pan_elements.Name = "pan_elements";
            this.pan_elements.Size = new System.Drawing.Size(205, 307);
            this.pan_elements.TabIndex = 3;
            // 
            // pan_controles
            // 
            this.pan_controles.Controls.Add(this.lv_controles);
            this.pan_controles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_controles.Location = new System.Drawing.Point(0, 31);
            this.pan_controles.Name = "pan_controles";
            this.pan_controles.Size = new System.Drawing.Size(205, 276);
            this.pan_controles.TabIndex = 1;
            // 
            // pan_doc
            // 
            this.pan_doc.Controls.Add(this.chk_docexistant);
            this.pan_doc.Dock = System.Windows.Forms.DockStyle.Top;
            this.pan_doc.Location = new System.Drawing.Point(0, 0);
            this.pan_doc.Name = "pan_doc";
            this.pan_doc.Size = new System.Drawing.Size(205, 31);
            this.pan_doc.TabIndex = 0;
            // 
            // chk_docexistant
            // 
            this.chk_docexistant.AutoSize = true;
            this.chk_docexistant.Location = new System.Drawing.Point(6, 8);
            this.chk_docexistant.Name = "chk_docexistant";
            this.chk_docexistant.Size = new System.Drawing.Size(144, 17);
            this.chk_docexistant.TabIndex = 0;
            this.chk_docexistant.Text = "Existing document|30044";
            this.chk_docexistant.UseVisualStyleBackColor = true;
            // 
            // CCtrlSelectHelpType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pan_elements);
            this.Controls.Add(this.pan_projet);
            this.Name = "CCtrlSelectHelpType";
            this.Size = new System.Drawing.Size(465, 307);
            this.pan_projet.ResumeLayout(false);
            this.pan_elements.ResumeLayout(false);
            this.pan_controles.ResumeLayout(false);
            this.pan_doc.ResumeLayout(false);
            this.pan_doc.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TreeView tv_projet;
		private System.Windows.Forms.ListView lv_controles;
		private System.Windows.Forms.Panel pan_projet;
		private System.Windows.Forms.Panel pan_elements;
		private System.Windows.Forms.Panel pan_controles;
		private System.Windows.Forms.Panel pan_doc;
		private System.Windows.Forms.CheckBox chk_docexistant;
		private System.Windows.Forms.ColumnHeader col_controlesLies;
	}
}
