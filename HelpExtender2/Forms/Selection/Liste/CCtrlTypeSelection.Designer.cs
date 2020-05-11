namespace HelpExtender
{
	partial class CCtrlTypeSelection
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
            this.cmb_typeselec = new System.Windows.Forms.ComboBox();
            this.lbl_type = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_typeselec
            // 
            this.cmb_typeselec.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmb_typeselec.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_typeselec.FormattingEnabled = true;
            this.cmb_typeselec.Location = new System.Drawing.Point(103, 4);
            this.cmb_typeselec.Name = "cmb_typeselec";
            this.cmb_typeselec.Size = new System.Drawing.Size(228, 21);
            this.cmb_typeselec.TabIndex = 0;
            this.cmb_typeselec.SelectionChangeCommitted += new System.EventHandler(this.cmb_typeselec_SelectionChangeCommitted);
            // 
            // lbl_type
            // 
            this.lbl_type.AutoSize = true;
            this.lbl_type.Location = new System.Drawing.Point(3, 7);
            this.lbl_type.Name = "lbl_type";
            this.lbl_type.Size = new System.Drawing.Size(112, 13);
            this.lbl_type.TabIndex = 1;
            this.lbl_type.Text = "Selection mode|30048";
            // 
            // CCtrlTypeSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cmb_typeselec);
            this.Controls.Add(this.lbl_type);
            this.Name = "CCtrlTypeSelection";
            this.Size = new System.Drawing.Size(334, 31);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmb_typeselec;
		private System.Windows.Forms.Label lbl_type;
	}
}
