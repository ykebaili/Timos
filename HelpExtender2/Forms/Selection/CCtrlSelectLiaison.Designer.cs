namespace HelpExtender
{
	partial class CCtrlSelectLiaison
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
            this.pan_typeliaison = new System.Windows.Forms.Panel();
            this.cmb_typeliaison = new System.Windows.Forms.ComboBox();
            this.lbl_typeliaison = new System.Windows.Forms.Label();
            this.pan_typeliaison.SuspendLayout();
            this.SuspendLayout();
            // 
            // pan_typeliaison
            // 
            this.pan_typeliaison.Controls.Add(this.cmb_typeliaison);
            this.pan_typeliaison.Controls.Add(this.lbl_typeliaison);
            this.pan_typeliaison.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pan_typeliaison.Location = new System.Drawing.Point(0, 0);
            this.pan_typeliaison.Name = "pan_typeliaison";
            this.pan_typeliaison.Size = new System.Drawing.Size(418, 32);
            this.pan_typeliaison.TabIndex = 1;
            // 
            // cmb_typeliaison
            // 
            this.cmb_typeliaison.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_typeliaison.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_typeliaison.FormattingEnabled = true;
            this.cmb_typeliaison.Location = new System.Drawing.Point(104, 6);
            this.cmb_typeliaison.Name = "cmb_typeliaison";
            this.cmb_typeliaison.Size = new System.Drawing.Size(311, 21);
            this.cmb_typeliaison.TabIndex = 1;
            this.cmb_typeliaison.SelectionChangeCommitted += new System.EventHandler(this.cmb_typeliaison_SelectionChangeCommitted);
            // 
            // lbl_typeliaison
            // 
            this.lbl_typeliaison.AutoSize = true;
            this.lbl_typeliaison.Location = new System.Drawing.Point(3, 9);
            this.lbl_typeliaison.Name = "lbl_typeliaison";
            this.lbl_typeliaison.Size = new System.Drawing.Size(82, 13);
            this.lbl_typeliaison.TabIndex = 0;
            this.lbl_typeliaison.Text = "Link type|30049";
            // 
            // CCtrlSelectLiaison
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.pan_typeliaison);
            this.Name = "CCtrlSelectLiaison";
            this.Size = new System.Drawing.Size(418, 32);
            this.pan_typeliaison.ResumeLayout(false);
            this.pan_typeliaison.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pan_typeliaison;
		private System.Windows.Forms.ComboBox cmb_typeliaison;
		private System.Windows.Forms.Label lbl_typeliaison;
	}
}
